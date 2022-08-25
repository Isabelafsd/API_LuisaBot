using System;

namespace API_LuisaBot.Models
{
    public class TemaPerguntaModel : BaseModel
    {
        public Guid TemaId { get; set; }
        public TemaModel Tema { get; set; }
        public Guid PerguntaId { get; set; }
        public PerguntaModel Pergunta { get; set; }
    }
}
