using AIService.Entities;
using AIService.GeneralRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AIService.CQRS.AskQuestionCommand;

public class AskQuestionRequest : IRequest<AskQuestionRequest.AskQuestionResponse>
{
    public int? UserCode { get; set; }
    public string? Question { get; set; }

    public class AskQuestionCommandHandler : IRequestHandler<AskQuestionRequest, AskQuestionResponse>
    {
        private readonly IGeneralRepository _generalRepository;

        public AskQuestionCommandHandler(IGeneralRepository generalRepository)
        {
            _generalRepository = generalRepository;
        }

        public async Task<AskQuestionResponse> Handle(AskQuestionRequest request, CancellationToken cancellationToken)
        {
            var user = await _generalRepository.Query<User>()
               .FirstOrDefaultAsync(_=>_.UserCode == request.UserCode);

            var aiResponse = new AıResponse(); 
            // kg / m2

            var userGender = user.Gender == true ? "Erkek" : "Kadın";

            if (user.UserBodyIndex <= 18.5)
            {
                aiResponse = await _generalRepository.Query<AıResponse>()
                    .Where(_ => _.UserBodyIndex <= 18.5 && _.User.Gender == user.Gender)
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);
            }
            else if (user.UserBodyIndex >= 18.5 && user.UserBodyIndex <= 24.9)
            {
                aiResponse = await _generalRepository.Query<AıResponse>()
                    .Where(_ => _.UserBodyIndex >= 18.5 && _.UserBodyIndex <= 24.9 && _.User.Gender == user.Gender)
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);
                
            }
            else if (user.UserBodyIndex >= 25 && user.UserBodyIndex <= 29.9)
            {
                aiResponse = await _generalRepository.Query<AıResponse>()
                    .Where(_ => _.UserBodyIndex >= 25 && _.UserBodyIndex <= 29.9 && _.User.Gender == user.Gender)
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);
                
            }
            else if (user.UserBodyIndex >= 30 && user.UserBodyIndex <= 40)
            {
                aiResponse = await _generalRepository.Query<AıResponse>()
                    .Where(_ => _.UserBodyIndex >= 30 && _.UserBodyIndex <= 40 && _.User.Gender == user.Gender)
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);
                
            }
            else if (user.UserBodyIndex >= 40)
            {
                aiResponse = await _generalRepository.Query<AıResponse>()
                    .Where(_ => _.UserBodyIndex >= 40 && _.User.Gender == user.Gender)
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);
            }
            else
            {
                var baseQuery = $"Ben {user.Kilo} kilo, {user.Height} boyunda, {user.Age} yaşında, {userGender} cinsiyetli biriyim. Bunları göz önünde bulundurarak ";

                string sendQuery = $"{baseQuery} {request.Question}";

                string outputResult = await _generalRepository.AskGpt(sendQuery);

                aiResponse.Question = sendQuery;
                aiResponse.Message = outputResult;
                aiResponse.User = user;
                aiResponse.UserBodyIndex = user.Kilo / (user.Height * user.Height);
                
                _generalRepository.add(aiResponse);
                await _generalRepository.SaveChangesAsync(cancellationToken);

                return new AskQuestionResponse
                {
                    Message = outputResult,
                };
            }

            return new AskQuestionResponse
            {
                Message = aiResponse.Message
            };
        }
    }
    
    public class AskQuestionResponse
    {
        public string Message { get; set; }
    }
}