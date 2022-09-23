using System;

namespace API_LuisaBot.Models.Requests
{
    public class RespostaRequest
    {
        public string Descricao { get; set; }
        public string Referencia { get; set; }
        public int Ordem { get; set; }
        public bool IsImagem { get; set; }
        public int PerguntaId { get; set; }
    }

    public class RespostaUpdateRequest
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Referencia { get; set; }
        public int Ordem { get; set; }
        public bool IsImagem { get; set; }
        public int PerguntaId { get; set; }
    }
}
