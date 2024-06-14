

using AutoMapper;
using StudentManagement.Commons.DTOs;
using StudentManagement.Commons.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Student, StudentDto>(); 
        CreateMap<StudentDto, Student>(); 
    }
}
