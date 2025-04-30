using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentPortal1._01.Pages.Admin
{
    public partial class CourseStudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["aid"] == null)
                {
                    Response.Redirect("AdminLogin.aspx");
                }
                else
                {
                    string course_id = Request.QueryString["course_id"].ToString();
                    string id = Session["aid"].ToString();
                    ID.Text = id;
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
                    con.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT m.roll_no, s.student_name, s.section, c.course_name FROM Marks m, Student s, Course c WHERE m.course_id = @course_id AND m.roll_no = s.roll_no AND m.course_id = c.course_id", con);
                    sqlCommand.Parameters.AddWithValue("course_id", course_id);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    DataTable dt = new DataTable();
                    sqlDataAdapter.Fill(dt);
                    lvcourse.DataSource = dt;
                    lvcourse.DataBind();
                    con.Close();
                }
            }
        }
    }
}