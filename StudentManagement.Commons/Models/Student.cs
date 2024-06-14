using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Commons.enums;

namespace StudentManagement.Commons.Models
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name should not be empty")]
        public string Name { get; set; }
        [Range(1,150,ErrorMessage ="Age should be between 1 and 150")]
        public int Age { get; set; }
        [Required(ErrorMessage ="Please specify the Gender")]
        
        public String Gender { get; set; }

        [Range(1,12,ErrorMessage ="Please enter the standard between 1 and 12")]
        public int Standard { get; set; }
    }
}
