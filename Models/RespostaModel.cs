using System;

namespace API_LuisaBot.Models
{
    public class RespostaModel : BaseModel
    {
        public string Descricao { get; set; }
        public string Referencia { get; set; }
        public int Ordem { get; set; }
        public bool IsImagem { get; set; }
        public Guid PerguntaId { get; set; }
        public PerguntaModel Pergunta { get; set; }
    }
}
