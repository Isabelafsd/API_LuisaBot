using API_LuisaBot.Interfaces.Repositories;
using API_LuisaBot.Models;
using API_LuisaBot.Models.Requests;
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
    [Route("/sugestao")]
    public class SugestaoController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public SugestaoController(IUnitOfWork context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            var sugestoes =await _context.Sugestoes.GetAll();
            return sugestoes is not null ? Ok(sugestoes) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var sugestao = await _context.Sugestoes.GetById(id);
            return sugestao == null ? NotFound() : Ok(sugestao);
        }

        [HttpPost]
        public async Task<IActionResult> PostSugestao(SugestaoRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            SugestaoModel sugestao = new() {
                Descricao = request.Descricao,
                IsPergunta = request.IsPergunta,
                Tema = request.Tema
            };

            try
            {
                await _context.Sugestoes.Add(sugestao);
                return Created($"sugestao/{sugestao.Id}",sugestao);
            }
            catch (Exception e) 
            {
                return BadRequest();
            }      
        }
    }
}
