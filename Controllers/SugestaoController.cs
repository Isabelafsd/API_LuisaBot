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
        public async Task<IActionResult> GetById(int id)
        {
            var sugestao = await _context.Sugestoes.GetById(id);
            return sugestao == null ? NotFound() : Ok(sugestao);
        }

        [HttpPut()]
        public async Task<IActionResult> Update(SugestaoUpdateRequest sugestao)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                SugestaoModel sugestaoModel = new()
                {
                    Id = sugestao.Id,
                    Descricao = sugestao.Descricao,
                    IsPergunta = sugestao.IsPergunta
                };
                await _context.Sugestoes.Update(sugestaoModel);
                return Ok($"O registro de id {sugestao.Id} foi atualizado");
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
                var sugestao = await _context.Sugestoes.GetById(id);
                await _context.Sugestoes.Remove(sugestao);
                return Ok($"O registro de id {id} foi excluido");
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostSugestao(SugestaoRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            SugestaoModel sugestao = new() {
                Descricao = request.Descricao,
                IsPergunta = request.IsPergunta
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
