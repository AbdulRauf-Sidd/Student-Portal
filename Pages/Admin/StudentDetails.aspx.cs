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
    public partial class StudentDetails : System.Web.UI.Page
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
                    string roll = Request.QueryString["roll_no"].ToString();
                    string id = Session["aid"].ToString();
                    ID.Text = id;
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
                    con.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Student WHERE roll_no = @roll_no", con);
                    sqlCommand.Parameters.AddWithValue("roll_no", roll);
                    SqlDataReader reader;
                    reader = sqlCommand.ExecuteReader();


                    if (reader.HasRows)
                    {
                        reader.Read();
                        roll_no.Text = reader.GetSqlString(0).ToString();
                        name.Text = reader.GetSqlString(1).ToString();
                        deplist.Text = reader.GetSqlString(2).ToString();
                        semesterlist.Text = reader.GetSqlInt32(3).ToString();
                        section.Text = reader.GetSqlString(4).ToString();
                    }
                    con.Close();
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            string roll = Request.QueryString["roll_no"].ToString();
            string names = name.Text;
            string dep = deplist.Text;
            string sec = section.Text;
            int sem = int.Parse(semesterlist.Text);
            if (names.Length > 4)
            {
                if (!names.Any(char.IsDigit))
                {
                    DBHelper dBHelper = new DBHelper();
                    dBHelper.UpdateStudent(roll, names, dep, sem, sec);
                    label3.Text = "Table Updated";
                }
                else
                {
                    label3.ForeColor = System.Drawing.Color.Red;
                    label3.Text = "Name Cannot contain any digits";
                }
            }
            else
            {
                label3.ForeColor = System.Drawing.Color.Red;
                label3.Text = "Name must contain more than 4 characters";
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            DBHelper db = new DBHelper();
            db.DeleteStudent(Request.QueryString["roll_no"].ToString());
            label3.Text = "Table Updated";
            Response.AddHeader("Refresh", "1;Students.aspx");
        }

        protected void Courses_Click(object sender, EventArgs e)
        {

            Response.Redirect("StudentCourse.aspx?roll_no=" + Request.QueryString["roll_no"].ToString());
        }
    }
}