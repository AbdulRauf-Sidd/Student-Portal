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
    public partial class ChangePassword : System.Web.UI.Page
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
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            if (current_password.Text == null || new_password.Text == null)
            {
                if (new_password.Text == null)
                {
                    label2.Text = "Please Enter New Password";
                }
                if (current_password.Text == null)
                {
                    label1.Text = "Please Enter Current Password";
                }
            }
            else
            {

                string id = Session["aid"].ToString() + "@example.edu";
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
                con.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT password FROM Users WHERE id = @id AND password = @password AND clearance_level = 1", con);
                sqlCommand.Parameters.AddWithValue("id", id);
                sqlCommand.Parameters.AddWithValue("password", current_password.Text);
                SqlDataReader reader;
                reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    con.Close();
                    SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
                    con2.Open();
                    SqlCommand sqlCommand2 = new SqlCommand("UPDATE Users SET password = @pass WHERE id = @id", con2);
                    sqlCommand2.Parameters.AddWithValue("id", id);
                    sqlCommand2.Parameters.AddWithValue("pass", new_password.Text);
                    SqlDataReader reader2;
                    reader2 = sqlCommand2.ExecuteReader();
                    con2.Close();
                    label3.ForeColor = System.Drawing.Color.Green;
                    label3.Text = "Password Changed";
                    Response.AppendHeader("Refresh", "1;url=Dashboard.aspx");
                }
                else
                {
                    label3.ForeColor = System.Drawing.Color.Red;
                    label3.Text = "Incorrect Current Password";
                }
            }


        }
    }
}