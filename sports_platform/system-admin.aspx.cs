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
    public partial class system_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void add_club_SA_btn_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Sports_Platform_DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            
            string clubName = club_name_SA_add.Text;
            string clubLocation = club_location_SA_add.Text;

            if (clubName == "" || clubLocation == "")
                MessageBox.Show("one of the fields is empty!");
            else
            {
                SqlCommand addClub = new SqlCommand("addClub", conn);
                addClub.CommandType = CommandType.StoredProcedure;
                addClub.Parameters.Add(new SqlParameter("@club_name", clubName));
                addClub.Parameters.Add(new SqlParameter("@clubLocation", clubLocation));

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                addClub.ExecuteNonQuery();
                conn.Close();
            }
        }

        protected void delete_club_SA_btn_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Sports_Platform_DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string clubName = club_name_SA_del.Text;
            SqlCommand clubs = new SqlCommand("SELECT * FROM allClubs", conn);

            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlDataReader rdr = clubs.ExecuteReader(CommandBehavior.CloseConnection);
            bool clubFound = false;
            while (rdr.Read())
            {
                String club = rdr.GetString(rdr.GetOrdinal("name"));
                if (club == clubName)
                    clubFound = true;
            }
            rdr.Close();

            if (clubFound)
            {
                SqlCommand deleteClub = new SqlCommand("deleteClub", conn);
                deleteClub.CommandType = CommandType.StoredProcedure;
                deleteClub.Parameters.Add(new SqlParameter("@club_name", clubName));

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                deleteClub.ExecuteNonQuery();
                conn.Close();
            }
            else
                MessageBox.Show("this club does not exist!");
        }

        protected void add_stadium_SA_btn_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Sports_Platform_DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string stadiumName = stadium_name_SA_add.Text;
            string stadiumLocation = stadium_location_SA_add.Text;
            string stadiumCapacity = stadium_capacity_SA_add.Text;

            if (stadiumName == "" || stadiumLocation == "" || stadiumCapacity =="")
                MessageBox.Show("one of the fields is empty!");
            else
            {
                SqlCommand addStadium = new SqlCommand("addStadium", conn);
                addStadium.CommandType = CommandType.StoredProcedure;
                addStadium.Parameters.Add(new SqlParameter("@stadium_name", stadiumName));
                addStadium.Parameters.Add(new SqlParameter("@stadium_location", stadiumLocation));
                addStadium.Parameters.Add(new SqlParameter("@stadium_capacity", stadiumCapacity));

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                addStadium.ExecuteNonQuery();
                conn.Close();
            }

        }

        protected void delete_stadium_SA_btn_Click(object sender, EventArgs e)
        {
            //check stadium

            string connStr = WebConfigurationManager.ConnectionStrings["Sports_Platform_DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string stadiumName = stadium_name_SA_del.Text;
            SqlCommand stadiums = new SqlCommand("SELECT * FROM allStadiums", conn);

            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlDataReader rdr = stadiums.ExecuteReader(CommandBehavior.CloseConnection);
            bool stadiumFound = false;
            while (rdr.Read())
            {
                String stadium = rdr.GetString(rdr.GetOrdinal("name"));
                if (stadium == stadiumName)
                    stadiumFound = true;
            }
            rdr.Close();

            if (stadiumFound)
            {
                SqlCommand deleteStadium = new SqlCommand("deleteStadium", conn);
                deleteStadium.CommandType = CommandType.StoredProcedure;
                deleteStadium.Parameters.Add(new SqlParameter("@stadium_name", stadiumName));

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                deleteStadium.ExecuteNonQuery();
                conn.Close();
            }
            else
                MessageBox.Show("this stadium does not exist!");
        }

        protected void block_fan_SA_btn_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Sports_Platform_DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string nationalID = block_fan_SA.Text;
            
            SqlCommand natID_cmd = new SqlCommand("SELECT * FROM allFans", conn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlDataReader rdr = natID_cmd.ExecuteReader(CommandBehavior.CloseConnection);
            bool fanFound = false;
            while (rdr.Read())
            {
                String natID = rdr.GetString(rdr.GetOrdinal("national_ID"));
                if (natID == nationalID)
                    fanFound = true;
            }
            rdr.Close();

            if (fanFound)
            {
                SqlCommand blockFan = new SqlCommand("blockFan", conn);
                blockFan.CommandType = CommandType.StoredProcedure;
                blockFan.Parameters.Add(new SqlParameter("@fan_national_ID", nationalID));

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                blockFan.ExecuteNonQuery();
                conn.Close();
            }
            else
                MessageBox.Show("this fan does not exist!");
        }
    }
}