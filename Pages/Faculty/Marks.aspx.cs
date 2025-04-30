using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentPortal1._01.Pages.Faculty
{
    public partial class Marks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["id"] == null)
                {
                    Response.Redirect("FacultyLogin.aspx");
                }
                else
                {
                    string roll_no = Request.QueryString["roll_no"].ToString();
                    string course_id = Request.QueryString["course_id"].ToString();
                    string id = Session["id"].ToString();
                    faculty_name.Text = Session["fname"].ToString();
                    ID.Text = id;
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
                    con.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT s.roll_no, s.student_name, m.assignment_1, m.assignment_2, m.quiz_1, m.quiz_2, m.quiz_3, m.quiz_4, m.quiz_5, m.mid_exam FROM Marks m, Student s WHERE m.roll_no = @roll_no AND m.course_id = @course_id AND m.roll_no = s.roll_no", con);
                    sqlCommand.Parameters.AddWithValue("course_id", course_id);
                    sqlCommand.Parameters.AddWithValue("roll_no", roll_no);
                    SqlDataReader reader;
                    reader = sqlCommand.ExecuteReader();
                    

                    if (reader.HasRows)
                    {
                        reader.Read();
                        roll.Text = reader.GetSqlString(0).ToString();
                        name.Text = reader.GetSqlString(1).ToString();
                        assignment1.Text = reader.GetDouble(2).ToString();
                        assignment2.Text = reader.GetDouble(3).ToString();
                        quiz1.Text = reader.GetDouble(4).ToString();
                        quiz2.Text = reader.GetDouble(5).ToString();
                        quiz3.Text = reader.GetDouble(6).ToString();
                        quiz4.Text = reader.GetDouble(7).ToString();
                        quiz5.Text = reader.GetDouble(8).ToString();
                        mid.Text = reader.GetDouble(9).ToString();
                    }
                    else
                    {
                        //
                    }
                    con.Close();
                }
            }
        }
        protected void Save_Click(object sender, EventArgs e)
        {
            try
            {
                double a1 = double.Parse(assignment1.Text.ToString());
                double a2 = double.Parse(assignment2.Text.ToString());
                double q1 = double.Parse(quiz1.Text.ToString());
                double q2 = double.Parse(quiz2.Text.ToString());
                double q3 = double.Parse(quiz3.Text.ToString());
                double q4 = double.Parse(quiz4.Text.ToString());
                double q5 = double.Parse(quiz5.Text.ToString());
                double mids = double.Parse(mid.Text.ToString());

                if (a1 < 0 || a1 > 5 || a2 < 0 || a2 > 5 || q1 < 0 || q1 > 5 || q2 < 0 || q2 > 5 || q3 < 0 || q3 > 5 || q4 < 0 || q4 > 5 || q5 < 0 || q5 > 5)
                {
                    throw new Exception();
                }
                else
                {
                    string roll_no = Request.QueryString["roll_no"].ToString();
                    string course_id = Request.QueryString["course_id"].ToString();
                    DBHelper db = new DBHelper();
                    db.UpdateMarks(roll_no, course_id, a1, a2, q1, q2, q3, q4, q5, mids);
                    error.Text = "Updated Succesfully";
                    Response.AppendHeader("Refresh", "2;url=CourseStudents.aspx?course_id=" + course_id);
                }
            }
            catch (Exception ex)
            {
                error.Text = "Error. please kill yourself";
            }
        }
    }
}