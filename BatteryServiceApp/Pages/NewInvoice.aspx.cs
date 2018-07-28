using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Invoice;

namespace BatteryServiceApp.Pages
{
    public partial class NewInvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlState.DataSource = GetStates();
                ddlState.DataBind();
            }
        }

        public DataTable GetStates()
        {
            string strcon = ConfigurationManager.ConnectionStrings["batteryAppConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);

            SqlCommand cmd = new SqlCommand("select  iStateId as Text,sState as Value from dbo.StatesOfIndia");
            cmd.Connection = con;
            con.Open();

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();

            return ds.Tables[0];
        }

        protected void btnAddInvoice_Click(object sender, EventArgs e)
        {
            Customer oCustomer = new Customer();
            oCustomer.sMobileNumber = txtMobileNumber.Text;
            oCustomer.sName = txtName.Text;
            oCustomer.sPinCode = txtPinCode.Text;
            oCustomer.sAddress = txtAddress.Text;
            oCustomer.iState = Convert.ToInt32(ddlState.SelectedItem.Value);

            InvoiceMapper objInvoice = new InvoiceMapper();
            if (objInvoice.IsCustomerExists(txtMobileNumber.Text))
                objInvoice.UpdateExistingCustomer(oCustomer);
            else
                objInvoice.AddCustomer(oCustomer);
        }
    }
}