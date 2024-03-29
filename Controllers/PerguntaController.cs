﻿using API_LuisaBot.Interfaces.Repositories;
using API_LuisaBot.Models;
using API_LuisaBot.Models.Requests;
using API_LuisaBot.Models.Responses;
using API_LuisaBot.Repositories.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_LuisaBot.Controllers
{
    [ApiController]
    [Route("/pergunta")]
    public class PerguntaController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public PerguntaController(IUnitOfWork context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            var perguntas = await _context.Perguntas.GetAll();
            return perguntas is not null ? Ok(perguntas) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pergunta = await _context.Perguntas.GetById(id);
            return pergunta == null ? NotFound() : Ok(pergunta);
        }

        [HttpPut()]
        public async Task<IActionResult> Update(PerguntaUpdateRequest pergunta)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                PerguntaModel perguntaModel = new()
                {
                    Id = pergunta.Id,
                    Descricao = pergunta.Descricao,
                    Ordem = pergunta.Ordem
                };
                await _context.Perguntas.Update(perguntaModel);
                return Ok($"O registro de id {pergunta.Id} foi atualizado");
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
                var pergunta = await _context.Perguntas.GetById(id);
                await _context.Perguntas.Remove(pergunta);
                return Ok($"O registro de id {id} foi excluido");
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostPergunta(PerguntaRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            PerguntaModel pergunta = new() {
                Descricao = request.Descricao,
                Ordem = request.Ordem
            };

            try
            {
                await _context.Perguntas.Add(pergunta);
                return Created($"pergunta/{pergunta.Id}", pergunta);
            }
            catch (Exception e) 
            {
                return BadRequest();
            }      
        }

        [HttpGet("tema-pergunta")]
        public async Task<IActionResult> GetPerguntasByTemas(int temaId)
        {
            var listaPerguntas = new List<PerguntasByTemasResponse>();
            var perguntas = await _context.TemasPerguntas.GetAllPerguntasByTemaId(temaId);
            perguntas = perguntas.OrderBy(x=>x.Ordem).ToList();
            try
            {
                foreach (var pergunta in perguntas) {
                    var perguntaResponse = new PerguntasByTemasResponse {
                        pergunta = pergunta.Descricao,
                        perguntaId = pergunta.Id,
                        ordem = pergunta.Ordem
                    };
                    listaPerguntas.Add(perguntaResponse);
                }
                return listaPerguntas.Any() ? Ok(listaPerguntas) : NotFound();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}


/*TODO:
  Tratamento de erros e uso de services
  swagger rota principal
  unique operator para o banco
 */