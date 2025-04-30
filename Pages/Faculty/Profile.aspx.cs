using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentPortal1._01.Pages.Faculty
{
    public partial class Profile : System.Web.UI.Page
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
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
                    con.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT i.instructor_name, i.address, i.phone_no FROM Instructor i, Course_Instructor c WHERE i.instructor_id = @id AND c.instructor_id = @id GROUP BY i.instructor_name, i.phone_no, i.address", con);
                    sqlCommand.Parameters.AddWithValue("id", id);
                    SqlDataReader reader;
                    reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        faculty_name2.Text = reader.GetSqlString(0).ToString();
                        faculty_name.Text = faculty_name2.Text.ToString();
                        Session["fname"] = faculty_name2.Text;
                        address.Text = reader.GetSqlString(1).ToString();
                        phone.Text = reader.GetSqlString(2).ToString();
                    }
                    else
                    {
                        faculty_name.Text = "error 404";
                        Session["fname"] = faculty_name.Text;
                    }
                    ID.Text = id;
                    ID2.Text = id;
                }
            }
        }

        protected void Change_Password_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx");
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditProfile.aspx");
        }
    }
}