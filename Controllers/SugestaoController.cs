using API_LuisaBot.Models;
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
        private readonly AppDbContext _context;
        public SugestaoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            var sugestoes = await _context
                .Sugestoes
                .AsNoTracking()
                .ToListAsync();
            return Ok(sugestoes);
        }

        [HttpGet]
        [Route("sugestao/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var sugestao = await _context
                .Sugestoes
                .AsNoTracking()
                .FirstOrDefaultAsync(x=>x.Id == id);
            return sugestao == null ?NotFound() : Ok(sugestao);
        }

        //[HttpPost]
        //[Route("sugestao/{id}")]
        //public async Task<IActionResult> PostSugestao(Guid id)
        //{
        //    var sugestao = await _context
        //        .Sugestoes
        //        .AsNoTracking()
        //        .FirstOrDefaultAsync(x => x.Id == id);
        //    return sugestao == null ? NotFound() : Ok(sugestao);
        //}
    }
}
