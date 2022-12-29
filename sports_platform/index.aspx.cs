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
    public partial class index : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Sports_Platform_DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string currentUserUsername = username.Text;
            string currentUserPassword = password.Text;

            Session["user"]= currentUserUsername;
            Session["password"]= currentUserPassword;

            if (conn.State == ConnectionState.Closed)
                conn.Open();

            SqlCommand pwCmd = new SqlCommand($"SELECT password FROM SystemUser WHERE username = '{currentUserUsername}'", conn);
            SqlCommand sysAdmin = new SqlCommand("SELECT * FROM SystemAdmin", conn);
            SqlCommand SAM = new SqlCommand("SELECT * FROM SportsAssociationManager", conn);
            SqlCommand SM = new SqlCommand("SELECT * FROM StadiumManager", conn);
            SqlCommand CR = new SqlCommand("SELECT * FROM ClubRepresentative", conn);
            SqlCommand fan = new SqlCommand("SELECT * FROM Fan", conn);

            bool pwCorrect = false;
            bool isSysAdmin = false;
            bool isSAM = false;
            bool isSM = false;
            bool isCR = false;
            bool isFan = false;

            SqlDataReader rdr = sysAdmin.ExecuteReader();
            while (rdr.Read())
            {
                String username = rdr.GetString(rdr.GetOrdinal("username"));
                if (username == currentUserUsername)
                {
                    isSysAdmin = true;
                    rdr.Close();
                    SqlDataReader rdrPW = pwCmd.ExecuteReader();
                    rdrPW.Read();
                    String actualPW = rdrPW.GetString(rdrPW.GetOrdinal("password"));
                    if (actualPW == currentUserPassword)
                        pwCorrect = true;
                    rdrPW.Close();
                    break;
                }
            }
            rdr.Close();

            SqlDataReader rdr2 = SAM.ExecuteReader();
            while (rdr2.Read())
            {
                String username = rdr2.GetString(rdr2.GetOrdinal("username"));
                if (username == currentUserUsername)
                {
                    isSAM = true;
                    rdr2.Close();
                    SqlDataReader rdrPW = pwCmd.ExecuteReader();
                    rdrPW.Read();
                    String actualPW = rdrPW.GetString(rdrPW.GetOrdinal("password"));
                    if (actualPW == currentUserPassword)
                        pwCorrect = true;
                    rdrPW.Close();
                    break;
                }
            }
            rdr2.Close();

            SqlDataReader rdr3 = SM.ExecuteReader();
            while (rdr3.Read())
            {
                String username = rdr3.GetString(rdr3.GetOrdinal("username"));
                if (username == currentUserUsername)
                {
                    isSM = true;
                    rdr3.Close();
                    SqlDataReader rdrPW = pwCmd.ExecuteReader();
                    rdrPW.Read();
                    String actualPW = rdrPW.GetString(rdrPW.GetOrdinal("password"));
                    if (actualPW == currentUserPassword)
                        pwCorrect = true;
                    rdrPW.Close();
                    break;
                }
            }
            rdr3.Close();

            SqlDataReader rdr4 = CR.ExecuteReader();
            while (rdr4.Read())
            {
                String username = rdr4.GetString(rdr4.GetOrdinal("username"));
                if (username == currentUserUsername)
                {
                    isCR = true;
                    rdr4.Close();
                    SqlDataReader rdrPW = pwCmd.ExecuteReader();
                    rdrPW.Read();
                    String actualPW = rdrPW.GetString(rdrPW.GetOrdinal("password"));
                    if (actualPW == currentUserPassword)
                        pwCorrect = true;
                    rdrPW.Close();
                    break;
                }
            }
            rdr4.Close();

            SqlDataReader rdr5 = fan.ExecuteReader();
            while (rdr5.Read())
            {
                String username = rdr5.GetString(rdr5.GetOrdinal("username"));
                if (username == currentUserUsername)
                {
                    isFan = true;
                    rdr5.Close();
                    SqlDataReader rdrPW = pwCmd.ExecuteReader();
                    rdrPW.Read();
                    String actualPW = rdrPW.GetString(rdrPW.GetOrdinal("password"));
                    if (actualPW == currentUserPassword)
                        pwCorrect = true;
                    rdrPW.Close();
                    break;
                }

            }
            rdr5.Close();

            if (isSysAdmin && pwCorrect)
            {
                //TODO

                Response.Redirect("system-admin.aspx");
            }
            else if (isSAM && pwCorrect)
            {
                //TODO
                Response.Redirect("sports-association-manager.aspx");
            }
            else if (isSM && pwCorrect)
            {
                Response.Redirect("StadiumManager.aspx");
            }
            else if (isCR && pwCorrect)
            {
                SqlCommand clubNamee = new SqlCommand($"SELECT C.name FROM Club C inner join ClubRepresentative CR on C.club_ID = CR.club_ID " +
                    $"WHERE username = '{currentUserUsername}'", conn);
                SqlDataReader rdrClub = clubNamee.ExecuteReader();
                rdrClub.Read();
                Session["club"] = rdrClub.GetString(rdrClub.GetOrdinal("name"));
                rdrClub.Close();
                Response.Redirect("CR_home.aspx");
            }
            else if (isFan && pwCorrect)    
            {
                SqlCommand natID_cmd = new SqlCommand($"SELECT national_ID FROM Fan " +
                    $"WHERE username = '{currentUserUsername}'", conn);
                SqlDataReader rdrNatID = natID_cmd.ExecuteReader();
                rdrNatID.Read();
                Session["nationalID"] = rdrNatID.GetString(rdrNatID.GetOrdinal("national_ID"));
                rdrNatID.Close();
                
                Response.Redirect("fan.aspx");
            }
            else
                MessageBox.Show("invalid credentials!");

            conn.Close();
        }

        protected void register_SAM_Click(object sender, EventArgs e)
        {
            Response.Redirect("SAM_register_page.aspx");
        }

        protected void register_CR_Click(object sender, EventArgs e)
        {
            Response.Redirect("CR_register_page.aspx");
        }

        protected void register_SM_Click(object sender, EventArgs e)
        {
            Response.Redirect("stadiummanagerregister.aspx");

        }

        protected void register_fan_Click(object sender, EventArgs e)
        {
            Response.Redirect("fanregister.aspx");

        }
    }

    
}