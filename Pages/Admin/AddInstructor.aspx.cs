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
    public partial class AddInstructor : System.Web.UI.Page
    {
        public static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
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
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            string names = name.Text;
            string add = address.Text;
            string phon = phone.Text;
            bool check = IsDigitsOnly(phon);
            if (names.Length > 4)
            {
                if (!names.Any(char.IsDigit))
                {
                    if (add.Length > 4)
                    {
                        if (phon.Length > 5 && check) 
                        {
                            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
                            con.Open();
                            SqlCommand sqlCommand = new SqlCommand("SELECT MAX(instructor_id) FROM Instructor", con);
                            SqlDataReader reader;
                            reader = sqlCommand.ExecuteReader();
                            string oldid = "";
                            if (reader.HasRows)
                            {
                                reader.Read();
                                oldid = reader.GetSqlString(0).ToString();
                            }
                            con.Close();
                            int number = int.Parse(oldid.Substring(1)) + 1;
                            string newid;
                            if (number < 9)
                            {
                                newid = "t00" + number;
                            }
                            else if (number < 100)
                            {
                                newid = "t0" + number;
                            }
                            else
                            {
                                newid = "t" + number;
                            }

                            SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
                            con2.Open();
                            SqlCommand sqlCommand2 = new SqlCommand("INSERT INTO Instructor VALUES (@id, @name, @add, @phone)", con2);
                            sqlCommand2.Parameters.AddWithValue("id", newid);
                            sqlCommand2.Parameters.AddWithValue("name", names);
                            sqlCommand2.Parameters.AddWithValue("add", add);
                            sqlCommand2.Parameters.AddWithValue("phone", phon);
                            SqlDataReader reader2;
                            reader2 = sqlCommand2.ExecuteReader();
                            con2.Close();
                            label3.ForeColor = System.Drawing.Color.Green;
                            label3.Text = "Added Successfully";
                        }
                        else
                        {
                            pho.Text = "Incorrect Format";
                        }
                    }
                    else
                    {
                        addresslb.Text = "Address Must contain more than 4 characters";
                    }
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
    }
}