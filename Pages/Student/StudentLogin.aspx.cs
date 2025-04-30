using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentPortal1._01.Pages
{
    public partial class StudentLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login(object sender, EventArgs e)
        {

            /*SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT password FROM Users WHERE id = " + email.ToString() + " AND clearance_level = 3", con);
            SqlDataReader sqlData = cmd.ExecuteReader();*/

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Users WHERE id = @id AND password = @password AND clearance_level = 3", con);
            sqlCommand.Parameters.AddWithValue("id", email.Text.ToString());
            sqlCommand.Parameters.AddWithValue("password", password2.Text.ToString());
            SqlDataReader reader;
            reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                Session["roll_no"] = email.Text.ToString().Substring(0, email.Text.ToString().IndexOf("@"));
                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                Label.Text = "Invalid username or password";
            }


           /* SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Course", con);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            ListView2.DataSource = dt;
            ListView2.DataBind();
            con.Close();*/

            
        }
    }
}