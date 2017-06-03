using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace firstapp.Models
{
    public class Curso
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Creditos { get; set; }
        public ICollection<Inscripcion> Inscripciones { get; set; }
    }
}
