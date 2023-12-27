namespace AIService.Entities;

public class User
{
    public int Id { get; set; }
    public int UserCode { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public double Kilo { get; set; }
    public double Height { get; set; }
    public int Age { get; set; }
    public bool Gender { get; set; }
    public double UserBodyIndex { get; set; }
    public ICollection<AıResponse> Responses { get; set; }
}