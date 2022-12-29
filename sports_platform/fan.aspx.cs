using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace sports_platform
{
    public partial class fan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Sports_Platform_DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            SqlCommand cmd1 = new SqlCommand("SELECT * FROM allMatches", conn);
            SqlDataReader rdr = cmd1.ExecuteReader();
            GridView1.DataSource = rdr;
            GridView1.DataBind();
            rdr.Close();

            conn.Close();
        }

        protected void starting_time_Btn_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Sports_Platform_DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            string startingTime = starting_time.Text;
            if (startingTime == "")
                MessageBox.Show("please input a start time");
            else
            {
                string query = $"SELECT * FROM dbo.availableMatchesStartingFrom('{startingTime}')";
                SqlCommand viewMatches = new SqlCommand(query, conn);
                SqlDataReader rdr = viewMatches.ExecuteReader();
                GridView1.DataSource = rdr;
                try
                {
                    GridView1.DataBind();
                    rdr.Close();
                }
                catch (SqlException)
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    rdr.Close();
                    SqlCommand cmd1 = new SqlCommand("SELECT * FROM allMatches", conn);
                    SqlDataReader rdr2 = cmd1.ExecuteReader();
                    GridView1.DataSource = rdr2;
                    GridView1.DataBind();
                    rdr2.Close();
                    MessageBox.Show("incorrect time format");
                }
            }
            conn.Close();
        }

        protected void purchaseTicket_btn_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Sports_Platform_DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String nationalID = Session["nationalID"].ToString();
            String hostName = host_name_Fan_purchase.Text;
            String guestName = guest_name_Fan_purchase.Text;
            String startTime = start_time_Fan_purchase.Text;

            if (conn.State == ConnectionState.Closed)
                conn.Open();

            SqlCommand clubs = new SqlCommand("SELECT * FROM allClubs", conn);
            SqlDataReader rdr = clubs.ExecuteReader(CommandBehavior.CloseConnection);
            bool hostClubFound = false;
            bool guestClubFound = false;
            while (rdr.Read())
            {
                String clubName = rdr.GetString(rdr.GetOrdinal("name"));
                if (hostName == clubName)
                    hostClubFound = true;
                if (guestName == clubName)
                    guestClubFound = true;
            }
            rdr.Close();

            if (hostClubFound && guestClubFound)
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand purchaseTicket = new SqlCommand("purchaseTicket", conn);
                purchaseTicket.CommandType = CommandType.StoredProcedure;

                purchaseTicket.Parameters.Add(new SqlParameter("@national_id", nationalID));
                purchaseTicket.Parameters.Add(new SqlParameter("@host_club", hostName));
                purchaseTicket.Parameters.Add(new SqlParameter("@guest_club", guestName));
                purchaseTicket.Parameters.Add(new SqlParameter("@start_time", startTime));
                try
                {
                    purchaseTicket.ExecuteNonQuery();
                    MessageBox.Show("ticket purchased successfully");
                }
                catch (SqlException)
                {
                    MessageBox.Show("this ticket does not exist");
                }
                conn.Close();
            }
            else
                MessageBox.Show("invalid club name");


        }
    }
}