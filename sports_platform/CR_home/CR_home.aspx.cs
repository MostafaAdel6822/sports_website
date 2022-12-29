using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Security.Cryptography;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Forms;

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
            string query = $"select * from Club C inner join ClubRepresentative CR " +
                $"on C.club_ID = CR.club_ID where CR.username='{Session["user"]}'";
            SqlCommand viewCLub = new SqlCommand(query, conn);
            SqlDataReader rdr = viewCLub.ExecuteReader();
            GridView1.DataSource = rdr;
            GridView1.DataBind();
            rdr.Close();

            string query2 = $"select * from upcomingMatchesOfClub('{Session["club"]}')";
            SqlCommand viewUpcomingMatches = new SqlCommand(query2, conn);
            SqlDataReader rdr2 = viewUpcomingMatches.ExecuteReader();
            GridView3.DataSource = rdr2;
            GridView3.DataBind();
            rdr2.Close();

            SqlCommand viewImage = new SqlCommand("getImage", conn);
            viewImage.CommandType = CommandType.StoredProcedure;
            int imageId = 1;
            viewImage.Parameters.Add(new SqlParameter("@id", imageId));
            byte[] imageValue = (byte[])viewImage.ExecuteScalar();
            string strBase64 = Convert.ToBase64String(imageValue);
            Image1.ImageUrl = "data:Image/png;base64," + strBase64;

            SoundPlayer sound = new SoundPlayer("C:\\Users\\Admin\\Desktop\\GUC\\Semester 5\\Database1(CSEN501)\\milestone3\\sports_platform\\sports_platform\\CR_home\\barcaAnthem.wav");
            //sound.Play();

            conn.Close();
        }

        protected void Send_Request(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Sports_Platform_DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String stadiumName = Stadium.Text;
            //String startTime = StartTime.Text;
            if (stadiumName == "")
                MessageBox.Show("Please Fill All Fields!");
            else
            {
                try
                {

                    DateTime startTime = DateTime.ParseExact(StartTime.Text, "yyyy-MM-dd HH:mm:ss", new CultureInfo("en-US"));
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    //Validate Stadium
                    SqlCommand stadiums = new SqlCommand("SELECT * FROM allStadiums", conn);
                    SqlDataReader rdr2 = stadiums.ExecuteReader(CommandBehavior.CloseConnection);
                    bool stadiumFound = false;
                    while (rdr2.Read())
                    {
                        String stadium = rdr2.GetString(rdr2.GetOrdinal("name"));
                        if (stadium == stadiumName)
                            stadiumFound = true;
                    }
                    rdr2.Close();
                    //validate start_time
                    Boolean matchFound = false;
                    SqlCommand findMatch = new SqlCommand("select * from allMatches", conn);
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    SqlDataReader rdrMatch = findMatch.ExecuteReader();
                    while (rdrMatch.Read())
                    {
                        DateTime actual_time = rdrMatch.GetDateTime(rdrMatch.GetOrdinal("start_time"));
                        int flag = DateTime.Compare(actual_time, startTime);
                        if (flag == 0)
                            matchFound = true;
                    }
                    rdrMatch.Close();


                    if (stadiumFound && matchFound)
                    {
                        SqlCommand send_Host_Request = new SqlCommand("addHostRequest", conn);
                        send_Host_Request.CommandType = CommandType.StoredProcedure;
                        send_Host_Request.Parameters.Add(new SqlParameter("@clubName", "barca"));
                        send_Host_Request.Parameters.Add(new SqlParameter("@stadiumName", stadiumName));
                        send_Host_Request.Parameters.Add(new SqlParameter("@start_time", startTime));
                        if (conn.State == ConnectionState.Closed)
                            conn.Open();
                        send_Host_Request.ExecuteNonQuery();
                        conn.Close();
                        //Response.Write("Request Sent!");
                        MessageBox.Show("Request Sent Successfully!");
                    }
                    else
                    {
                        if (!stadiumFound)
                            MessageBox.Show("Invalid Stadium ");
                        if (!matchFound)
                            MessageBox.Show("Invalid Match ");



                    }
                }


                catch (FormatException)
                {
                    MessageBox.Show("Incorrect Format");
                }
            }
        }

        protected void View_Available_Stadiums(object sender, EventArgs e)
        {

            string connStr = WebConfigurationManager.ConnectionStrings["Sports_Platform_DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                DateTime search_time = DateTime.ParseExact(searchDate.Text, "yyyy/MM/dd", new CultureInfo("en-US"));
                //String search_time = searchDate.Text;
                if (search_time == null)
                    MessageBox.Show("Enter a Start Time!");
                else
                {
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
            catch (FormatException)
            {
                MessageBox.Show("Incorrect Format");
            }

        }
    }
}
