using Microsoft.EntityFrameworkCore;
using vibe_api.Entity;

namespace vibe_api.Repository;

public interface IRepository<T> where T : class, IEntity
{
    DbSet<T> Entities { get; }
    T Add(T entity);
    T Update(T entity);
    T Get(long id);
    void Delete(T entity);
}