using System;
using System.Collections.Generic;

namespace firstapp.Models
{
    public enum Nota
    {
        A,B,C,D,E,F,G
    }

    public class Inscripcion
    {
        public int IDInscripcion { get; set;}
        public int IDCurso { get; set; }
        public int IDUser { get; set; }
        public Nota? Nota { get; set; }

        public Curso Curso { get; set; }
        public User User { get; set; }
    }
}
