using System;

namespace API_LuisaBot.Models.Requests
{
    public class TemaPerguntaRequest 
    {
        public Guid TemaId { get; set; }
        public Guid PerguntaId { get; set; }
    }
}
