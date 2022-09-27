using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_LuisaBot.Models
{
    public class SugestaoModel : BaseModel
    {
        public string Descricao { get; set; }
        public bool IsPergunta { get; set; }
    }
}
