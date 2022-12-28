﻿using System;
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
    public partial class SAM_register_page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addSAM(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Sports_Platform_DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String name = sam_name.Text;
            String username = sam_username.Text;
            String password = sam_password.Text;
            if (name == "" || username == "" || password == "")
                MessageBox.Show("Please Fill All Fields!");
            else
            {
                SqlCommand addSAM = new SqlCommand("addAssociationManager", conn);
                addSAM.CommandType = CommandType.StoredProcedure;
                addSAM.Parameters.Add(new SqlParameter("@name", name));
                addSAM.Parameters.Add(new SqlParameter("@username", username));
                addSAM.Parameters.Add(new SqlParameter("@password", password));
                conn.Open();
                addSAM.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Registered Successfully");
            }


        }
    }
}