using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sports_platform.ClubRepresentative
{
    public partial class CR_home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Sports_Platform_DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            //string username = "lionel";
            string query = "select * from viewClubInfo('lionel')";
            SqlCommand viewCLub = new SqlCommand(query,conn);
            SqlDataReader rdr = viewCLub.ExecuteReader();
            GridView1.DataSource = rdr;
            GridView1.DataBind();
            rdr.Close();

            string query2 = "select * from upcomingMatchesOfClub('barca')";
            SqlCommand viewUpcomingMatches = new SqlCommand(query2, conn);
            SqlDataReader rdr2 = viewUpcomingMatches.ExecuteReader();
            GridView3.DataSource = rdr2;
            GridView3.DataBind();
            rdr2.Close();

            conn.Close();
        }

        protected void Send_Request(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Sports_Platform_DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String clubName = Club.Text;
            String stadiumName = Stadium.Text;
            DateTime startTime = DateTime.ParseExact(StartTime.Text, "yyyy/MM/dd", new CultureInfo("en-US"));
            

            SqlCommand send_Host_Request = new SqlCommand("addHostRequest", conn);
            send_Host_Request.CommandType = CommandType.StoredProcedure;
            send_Host_Request.Parameters.Add(new SqlParameter("@clubName", clubName));
            send_Host_Request.Parameters.Add(new SqlParameter("@stadiumName", stadiumName));
            send_Host_Request.Parameters.Add(new SqlParameter("@start_time", startTime));
            conn.Open();
            send_Host_Request.ExecuteNonQuery();
            conn.Close();
            Response.Write("Request Sent!");



        }

        protected void View_Available_Stadiums(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Sports_Platform_DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            DateTime search_time = DateTime.ParseExact(searchDate.Text, "yyyy/MM/dd", new CultureInfo("en-US"));
            string query2 = $"select * from dbo.viewAvailableStadiumsOn('{search_time}')";
            SqlCommand viewStadiums = new SqlCommand(query2, conn);
            conn.Open();    
            SqlDataReader rdr = viewStadiums.ExecuteReader();
            GridView2.DataSource = rdr;
            GridView2.DataBind();
            rdr.Close();
            conn.Close();



        }
    }
}