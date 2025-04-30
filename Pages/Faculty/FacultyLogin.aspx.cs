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
    public partial class FacultyLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["id"] = null;
            Session["fname"] = null;
        }

        protected void Login(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Users WHERE id = @id AND password = @password AND clearance_level = 2", con);
            sqlCommand.Parameters.AddWithValue("id", email.Text.ToString());
            sqlCommand.Parameters.AddWithValue("password", password2.Text.ToString());
            SqlDataReader reader;
            reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                Session["id"] = email.Text.ToString().Substring(0, email.Text.ToString().IndexOf("@"));
                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                Label.Text = "Invalid username or password";
            }
        }
    }
}