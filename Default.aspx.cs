using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio11
{
    public partial class _Default : Page
    {
        static List<Alumno> alumnoTemp = new List<Alumno>();
        static List<Nota> NotasTemp = new List<Nota>();
        static List<Universidad> universidades = new List<Universidad>();

        private void SaveJsonUnivercity()
        {
            string json = JsonConvert.SerializeObject(universidades);   
            string archivo = Server.MapPath("Universidades.json");
            System.IO.File.WriteAllText(archivo, json);
        }
        private void ReadJsonUnivercity()
        {
            string archivo = Server.MapPath("Universidades.json");
            StreamReader jsonStream = File.OpenText(archivo);
            string json = jsonStream.ReadToEnd();
            jsonStream.Close();

            universidades = JsonConvert.DeserializeObject<List<Universidad>>(json);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReadJsonUnivercity();
            }
        }

        protected void ButtonAddNotas_Click(object sender, EventArgs e)
        {
            Nota nota = new Nota();
            nota.Curso = TextBoxCourse.Text;
            nota.Punteo = Convert.ToInt16(TextBoxPTS.Text);

            NotasTemp.Add(nota);

            GridView2.DataSource = NotasTemp;
            GridView2.DataBind();
        }

        protected void ButtonAddStudent_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno();
            alumno.FirstName = TextBoxName.Text;
            alumno.LastName = TextBoxLastName.Text;
            alumno.NoCarne = TextBoxId.Text;
            alumno.Notas = NotasTemp.ToArray().ToList();

            alumnoTemp.Add(alumno);
            NotasTemp.Clear();
        }

        protected void ButtonSaveUnivercity_Click(object sender, EventArgs e)
        {
            Universidad uni = new Universidad();
            uni.Nombre = DropDownListUni.Text;
            uni.Sede = null;
            uni.Alumnos = alumnoTemp.ToArray().ToList();

            universidades.Add(uni);

            SaveJsonUnivercity();

            alumnoTemp.Clear();
        }
    }
}