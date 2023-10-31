using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels;
using Persistance.Entities;

namespace ChatGptDeneme.Services;

public class OpenAıCompletionService : BackgroundService
{
    private readonly IOpenAIService _openAıService;

    public OpenAıCompletionService(IOpenAIService openAıService)
    {
        _openAıService = openAıService;
    }

    protected override async Task<AIResponse> ExecuteAsync(CancellationToken stoppingToken)
    {
        AIResponse response = new();
        
        while (true)
        {
            Console.Write("::");

            CompletionCreateResponse result = await _openAıService.Completions.CreateCompletion(new CompletionCreateRequest()
            {
                Prompt = Console.ReadLine(),
                MaxTokens = 1000
            }, Models.TextDavinciV3, cancellationToken: stoppingToken);

            response.Message = result.Choices[0].Text;

            return response;
        }
        
    }
}