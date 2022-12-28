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
            SqlCommand addCR = new SqlCommand("addRepresentative", conn);
            addCR.CommandType = CommandType.StoredProcedure;
            addCR.Parameters.Add(new SqlParameter("@representative_name", name));
            addCR.Parameters.Add(new SqlParameter("@representative_username", username));
            addCR.Parameters.Add(new SqlParameter("@representative_password", password));
            addCR.Parameters.Add(new SqlParameter("@represented_club_name", club_name));
            conn.Open();
            addCR.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Registered Successfully");
        }
    }
}