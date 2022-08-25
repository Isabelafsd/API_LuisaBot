using System.Collections.Generic;

namespace API_LuisaBot.Models
{
    public class TemaModel : BaseModel
    {
        public string Nome { get; set; }
        public int Ordem { get; set; }
        public ICollection<TemaPerguntaModel> TemaPerguntas { get; set; }
    }
}
