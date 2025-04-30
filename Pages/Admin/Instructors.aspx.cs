using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentPortal1._01.Pages.Admin
{
    public partial class Instructors : System.Web.UI.Page
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
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
                    con.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Instructor", con);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    DataTable dt = new DataTable();
                    sqlDataAdapter.Fill(dt);
                    lvstudent.DataSource = dt;
                    lvstudent.DataBind();
                    con.Close();
                }
            }
        }

        protected void Details_Click(object sender, CommandEventArgs e)
        {
            Response.Redirect("InstructorDetails.aspx?id=" + e.CommandArgument.ToString());
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Instructor WHERE instructor_id = @id", con);
            sqlCommand.Parameters.AddWithValue("id", search_box.Text.ToString());
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            lvstudent.DataSource = dt;
            lvstudent.DataBind();
            con.Close();
        }
    }
}