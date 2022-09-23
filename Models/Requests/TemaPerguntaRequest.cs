using System;

namespace API_LuisaBot.Models.Requests
{
    public class TemaPerguntaRequest 
    {
        public int TemaId { get; set; }
        public int PerguntaId { get; set; }
    }

    public class TemaPerguntaUpdateRequest
    {
        public int Id { get; set; }
        public int TemaId { get; set; }
        public int PerguntaId { get; set; }
    }
}
