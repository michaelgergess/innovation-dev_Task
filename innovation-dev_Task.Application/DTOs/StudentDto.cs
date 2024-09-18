using innovation_dev_Task.Domain.Entities;

namespace innovation_dev_Task.Application.DTOs
{
    public record StudentDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public DateTime DateOfBirth { get; init; }
        public string Address { get; init; }
        public string Email { get; init; }
        public ICollection<Subject> Subjects { get; init; }
    }

}
