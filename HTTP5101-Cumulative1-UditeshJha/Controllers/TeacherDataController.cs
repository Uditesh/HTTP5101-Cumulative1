using HTTP5101_Cumulative1_UditeshJha.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HTTP5101_Cumulative1_UditeshJha.Controllers
{
    public class TeacherDataController : ApiController
    {
        // The database context class which allows us to access our MySQL Database.
        private SchoolDbContext School = new SchoolDbContext();

        //This Controller Will access the teachers table of our blog database.
        /// <summary>
        /// Returns a list of teachers in the system
        /// </summary>
        /// <example>GET api/TeacherData/ListTeachers</example>
        /// <returns>
        /// A list of teachers (first names and last names)
        /// </returns>
        [HttpGet]
        [Route("api/TeacherData/ListTeachers/{SearchKey}")]
        public IEnumerable<Teacher> ListTeachers(string SearchKey = null)
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from teachers where lower(teacherfname) like " +
                "lower(@key) or lower(teacherlname) like lower(@key)" +
                "or hiredate like (@key) or salary like (@key)";
            cmd.Parameters.AddWithValue("@key","%" +SearchKey+"%");
            cmd.Prepare();

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of teachers
            List<Teacher> teachers = new List<Teacher> { };

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFname = (string)ResultSet["teacherfname"];
                string TeacherLname = (string)ResultSet["teacherlname"];
                string EmployeeNumber= (string)ResultSet["employeenumber"];
                DateTime HireDate= (DateTime)ResultSet["hiredate"];
                decimal Salary = (decimal)ResultSet["salary"];
                Teacher teacher = new Teacher();
                teacher.TeacherId = TeacherId;
                teacher.TeacherFname = TeacherFname;
                teacher.TeacherLname = TeacherLname;
                teacher.EmployeeNumber = EmployeeNumber;
                teacher.HireDate = HireDate;
                teacher.Salary = Salary;

                //Add the Teacher to the List
                teachers.Add(teacher);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of teachers names
            return teachers;
        }

        /// <summary>
        /// Returns found teacher by id
        /// </summary>
        /// <example>GET api/TeacherData/FindTeacher/2</example>
        /// <returns>
        /// A teacher's all data
        /// </returns>
        [HttpGet]
        public Teacher FindTeacher(int id)
        {
            Teacher newTeacher = new Teacher();

            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from teachers where teacherid = "+id;

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFname = ResultSet["teacherfname"].ToString();
                string TeacherLname = ResultSet["teacherlname"].ToString();
                string EmployeeNumber = ResultSet["employeenumber"].ToString();
                DateTime HireDate = (DateTime)ResultSet["hiredate"];
                decimal Salary = (decimal)ResultSet["salary"];

                newTeacher.TeacherId = TeacherId;
                newTeacher.TeacherFname = TeacherFname;
                newTeacher.TeacherLname = TeacherLname;
                newTeacher.EmployeeNumber = EmployeeNumber;
                newTeacher.HireDate = HireDate;
                newTeacher.Salary = Salary;

            }
            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();
            return newTeacher;

        }

        /// <summary>
        /// Delete a teacher by id
        /// </summary>
        /// <example>GET api/TeacherData/DeleteTeacher/2</example>
        /// <returns>
        /// Returns nothing
        /// </returns>
        [HttpPost]
        public void DeleteTeacher(int id)
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL query
            cmd.CommandText = " Delete from teachers where teacherid = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
            Conn.Close();
        }

        /// <summary>
        /// Add a new teacher
        /// </summary>
        /// <example>GET api/TeacherData/AddTeacher/2</example>
        /// <returns>
        /// Returns nothing
        /// </returns>
        [HttpPost]
        internal void AddTeacher([FromBody]Teacher newTeacher)
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL query
            cmd.CommandText = "insert into teachers(teacherfname,teacherlname,employeenumber," +
                "hiredate, salary ) values(@TeacherFname,@TeacherLname,@EmployeeNumber," +
                "@HireDate,@Salary)";
            cmd.Parameters.AddWithValue("@TeacherFname", newTeacher.TeacherFname);
            cmd.Parameters.AddWithValue("@TeacherLname", newTeacher.TeacherLname);
            cmd.Parameters.AddWithValue("@EmployeeNumber", newTeacher.EmployeeNumber);
            cmd.Parameters.AddWithValue("@HireDate", newTeacher.HireDate);
            cmd.Parameters.AddWithValue("@Salary", newTeacher.Salary);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
            Conn.Close();
        }

        /// <summary>
        ///  Update a teacher by Id
        /// </summary>
        /// <param name="id">The id of the teacher which is to be updated.</param>
        /// <param name="teacherData">Its a data of the teacher.</param>
        /// <returns>
        ///  Returns nothing
        /// </returns>
        [HttpPost]
        public void UpdateTeacher(int id, [FromBody] Teacher teacherData)
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL query
            cmd.CommandText = "UPDATE teachers set " +
                "teacherfname = @fname , teacherlname = @lname," + "employeenumber = @enum"+
                ", salary = @salary " +
                "where teacherid = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@fname", teacherData.TeacherFname);
            cmd.Parameters.AddWithValue("@lname", teacherData.TeacherLname);
            cmd.Parameters.AddWithValue("@enum", teacherData.EmployeeNumber);
            cmd.Parameters.AddWithValue("@salary", teacherData.Salary);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            Conn.Close();

        }
    }
}
