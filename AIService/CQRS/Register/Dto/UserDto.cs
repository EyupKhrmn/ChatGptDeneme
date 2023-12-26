namespace AIService.CQRS.Register.Dto
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Kilo { get; set; }
        public int Height { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
    }
}
