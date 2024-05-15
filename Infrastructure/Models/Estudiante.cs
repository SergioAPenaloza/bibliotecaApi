using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            Prestamos = new HashSet<Prestamo>();
        }

        public int EstId { get; set; }
        public string? EstNombre { get; set; }
        public string? EstApellido { get; set; }
        public DateTime? EstFecha { get; set; }
        public int? CarId { get; set; }

        public virtual Carrera? Car { get; set; }
        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}
