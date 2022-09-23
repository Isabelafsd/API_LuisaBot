using API_LuisaBot.Interfaces.Repositories;
using API_LuisaBot.Models.Requests;
using API_LuisaBot.Models.Responses;
using API_LuisaBot.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace API_LuisaBot.Controllers
{
    [ApiController]
    [Route("/resposta")]
    public class RespostaController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public RespostaController(IUnitOfWork context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var respostas = await _context.Respostas.GetAll();
            return respostas is not null ? Ok(respostas) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var resposta = await _context.Respostas.GetById(id);
            return resposta == null ? NotFound() : Ok(resposta);
        }

        [HttpPut()]
        public async Task<IActionResult> Update(RespostaUpdateRequest resposta)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                RespostaModel respostaModel = new()
                {
                    Id = resposta.Id,
                    Descricao = resposta.Descricao,
                    Ordem = resposta.Ordem,
                    IsImagem = resposta.IsImagem,
                    PerguntaId = resposta.PerguntaId
                };

                await _context.Respostas.Update(respostaModel);
                return Ok($"O registro de id {resposta.Id} foi atualizado");
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
                var resposta = await _context.Respostas.GetById(id);
                await _context.Respostas.Remove(resposta);
                return Ok($"O registro de id {id} foi excluido");
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostResposta(RespostaRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            RespostaModel resposta = new()
            {
                Descricao = request.Descricao,
                IsImagem = request.IsImagem,
                Ordem = request.Ordem,
                Referencia = request.Referencia,
                PerguntaId = request.PerguntaId
            };

            try
            {
                await _context.Respostas.Add(resposta);
                return Created($"resposta/{resposta.Id}", resposta);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("resposta-pergunta")]
        public async Task<IActionResult> GetRespostasByPergunta(int perguntaId)
        {
            var listaRespostas = new List<RespostaResponse>();
            var respostas = await _context.Respostas.GetAllRespostasByPergunta(perguntaId);
            respostas = respostas.OrderBy(x => x.Ordem).ToList();
            try
            {
                foreach (var resposta in respostas)
                {
                    var response = new RespostaResponse
                    {
                        Referencia = resposta.Referencia,
                        Descricao = resposta.Descricao
                    };
                    listaRespostas.Add(response);
                }
                return listaRespostas.Any() ? Ok(listaRespostas) : NotFound();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}