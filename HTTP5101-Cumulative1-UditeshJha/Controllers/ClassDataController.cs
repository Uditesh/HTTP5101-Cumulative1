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
    public class ClassDataController : ApiController
    {
        // The database context class which allows us to access our MySQL Database.
        private SchoolDbContext School = new SchoolDbContext();

        //This Controller Will access the classes table of our blog database.
        /// <summary>
        /// Returns a list of classes in the system
        /// </summary>
        /// <example>GET api/ClassData/ListClassess</example>
        /// <returns>
        /// A list of classes 
        /// </returns>
        [HttpGet]
        public IEnumerable<Class> ListClasses()
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from classes";

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of classes
            List<Class> classes = new List<Class> { };

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int ClassId = Convert.ToInt32(ResultSet["classid"]);
                string ClassCode = (string)ResultSet["classcode"];
                int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                DateTime StartDate = (DateTime)ResultSet["startdate"];
                DateTime FinishDate = (DateTime)ResultSet["finishdate"];
                string ClassName = (string)ResultSet["classname"];

                Class cl = new Class();
                cl.ClassId = ClassId;
                cl.ClassCode = ClassCode;
                cl.TeacherId = TeacherId;
                cl.StartDate = StartDate;
                cl.FinishDate = FinishDate;
                cl.ClassName = ClassName;

                //Add the Class to the List
                classes.Add(cl);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of CLass
            return classes;
        }

        [HttpGet]
        public Class FindClass(int id)
        {
            Class newClass = new Class();

            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from classes where classid = " + id;

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int ClassId = Convert.ToInt32(ResultSet["classid"]);
                string ClassCode = (string)ResultSet["classcode"];
                int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                DateTime StartDate = (DateTime)ResultSet["startdate"];
                DateTime FinishDate = (DateTime)ResultSet["finishdate"];
                string ClassName = (string)ResultSet["classname"];

                newClass.ClassId = ClassId;
                newClass.ClassCode = ClassCode;
                newClass.TeacherId = TeacherId;
                newClass.StartDate = StartDate;
                newClass.FinishDate = FinishDate;
                newClass.ClassName = ClassName;

            }
            return newClass;

        }
    }
}
