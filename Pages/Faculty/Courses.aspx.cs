using StudentPortal1._01.Pages.Student;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentPortal1._01.Pages.Faculty
{
    public partial class Courses : System.Web.UI.Page
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
                    string id = Session["id"].ToString();
                    faculty_name.Text = Session["fname"].ToString();
                    ID.Text = id;
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
                    con.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT ci.course_id, c.course_name, COUNT(m.roll_no) AS no_students FROM Course_Instructor ci, Marks m, Course c WHERE ci.instructor_id = @id AND m.instructor_id = ci.instructor_id AND c.course_id = ci.course_id AND m.course_id = c.course_id AND m.instructor_id = ci.instructor_id GROUP BY ci.course_id, c.course_name", con);
                    sqlCommand.Parameters.AddWithValue("id", id);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    DataTable dt = new DataTable();
                    sqlDataAdapter.Fill(dt);
                    lvcourse.DataSource = dt;
                    lvcourse.DataBind();
                    con.Close();

                }
            }
        }

        protected void ListStudents_Click(object sender, CommandEventArgs e)
        {
            Response.Redirect("CourseStudents.aspx?course_id=" + e.CommandArgument.ToString());
        }
    }
}