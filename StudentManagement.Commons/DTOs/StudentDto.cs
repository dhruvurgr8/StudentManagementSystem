using StudentManagement.Commons.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Commons.DTOs
{
    public class StudentDto
    {
        [Required(ErrorMessage = "Name should not be empty")]
        public string Name { get; set; }
        [Range(1, 150, ErrorMessage = "Age should be between 1 and 150")]
        public int Age { get; set; }


        [EnumDataType(typeof(Gender))]
        [Range(0, 2, ErrorMessage = "Value should be between 0 and 2")]
        public Gender Gender { get; set; }
        [Range(1, 12, ErrorMessage = "Please enter the standarad between 1 and 12")]
        public int Standard { get; set; }
        
        
    }   
}       
        