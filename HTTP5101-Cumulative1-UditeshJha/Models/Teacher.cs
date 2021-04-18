using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HTTP5101_Cumulative1_UditeshJha.Models
{
    public class Teacher
    {
        public int TeacherId;
        /* server side validation */
        [Required(ErrorMessage = "Enter first name")]
        public string TeacherFname;
        [Required(ErrorMessage = "Enter last name")]
        public string TeacherLname;
        [Required(ErrorMessage = "Enter Employee Number")]
        public string EmployeeNumber;
        [Required(ErrorMessage = "Enter Date Time")]
        [DataType(DataType.DateTime)]
        public DateTime HireDate;
        [Required(ErrorMessage = "Enter Salary")]
        public decimal Salary;
        public Teacher() { }
    }
}