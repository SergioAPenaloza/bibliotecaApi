using Core.ModelsView;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IAreaServices
    {
        public List<AreaView> Listar();
        
        public AreaView Buscar(int id);

        public int  Eliminar(int id);

        public int Agregar(Area Registro);

        public int Editar(int id, Area registro);
    }
}
