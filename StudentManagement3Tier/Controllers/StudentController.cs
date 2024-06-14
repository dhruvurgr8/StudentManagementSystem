using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Commons.DTOs;
using StudentManagement.Commons.Models;
using StudentManagement.Helpers;
using StudentManagement.Services.Services.IService;
using StudentManagement.Services.Services.Service;

namespace StudentManagement3Tier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;
        private readonly IMapper mapper;
        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
           
        }

        // http route to get the student data
        [HttpGet("getstudents")]
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                var students = await studentService.GetAllStudents();
               
                return Ok(students);
            }
            catch (StudentNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        // post method to add student data in the databse
        [HttpPost("addstudentdata")]
        public async Task<IActionResult> AddStudent(StudentDto studentDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                
                await studentService.AddStudentData(studentDto);
                return Ok(studentDto);
            }
            catch (StudentAlreadyExistException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // delete request to delete the student data based on the id provided
        [HttpDelete("deletestudentdata/{id}")]
        public async Task <IActionResult> DeleteStudent(int id)
        {
            try
            {
                await studentService.DeleteStudentData(id);
                return Ok("Student data deleted Successfully");
            }
           catch(StudentNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
               
          

        }

        // put request to update the student data based on the id provided and student body
        [HttpPut("updatestudent")]
        public async Task<IActionResult> UpdateStudent(UpdateStatudentModel studentDto)
        {
            try
            {
               
                await studentService.UpdateStudentData(studentDto.Id, studentDto);
                return Ok(studentDto);
            }
            catch(StudentNotFoundException ex)
            {
                return NotFound(ex.Message) ;
            }
                      

        }
    }
}
