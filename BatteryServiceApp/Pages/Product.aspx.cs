using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BatteryServiceApp.Pages
{
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlProductType.DataSource = GetProductList();
            ddlProductType.DataTextField = "Text";
            ddlProductType.DataValueField = "Value";
            ddlProductType.DataBind();

        }

        public DataTable GetProductList()
        {
            string strcon = ConfigurationManager.ConnectionStrings["batteryAppConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);

            SqlCommand cmd = new SqlCommand("select  sProductType as Text,iProductTypeId as Value from dbo.ProductType");
            cmd.Connection = con;
            con.Open();

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();

            return ds.Tables[0];
        }

        protected void BtnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["batteryAppConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(strcon);

                SqlCommand cmd = new SqlCommand("Insert Into Product Values ('" + txtProducts.Text + "'," + ddlProductType.SelectedValue + ")");
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                txtProducts.Text = string.Empty;
                ddlProductType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;          }
            
        }
    }
}