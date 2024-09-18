
using innovation_dev_Task.Domain.Entities;

namespace innovation_dev_Task.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Subject> SubjectRepository { get; }

        IRepository<Student> StudentRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
