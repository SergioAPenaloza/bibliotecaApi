using Business.Interfaces;
using Core.ModelsView;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class LibroServices : ILibroServices
    {
        private readonly bibliotecaContext _contex;

        public LibroServices() { }

        public LibroServices(bibliotecaContext contex)
        {
            _contex = contex;
        }

        public List<LibroView> Listar()
        {
            List<LibroView> ListaLibroView = new List<LibroView>();
            var ListServicios = _contex.Libros.ToList();

            if (ListServicios != null)
            {
                foreach (var index in ListServicios)
                {
                    LibroView LibroView = new LibroView()
                    {
                        LibId = index.LibId,
                        LibNombre = index.LibNombre,
                        AreId = index.AreId,

                    };
                    ListaLibroView.Add(LibroView);
                }

            }
            return ListaLibroView;
        }

        public LibroView Buscar(int id)
        {
            var libro = _contex.Libros.Find(id);
            if (libro == null)
            {
                return null;
            }

            var libroView = new LibroView
            {
                LibId = libro.LibId,
                LibNombre = libro.LibNombre,
                AreId = libro.AreId,
            };

            return libroView;
        }

        public int Agregar(Libro registro)
        {
            var item = new Libro
            {
                LibId = registro.LibId,
                LibNombre = registro.LibNombre,
                AreId = registro.AreId,
            };
            _contex.Libros.Add(item);
            _contex.SaveChanges();

            return item.LibId;
        }

        public int Editar(int id, Libro registro)
        {
            var item = _contex.Libros.Find(id);
            item.LibNombre = registro.LibNombre;
            item.AreId = registro.AreId;
            _contex.SaveChanges();
            return item.LibId;
        }

        public int Eliminar(int id)
        {
            var libro = _contex.Libros.Find(id);
            _contex.Libros.Remove(libro);
            _contex.SaveChanges();
            return id;

        }
    }
}
