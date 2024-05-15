using Microsoft.AspNetCore.Mvc;
using Business.Implementations;
using Business.Interfaces;
using Infrastructure.Models;
//using Business.Implementations;
//using Core.ModelsView; 
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BibliotecaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IAreaServices _services;

        public AreaController(IAreaServices services)
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
        public async Task<ActionResult> Post(Area registro)
        {
            try
            {
                int areNom = 0;
                areNom = _services.Agregar(registro);
                return Ok(areNom);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //PUT api/<AreaController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Area registro)
        {
            try
            {
                int areNom = 0;
                areNom = _services.Editar(id, registro);
                return Ok(areNom);
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
               int idArea = 0;
               idArea=  _services.Eliminar(id);
                return Ok(idArea);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
