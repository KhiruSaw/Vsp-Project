using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VSPApplication.Models
{
    public class PickTicket:IDisposable
    {
        public string beg_fg_id { get; set; }
        public string end_fg_id { get; set; }
        public string beg_customer_id { get; set; }
        public string end_customer_id { get; set; }
        public string beg_customer_name { get; set; }
        public string end_customer_name { get; set; }
        public string beg_date { get; set; }
        public string end_date { get; set; }
        public string beg_inventory_type { get; set; }
        public string end_inventory_type { get; set; }
        public string beg_sales_rep { get; set; }
        public string end_sales_rep { get; set; }
        public string beg_shipto_id { get; set; }
        public string end_shipto_id { get; set; }
        public string beg_order_type { get; set; }
        public string end_order_type { get; set; }
        public string beg_product_code { get; set; }
        public string end_product_code { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Dispose();

        }
    }
}