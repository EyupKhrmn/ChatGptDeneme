namespace AIService.CQRS.Register.Dto
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public double Kilo { get; set; }
        public double Height { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
    }
}
