using Business.Interfaces;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BibliotecaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroServices _services;

        public LibroController(ILibroServices services)
        {
            _services = services;
        }
       
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var ListServicio = _services.Listar();
                return Ok(ListServicio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var item = _services.Buscar(id);
                if (item == null)
                {
                    return NotFound();
                }
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Libro registro)
        {
            try
            {
                int LibNom = 0;
                LibNom = _services.Agregar(registro);
                return Ok(LibNom);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Libro registro)
        {
            try
            {
                int libNom = 0;
                libNom = _services.Editar(id, registro);
                return Ok(libNom);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                int idLibro = 0;
                idLibro = _services.Eliminar(id);
                return Ok(idLibro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
