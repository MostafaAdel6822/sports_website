using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace sports_platform
{
    public partial class sports_association_manager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void add_match_btn_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Sports_Platform_DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String hostName = host_name_SAM_add.Text;
            String guestName = guest_name_SAM_add.Text;
            String startTime = start_time_SAM_add.Text;
            String endTime = end_time_SAM_add.Text;

            SqlCommand clubs = new SqlCommand("allClubs", conn);
            clubs.CommandType = CommandType.TableDirect;

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

            if (hostClubFound && guestClubFound)
            {
                SqlCommand addMatch = new SqlCommand("addNewMatch", conn);
                addMatch.CommandType = CommandType.StoredProcedure;

                addMatch.Parameters.Add(new SqlParameter("@host_name", hostName));
                addMatch.Parameters.Add(new SqlParameter("@guest_name", guestName));
                addMatch.Parameters.Add(new SqlParameter("@start_time", startTime));
                addMatch.Parameters.Add(new SqlParameter("@end_time", endTime));

                conn.Open();
                addMatch.ExecuteNonQuery();
                conn.Close();
            }
            else
                Response.Write("Incorrect Club name!");

        }

        protected void delete_match_btn_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Sports_Platform_DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String hostName = host_name_SAM_del.Text;
            String guestName = guest_name_SAM_del.Text;
            // String startTime = start_time_SAM_del.Text;
            // String endTime = end_time_SAM_del.Text;

            SqlCommand clubs = new SqlCommand("allClubs", conn);
            clubs.CommandType = CommandType.TableDirect;

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

            if (hostClubFound && guestClubFound)
            {
                SqlCommand deleteMatch = new SqlCommand("deleteMatch", conn);
                deleteMatch.CommandType = CommandType.StoredProcedure;

                deleteMatch.Parameters.Add(new SqlParameter("@host_name", hostName));
                deleteMatch.Parameters.Add(new SqlParameter("@guest_name", guestName));
                //removed 2 parameters for start and end time

                conn.Open();
                deleteMatch.ExecuteNonQuery();
                conn.Close();
            }
            else
                Response.Write("Incorrect Club name!");
        }
    }
}