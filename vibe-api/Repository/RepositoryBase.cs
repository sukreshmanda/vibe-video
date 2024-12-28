using Microsoft.EntityFrameworkCore;
using vibe_api.Entity;
using vibe_api.Helper.Exceptions;

namespace vibe_api.Repository;

public class RepositoryBase<T>(AppDbContext dbContext) : IRepository<T>
    where T : class, IEntity
{
    private AppDbContext DbContext { get; } = dbContext;

    public DbSet<T> Entities { get; } = dbContext.Set<T>();

    public T Add(T entity)
    {
        var item = Entities.Add(entity).Entity;
        DbContext.SaveChanges();
        return item;
    }

    public T Update(T entity)
    {
        return Entities.Update(entity).Entity;
    }

    public T Get(long id)
    {
        var entity = Entities.Find(id);
        if (entity == null) throw new EntityException(EntityErrorMessage.EntityNotFound);
        return entity;
    }

    public void Delete(T entity)
    {
        Entities.Remove(entity);
    }
}