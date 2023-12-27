namespace AIService.Entities;

public class AıResponse
{
    public int Id { get; set; }
    public User User { get; set; }
    public string Message { get; set; }
    public string Question { get; set; }
    public double UserBodyIndex { get; set; }
}