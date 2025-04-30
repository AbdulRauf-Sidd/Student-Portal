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
    public partial class StudentInfo : System.Web.UI.Page
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
                    string id = Session["id"].ToString();
                    faculty_name.Text = Session["fname"].ToString();
                    ID.Text = id;
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
                    con.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT m.roll_no, m.course_id, c.course_name FROM Marks m, Course c WHERE m.roll_no = @roll_no AND m.course_id = c.course_id AND m.instructor_id = @id", con);
                    sqlCommand.Parameters.AddWithValue("roll_no", roll_no);
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

        protected void Marks_Click(object sender, CommandEventArgs e)
        {
            string roll_no = Request.QueryString["roll_no"].ToString();
            Response.Redirect("Marks.aspx?roll_no=" + roll_no + "&course_id=" + e.CommandArgument.ToString());
        }
    }

}