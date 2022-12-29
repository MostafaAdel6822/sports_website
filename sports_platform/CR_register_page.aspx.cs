using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace sports_platform
{
    public partial class CR_register_page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addCR(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Sports_Platform_DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String name = cr_name.Text;
            String username = cr_username.Text;
            String password = cr_password.Text;
            String club_name = cr_cub_name.Text;
            if (name == "" || username == "" || password == "" || club_name == "")
            {
                MessageBox.Show("Please Fill all Fields!");
            }
            else
            {
              
                SqlCommand userCmd = new SqlCommand("SELECT * FROM SystemUser", conn);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlDataReader userRdr = userCmd.ExecuteReader();
                bool usernameFound = false;
                while (userRdr.Read())
                {
                    String current_username = userRdr.GetString(userRdr.GetOrdinal("username"));
                    if (username == current_username)
                        usernameFound = true;
                }
                userRdr.Close();
                if (!usernameFound)
                {

                    SqlCommand clubCmd = new SqlCommand("SELECT * FROM Club", conn);
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    SqlDataReader clubRdr = clubCmd.ExecuteReader();
                    bool clubExist = false;
                    while (clubRdr.Read())
                    {
                        String temp_name = clubRdr.GetString(clubRdr.GetOrdinal("name"));
                        if (club_name == temp_name)
                            clubExist = true;
                    }
                    clubRdr.Close();

                    if (clubExist)
                    {
                        SqlCommand addCR = new SqlCommand("addRepresentative", conn);
                        addCR.CommandType = CommandType.StoredProcedure;
                        addCR.Parameters.Add(new SqlParameter("@representative_name", name));
                        addCR.Parameters.Add(new SqlParameter("@representative_username", username));
                        addCR.Parameters.Add(new SqlParameter("@representative_password", password));
                        addCR.Parameters.Add(new SqlParameter("@represented_club_name", club_name));
                        if (conn.State == ConnectionState.Closed)
                            conn.Open();
                        addCR.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Registered Successfully");
                    }
                    else
                        MessageBox.Show("Invalid Club");

                }
                else
                    MessageBox.Show("Username Already Exists!");
                
                
            }
        }
    }
}