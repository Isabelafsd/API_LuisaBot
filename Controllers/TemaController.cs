using API_LuisaBot.Interfaces.Repositories;
using API_LuisaBot.Models.Requests;
using API_LuisaBot.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Xml.Linq;

namespace API_LuisaBot.Controllers
{
    [ApiController]
    [Route("/tema")]
    public class TemaController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public TemaController(IUnitOfWork context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var temas = await _context.Temas.GetAll();
            return temas is not null ? Ok(temas) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var tema = await _context.Temas.GetById(id);
            return tema == null ? NotFound() : Ok(tema);
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetByName(string name)
        {
            var tema = await _context.Temas.GetByName(name);
            return tema is null ? NotFound() : Ok(tema);
        }


        [HttpPost]
        public async Task<IActionResult> PostTema(TemaRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            TemaModel tema = new()
            {
                Nome = request.Nome,
                Ordem = request.Ordem
            };

            try
            {
                await _context.Temas.Add(tema);
                return Created($"tema/{tema.Id}", tema);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
