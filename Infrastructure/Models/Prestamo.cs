using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public partial class Prestamo
    {
        public int PreId { get; set; }
        public DateTime? PreFecha { get; set; }
        public int? EstId { get; set; }
        public int? LibId { get; set; }

        public virtual Estudiante? Est { get; set; }
        public virtual Libro? Lib { get; set; }
    }
}
