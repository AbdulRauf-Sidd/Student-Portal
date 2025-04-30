using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Web.UI.WebControls;
using System.Collections;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Xml.Linq;

namespace StudentPortal1._01
{
    public class DBHelper
    {
        public StringBuilder GetEverything()
        {
            StringBuilder html = new StringBuilder();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            con.Open();
            SqlCommand sqlCommand = con.CreateCommand();
            sqlCommand.CommandText = "SELECT * FROM Course";
            sqlCommand.Connection = con;
            SqlDataReader sqlData = sqlCommand.ExecuteReader();

            html.Append("<tr><th>name</th><th>id</th></tr>");
            if (sqlData.HasRows)
            {
                while (sqlData.Read())
                {
                    html.Append("<tr>");
                    html.Append("<td>" + sqlData[0].ToString() + "</td>");
                    html.Append("<td>" + sqlData[1].ToString() + "</td>");
                    html.Append("</tr>");
                }
            }
            return html;

        }

        public StringBuilder GetStudentsForATeacher (string tid, string  cid)
        {
            StringBuilder html = new StringBuilder();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("UPDATE Marks SET assignment_1 = , assignment_2 = 0, quiz_1 = 0, quiz_2 = 0, quiz_3 = 0, quiz_4 = 0, quiz_5 = 0, mid_exam = 0 WHERE roll_no = '21B-003-CE' AND course_id = 'c01'", con);
            SqlDataReader sqlData = sqlCommand.ExecuteReader();

            html.Append("<tr><th>Student Name</th></tr>");

            if (sqlData.HasRows)
            {
                while (sqlData.Read())
                {
                    html.Append("<tr>");
                    html.Append("<td>" + sqlData[0].ToString() + "</td>");
                    html.Append("</tr>");
                }
            }
            con.Close();
            return html;
        }

        public void UpdateMarks(string roll_no, string course_id, double a1, double a2, double q1, double q2, double q3, double q4, double q5, double mid)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("UPDATE Marks SET assignment_1 = @a1, assignment_2 = @a2, quiz_1 = @q1, quiz_2 = @q2, quiz_3 = @q3, quiz_4 = @q4, quiz_5 = @q5, mid_exam = @mid WHERE roll_no = @roll_no AND course_id = @course_id", con);
            sqlCommand.Parameters.AddWithValue("roll_no", roll_no);
            sqlCommand.Parameters.AddWithValue("course_id", course_id);
            sqlCommand.Parameters.AddWithValue("a1", a1);
            sqlCommand.Parameters.AddWithValue("a2", a2);
            sqlCommand.Parameters.AddWithValue("q1", q1);
            sqlCommand.Parameters.AddWithValue("q2", q2);
            sqlCommand.Parameters.AddWithValue("q3", q3);
            sqlCommand.Parameters.AddWithValue("q4", q4);
            sqlCommand.Parameters.AddWithValue("q5", q5);
            sqlCommand.Parameters.AddWithValue("mid", mid);
            SqlDataReader sqlData = sqlCommand.ExecuteReader();
            con.Close();
        }

