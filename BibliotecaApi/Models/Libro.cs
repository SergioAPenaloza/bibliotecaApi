using System;
using System.Collections.Generic;

namespace BibliotecaApi.Models
{
    public partial class Libro
    {
        public Libro()
        {
            Prestamos = new HashSet<Prestamo>();
        }

        public int LibId { get; set; }
        public string? LibNombre { get; set; }
        public int? AreId { get; set; }

        public virtual Area? Are { get; set; }
        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}
