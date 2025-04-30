using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentPortal1._01.Pages
{
    public partial class Dashboard : System.Web.UI.Page
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
                        Session["name"] = student_name.Text;
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
        
    }
}