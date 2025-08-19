namespace LabResultApi.Services.Repository;

public interface IRepository<TEntity> where TEntity : class
{
    IEnumerable<TEntity> GetAll();
    void Add(TEntity entity);
    void AddMany(IEnumerable<TEntity> entities);
}
