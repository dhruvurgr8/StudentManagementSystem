using StudentManagement.Commons.DTOs;
using StudentManagement.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DAL.Repositories.IRepository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudents();
        Task AddStudentData(Student student);

        Task DeleteStudentData(int id);
        Task UpdateStudentData(int id, Student student);
        Task <Student> GetStudentById(int id);
        Task <bool> getStudentByName(string name);
    }
}
