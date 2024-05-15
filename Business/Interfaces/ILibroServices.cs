using Core.ModelsView;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ILibroServices
    {
        public List<LibroView> Listar();
        public LibroView Buscar(int id);
        public int Eliminar(int id);
        public int Agregar(Libro registro);
        public int Editar(int id, Libro registro);
    }
}
