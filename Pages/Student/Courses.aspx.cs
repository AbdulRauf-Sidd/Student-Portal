using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentPortal1._01.Pages.Student
{
    public partial class Courses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["roll_no"] != null)
                {
                    string roll = Session["roll_no"].ToString();
                    name.Text = Session["name"].ToString();
                    roll_no.Text = roll;
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT c.course_id, c.course_name, i.instructor_name AS course_instructor FROM Course c, Instructor i, Marks m WHERE m.roll_no = @roll_no AND m.course_id = c.course_id AND m.instructor_id = i.instructor_id", con);
                    cmd.Parameters.AddWithValue("roll_no", roll);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sqlDataAdapter.Fill(dt);
                    lvcourse.DataSource = dt;
                    lvcourse.DataBind();
                    con.Close();
                }
                else
                {
                    Response.Redirect("StudentLogin.aspx");
                }
            }

        }
    }
}