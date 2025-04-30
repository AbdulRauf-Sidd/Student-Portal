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
    public partial class EditProfile : System.Web.UI.Page
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
                    con.Close();
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            if (faculty_name2.Text == null || address.Text == null || phone.Text == null) 
            {
                error.Text = "Please fill all details";
            }
            else
            {
                string name = faculty_name2.Text.ToString();
                string add = address.Text.ToString();
                string ph = phone.Text.ToString();
                string id = Session["id"].ToString();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
                con.Open();
                SqlCommand sqlCommand = new SqlCommand("UPDATE Instructor SET instructor_name = @name, address = @add, phone_no = @ph WHERE instructor_id = @id", con);
                sqlCommand.Parameters.AddWithValue("id", id);
                sqlCommand.Parameters.AddWithValue("name", name);
                sqlCommand.Parameters.AddWithValue("add", add);
                sqlCommand.Parameters.AddWithValue("ph", ph);
                SqlDataReader reader;
                reader = sqlCommand.ExecuteReader();
                error2.Text = "Details updated successfully";
                Response.AppendHeader("Refresh", "1;url=Dashboard.aspx");
            }
        }
    }
}