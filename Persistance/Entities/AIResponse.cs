namespace Persistance.Entities
{
    public class AIResponse
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Message { get; set; }
    }
}