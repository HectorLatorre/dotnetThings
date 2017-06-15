using System;
using System.Collections.Generic;

namespace firstapp.Models
{
    public class User
    {
        public int IDUser { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<Inscripcion> Inscripciones { get; set; }
    }
}