        public void AddStudent(string name, string dep, string sem, string sec)
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            keyValuePairs.Add("computer science", "CS");
            keyValuePairs.Add("computer engineering", "CE");
            keyValuePairs.Add("electrical engineering", "EE");
            keyValuePairs.Add("mechanical engineering", "ME");
            keyValuePairs.Add("software engineering", "SE");
            string l = keyValuePairs[dep];
            string f = DateTime.Now.Year.ToString();
            string year = DateTime.Now.Year.ToString().Substring(2, 2);
            string query = year + "%" + l;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT MAX(roll_no) FROM Student WHERE roll_no like @roll_no", con);
            sqlCommand.Parameters.AddWithValue("roll_no", query);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            string new_roll;
            if (reader.HasRows)
            {
                reader.Read();
                if (reader.GetSqlString(0).ToString() != null)
                {
                    string roll_no;
                    int roll = int.Parse(reader.GetSqlString(0).ToString().Substring(4, 3)) + 1;
                    if (roll < 10)
                    {
                        roll_no = "00" + roll;
                    }
                    else if (roll < 100)
                    {
                        roll_no = "0" + roll;
                    }
                    else
                    {
                        roll_no = "" + roll;
                    }
                    new_roll = year + "B-" + roll_no + "-" + l;
                }
                else
                {
                    new_roll = year + "B-001-" + l;
                }
            }
            else
            {
                new_roll = year + "B-001-" + l;
            }
            reader.Close();
            con.Close();
            SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            con2.Open();
            SqlCommand sqlCommand2 = new SqlCommand("INSERT INTO Student VALUES(@roll, @name, @dep, @sem, @sec)", con2);
            sqlCommand2.Parameters.AddWithValue("roll", new_roll);
            sqlCommand2.Parameters.AddWithValue("name", name);
            sqlCommand2.Parameters.AddWithValue("dep", dep);
            sqlCommand2.Parameters.AddWithValue("sem", sem);
            sqlCommand2.Parameters.AddWithValue("sec", sec);
            SqlDataReader reader2 = sqlCommand2.ExecuteReader();
            con2.Close();

        }

        public void DeleteStudentCourse(string roll_no, string course_id)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("DELETE FROM Student_Course WHERE roll_no = @roll_no AND course_id = @course_id", con);
            sqlCommand.Parameters.AddWithValue("roll_no", roll_no);
            sqlCommand.Parameters.AddWithValue("course_id", course_id);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            con.Close();
        }

        public void DeleteStudent(string roll_no)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("DELETE FROM Student_Course WHERE roll_no = @roll_no", con);
            sqlCommand.Parameters.AddWithValue("roll_no", roll_no);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            con.Close();
            SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            con2.Open();
            SqlCommand sqlCommand1 = new SqlCommand("DELETE FROM Student WHERE roll_no = @roll_no", con2);
            sqlCommand1.Parameters.AddWithValue("roll_no", roll_no);
            SqlDataReader reader2 = sqlCommand1.ExecuteReader();
            con2.Close();
        }

        public void AddStudentCourse(string roll_no, string course_id)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO Student_Course VALUES (@roll_no, @course_id)", con);
            sqlCommand.Parameters.AddWithValue("roll_no", roll_no);
            sqlCommand.Parameters.AddWithValue("course_id", course_id);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            con.Close();
        }

        public void UpdateStudent(string roll, string name, string dep, int sem, string sec)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("UPDATE Student SET student_name = @name, department = @dep, semester = @sem, section = @sec WHERE roll_no = @roll", con);
            sqlCommand.Parameters.AddWithValue("roll", roll);
            sqlCommand.Parameters.AddWithValue("name", name);
            sqlCommand.Parameters.AddWithValue("dep", dep);
            sqlCommand.Parameters.AddWithValue("sem", sem);
            sqlCommand.Parameters.AddWithValue("sec", sec);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            con.Close();
        }

        public void InsertInstructor(string name, string add, string phone)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT MAX(instructor_id) FROM Instructor", con);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            string new_roll;
            if (reader.HasRows)
            {
                reader.Read();
                if (reader.GetSqlString(0).ToString() != null)
                {
                    string roll_no;
                    int roll = int.Parse(reader.GetSqlString(0).ToString().Substring(1, 3)) + 1;
                    if (roll < 10)
                    {
                        roll_no = "00" + roll;
                    }
                    else if (roll < 100)
                    {
                        roll_no = "0" + roll;
                    }
                    else
                    {
                        roll_no = "" + roll;
                    }
                    new_roll = "t" + roll_no;
                }
                else
                {
                    new_roll = "t001";
                }
            }
            else
            {
                new_roll = "t001";
            }
            reader.Close();
            con.Close();
            SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            con2.Open();
            SqlCommand sqlCommand2 = new SqlCommand("INSERT INTO Instructor VALUES(@id, @name, @add, @pho)", con2);
            sqlCommand2.Parameters.AddWithValue("id", new_roll);
            sqlCommand2.Parameters.AddWithValue("name", name);
            sqlCommand2.Parameters.AddWithValue("add", add);
            sqlCommand2.Parameters.AddWithValue("pho", phone);
            SqlDataReader reader2 = sqlCommand2.ExecuteReader();
            con2.Close();
        }

        public void UpdateInstructor(string roll, string name, string add, string phone)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("UPDATE Instructor SET instructor_name = @name, address = @add, phone_no = @phone WHERE instructor_id = @id", con);
            sqlCommand.Parameters.AddWithValue("name", name);
            sqlCommand.Parameters.AddWithValue("add", add);
            sqlCommand.Parameters.AddWithValue("phone", phone);
            sqlCommand.Parameters.AddWithValue("id", roll);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            con.Close();
        }

        public void DeleteCourseInstructor(string id, string course_id)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("DELETE FROM Course_Instructor WHERE instructor_id = @id AND course_id = @course_id", con);
            sqlCommand.Parameters.AddWithValue("id", id);
            sqlCommand.Parameters.AddWithValue("course_id", course_id);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            con.Close();
        }

        public void DeleteInstructor(string id)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("DELETE FROM Instructor WHERE instructor_id = @id", con);
            sqlCommand.Parameters.AddWithValue("id", id);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            con.Close();
        }
    }
}