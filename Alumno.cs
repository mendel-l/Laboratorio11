using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio11
{
    public class Alumno : Persona
    {
        public string NoCarne { get; set; }
        public List<Nota> Notas { get; set; }
    }
}