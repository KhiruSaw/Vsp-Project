using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace VSPApplication.Models
{
    public class PickTicketModelService
    {
        public DataTable GetEmployeeInfo()
        {
            try
            {
                List<PickTicket> objEmpList = new List<PickTicket>();
                string conn = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                SqlConnection scon = new SqlConnection(conn);
                using (SqlCommand scmd = new SqlCommand("rpt_VSP7150_0", scon))
                {
                    scmd.CommandType = CommandType.StoredProcedure;
                    //ex = { "Procedure or function 'rpt_VSP7150_0' expects parameter '@beg_fg_id', which was not supplied."}
                    scmd.Parameters.AddWithValue("@beg_fg_id", "*All Files");
                    scmd.Parameters.AddWithValue("@end_fg_id", "0");
                    scmd.Parameters.AddWithValue("@beg_customer_id", "*All Files");
                    scmd.Parameters.AddWithValue("@end_customer_id", "0");
                    scmd.Parameters.AddWithValue("@beg_customer_name", "*All Files");
                    scmd.Parameters.AddWithValue("@end_customer_name", "0");
                    scmd.Parameters.AddWithValue("@beg_date", "*All Files");
                    scmd.Parameters.AddWithValue("@end_date", "0");
                    scmd.Parameters.AddWithValue("@beg_inventory_type", "*All Files");
                    scmd.Parameters.AddWithValue("@end_inventory_type", "0");
                    scmd.Parameters.AddWithValue("@beg_sales_rep", "*All Files");
                    scmd.Parameters.AddWithValue("@end_sales_rep", "0");
                    scmd.Parameters.AddWithValue("@beg_shipto_id", "*All Files");
                    scmd.Parameters.AddWithValue("@end_shipto_id", "0");
                    scmd.Parameters.AddWithValue("@beg_order_type", "*All Files");
                    scmd.Parameters.AddWithValue("@end_order_type", "0");
                    scmd.Parameters.AddWithValue("@beg_product_code", "*All Files");
                    scmd.Parameters.AddWithValue("@end_product_code", "0");
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(scmd);
                    da.Fill(ds);
                    DataTable dt = ds.Tables[0];

                    return dt;
                   
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}