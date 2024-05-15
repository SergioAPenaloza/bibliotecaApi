using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ModelsView
{
    public class EstudianteView
    {
        public int EstId { get; set; }
        public string? EstNombre { get; set; }
        public string? EstApellido { get; set; }
        public DateTime? EstFecha { get; set; }
        public int? CarId { get; set; }
    }
}
