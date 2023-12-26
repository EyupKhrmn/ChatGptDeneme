using AIService.CQRS.Register.Dto;
using AIService.Entities;
using AIService.GeneralRepository;
using MediatR;

namespace AIService.CQRS.Register
{
    public class RegisterCommand : IRequest<RegisterCommandResponse>
    {
        public UserDto user { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterCommandResponse>
        {
            private readonly IGeneralRepository _generalRepository;

            public RegisterCommandHandler(IGeneralRepository generalRepository)
            {
                _generalRepository = generalRepository;
            }

            public async Task<RegisterCommandResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                Random randomNumber = new Random();

                var user = new User
                {
                    Name = request.user.Name,
                    Age = request.user.Age,
                    Gender = request.user.Gender,
                    Height = request.user.Height,
                    Kilo = request.user.Kilo,
                    Password = request.user.Password,
                    Surname = request.user.Surname,
                    Username = request.user.Username,
                    UserCode = randomNumber.Next(0,10)
                };

                _generalRepository.add(user);
                await _generalRepository.SaveChangesAsync(cancellationToken);

                return new RegisterCommandResponse
                {
                    Message = "Lütfen Kullanıcı kodunuzu (UserCode) Unutmayınız",
                    UserCode = user.UserCode
                };
            }
        }
    }

    public class RegisterCommandResponse
    {
        public string? Message { get; set; }
        public int? UserCode { get; set; }
    }
}
