using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentPortal1._01.Pages.Admin
{
    public partial class EditInstructorCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["aid"] == null)
            {
                Response.Redirect("AdminLogin.aspx");
            }
            else
            {
                string course_id = Request.QueryString["course_id"].ToString();
                string id = Session["aid"].ToString();
                string tid = Request.QueryString["id"].ToString();
                ID.Text = id;
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
                con.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT sections FROM Course_Instructor WHERE course_id = @course_id AND instructor_id <> @id", con);
                sqlCommand.Parameters.AddWithValue("course_id", course_id);
                sqlCommand.Parameters.AddWithValue("id", tid);
                SqlDataReader reader;
                reader = sqlCommand.ExecuteReader();

                string sections = "";


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        sections += reader.GetSqlString(0).ToString();
                    }
                }
                con.Close();
                sections = sections.Replace(",", "");
                sections = sections.Replace(" ", "");

                string input = "ABCD";
                int n = input.Length;
                int powerSetCount = 1 << n;
                var powerset = new List<string>();
                List<string> availableSections = new List<string>();

                for (int setMask = 0; setMask < powerSetCount; setMask++)
                {
                    var s = new StringBuilder();
                    for (int i = 0; i < n; i++)
                    {
                        // Checking whether i'th element of input collection should go to the current subset.
                        if ((setMask & (1 << i)) > 0)
                        {
                            s.Append(input[i]);
                        }
                    }
                    powerset.Add(s.ToString());
                }

                List<string> list = new List<string>();
                for (int o = 0; o < sections.Length; o++)
                {
                    list.Add(sections[o].ToString());
                }

                if (sections.Length < 1)
                {
                    for (int i = 0; i < powerset.Count; i++)
                    {
                        secdrop.Items.Add(powerset[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < powerset.Count; i++)
                    {
                        bool found = false;
                        for (int j = 0; j < list.Count; j++)
                        {
                            if (powerset[i].Contains(sections[j]))
                            {
                                found = true;
                            }

                        }
                        if (!found)
                        {
                            availableSections.Add(powerset[i]);
                            secdrop.Items.Add(powerset[i]);
                        }
                    }
                }
            }
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            if (secdrop.Text.Length > 0)
            {
                string sect = "";
                for (int i = 0; i < secdrop.Text.Length; i++)
                {
                    if (i != secdrop.Text.Length - 1)
                    {
                        sect += secdrop.Text[i] + ", ";
                    }
                    else
                    {
                        sect += secdrop.Text[i];
                    }
                }

                string id = Request.QueryString["id"].ToString();
                string course_id = Request.QueryString["course_id"].ToString();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
                con.Open();
                SqlCommand sqlCommand = new SqlCommand("UPDATE Course_Instructor SET sections = @sec WHERE course_id = @course_id AND instructor_id = @id", con);
                sqlCommand.Parameters.AddWithValue("course_id", course_id);
                sqlCommand.Parameters.AddWithValue("id", id);
                sqlCommand.Parameters.AddWithValue("sec", sect);
                SqlDataReader reader;
                reader = sqlCommand.ExecuteReader();
                con.Close();
                label3.ForeColor = System.Drawing.Color.Green;
                label3.Text = "Updated Successfully";
                Response.AddHeader("Refresh", "1;Dashboard.aspx");
            }
            label3.Text = "section not selected";



        }
    }
}