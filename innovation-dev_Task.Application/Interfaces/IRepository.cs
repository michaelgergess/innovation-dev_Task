using innovation_dev_Task.Domain.Entities;

namespace innovation_dev_Task.Application.Interfaces
{
    public interface IRepository<T> where T : BaseClass
    {  
        Task AddAsync(T entity);
        Task<T> GetByNameAsync(string name);
        Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<int> ids);
        Task<IEnumerable<T>> GetAllAsync();
        void Attach<T>(T entity);
        
    }
}
