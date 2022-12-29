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
using System.Globalization;

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

            SqlCommand cmd1 = new SqlCommand($"select S.ID, S.name, S.location, S.capacity, S.status from Stadium S inner join StadiumManager SM " +
                $"on SM.stadium_ID=S.ID where SM.username='{Session["user"]}'", conn);
            SqlDataReader rdr = cmd1.ExecuteReader();
            GridView1.DataSource = rdr;
            GridView1.DataBind();
            rdr.Close();

            //String username = TextBox4.Text;
            SqlCommand cmd2 = new SqlCommand($"select * from dbo.allPending('{Session["user"]}')", conn);
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
            //String starttime = TextBox3.Text;
            //DateTime starttime= DateTime.ParseExact(TextBox3.Text, "yyyy/MM/dd HH:mm:ss", new CultureInfo("en-US"));
            if (hostname == "" || guestname == "")
                MessageBox.Show("one of the fields is empty!");
            else
            {
                try
                {
                    DateTime starttime = DateTime.Parse(TextBox3.Text);
                    SqlCommand clubs = new SqlCommand("SELECT * FROM allClubs", conn);
                    if (conn.State == ConnectionState.Closed)
                        conn.Open(); SqlDataReader rdr = clubs.ExecuteReader(CommandBehavior.CloseConnection);
                    bool hostClubFound = false;
                    while (rdr.Read())
                    {
                        String clubName = rdr.GetString(rdr.GetOrdinal("name"));
                        if (hostname == clubName)
                            hostClubFound = true;
                    }
                    rdr.Close();

                    if (hostClubFound)
                    {
                        SqlCommand clubRep = new SqlCommand($"SELECT * FROM ClubRepresentative CR inner join Club C on CR.club_ID=C.club_ID where C.name='{hostname}'", conn);
                        if (conn.State == ConnectionState.Closed)
                            conn.Open();
                        SqlDataReader rdr2 = clubRep.ExecuteReader();
                        rdr2.Read();
                        String RepName = rdr2.GetString(rdr2.GetOrdinal("name"));
                        rdr2.Close();
                        SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.allPendingRequests('{Session["user"]}')", conn);
                        SqlDataReader rdr3 = cmd.ExecuteReader();
                        bool requestfound = false;
                        while (rdr3.Read())
                        {
                            String repName = rdr3.GetString(rdr3.GetOrdinal("repName"));
                            String guest = rdr3.GetString(rdr3.GetOrdinal("guest_name"));
                            DateTime Time = rdr3.GetDateTime(rdr3.GetOrdinal("start_time"));
                            Response.Write(Time + "  " + starttime + "  " + repName + "  " + RepName);

                            if (RepName == repName && guest == guestname)
                            {
                                if (DateTime.Compare(starttime, Time) == 0)
                                {
                                    Response.Write("fergdbgdfbhgf");
                                    requestfound = true;
                                }
                            }
                        }
                        rdr3.Close();
                        if (requestfound)
                        {
                            SqlCommand acceptproc = new SqlCommand("acceptRequest", conn);
                            acceptproc.CommandType = CommandType.StoredProcedure;

                            acceptproc.Parameters.Add(new SqlParameter("@host_name", hostname));
                            acceptproc.Parameters.Add(new SqlParameter("@guest_name", guestname));
                            acceptproc.Parameters.Add(new SqlParameter("@start_time", starttime));
                            acceptproc.Parameters.Add(new SqlParameter("@username", Session["user"]));
                            acceptproc.ExecuteNonQuery();
                            MessageBox.Show("the request accepted successfully");
                            conn.Close();
                        }
                        else
                        {
                            MessageBox.Show("invalid request");
                        }
                    }
                    else
                    {
                        MessageBox.Show("invalid host club");
                    }
                    
                }
                catch (FormatException)
                {
                    MessageBox.Show("invalid  format");

                }
            }
        }

        protected void Reject_Request(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Sports_Platform_DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            conn.Open();

            String hostname = TextBox1.Text;
            String guestname = TextBox2.Text;
            //String starttime = TextBox3.Text;
            if (hostname == "" || guestname == "")
                MessageBox.Show("one of the fields is empty!");
            else
            {
                try
                {
                    DateTime starttime = DateTime.Parse(TextBox3.Text);
                    if (hostname == "" || guestname == "" || starttime == null)
                        MessageBox.Show("one of the fields is empty!");
                    else
                    {
                        SqlCommand clubs = new SqlCommand("SELECT * FROM allClubs", conn);

                        if (conn.State == ConnectionState.Closed)
                            conn.Open();
                        SqlDataReader rdr = clubs.ExecuteReader(CommandBehavior.CloseConnection);
                        bool hostClubFound = false;
                        while (rdr.Read())
                        {
                            String clubName = rdr.GetString(rdr.GetOrdinal("name"));
                            if (hostname == clubName)
                                hostClubFound = true;
                        }
                        rdr.Close();

                        if (hostClubFound)
                        {
                            SqlCommand clubRep = new SqlCommand($"SELECT * FROM ClubRepresentative CR inner join Club C on CR.club_ID=C.club_ID where C.name='{hostname}'", conn);
                            if (conn.State == ConnectionState.Closed)
                                conn.Open();
                            SqlDataReader rdr2 = clubRep.ExecuteReader(CommandBehavior.CloseConnection);
                            rdr2.Read();
                            String RepName = rdr2.GetString(rdr2.GetOrdinal("name"));
                            rdr2.Close();
                            SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.allPendingRequests('{Session["user"]}')", conn);
                            if (conn.State == ConnectionState.Closed)
                                conn.Open();
                            SqlDataReader rdr3 = cmd.ExecuteReader();
                            bool requestfound = false;
                            while (rdr3.Read())
                            {
                                String repName = rdr3.GetString(rdr3.GetOrdinal("repName"));
                                String guest = rdr3.GetString(rdr3.GetOrdinal("guest_name"));
                                DateTime Time = rdr3.GetDateTime(rdr3.GetOrdinal("start_time"));

                                if (RepName == repName && guest == guestname)
                                {
                                    if (DateTime.Compare(Time, starttime) == 0)
                                        requestfound = true;
                                }
                            }
                            rdr3.Close();
                            if (requestfound)
                            {
                                SqlCommand rejectproc = new SqlCommand("rejectRequest", conn);
                                rejectproc.CommandType = CommandType.StoredProcedure;
                                rejectproc.Parameters.Add(new SqlParameter("@host_name", hostname));
                                rejectproc.Parameters.Add(new SqlParameter("@guest_name", guestname));
                                rejectproc.Parameters.Add(new SqlParameter("@start_time", starttime));
                                rejectproc.Parameters.Add(new SqlParameter("@username", Session["user"]));
                                rejectproc.ExecuteNonQuery();
                                MessageBox.Show("the request rejected successfully");
                                conn.Close();
                            }
                            else
                            {
                                MessageBox.Show("invalid request");
                            }

                        }
                        else
                        {
                            MessageBox.Show("invalid host club");
                        }
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("invalid format");
                }
            }

        }
    }
}
