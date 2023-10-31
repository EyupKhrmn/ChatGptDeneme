using MediatR;

namespace AIService.CQRS.AskQuestionCommand;

public class AskQuestionRequest : IRequest<string>
{

    public string Question { get; set; }
    
    
    
    
    
    public class AskQuestionCommandHandler : IRequestHandler<AskQuestionRequest,string>
    {
        public Task<string> Handle(AskQuestionRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}