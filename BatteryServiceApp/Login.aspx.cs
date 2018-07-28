using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BatteryServiceApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public string HashedPassword(string Password)
        {
            SHA512Managed shaAlgo = new SHA512Managed();
            byte[] hashPswd1 = shaAlgo.ComputeHash(Encoding.UTF8.GetBytes(Password));
            byte[] hashPswd2 = shaAlgo.ComputeHash(hashPswd1);
            return BitConverter.ToString(hashPswd2).Replace("-",string.Empty);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string strcon = ConfigurationManager.ConnectionStrings["batteryAppConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);

            SqlCommand cmd = new SqlCommand("select 1 from UserCredentials where sUserName = @username and sPassword = @password;");
            cmd.Parameters.AddWithValue("@username", txtUsername.Text);
            cmd.Parameters.AddWithValue("@password", HashedPassword(txtPassword.Text));
            cmd.Connection = con;
            con.Open();

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                    Response.Redirect("Default.aspx");
                else
                    lblInvalidLogin.Visible = true;
            }
            else
                lblInvalidLogin.Visible = true;


            //txtUsername.Text = ;
        }
    }
}