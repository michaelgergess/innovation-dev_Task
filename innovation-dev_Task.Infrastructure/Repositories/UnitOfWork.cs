using innovation_dev_Task.Application.Interfaces;
using innovation_dev_Task.Domain.Entities;
using innovation_dev_Task.Infrastructure.Context;


namespace innovation_dev_Task.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IRepository<Subject> _subjectRepository;
        private IRepository<Student> _studentRepository;


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public UnitOfWork()
        {
        }

        public IRepository<Subject> SubjectRepository
        {
            get
            {
                return _subjectRepository ??= new Repository<Subject>(_context);
            }
        }
        public IRepository<Student> StudentRepository
        {
            get
            {
                return _studentRepository ??= new Repository<Student>(_context);
            }
        }
      

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}