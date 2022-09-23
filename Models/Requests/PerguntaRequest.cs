namespace API_LuisaBot.Models.Requests
{
    public class PerguntaRequest
    {
        public string Descricao { get; set; }
        public int Ordem { get; set; }
    }

    public class PerguntaUpdateRequest
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Ordem { get; set; }
    }
}
