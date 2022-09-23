namespace API_LuisaBot.Models.Requests
{
    public class TemaRequest
    {
        public string Nome { get; set; }
        public int Ordem { get; set; }
    }

    public class TemaUpdateRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Ordem { get; set; }
    }
}
