using Microsoft.EntityFrameworkCore;
using StudentManagement.Commons.DTOs;
using StudentManagement.Commons.Models;
using StudentManagement.ConnectionModels.Data;
using StudentManagement.DAL.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DAL.Repositories.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ConnectionDbContext connectionDb;
        public StudentRepository(ConnectionDbContext studentDb)
        {
            connectionDb = studentDb;
        }
        // method to get the students data
        public async Task<List<Student>> GetAllStudents()
        {
            var students = await connectionDb.Students.ToListAsync();
            return students;
        }

        //method to add student data
        public async Task  AddStudentData(Student student)
        {
            await connectionDb.Students.AddAsync(student);
            await connectionDb.SaveChangesAsync();
           

        }

        //method to delete student data
        public async Task DeleteStudentData(int id)
        {
            var student = await connectionDb.Students.FindAsync(id);

            connectionDb.Students.Remove(student);
            await connectionDb.SaveChangesAsync();
        }

        //method to update student data
        public async Task UpdateStudentData(int id, Student student)
        {
            var studentToUpdate = await connectionDb.Students.FindAsync(id);


            if (studentToUpdate != null)
            {
                studentToUpdate.Name = student.Name;
                studentToUpdate.Age = student.Age;
                studentToUpdate.Gender = student.Gender;
                studentToUpdate.Standard = student.Standard;

                await connectionDb.SaveChangesAsync();
            }
        }
        //method to find the student by id
        public async Task<Student> GetStudentById(int id)
        {
            var student = await connectionDb.Students.FindAsync(id);
            return student;
        }
        //method to get the student by name
        public async Task <bool> getStudentByName(string name)
        {
            var student = await connectionDb.Students.FirstOrDefaultAsync(s => s.Name == name);
            if (student !=null)
            {
                return true;
            }
            return false;
        }
    }
}
