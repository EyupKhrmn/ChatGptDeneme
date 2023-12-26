using AIService.Entities;
using AIService.GeneralRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static AIService.CQRS.AskQuestionCommand.AskQuestionRequest.AskQuestionCommandHandler;

namespace AIService.CQRS.AskQuestionCommand;

public class AskQuestionRequest : IRequest<AskQuestionResponse>
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

            var userGender = user.Gender == true ? "Erkek" : "Kadın";

            var baseQuery = $"Ben {user.Kilo} kilo, {user.Height} boyunda, {user.Age} yaşında, {userGender} cinsiyetli biriyim. Bunları göz önünde bulundurarak ";

            string sendQuery = $"{baseQuery} {request.Question}";

            string outputResult = await _generalRepository.AskGpt(sendQuery);

            aiResponse.Question = sendQuery;
            aiResponse.Message = outputResult;
            aiResponse.User = user;

            _generalRepository.add(aiResponse);
            await _generalRepository.SaveChangesAsync(cancellationToken);

            return new AskQuestionResponse
            {
                Message = outputResult,
            };
        }

        public class AskQuestionResponse
        {
            public string Message { get; set; }
        }
    }
}