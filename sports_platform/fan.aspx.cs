using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            
            string query = String.Format("SELECT * FROM dbo.availableMatchesStartingFrom('{0}')", startingTime);
            SqlCommand viewMatches = new SqlCommand(query, conn);
            SqlDataReader rdr = viewMatches.ExecuteReader();
            GridView1.DataSource = rdr;
            GridView1.DataBind();
            rdr.Close();

            conn.Close();
        }

        protected void purchaseTicket_btn_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Sports_Platform_DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            //TODO: get national id using current user
            String nationalID = "";
            String hostName = host_name_Fan_purchase.Text;
            String guestName = guest_name_Fan_purchase.Text;
            String startTime = start_time_Fan_purchase.Text;

            if (conn.State == ConnectionState.Closed)
                conn.Open();

            SqlCommand clubs = new SqlCommand("SELECT * FROM allClubs", conn);

            conn.Open();
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
                SqlCommand purchaseTicket = new SqlCommand("addNewMatch", conn);
                purchaseTicket.CommandType = CommandType.StoredProcedure;

                purchaseTicket.Parameters.Add(new SqlParameter("@national_id", nationalID));
                purchaseTicket.Parameters.Add(new SqlParameter("@host_name", hostName));
                purchaseTicket.Parameters.Add(new SqlParameter("@guest_name", guestName));
                purchaseTicket.Parameters.Add(new SqlParameter("@start_time", startTime));

                purchaseTicket.ExecuteNonQuery();
                conn.Close();

                Response.Write("ticket purchased successfully ✔");

            }
            else
                Response.Write("invalid club name❌");


        }
    }
}