using AutoMapper;
using innovation_dev_Task.Application.DTOs;
using innovation_dev_Task.Application.Interfaces;
using innovation_dev_Task.Domain.Entities;

namespace innovation_dev_Task.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CreateStudentDto> AddStudentAsync(CreateStudentDto studentDto)
        {

            if (studentDto == null || studentDto.SelectedSubjectIds == null ||studentDto.SelectedSubjectIds.Count > 2) throw new ArgumentNullException(nameof(studentDto));

            var existStudent = await _unitOfWork.StudentRepository.GetByNameAsync(studentDto.Name);
            if (existStudent != null)
                return null;

            var subjects = await _unitOfWork.SubjectRepository.GetByIdsAsync(studentDto.SelectedSubjectIds);

            Student? student = _mapper.Map<Student>(studentDto);
            foreach (var subject in subjects)
            {
                _unitOfWork.SubjectRepository.Attach(subject); 
            }
            student.Subjects = subjects.ToList();
            await _unitOfWork.StudentRepository.AddAsync(student);
            await _unitOfWork.SaveChangesAsync();
            return studentDto;
        }
        public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
        {
            var students = await _unitOfWork.StudentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }
        public async Task<CreateSubjectDto> AddSubjectAsync(CreateSubjectDto subjectDto)
        {
            if (subjectDto == null) throw new ArgumentNullException(nameof(subjectDto));
            var existSubject = await _unitOfWork.SubjectRepository.GetByNameAsync(subjectDto.Name);
            if (existSubject != null)
                return null;
            var subject = _mapper.Map<Subject>(subjectDto);
            await _unitOfWork.SubjectRepository.AddAsync(subject);
            await _unitOfWork.SaveChangesAsync();
            return subjectDto;
        }
        public async Task<IEnumerable<SubjectDto>> GetAllSubjectsAsync()
        {
            var subjects = await _unitOfWork.SubjectRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SubjectDto>>(subjects);
        }
        public async Task<bool> ValidateStudentName(string name)
        {
            var studentExists = await _unitOfWork.StudentRepository.GetByNameAsync(name);
            if (studentExists != null)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> ValidateSubjectName(string name)
        {
            var studentExists = await _unitOfWork.SubjectRepository.GetByNameAsync(name);
            if (studentExists != null)
            {
                return true;
            }
            return false;
        }
    }
}
