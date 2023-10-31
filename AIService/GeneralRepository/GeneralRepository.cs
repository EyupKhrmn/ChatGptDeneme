using AIService.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using OpenAI_API;
using OpenAI_API.Completions;

namespace AIService.GeneralRepository;

public class GeneralRepository<TContext> : IGeneralRepository where TContext : DbContext
{
    protected TContext _context { get; set; }

    public DatabaseFacade Database => _context.Database;

    public GeneralRepository(TContext context)
    {
        _context = context;
    }

    public void add(object entity)
    {
        _context.Add(entity);
    }

    public void delete(object entity)
    {
        _context.Remove(entity);
    }

    public void update(object entity)
    {
        _context.Update(entity);
    }
    
    public IQueryable<TEntity> Query<TEntity>()
        where TEntity : class
    {
        return _context.Set<TEntity>();
    }

    public async Task<string> AskGpt(string query)
    {
        string outputResult = "";

        var opanai = new OpenAIAPI("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");
        CompletionRequest request = new CompletionRequest();
        request.Prompt = query;
        request.Model = OpenAI_API.Models.Model.DavinciText;
        request.MaxTokens = 500;

        var completions = await opanai.Completions.CreateCompletionAsync(request);
        
        foreach (var completion in completions.Completions)
        {
            outputResult += completion.Text;
        }
        
        Console.WriteLine(outputResult);

        return outputResult;
    }
}