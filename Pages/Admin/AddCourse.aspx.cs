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
    public partial class AddCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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

        protected void Add_Click(object sender, EventArgs e)
        {
            if (cname.Text.Length > 1)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
                con.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT MAX(course_id) FROM Course", con);
                SqlDataReader reader;
                reader = sqlCommand.ExecuteReader();
                int oldid = 0;
                string newid = "c";
                if (reader.HasRows)
                {
                    reader.Read();
                    oldid = int.Parse(reader.GetSqlString(0).ToString().Substring(1)) + 1;
                }

                if (oldid < 9)
                {
                    newid += "0" + oldid;
                }
                else
                {
                    newid += oldid;
                }
                con.Close();
                SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
                con2.Open();
                SqlCommand sqlCommand2 = new SqlCommand("INSERT INTO Course VALUES (@id, @cname)", con2);
                sqlCommand2.Parameters.AddWithValue("@id", newid);
                sqlCommand2.Parameters.AddWithValue("@cname", cname.Text);
                SqlDataReader reader2;
                reader2 = sqlCommand2.ExecuteReader();
                con2.Close();
                label3.ForeColor = System.Drawing.Color.Green;
                label3.Text = "Course Added";
            }
            else
            {
                label3.ForeColor = System.Drawing.Color.Red;
                label3.Text = "Enter Course Name";
            }
        }
    }
}