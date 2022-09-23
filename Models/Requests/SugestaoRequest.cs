using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_LuisaBot.Models.Requests
{
    public class SugestaoRequest
    {
        public string Descricao { get; set; }
        public string Tema { get; set; }
        public bool IsPergunta { get; set; }
    }

    public class SugestaoUpdateRequest
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Tema { get; set; }
        public bool IsPergunta { get; set; }
    }
}
