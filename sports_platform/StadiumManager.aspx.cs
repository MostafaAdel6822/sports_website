using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;

namespace sports_platform
{
    public partial class StadiumManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Sports_Platform_DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            if (conn.State == ConnectionState.Closed)
                conn.Open();

            SqlCommand cmd1 = new SqlCommand($"select * from Stadium S inner join StadiumManager SM " +
                $"on SM.stadium_ID=S.ID where SM.username='{Session["user"]}'", conn);
            SqlDataReader rdr = cmd1.ExecuteReader();
            GridView1.DataSource = rdr;
            GridView1.DataBind();
            rdr.Close();

            String username = TextBox4.Text;
            SqlCommand cmd2 = new SqlCommand($"select * from dbo.allPendingRequests('{Session["user"]}')", conn);

            SqlDataReader rdr2 = cmd2.ExecuteReader();
            GridView2.DataSource = rdr2;
            GridView2.DataBind();
            rdr2.Close();

            conn.Close();
        }
        protected void Accept_Request(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Sports_Platform_DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            conn.Open();

            String hostname = TextBox1.Text;
            String guestname = TextBox2.Text;
            String starttime = TextBox3.Text;
              
            if (hostname == "" || guestname == "" || starttime== "")
                MessageBox.Show("one of the fields is empty!");
            else
            {

                SqlCommand acceptproc = new SqlCommand("acceptRequest", conn);
                acceptproc.CommandType = CommandType.StoredProcedure;

                acceptproc.Parameters.Add(new SqlParameter("@host_name", hostname));
                acceptproc.Parameters.Add(new SqlParameter("@guest_name", guestname));
                acceptproc.Parameters.Add(new SqlParameter("@start_time", starttime));
                acceptproc.Parameters.Add(new SqlParameter("@username", Session["user"]));

                acceptproc.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("the request accepted successfully");
            }
        
        }

        protected void Reject_Request(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Sports_Platform_DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            conn.Open();

            String hostname = TextBox1.Text;
            String guestname = TextBox2.Text;
            String starttime = TextBox3.Text;
            

            if (hostname == "" || guestname == "" || starttime== "")
                MessageBox.Show("one of the fields is empty!");
            else
            {
                SqlCommand rejectproc = new SqlCommand("rejectRequest", conn);
                rejectproc.CommandType = CommandType.StoredProcedure;

                rejectproc.Parameters.Add(new SqlParameter("@host_name", hostname));
                rejectproc.Parameters.Add(new SqlParameter("@guest_name", guestname));
                rejectproc.Parameters.Add(new SqlParameter("@start_time", starttime));
                rejectproc.Parameters.Add(new SqlParameter("@username",Session["user"]));

                rejectproc.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("the request rejected successfully");
            }
        }
    }
}