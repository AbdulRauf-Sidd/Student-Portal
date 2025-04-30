using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentPortal1._01.Pages.Admin
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["aid"] = null;
            Session["aname"] = null;
        }

        protected void Login(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Users WHERE id = @id AND password = @password AND clearance_level = 1", con);
            sqlCommand.Parameters.AddWithValue("id", email.Text.ToString());
            sqlCommand.Parameters.AddWithValue("password", password2.Text.ToString());
            SqlDataReader reader;
            reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                Session["aid"] = email.Text.ToString().Substring(0, email.Text.ToString().IndexOf("@"));
                Label.ForeColor = System.Drawing.Color.Green;
                Label.Text = "Logging in...";
                Response.AppendHeader("Refresh", "1;Dashboard.aspx");
            }
            else
            {
                Label.ForeColor = System.Drawing.Color.Red;
                Label.Text = "Invalid username or password";
            }
        }
    }
}