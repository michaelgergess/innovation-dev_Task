using innovation_dev_Task.Application.DTOs;

namespace innovation_dev_Task.Application.Services
{
    public interface IStudentService
    {
        Task<CreateStudentDto> AddStudentAsync(CreateStudentDto studentDto);
        Task<CreateSubjectDto> AddSubjectAsync(CreateSubjectDto subjectDto);
        Task<IEnumerable<StudentDto>> GetAllStudentsAsync();
        Task<IEnumerable<SubjectDto>> GetAllSubjectsAsync();
        Task<bool> ValidateStudentName(string name);
        Task<bool> ValidateSubjectName(string name);

    }
}