using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics.Eventing.Reader;

namespace StudentPortal1._01.Pages.Admin
{
    public partial class AddStudent : System.Web.UI.Page
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
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            string names = name.Text;
            string dep = deplist.Text;
            string sec = section.Text;
            string sem = semesterlist.Text;
            if (names.Length > 4)
            {
                if (!names.Any(char.IsDigit))
                {
                    DBHelper dBHelper = new DBHelper();
                    dBHelper.AddStudent(names, dep, sem, sec);
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
    }
}