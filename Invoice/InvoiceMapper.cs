using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice
{
    public class InvoiceMapper
    {
        public void AddCustomer(Customer oCustomer)
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["batteryAppConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(strcon);

                SqlCommand cmd = new SqlCommand("Insert Into CustomerDetails Values (@sMobileNumber,@sName,@sAddress,@sState,@sPinCode)");
                cmd.Parameters.AddWithValue("@sMobileNumber", oCustomer.sMobileNumber);
                cmd.Parameters.AddWithValue("@sName", oCustomer.sName);
                cmd.Parameters.AddWithValue("@sAddress", oCustomer.sAddress);
                cmd.Parameters.AddWithValue("@sState", oCustomer.iState);
                cmd.Parameters.AddWithValue("@sPinCode", oCustomer.sPinCode);

                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsCustomerExists(string sMobileNumber)
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["batteryAppConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(strcon);

                SqlCommand cmd = new SqlCommand("select count(1) from CustomerDetails where sMobileNumber = @sMobileNumber");
                cmd.Parameters.AddWithValue("@sMobileNumber", sMobileNumber);
                cmd.Connection = con;
                con.Open();
                if (cmd.ExecuteScalar().ToString() == "1")
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateExistingCustomer(Customer oCustomer)
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["batteryAppConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(strcon);

                SqlCommand cmd = new SqlCommand("UPDATE CustomerDetails SET sMobileNumber=@sMobileNumber,sName=@sName,sAddress=@sAddress,sState=@sState,sPinCode=@sPinCode");
                cmd.Parameters.AddWithValue("@sMobileNumber", oCustomer.sMobileNumber);
                cmd.Parameters.AddWithValue("@sName", oCustomer.sName);
                cmd.Parameters.AddWithValue("@sAddress", oCustomer.sAddress);
                cmd.Parameters.AddWithValue("@sState", oCustomer.iState);
                cmd.Parameters.AddWithValue("@sPinCode", oCustomer.sPinCode);

                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
