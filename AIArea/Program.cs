using ChatGptDeneme;
using ChatGptDeneme.Services;
using OpenAI.GPT3.Extensions;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddOpenAIService(settings => settings.ApiKey = "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");
        services.AddHostedService<OpenAıCompletionService>();
        
    })
    .Build();


host.Run();