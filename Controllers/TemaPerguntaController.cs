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
    [Route("/tema-pergunta")]
    public class TemaPerguntaController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public TemaPerguntaController(IUnitOfWork context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var temasPerguntas = await _context.TemasPerguntas.GetAll();
            return temasPerguntas is not null ? Ok(temasPerguntas) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var tema = await _context.TemasPerguntas.GetById(id);
            return tema == null ? NotFound() : Ok(tema);
        }

        [HttpPost]
        public async Task<IActionResult> PostTemaPergunta(TemaPerguntaRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            TemaPerguntaModel temaPergunta = new()
            {
                TemaId = request.TemaId,
                PerguntaId = request.PerguntaId
            };

            try
            {
                await _context.TemasPerguntas.Add(temaPergunta);
                return Created($"TemasPerguntas/{temaPergunta.Id}", temaPergunta);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
