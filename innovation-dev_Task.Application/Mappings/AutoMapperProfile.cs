

using AutoMapper;
using innovation_dev_Task.Application.DTOs;
using innovation_dev_Task.Domain.Entities;

namespace innovation_dev_Task.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
           

            CreateMap<Student, CreateStudentDto>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Subject, CreateSubjectDto>().ReverseMap();
            CreateMap<Subject, SubjectDto>().ReverseMap();


        }
    }
}
