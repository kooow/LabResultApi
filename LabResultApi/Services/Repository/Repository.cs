using LabResultApi.Services.Database;

namespace LabResultApi.Services.Repository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly LabResultDbContext _dbContext;

    public Repository(LabResultDbContext context)
    {
        _dbContext = context;
    }

    public void Add(TEntity entity)
    {
        _dbContext.Set<TEntity>().Add(entity);
        _dbContext.SaveChanges();
    }

    public void AddMany(IEnumerable<TEntity> entities)
    {
        _dbContext.Set<TEntity>().AddRange(entities);
        _dbContext.SaveChanges();
    }

    public IEnumerable<TEntity> GetAll()
    {
        return [.. _dbContext.Set<TEntity>()];
    }
}