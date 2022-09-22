using System.Collections.Generic;

namespace API_LuisaBot.Models
{
    public class PerguntaModel : BaseModel
    {
        public string Descricao { get; set; }
        public int Ordem { get; set; }
        public ICollection<TemaPerguntaModel> TemaPerguntas { get; set; }
        public ICollection<RespostaModel> Respostas{ get; set; }
    }
}
