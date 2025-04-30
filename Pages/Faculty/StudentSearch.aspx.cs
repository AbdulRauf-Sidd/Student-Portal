using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentPortal1._01.Pages.Faculty
{
    public partial class StudentSearch : System.Web.UI.Page
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
                    ID.Text = id;
                    faculty_name.Text = Session["fname"].ToString();
                }
            }
        }


        protected void Search_Click(object sender, EventArgs e)
        {
            if (search_box.Text == null)
            {
                return;
            }
            else
            {
                string query = search_box.Text.ToString().ToLower();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
                con.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT s.roll_no, s.student_name, s.section FROM Student s, Marks m WHERE LOWER(s.roll_no) = @roll_no AND s.roll_no = m.roll_no AND m.instructor_id = @id", con);
                sqlCommand.Parameters.AddWithValue("roll_no", query);
                sqlCommand.Parameters.AddWithValue("id", Session["id"].ToString());
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                students.DataSource = dt;
                students.DataBind();
                con.Close();
            }
        }


        protected void Student_Click(object sender, CommandEventArgs e)
        {
            Response.Redirect("StudentInfo.aspx?roll_no=" + e.CommandArgument.ToString()) ; //TODO
        }
    }
}