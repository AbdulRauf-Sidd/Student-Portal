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
    public partial class StudentCourse : System.Web.UI.Page
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
                    string roll = Request.QueryString["roll_no"].ToString();
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
                    con.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT ci.roll_no, ci.course_id, c.course_name FROM Student_Course ci, Course c WHERE c.course_id = ci.course_id AND ci.roll_no = @roll_no", con);
                    sqlCommand.Parameters.AddWithValue("roll_no", roll);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    DataTable dt = new DataTable();
                    sqlDataAdapter.Fill(dt);
                    lvcourse.DataSource = dt;
                    lvcourse.DataBind();
                    con.Close();
                    SqlConnection con3 = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
                    con3.Open();
                    SqlCommand sqlCommand3 = new SqlCommand("SELECT ci.roll_no, ci.course_id, c.course_name FROM Student_Course ci, Course c WHERE c.course_id = ci.course_id AND ci.roll_no = @roll_no", con3);
                    sqlCommand3.Parameters.AddWithValue("roll_no", roll);
                    SqlDataReader reader = sqlCommand3.ExecuteReader();
                    SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
                    con2.Open();
                    SqlCommand sqlCommand2 = new SqlCommand("SELECT * FROM Course", con2);
                    SqlDataReader reader2 = sqlCommand2.ExecuteReader();

                    Dictionary<string, string> coursedic = new Dictionary<string, string>();
                    List<string> courseidlist = new List<string>();
                    List<string> coursenamelist = new List<string>();
                    courses.Items.Clear();

                    while (reader2.Read())
                    {
                        coursedic.Add(reader2.GetSqlString(0).ToString(), reader2.GetSqlString(1).ToString());
                    }

                    while (reader.Read())
                    {
                        courseidlist.Add(reader.GetSqlString(1).ToString());
                        coursenamelist.Add(reader.GetSqlString(2).ToString());
                    }

                    foreach (var course in coursedic) 
                    {
                        if (!courseidlist.Contains(course.Key)) {
                            courses.Items.Add(course.Value);
                        }
                    }
                    con2.Close();
                    con3.Close();
                }
            }
        }

        protected void Delete_Click(object sender, CommandEventArgs e)
        {
            string roll = Request.QueryString["roll_no"].ToString();
            DBHelper dBHelper = new DBHelper();
            dBHelper.DeleteStudentCourse(roll, e.CommandArgument.ToString());
            Response.Redirect("StudentCourse.aspx?roll_no=" + roll);
        }

        protected void Add_Click(object sender, EventArgs e) 
        {
            SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            con2.Open();
            SqlCommand sqlCommand2 = new SqlCommand("SELECT * FROM Course", con2);
            SqlDataReader reader2 = sqlCommand2.ExecuteReader();
            Dictionary<string, string> coursedic = new Dictionary<string, string>();
            while (reader2.Read())
            {
                coursedic.Add(reader2.GetSqlString(1).ToString(), reader2.GetSqlString(0).ToString());
            }
            con2.Close();
            string roll = Request.QueryString["roll_no"].ToString();
            DBHelper dBHelper = new DBHelper();
            string id = coursedic[courses.Text.ToString()];
            dBHelper.AddStudentCourse(roll, id);
            Response.Redirect("StudentCourse.aspx?roll_no=" + roll);
        }
    }
}