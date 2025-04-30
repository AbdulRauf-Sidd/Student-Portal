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
    public partial class InstructorCourses : System.Web.UI.Page
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
                    string tid = Request.QueryString["id"];
                    ID.Text = id;
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
                    con.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT ci.instructor_id, ci.course_id, c.course_name FROM Course_Instructor ci, Course c WHERE c.course_id = ci.course_id AND ci.instructor_id = @id", con);
                    sqlCommand.Parameters.AddWithValue("id", tid);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    DataTable dt = new DataTable();
                    sqlDataAdapter.Fill(dt);
                    lvcourse.DataSource = dt;
                    lvcourse.DataBind();
                    con.Close();
                    SqlConnection con3 = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
                    con3.Open();
                    SqlCommand sqlCommand3 = new SqlCommand("SELECT ci.course_id, c.course_name FROM Course_Instructor ci, Course c WHERE c.course_id = ci.course_id AND ci.instructor_id = @id", con3);
                    sqlCommand3.Parameters.AddWithValue("id", tid);
                    SqlDataReader reader = sqlCommand3.ExecuteReader();
                    SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
                    con2.Open();
                    SqlCommand sqlCommand2 = new SqlCommand("SELECT * FROM Course", con2);
                    SqlDataReader reader2 = sqlCommand2.ExecuteReader();

                    Dictionary<string, string> coursedic = new Dictionary<string, string>();
                    List<string> courseidlist = new List<string>();
                    List<string> coursenamelist = new List<string>();
                    coursedrop.Items.Clear();

                    while (reader2.Read())
                    {
                        coursedic.Add(reader2.GetSqlString(0).ToString(), reader2.GetSqlString(1).ToString());
                    }

                    while (reader.Read())
                    {
                        courseidlist.Add(reader.GetSqlString(0).ToString());
                        coursenamelist.Add(reader.GetSqlString(1).ToString());
                    }

                    foreach (var course in coursedic)
                    {
                        if (!courseidlist.Contains(course.Key))
                        {
                            coursedrop.Items.Add(course.Value);
                            coursedrop.DataValueField = course.Key;
                        }
                    }
                    con2.Close();
                    con3.Close();
                }
            }
        }

        protected void Edit_Click(object sender, CommandEventArgs e)
        {
            Response.Redirect("EditInstructorCourse.aspx?course_id=" + e.CommandArgument.ToString() + "&id=" + Request.QueryString["id"].ToString());
        }

        protected void Delete_Click(object sender, CommandEventArgs e)
        {
            string id = Request.QueryString["id"].ToString();
            DBHelper dBHelper = new DBHelper();
            dBHelper.DeleteCourseInstructor(id, e.CommandArgument.ToString());
            Response.Redirect("InstructorCourses.aspx?id=" + Request.QueryString["id"].ToString());
        }

        protected void Add_Click(object sender, EventArgs e) 
        {
            SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            con2.Open();
            SqlCommand sqlCommand2 = new SqlCommand("SELECT * FROM Course", con2);
            SqlDataReader reader2 = sqlCommand2.ExecuteReader();

            Dictionary<string, string> coursedic = new Dictionary<string, string>();
            List<string> courseidlist = new List<string>();
            List<string> coursenamelist = new List<string>();
            while (reader2.Read())
            {
                coursedic.Add(reader2.GetSqlString(1).ToString(), reader2.GetSqlString(0).ToString());
            }
            con2.Close();
            string course_id = coursedic[coursedrop.Text.ToString()];

            Response.Redirect("AddInstructorCourse.aspx?course_id=" + course_id + "&id=" + Request.QueryString["id"].ToString());
        }
    }
}