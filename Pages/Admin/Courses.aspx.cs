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
    public partial class Courses : System.Web.UI.Page
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
                    string id = Session["aid"].ToString();
                    ID.Text = id;
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
                    con.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT ci.course_id, c.course_name, COUNT(m.roll_no) AS no_students FROM Course_Instructor ci, Marks m, Course c WHERE c.course_id = ci.course_id AND m.course_id = c.course_id GROUP BY ci.course_id, c.course_name", con);
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