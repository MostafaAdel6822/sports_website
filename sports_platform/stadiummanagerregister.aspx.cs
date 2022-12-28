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
    public partial class registerpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Addition(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Sports_Platform_DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String name = TextBox1.Text;
            String username = TextBox2.Text;
            String pass = TextBox3.Text;
            String stadiumname = TextBox4.Text;

            if (name == "" || username == "" || pass == "" || stadiumname =="")
                MessageBox.Show("one of the fields is empty!");
            else {
                SqlCommand stadiums = new SqlCommand("SELECT * FROM allStadiums", conn);

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlDataReader rdr = stadiums.ExecuteReader(CommandBehavior.CloseConnection);
                bool stadiumFound = false;
                while (rdr.Read())
                {
                    String stadium = rdr.GetString(rdr.GetOrdinal("name"));
                    if (stadium == stadiumname)
                        stadiumFound = true;
                }
                rdr.Close();
                
                if (stadiumFound) {
                    SqlCommand cmd = new SqlCommand("addStadiumManager", conn);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add(new SqlParameter("@stadiumManagerName", name));
                    cmd.Parameters.Add(new SqlParameter("@stadiumManagerUserName", username));
                    cmd.Parameters.Add(new SqlParameter("@stadiumManagerPassword", pass));
                    cmd.Parameters.Add(new SqlParameter("@stadiumName", stadiumname));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("The Stadium Manager added successfully ");

                }
                else
                {
                    MessageBox.Show("stadium does not exist");
                }
              
            }
        }
    }
}