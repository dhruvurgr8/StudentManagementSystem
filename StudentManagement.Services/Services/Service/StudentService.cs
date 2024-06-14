using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Commons.DTOs;
using StudentManagement.Commons.Models;
using StudentManagement.ConnectionModels;
using StudentManagement.ConnectionModels.Data;
using StudentManagement.DAL.Repositories.IRepository;
using StudentManagement.Helpers;
using StudentManagement.Services.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services.Services.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }
        // Method to fetch all the students from the database
        public async Task<List<Student>> GetAllStudents()
        {

            var students = await studentRepository.GetAllStudents();
               if(students.Count == 0)
                {
                    throw new StudentNotFoundException("There are currently no students in the database");
                }
            return students;
        }

        //Method to create the new student data
        public async Task AddStudentData(StudentDto studentDto)
        {
            var student = mapper.Map<Student>(studentDto);
            var isStudentExist = await studentRepository.getStudentByName(student.Name);
            if(isStudentExist) {
                throw new StudentAlreadyExistException($"Student already exist with the name {student.Name}");
            }
            await studentRepository.AddStudentData(student);

        }
        ////Method to delete student data from the databse using the id
        public async Task DeleteStudentData(int id)
        {
            var student = await studentRepository.GetStudentById(id);
            if (student == null)
            {
                throw new StudentNotFoundException($"Student not found for the given id-{id}");
            }
            await studentRepository.DeleteStudentData(id);
        }

        ////Method to update student data based on id and the student data object
        public async Task UpdateStudentData(int id, UpdateStatudentModel studentdto)
        {
            var student = mapper.Map<Student>(studentdto);
            var studentToUpdate = await studentRepository.GetStudentById(id);
            if (studentToUpdate == null)
            {
                throw new StudentNotFoundException($"Student not found for the given id-{id}");
            }
            await studentRepository.UpdateStudentData(id, student);
        }
    }

}

