using AIService.Entities;
using AIService.GeneralRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AIService.CQRS.AskQuestionCommand
{
    public class AskRandomQuestionRequest : IRequest<AskRandomQuestionResponse>
    {
        public int UserCode { get; set; }
        public string  Question { get; set; }

        public class AskRandomQuestionCommandHandler : IRequestHandler<AskRandomQuestionRequest, AskRandomQuestionResponse>
        {
            private readonly IGeneralRepository _generalRepository;

            public AskRandomQuestionCommandHandler(IGeneralRepository generalRepository)
            {
                _generalRepository = generalRepository;
            }

            public async Task<AskRandomQuestionResponse> Handle(AskRandomQuestionRequest request, CancellationToken cancellationToken)
            {
                var user = await _generalRepository.Query<User>()
                   .FirstOrDefaultAsync(_ => _.UserCode == request.UserCode);

                var aiResponse = new AıResponse();

                string outputResult = await _generalRepository.AskGpt(request.Question);

                aiResponse.Question = request.Question;
                aiResponse.Message = outputResult;
                aiResponse.User = user;

                _generalRepository.add(aiResponse);
                await _generalRepository.SaveChangesAsync(cancellationToken);

                return new AskRandomQuestionResponse
                {
                    Message = outputResult,
                };
            }
        }
    }

    public class AskRandomQuestionResponse
    {
        public string Message { get; set; }
    }
}
