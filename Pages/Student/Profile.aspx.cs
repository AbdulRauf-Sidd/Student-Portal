using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentPortal1._01.Pages.Student
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["roll_no"] == null)
                {
                    Response.Redirect("StudentLogin.aspx");
                }
                else
                {
                    string roll = Session["roll_no"].ToString();
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
                    con.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Student WHERE roll_no = @roll_no", con);
                    sqlCommand.Parameters.AddWithValue("roll_no", roll);
                    SqlDataReader reader;
                    reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        student_name.Text = reader.GetSqlString(1).ToString();
                        student_name2.Text = student_name.Text;
                        dep.Text = reader.GetSqlString(2).ToString();
                        sem.Text = reader.GetInt32(3).ToString();
                        sec.Text = reader.GetSqlString(4).ToString();
                    }
                    else
                    {
                        student_name.Text = "error 404";
                        Session["name"] = student_name.Text;
                    }
                    roll_no.Text = roll;
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            if (cpass.Text == null || newpass.Text == null)
            {
                if (newpass.Text == null)
                {
                    nepass.Text = "Please Enter New Password";
                }
                if (cpass.Text == null)
                {
                    cupass.Text = "Please Enter Current Password";
                }
            }
            else
            {

                string id = Session["roll_no"].ToString() + "@example.edu";
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
                con.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT password FROM Users WHERE id = @id AND password = @password AND clearance_level = 3", con);
                sqlCommand.Parameters.AddWithValue("id", id);
                sqlCommand.Parameters.AddWithValue("password", cpass.Text);
                SqlDataReader reader;
                reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    con.Close();
                    SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
                    con2.Open();
                    SqlCommand sqlCommand2 = new SqlCommand("UPDATE Users SET password = @pass WHERE id = @id", con2);
                    sqlCommand2.Parameters.AddWithValue("id", id);
                    sqlCommand2.Parameters.AddWithValue("pass", newpass.Text);
                    SqlDataReader reader2;
                    reader2 = sqlCommand2.ExecuteReader();
                    con2.Close();
                    label3.Text = "Successful";
                    Response.AppendHeader("Refresh", "1;url=Dashboard.aspx");
                }
                else
                {
                    label3.Text = "NO!!!!";
                }
            }
        }
    }
}