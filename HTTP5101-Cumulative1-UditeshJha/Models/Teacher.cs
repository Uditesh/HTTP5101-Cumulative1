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
        [Required]
        public string TeacherFname;
        [Required]
        public string TeacherLname;
        [Required]
        public string EmployeeNumber;
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime HireDate;
        [Required]
        public decimal Salary;
        public Teacher() { }
    }
}