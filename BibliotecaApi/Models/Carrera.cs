using System;
using System.Collections.Generic;

namespace BibliotecaApi.Models
{
    public partial class Carrera
    {
        public Carrera()
        {
            Estudiantes = new HashSet<Estudiante>();
        }

        public int CarId { get; set; }
        public string? CarNombre { get; set; }

        public virtual ICollection<Estudiante> Estudiantes { get; set; }
    }
}
