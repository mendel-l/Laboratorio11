﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio11
{
    public class Universidad
    {
        public string Nombre { get; set; }
        public string Sede { get; set; }

        public List<Alumno> Alumnos { get; set; }
    }
}