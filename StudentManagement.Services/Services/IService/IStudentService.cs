using StudentManagement.Commons.DTOs;
using StudentManagement.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services.Services.IService
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudents();
        Task AddStudentData(StudentDto studentdto);

        Task DeleteStudentData(int id);
        Task UpdateStudentData(int id, UpdateStatudentModel studentdto);
    }
}
