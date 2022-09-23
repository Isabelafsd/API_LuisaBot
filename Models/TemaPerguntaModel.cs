using System;

namespace API_LuisaBot.Models
{
    public class TemaPerguntaModel : BaseModel
    {
        public int TemaId { get; set; }
        public TemaModel Tema { get; set; }
        public int PerguntaId { get; set; }
        public PerguntaModel Pergunta { get; set; }
    }
}
