using Infrastructure.Models;
using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.ModelsView;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace Business.Implementations
{
    public class AreaServices : IAreaServices
    {
        private readonly bibliotecaContext _contex;

        public AreaServices() { }

        public AreaServices(bibliotecaContext contex)
        {
            _contex = contex;
        }

        public List<AreaView> Listar() 
        { 
            List<AreaView> ListaAreaViews = new List<AreaView>();
            var ListServicios = _contex.Areas.ToList();

            if(ListServicios != null)
            {   foreach(var index in ListServicios)
                {
                    AreaView AreaView = new AreaView()
                    {

                        AreId = index.AreId,
                        AreNombre = index.AreNombre,

                    };
                    ListaAreaViews.Add(AreaView);
                }
                
            }
            return ListaAreaViews;
        }
        public AreaView Buscar(int id)
        {
            var area = _contex.Areas.Find(id); 
            if (area == null)
            {
                return null;
            }

            var areaView = new AreaView
            {
                AreId = area.AreId,
                AreNombre = area.AreNombre,
            };

            return areaView;
        }


        public int Agregar(Area Registro)
        {
            var item = new Area
            {
                AreNombre = Registro.AreNombre
            };
            _contex.Areas.Add(item);
            _contex.SaveChanges();

            return item.AreId;

        }

        public int Editar(int id, Area registro)
        {
            var item = _contex.Areas.Find(id);
            item.AreNombre = registro.AreNombre;
            _contex.SaveChanges();
            return item.AreId;
        }

        public int Eliminar(int id)
        {
            var area = _contex.Areas.Find(id);
            _contex.Areas.Remove(area);
            _contex.SaveChanges();
            return id;
        }

    }
}

