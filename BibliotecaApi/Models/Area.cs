using System;
using System.Collections.Generic;

namespace BibliotecaApi.Models
{
    public partial class Area
    {
        public Area()
        {
            Libros = new HashSet<Libro>();
        }

        public int AreId { get; set; }
        public string? AreNombre { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
