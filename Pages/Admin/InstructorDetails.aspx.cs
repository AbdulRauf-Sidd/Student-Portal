using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;

namespace StudentPortal1._01.Pages.Admin
{
    public partial class InstructorDetails : System.Web.UI.Page
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
                    string tid = Request.QueryString["id"].ToString();
                    string id = Session["aid"].ToString();
                    ID.Text = id;
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
                    con.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Instructor WHERE instructor_id = @id", con);
                    sqlCommand.Parameters.AddWithValue("id", tid);
                    SqlDataReader reader;
                    reader = sqlCommand.ExecuteReader();


                    if (reader.HasRows)
                    {
                        reader.Read();
                        tid2.Text = reader.GetSqlString(0).ToString();
                        name.Text = reader.GetSqlString(1).ToString();
                        address.Text = reader.GetSqlString(2).ToString();
                        phone.Text = reader.GetSqlString(3).ToString();
                    }
                    con.Close();
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            string roll = Request.QueryString["id"].ToString();
            string names = name.Text;
            string addresss = address.Text;
            string phoneno = phone.Text;
            try
            {
                int phones = int.Parse(phoneno);
            }
            catch (Exception ex)
            {
                pho.Text = "Only Digits allowed";
                return;
            }
            if (names.Length > 4)
            {
                if (!names.Any(char.IsDigit))
                {
                    DBHelper dBHelper = new DBHelper();
                    dBHelper.UpdateInstructor(roll, names, addresss, phoneno);
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
            db.DeleteInstructor(Request.QueryString["id"].ToString());
            label3.Text = "Table Updated";
            Response.AddHeader("Refresh", "1;Instructors.aspx");
        }

        protected void Courses_Click(object sender, EventArgs e)
        {

            Response.Redirect("InstructorCourses.aspx?id=" + Request.QueryString["id"].ToString());
        }
    
    }
}