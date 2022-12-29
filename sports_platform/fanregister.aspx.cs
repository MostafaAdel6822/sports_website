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
    public partial class fanregister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Addition(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Sports_Platform_DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            if (conn.State == ConnectionState.Closed)
                conn.Open();
            String name = TextBox1.Text;
            String username = TextBox2.Text;
            string pass = TextBox3.Text;
            String phone = TextBox4.Text;
            String ID = TextBox5.Text;
            String Add = TextBox6.Text; 
            String birthdate = TextBox7.Text;
        
            try
            {
                int phonenum = Int16.Parse(phone);
                
                if (name == "" || username == "" || pass == "" || phone == "" || ID == "" || Add == "" || birthdate == "")
                    MessageBox.Show("one of the fields is empty!");
                else 
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    SqlCommand userCmd = new SqlCommand("SELECT * FROM SystemUser", conn);
                    SqlDataReader userRdr = userCmd.ExecuteReader();
                    bool usernameFound = false;
                    while (userRdr.Read())
                    {
                        String current_username = userRdr.GetString(userRdr.GetOrdinal("username"));
                        if (username == current_username)
                            usernameFound = true;

                    }
                    userRdr.Close();
                    if (!usernameFound) {
                        if (conn.State == ConnectionState.Closed)
                            conn.Open();
                        SqlCommand cmd = new SqlCommand("addFan", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@name", name));
                        cmd.Parameters.Add(new SqlParameter("@username", username));
                        cmd.Parameters.Add(new SqlParameter("@password", pass));
                        cmd.Parameters.Add(new SqlParameter("@national_id", ID));
                        cmd.Parameters.Add(new SqlParameter("@birth_date", birthdate));
                        cmd.Parameters.Add(new SqlParameter("@address", Add));
                        cmd.Parameters.Add(new SqlParameter("@phone", phonenum));

                        
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("The Fan added successfully ");
                    }
                    else
                    {
                        MessageBox.Show("this username already exists");
                    }  
                }
            }
            catch
            {
                MessageBox.Show("invalid input");
            }
           

            /*Response.Redirect("indexpage");*/
        }
    }
}