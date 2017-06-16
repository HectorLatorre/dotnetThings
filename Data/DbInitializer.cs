using System;
using System.Linq;
using firstapp.Models;

namespace firstapp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(UniContext context)
        {
            context.Database.EnsureCreated();

            if (context.Usuarios.Any())
            {
                return;
            }

            var usuarios = new User[]{
                new User{Nombre="Héctor", Apellido="Latorre", Username="hlatorre", Password="123"},
                new User{Nombre="Isidora", Apellido="Guajardo", Username="iguajardo", Password="321"}
            };

            foreach (User s in usuarios){
                context.Usuarios.Add(s);
            }
            context.SaveChanges();

            var cursos = new Curso[]{
                new Curso{IDCurso=1000, Nombre="Biologia", Creditos=5},
                new Curso{IDCurso=1001, Nombre="Matematicas", Creditos=5}
            };

            foreach (Curso c in cursos){
                context.Cursos.Add(c);
            }
            context.SaveChanges();

            var inscripciones = new Inscripcion[]{
                new Inscripcion{IDUser=usuarios[0].IDUser, IDCurso=1000},
                new Inscripcion{IDUser=usuarios[1].IDUser, IDCurso=1001}
            };

            foreach (Inscripcion i in inscripciones){
                context.Inscripciones.Add(i);
            }
            context.SaveChanges();
        }
    }
}
