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
        public async Task<IActionResult> GetById(int id)
        {
            var tema = await _context.TemasPerguntas.GetById(id);
            return tema == null ? NotFound() : Ok(tema);
        }

        [HttpPut()]
        public async Task<IActionResult> Update(TemaPerguntaUpdateRequest temaPergunta)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                TemaPerguntaModel temaPerguntaModel = new()
                {
                    Id = temaPergunta.Id,
                    TemaId = temaPergunta.TemaId,
                    PerguntaId = temaPergunta.PerguntaId
                };
                await _context.TemasPerguntas.Update(temaPerguntaModel);
                return Ok($"O registro de id {temaPergunta.Id} foi atualizado");
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                var temaPergunta = await _context.TemasPerguntas.GetById(id);
                await _context.TemasPerguntas.Remove(temaPergunta);
                return Ok($"O registro de id {id} foi excluido");
            }
            catch (Exception e)
            {
                return BadRequest();
            }
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
