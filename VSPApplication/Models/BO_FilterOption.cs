using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VSPApplication.Models
{
    public class BO_FilterOption:IDisposable
    {
        public string AdjustmentLocCode { get; set; }
        public string Description { get; set; }
        public string FinishedGood { get; set; }
        public string CustomerPart { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string InventoryType { get; set; }
        public string ModelName { get; set; }
        public string SalesRep { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ShippingLocation { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Code { get; set; }
        public string MaterialID { get; set; }
        public string MaterialName { get; set; }
        public string VendorID { get; set; }
        public string VendorItem { get; set; }
        public string SizeCode { get; set; }
        public string TypeCode { get; set; }
        public string BoxSetID { get; set; }
        public string ShipToName { get; set; }
        public string CustomerPO { get; set; }
        public string JobID { get; set; }
        public string DateOrdered { get; set; }
        public string BillTo { get; set; }
        public string BillToName { get; set; }
        public string KindCode {get;set;}
        public string Warehouse { get; set; }
        public string WarehouseName { get; set; }
        public string Location { get; set; }
        public string Shelf { get; set; }
        public string Section { get; set; }
        public string Bin { get; set; }
        public string CostCenterID { get; set; }
        public string CostCenterName { get; set; }
        public string Class { get; set; }
        public string Department { get; set; }
        public string BillToNumb { get; set; }
        public string Status { get; set; }
        public string JCOEDescription { get; set; }
        public string MasterPartID { get; set; }
        public string ProductionType { get; set; }
        public string Days { get; set; }
        public string RecordType { get; set; }
        public string EstimateId { get; set; }
        public string DateEntered { get; set; }
        public string Title { get; set; }
        public string GenericJobID { get; set; }
        public string VendorName { get; set; }
        public string InvoiceId { get; set; }
        public string InvoiceDate { get; set; }
        public string JobOrderId { get; set; }
        public string JobOrderDesc { get; set; }
        public string Standard { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Dispose();

        }

    }
}