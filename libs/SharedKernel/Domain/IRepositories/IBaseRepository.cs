using Libs.SK.Domain.Entities;

namespace Libs.SK.Domain.IRepositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T> CreateAsync(T entity);
}
