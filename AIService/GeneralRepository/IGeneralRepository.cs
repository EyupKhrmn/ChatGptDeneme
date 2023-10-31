using AIService.Context;

namespace AIService.GeneralRepository;

public interface IGeneralRepository
{
    public void add(object entity);

    public void delete(object entity);

    public void update(object entity);

    public IQueryable<TEntity> Query<TEntity>()
        where TEntity : class;

    public Task<string> AskGpt(string query);
}