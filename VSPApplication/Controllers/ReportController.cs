using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using VSPApplication.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Dynamic;
//using ICSharpCode.SharpZipLib.Zip;
//using Ionic.Zip;
using System.IO;
using System.Web.UI;
using System.Collections;
using System.Threading;


namespace VSPApplication.Controllers
{
    public class ReportController : Controller
    {
        // GET:  Report
        public SqlConnection cn;
        public SqlCommand cmd;
        public String connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Report()
        {
            return View();
        }

        public async Task<ActionResult> RunReportAsyn()
        {
            Thread thread = new Thread(async () => await GenerateReport());         
            thread.Start();           
            return RedirectToAction("FilterOption", "Report");
           
        }       
        public async Task<ActionResult> RunReportAsyn7160()
        {
            Thread thread = new Thread(async () => await GenerateReport7160());
            thread.Start();           
            return RedirectToAction("FilterOption7160", "Report");
          
        }
        public async Task<ActionResult> RunReportAsyn7110()
        {
            Thread thread = new Thread(async () => await GenerateReport7110());
            thread.Start();           
            return RedirectToAction("FilterOption7110", "Report");
       
        }
        public async Task<ActionResult> RunReportAsyn7330()
        {
            ViewBag.msgReport = "Your Report will Generate shortly, Download link will be send to your email id shortly";
            var asynctask = await GenerateReport7330();

            if (asynctask == "Success")
            {

                string PDFUrl = Session["pdfPath"].ToString();

                string email = Session["EmailID"].ToString();
                //string email = Session["UserEmail"].ToString();
                Mails mail = new Mails();
                string reportName = "VSP7330";
                mail.SendPdfUrl(email, PDFUrl, reportName);

            }
            return RedirectToAction("FilterOption7330", "Report");
            //return msg = "Your Report will Generate shortly, Download link will be send to your email id shortly";
        }
        public async Task<ActionResult> RunReportAsyn7820()
        {
            Thread thread = new Thread(async () => await GenerateReport7820());
            thread.Start();           
            return RedirectToAction("FilterOption7820", "Report");
          
        }
        public async Task<ActionResult> RunReportAsyn7830()
        {
            Thread thread = new Thread(async () => await GenerateReport7830());
            thread.Start();          
            return RedirectToAction("FilterOption7830", "Report");
         
        }
        public async Task<ActionResult> RunReportAsyn9160()
        {
            Thread thread = new Thread(async () => await GenerateReport9160());
            thread.Start();         
            return RedirectToAction("FilterOption9160", "Report");
         
        }
        public async Task<ActionResult> RunReportAsyn7890()
        {
            ViewBag.msgReport = "Your Report will Generate shortly, Download link will be send to your email id shortly";
            var asynctask = await GenerateReport7890();

            if (asynctask == "Success")
            {

                string PDFUrl = Session["pdfPath"].ToString();

                string email = Session["EmailID"].ToString();
                //string email = Session["UserEmail"].ToString();
                Mails mail = new Mails();
                string reportName = "VSP7830";
                mail.SendPdfUrl(email, PDFUrl, reportName);

            }
            return RedirectToAction("FilterOption7890", "Report");
            //return msg = "Your Report will Generate shortly, Download link will be send to your email id shortly";
        }
        public async Task<ActionResult> RunReportAsyn8610()
        {
            
            Thread thread = new Thread(async () => await GenerateReport8610());          
            thread.Start();        
            return RedirectToAction("FilterOption8610", "Report");
          
        }
        public async Task<ActionResult> RunReportAsyn8620()
        {
            Thread thread = new Thread(async () => await GenerateReport8620());
            thread.Start();           
            return RedirectToAction("FilterOption8620", "Report");
           
        }
        public async Task<ActionResult> RunReportAsyn8400()
        {
            ViewBag.msgReport = "Your Report will Generate shortly, Download link will be send to your email id shortly";
            var asynctask = await GenerateReport8400();

            if (asynctask == "Success")
            {

                string PDFUrl = Session["pdfPath"].ToString();

                string email = Session["EmailID"].ToString();
                //string email = Session["UserEmail"].ToString();
                Mails mail = new Mails();
                string reportName = "VSP8400";
                mail.SendPdfUrl(email, PDFUrl, reportName);

            }
            return RedirectToAction("FilterOption8400", "Report");
            //return msg = "Your Report will Generate shortly, Download link will be send to your email id shortly";
        }
        public async Task<ActionResult> RunReportAsyn7910()
        {
            ViewBag.msgReport = "Your Report will Generate shortly, Download link will be send to your email id shortly";
            var asynctask = await GenerateReport7910();

            if (asynctask == "Success")
            {

                string PDFUrl = Session["pdfPath"].ToString();

                string email = Session["EmailID"].ToString();
                //string email = Session["UserEmail"].ToString();
                Mails mail = new Mails();
                string reportName = "VSP8620";
                mail.SendPdfUrl(email, PDFUrl, reportName);

            }
            return RedirectToAction("FilterOption7910", "Report");
            //return msg = "Your Report will Generate shortly, Download link will be send to your email id shortly";
        }
        public async Task<ActionResult> RunReportAsyn7170()
        {
            Thread thread = new Thread(async () => await GenerateReport7170());
            thread.Start();          
            return RedirectToAction("FilterOption7170", "Report");
          
        }
        public async Task<ActionResult> RunReportAsyn7180()
        {
            Thread thread = new Thread(async () => await GenerateReport7180());
            thread.Start();         
            return RedirectToAction("FilterOption7180", "Report");
         
        }       
        public async Task<ActionResult> RunReportAsyn7310()
        {
            Thread thread = new Thread(async () => await GenerateReport7310());
            thread.Start();          
            return RedirectToAction("FilterOption7310", "Report");
          
        }
        public async Task<ActionResult> RunReportAsyn7140()
        {
            Thread thread = new Thread(async () => await GenerateReport7140());
            thread.Start();          
            return RedirectToAction("FilterOption7140", "Report");          
        }
        public async Task<ActionResult> RunReportAsyn7810()
        {
            Thread thread = new Thread(async () => await GenerateReport7810());        
            thread.Start();          
            return RedirectToAction("FilterOption7810", "Report");          
        }
        public ActionResult AsynFilterOptionReport7150()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.FinishGoodItem = GetFinishGoodItem();
            mymodel.CustomerIDs = GetCustomerIDs();
            mymodel.CustomerName2 = GetCustomerName2();
            mymodel.InventoryType2 = GetInventoryType2();
            mymodel.SalesRep2 = GetSalesRep2();
            mymodel.ShippingLocation2 = GetShippingLocation2();
            mymodel.OrderType2 = GetOrderType2();
            mymodel.ProductCode2 = GetProductCode2();
            return View(mymodel);
        }
        public async Task<ActionResult> AsynReportView7150(FormCollection obj, string filter, string DateShipped)
        {
            var asynctask = await GenerateReportFilter7150(obj, filter, DateShipped);

            if (asynctask == "Success")
            {

                string PDFUrl = Session["pdfPath"].ToString();

                string email = Session["EmailID"].ToString();

                Mails mail = new Mails();
                string reportName = "VSP7150";
                mail.SendPdfUrl(email, PDFUrl, reportName);

            }
            return RedirectToAction("Dashboard", "Account", new { id = "1" });
        }
        public async Task<ActionResult> RunReportAsyn9170()
        {
            Thread thread = new Thread(async () => await GenerateReport9170());
            thread.Start();
          
            return RedirectToAction("FilterOption9170", "Report");
            //return msg = "Your Report will Generate shortly, Download link will be send to your email id shortly";
        }
        public async Task<ActionResult> RunReportAsyn7950()
        {
            Thread thread = new Thread(async () => await GenerateReport7950());
            thread.Start();           
            return RedirectToAction("FilterOption7950", "Report");
          
        }
        public async Task<ActionResult> RunReportAsyn7980()
        {
            Thread thread = new Thread(async () => await GenerateReport7980());
            thread.Start();            
            return RedirectToAction("FilterOption7980", "Report");
          
        }
        public async Task<ActionResult> RunReportAsyn7990()
        {
            Thread thread = new Thread(async () => await GenerateReport7990());
            thread.Start();          
            return RedirectToAction("FilterOption7990", "Report");
          
        }
        public async Task<ActionResult> RunReportAsyn8880()
        {
            Thread thread = new Thread(async () => await GenerateReport8880());
            thread.Start();           
            return RedirectToAction("FilterOption8880", "Report");
         
        }
        public async Task<ActionResult> RunReportAsyn7190()
        {
            Thread thread = new Thread(async () => await GenerateReport7190());
            thread.Start();           
            return RedirectToAction("FilterOption7190", "Report");
          
        }
        public async Task<ActionResult> RunReportAsyn7130()
        {
            Thread thread = new Thread(async () => await GenerateReport7130());
            thread.Start();          
            return RedirectToAction("FilterOption7130", "Report");          
        }

        public async Task<string> GenerateReport7130()
        {
            string ReportSuccess = "";
            ViewBag.msg = "Report generation process works on background. A confirmation mail will sent to email after report generation.";
            try
            {
                FormCollection obj = (FormCollection)TempData["ReportView"];
                ViewBag.FinishGoodsItems_Exp_Beg = obj["FinishGoodsItems_Exp_Beg"].ToString();
                ViewBag.Customer = obj["Customer"].ToString();
                ViewBag.DateExpiration_Beg = obj["DateExpiration_Beg"].ToString();
                ViewBag.txtDateExpiration_Beg = obj["txtDateExpiration_Beg"].ToString();
                ViewBag.DateExpiration_End = obj["DateExpiration_End"].ToString();
                ViewBag.txtDateExpiration_End = obj["txtDateExpiration_End"].ToString();

                ViewBag.DateExpiration = obj["DateExpiration"].ToString();

                string DateExpiration = obj["DateExpiration"].ToString();
                ViewBag.InventoryType_exp = obj["InventoryType_exp"].ToString();
                ViewBag.StandardClassification = obj["StandardClassification"].ToString();
                ViewBag.dllDiscontuned_Item = obj["dllDiscontuned_Item"].ToString();
                ViewBag.dllsorting7130 = obj["dllsorting7130"].ToString();


                string beg_date = string.Empty;
                string end_date = string.Empty;
                ViewBag.btn = "filter";             

                ViewBag.btn = "filter";            
                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(0);
                reportViewer.Height = Unit.Percentage(0);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7130";
                //string DateExpiration = obj["DateExpiration"].ToString();
                string FinishGoodsItems_Exp_Beg = obj["FinishGoodsItems_Exp_Beg"].ToString() != "" ? obj["FinishGoodsItems_Exp_Beg"].ToString() : "0";
                string FinishGoodsItems_Exp_End = obj["FinishGoodsItems_Exp_End"].ToString() != "" ? obj["FinishGoodsItems_Exp_End"].ToString() : "0";
                string Customer_Beg = obj["Customer_Beg"].ToString() != "" ? obj["Customer_Beg"].ToString() : "0";
                string Customer_End = obj["Customer_End"].ToString() != "" ? obj["Customer_End"].ToString() : "0";

                //string beg_customer_name = string.Empty;
                //if (obj["CustomerName1"].ToString() != "")
                //{
                //    beg_customer_name = obj["CustomerName1"].ToString();
                //}
                //else
                //{
                //    beg_customer_name = "0";
                //}
                //string end_customer_name = string.Empty;
                //if (obj["CustomerName2"].ToString() != "")
                //{
                //    end_customer_name = obj["CustomerName2"].ToString();
                //}
                //else
                //{
                //    end_customer_name = "0";
                //}

                if (DateExpiration == "Between Range")
                {
                    beg_date = obj["DateExpiration_Beg"].ToString();
                    end_date = obj["DateExpiration_End"].ToString();
                }
                else if (DateExpiration == "")
                {
                    beg_date = obj["txtDateExpiration_Beg"].ToString();
                    end_date = obj["txtDateExpiration_End"].ToString();
                }
                else if (DateExpiration == "*All Records")
                {
                    beg_date = obj["txtDateExpiration_Beg"].ToString();
                    end_date = obj["txtDateExpiration_End"].ToString();
                }
                else
                {
                    beg_date = obj["txtDateExpiration_Beg"].ToString();
                    end_date = obj["DateExpiration_End"].ToString();
                }

                string InventoryType_exp_Beg = obj["InventoryType_exp_Beg"].ToString() != "" ? obj["InventoryType_exp_Beg"].ToString() : "0";
                string InventoryType_exp_End = obj["InventoryType_exp_End"].ToString() != "" ? obj["InventoryType_exp_End"].ToString() : "0";
                string StandardClassification_Beg = obj["StandardClassification_Beg"].ToString() != "" ? obj["StandardClassification_Beg"].ToString() : "0";
                string StandardClassification_End = obj["StandardClassification_End"].ToString() != "" ? obj["StandardClassification_End"].ToString() : "0";
                string dllsorting7130 = obj["dllsorting7130"].ToString();
                string dllDiscontuned_Item = obj["dllDiscontuned_Item"].ToString();
                ReportParameter[] myparams = new ReportParameter[12];
                myparams[0] = new ReportParameter("beg_fg_id", FinishGoodsItems_Exp_Beg, false);
                myparams[1] = new ReportParameter("end_fg_id", FinishGoodsItems_Exp_End, false);
                myparams[2] = new ReportParameter("beg_cust_id", Customer_Beg, false);
                myparams[3] = new ReportParameter("end_cust_id", Customer_End, false);
                myparams[4] = new ReportParameter("beg_dis_date", beg_date, false);
                myparams[5] = new ReportParameter("end_dis_date", end_date, false);

                myparams[6] = new ReportParameter("beg_inventory_type", InventoryType_exp_Beg, false);
                myparams[7] = new ReportParameter("end_inventory_type", InventoryType_exp_End, false);
                myparams[8] = new ReportParameter("Standard_Classification_Beg", StandardClassification_Beg, false);
                myparams[9] = new ReportParameter("Standard_Classification_End", StandardClassification_End, false);
                myparams[10] = new ReportParameter("sort", dllsorting7130, false);
                myparams[11] = new ReportParameter("discont_items", dllDiscontuned_Item, false);

                reportViewer.ServerReport.SetParameters(myparams);


                Warning[] warnings;
                string[] streamids;
                string mimeType, encoding, extension, deviceInfo;

                deviceInfo = "True";

                byte[] bytes = reportViewer.ServerReport.Render("EXCEL", null, out mimeType, out encoding, out extension, out streamids, out warnings);

                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                string FolderPath = "~/VSP";
                bool exists = System.IO.Directory.Exists(Server.MapPath(FolderPath));
                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(FolderPath));
                }

                //string pdfPath = @"D:\Reports\VSP7150." + extension; // Path to export Report.

                string pdfPath = Server.MapPath("~/VSP/VSP7130." + extension);

           

                System.IO.FileStream pdfFile = new System.IO.FileStream(pdfPath, System.IO.FileMode.Create);
                pdfFile.Write(bytes, 0, bytes.Length);
                pdfFile.Close();
                //Response.Flush();
                //Response.End();
                string Link = "http://10.2.0.140/VSPAPPLICATION3/VSP/VSP7130.xls";
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_AsynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(TempData["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID", 7130);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Name", "Finish Goods Expiration");
                    cmd.Parameters.AddWithValue("@Asyn_Report_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Link", Link);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();
                }
                string email = TempData["EmailID"].ToString();               
                Mails mail = new Mails();
                string reportName = "VSP7130";
                mail.SendPdfUrl(email, pdfPath, reportName);
                ReportSuccess = "Success";
            }
            catch (Exception e)
            {

                ReportSuccess = "Failed";
            }

            return ReportSuccess;

        }
        public async Task<string> GenerateReport7190()
        {
            string ReportSuccess = "";
            ViewBag.msg = "Report generation process works on background. A confirmation mail will sent to email after report generation.";
            try
            {
                FormCollection obj = (FormCollection)TempData["ReportView"];
                string DateShipped = obj["DateShipped_Ord_Sum"].ToString();             
                string beg_date = string.Empty;
                string end_date = string.Empty;
                ViewBag.btn = "filter";             
                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(0);
                reportViewer.Height = Unit.Percentage(0);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7190";
                string FinishGoodsId_OrdSum_Beg = obj["FinishGoodsId_OrdSum_Beg"].ToString() != "" ? obj["FinishGoodsId_OrdSum_Beg"].ToString() : "0";
                string FinishGoodsId_OrdSum_End = obj["FinishGoodsId_OrdSum_End"].ToString() != "" ? obj["FinishGoodsId_OrdSum_End"].ToString() : "0";
                string CustomerID_Ord_Sum_Beg = obj["CustomerID_Ord_Sum_Beg"].ToString() != "" ? obj["CustomerID_Ord_Sum_Beg"].ToString() : "0";
                string CustomerID_Ord_Sum_End = obj["CustomerID_Ord_Sum_End"].ToString() != "" ? obj["CustomerID_Ord_Sum_End"].ToString() : "0";

                //string beg_customer_name = string.Empty;
                //if (obj["CustomerName1"].ToString() != "")
                //{
                //    beg_customer_name = obj["CustomerName1"].ToString();
                //}
                //else
                //{
                //    beg_customer_name = "0";
                //}
                //string end_customer_name = string.Empty;
                //if (obj["CustomerName2"].ToString() != "")
                //{
                //    end_customer_name = obj["CustomerName2"].ToString();
                //}
                //else
                //{
                //    end_customer_name = "0";
                //}

                if (DateShipped == "Between Range")
                {
                    beg_date = obj["DateShipped_Ord_Sum_Beg"].ToString();
                    end_date = obj["DateShipped_Ord_Sum_End"].ToString();
                }
                else if (DateShipped == "")
                {
                    beg_date = obj["txtDateShipped_Ord_Sum_Beg"].ToString();
                    end_date = obj["txtDateShipped_Ord_Sum_End"].ToString();
                }
                else if (DateShipped == "*All Records")
                {
                    beg_date = obj["txtDateShipped_Ord_Sum_Beg"].ToString();
                    end_date = obj["txtDateShipped_Ord_Sum_End"].ToString();
                }
                else
                {
                    beg_date = obj["txtDateShipped_Ord_Sum_Beg"].ToString();
                    end_date = obj["DateShipped_Ord_Sum_End"].ToString();
                }

                string beg_inventory_type = obj["InventoryType_Ord_Sum_Beg"].ToString() != "" ? obj["InventoryType_Ord_Sum_Beg"].ToString() : "0";
                string end_inventory_type = obj["InventoryType_Ord_Sum_End"].ToString() != "" ? obj["InventoryType_Ord_Sum_End"].ToString() : "0";
                string SubType2_Ord_Sum_Beg = obj["SubType2_Ord_Sum_Beg"].ToString() != "" ? obj["SubType2_Ord_Sum_Beg"].ToString() : "0";
                string SubType2_Ord_Sum_End = obj["SubType2_Ord_Sum_End"].ToString() != "" ? obj["SubType2_Ord_Sum_End"].ToString() : "0";
                string SubType3_Ord_Sum_Beg = obj["SubType3_Ord_Sum_Beg"].ToString() != "" ? obj["SubType3_Ord_Sum_Beg"].ToString() : "0";
                string SubType3_Ord_Sum_End = obj["SubType3_Ord_Sum_End"].ToString() != "" ? obj["SubType3_Ord_Sum_End"].ToString() : "0";
                string InvoiceIdNum_Beg = obj["InvoiceIdNum_Beg"].ToString() != "" ? obj["InvoiceIdNum_Beg"].ToString() : "0";
                string InvoiceIdNum_End = obj["InvoiceIdNum_End"].ToString() != "" ? obj["InvoiceIdNum_End"].ToString() : "0";
                //string beg_product_code = obj["beg_product_code"].ToString();
                //string end_product_code = obj["beg_product_code"].ToString();

                ReportParameter[] myparams = new ReportParameter[14];
                myparams[0] = new ReportParameter("beg_fg_id", FinishGoodsId_OrdSum_Beg, false);
                myparams[1] = new ReportParameter("end_fg_id", FinishGoodsId_OrdSum_End, false);
                myparams[2] = new ReportParameter("beg_customer_id", CustomerID_Ord_Sum_Beg, false);
                myparams[3] = new ReportParameter("end_customer_id", CustomerID_Ord_Sum_End, false);
                myparams[4] = new ReportParameter("beg_date", beg_date, false);
                myparams[5] = new ReportParameter("end_date", end_date, false);
                myparams[6] = new ReportParameter("beg_inventory_type", beg_inventory_type, false);
                myparams[7] = new ReportParameter("end_inventory_type", end_inventory_type, false);
                myparams[8] = new ReportParameter("beg_sub_type_2", SubType2_Ord_Sum_Beg, false);
                myparams[9] = new ReportParameter("end_sub_type_2", SubType2_Ord_Sum_End, false);
                myparams[10] = new ReportParameter("beg_sub_type_3", SubType3_Ord_Sum_Beg, false);
                myparams[11] = new ReportParameter("end_sub_type_3", SubType3_Ord_Sum_End, false);
                myparams[12] = new ReportParameter("Beg_Invoice_ID", InvoiceIdNum_Beg, false);
                myparams[13] = new ReportParameter("End_Invoice_ID", InvoiceIdNum_End, false);
                reportViewer.ServerReport.SetParameters(myparams);


                Warning[] warnings;
                string[] streamids;
                string mimeType, encoding, extension, deviceInfo;

                deviceInfo = "True";

                byte[] bytes = reportViewer.ServerReport.Render("EXCEL", null, out mimeType, out encoding, out extension, out streamids, out warnings);

                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                string FolderPath = "~/VSP";
                bool exists = System.IO.Directory.Exists(Server.MapPath(FolderPath));
                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(FolderPath));
                }

                //string pdfPath = @"D:\Reports\VSP7150." + extension; // Path to export Report.

                string pdfPath = Server.MapPath("~/VSP/VSP7190." + extension);

               

                System.IO.FileStream pdfFile = new System.IO.FileStream(pdfPath, System.IO.FileMode.Create);
                pdfFile.Write(bytes, 0, bytes.Length);
                pdfFile.Close();
                //Response.Flush();
                //Response.End();
                string Link = "http://10.2.0.140/VSPAPPLICATION3/VSP/VSP7190.xls";
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_AsynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(TempData["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID", 7190);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Name", "Customer Order Summery");
                    cmd.Parameters.AddWithValue("@Asyn_Report_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Link", Link);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();
                }
                string email = TempData["EmailID"].ToString();              
                Mails mail = new Mails();
                string reportName = "VSP7190";
                mail.SendPdfUrl(email, pdfPath, reportName);
                ReportSuccess = "Success";
            }
            catch (Exception e)
            {

                ReportSuccess = "Failed";
            }

            return ReportSuccess;

        }
        public async Task<string> GenerateReport7990()
        {
            string ReportSuccess = "";
            ViewBag.msg = "Report generation process works on background. A confirmation mail will sent to email after report generation.";
            try
            {
                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(900);
                reportViewer.Height = Unit.Percentage(900);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7990";
                FormCollection obj = (FormCollection)TempData["ReportView"];
                string MaterialID_Beg = obj["MaterialID_Beg"].ToString() != "" ? obj["MaterialID_Beg"].ToString() : "0";
                string MaterialID_End = obj["MaterialID_End"].ToString() != "" ? obj["MaterialID_End"].ToString() : "0";
                string MaterilaDesc_Beg = obj["MaterilaDesc_Beg"].ToString() != "" ? obj["MaterilaDesc_Beg"].ToString() : "0";
                string MaterilaDesc_End = obj["MaterilaDesc_End"].ToString() != "" ? obj["MaterilaDesc_End"].ToString() : "0";
                string VendorId_Beg = obj["VendorId_Beg"].ToString() != "" ? obj["VendorId_Beg"].ToString() : "0";
                string VendorId_End = obj["VendorId_End"].ToString() != "" ? obj["VendorId_End"].ToString() : "0";
                string VendorName_Beg = obj["VendorName_Beg"].ToString() != "" ? obj["VendorName_Beg"].ToString() : "0";
                string VendorName_End = obj["VendorName_End"].ToString() != "" ? obj["VendorName_End"].ToString() : "0";

                ReportParameter[] myparams = new ReportParameter[8];
                myparams[0] = new ReportParameter("beg_material_id", MaterialID_Beg, false);
                myparams[1] = new ReportParameter("end_material_id", MaterialID_End, false);
                myparams[2] = new ReportParameter("beg_material_desc", MaterilaDesc_Beg, false);
                myparams[3] = new ReportParameter("end_material_desc", MaterilaDesc_End, false);
                myparams[4] = new ReportParameter("beg_vendor_id", VendorId_Beg, false);
                myparams[5] = new ReportParameter("end_vendor_id", VendorId_End, false);
                myparams[6] = new ReportParameter("beg_vendor_name", VendorName_Beg, false);
                myparams[7] = new ReportParameter("end_vendor_name", VendorName_End, false);

                reportViewer.ServerReport.SetParameters(myparams);

                Warning[] warnings;
                string[] streamids;
                string mimeType, encoding, extension, deviceInfo;

                deviceInfo = "True";

                byte[] bytes = reportViewer.ServerReport.Render("EXCEL", null, out mimeType, out encoding, out extension, out streamids, out warnings);

                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                string FolderPath = "~/VSP";
                bool exists = System.IO.Directory.Exists(Server.MapPath(FolderPath));
                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(FolderPath));
                }             

                string pdfPath = Server.MapPath("~/VSP/VSP7990." + extension);
                System.IO.FileStream pdfFile = new System.IO.FileStream(pdfPath, System.IO.FileMode.Create);
                pdfFile.Write(bytes, 0, bytes.Length);
                pdfFile.Close();
                //Response.Flush();
                //Response.End();
                string Link = "http://10.2.0.140/VSPAPPLICATION3/VSP/VSP7990.xls";
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_AsynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(TempData["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID", 7990);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Name", "Material Allocations Report");
                    cmd.Parameters.AddWithValue("@Asyn_Report_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Link", Link);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();
                }
                string email = TempData["EmailID"].ToString();         
                Mails mail = new Mails();
                string reportName = "VSP7990";
                mail.SendPdfUrl(email, pdfPath, reportName);
                ReportSuccess = "Success";
            }
            catch (Exception e)
            {

                ReportSuccess = "Failed";
            }

            return ReportSuccess;

        }
        public async Task<string> GenerateReport8880()
        {
            string ReportSuccess = "";
            ViewBag.msg = "Report generation process works on background. A confirmation mail will sent to email after report generation.";
            try
            {
                FormCollection obj = (FormCollection)TempData["ReportView"];
                string Date = obj["DateFirstCost"].ToString();               
                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(0);
                reportViewer.Height = Unit.Percentage(0);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7170";
                string beg_date = string.Empty;
                string end_date = string.Empty;

                if (Date == "Between Range")
                {
                    beg_date = obj["DateFirstCost_Beg"].ToString();
                    end_date = obj["DateFirstCost_End"].ToString();
                }
                else if (Date == "")
                {
                    beg_date = obj["txtDateFirstCost_Beg"].ToString();
                    end_date = obj["txtDateFirstCost_End"].ToString();
                }
                else if (Date == "*All Records")
                {
                    beg_date = obj["txtDateFirstCost_Beg"].ToString();
                    end_date = obj["txtDateFirstCost_End"].ToString();

                }
                else
                {
                    beg_date = obj["txtDateFirstCost_Beg"].ToString();
                    end_date = obj["DateFirstCost_End"].ToString();
                }

                ReportParameter[] myparams = new ReportParameter[2];

                myparams[0] = new ReportParameter("beg_date", beg_date, false);
                myparams[1] = new ReportParameter("end_date", end_date, false);
                reportViewer.ServerReport.SetParameters(myparams);


                Warning[] warnings;
                string[] streamids;
                string mimeType, encoding, extension, deviceInfo;

                deviceInfo = "True";

                byte[] bytes = reportViewer.ServerReport.Render("EXCEL", null, out mimeType, out encoding, out extension, out streamids, out warnings);

                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                string FolderPath = "~/VSP";
                bool exists = System.IO.Directory.Exists(Server.MapPath(FolderPath));
                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(FolderPath));
                }            

                string pdfPath = Server.MapPath("~/VSP/VSP8880." + extension);            

                System.IO.FileStream pdfFile = new System.IO.FileStream(pdfPath, System.IO.FileMode.Create);
                pdfFile.Write(bytes, 0, bytes.Length);
                pdfFile.Close();
                //Response.Flush();
                //Response.End();
                string Link = "http://10.2.0.140/VSPAPPLICATION3/VSP/VSP8880.xls";
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_AsynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(TempData["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID", 8880);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Name", "ECL Cost");
                    cmd.Parameters.AddWithValue("@Asyn_Report_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Link", Link);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();
                }
                string email = TempData["EmailID"].ToString();              
                Mails mail = new Mails();
                string reportName = "VSP8880";
                mail.SendPdfUrl(email, pdfPath, reportName);
                ReportSuccess = "Success";
            }
            catch (Exception e)
            {

                ReportSuccess = "Failed";
            }

            return ReportSuccess;

        }
        public async Task<string> GenerateReport7980()
        {
            string ReportSuccess = "";
            ViewBag.msg = "Report generation process works on background. A confirmation mail will sent to email after report generation.";
            try
            {
                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(900);
                reportViewer.Height = Unit.Percentage(900);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7980";
                FormCollection obj = (FormCollection)TempData["ReportView"];
                string MasterPartNum_Beg = obj["MasterPartNum_Beg"].ToString() != "" ? obj["MasterPartNum_Beg"].ToString() : "0";
                string MasterPartNum_End = obj["MasterPartNum_End"].ToString() != "" ? obj["MasterPartNum_End"].ToString() : "0";
                string MasterPartDesc_Beg = obj["MasterPartDesc_Beg"].ToString() != "" ? obj["MasterPartDesc_Beg"].ToString() : "0";
                string MasterPartDesc_End = obj["MasterPartDesc_End"].ToString() != "" ? obj["MasterPartDesc_End"].ToString() : "0";
                string FinishGoodsID_Beg = obj["FinishGoodsID_Beg"].ToString() != "" ? obj["FinishGoodsID_Beg"].ToString() : "0";
                string FinishGoodsID_End = obj["FinishGoodsID_End"].ToString() != "" ? obj["FinishGoodsID_End"].ToString() : "0";
                string FinishGoodsDesc_Beg = obj["FinishGoodsDesc_Beg"].ToString() != "" ? obj["FinishGoodsDesc_Beg"].ToString() : "0";
                string FinishGoodsDesc_End = obj["FinishGoodsDesc_End"].ToString() != "" ? obj["FinishGoodsDesc_End"].ToString() : "0";
                string CustID_Beg = obj["CustID_Beg"].ToString() != "" ? obj["CustID_Beg"].ToString() : "0";
                string CustID_End = obj["CustID_End"].ToString() != "" ? obj["CustID_End"].ToString() : "0";
                string CustName_Beg = obj["CustName_Beg"].ToString() != "" ? obj["CustName_Beg"].ToString() : "0";
                string CustName_End = obj["CustName_End"].ToString() != "" ? obj["CustName_End"].ToString() : "0";
                string ddlDept = obj["dllDept"].ToString();
                //beg_date = obj["DateShipped1"].ToString();
                //end_date = obj["DateShipped2"].ToString();
                //if (OEDateWanted == "Between Range")
                //{
                //    OEDateWanted_Beg = obj["OEDateWanted_Beg"].ToString();
                //    OEDateWanted_End = obj["OEDateWanted_End"].ToString();
                //}
                //else if (OEDateWanted == "")
                //{
                //    OEDateWanted_Beg = obj["txtOEDateWanted_Beg"].ToString();
                //    OEDateWanted_End = obj["txtOEDateWanted_End"].ToString(); ;
                //}
                //else if (OEDateWanted == "*All Records")
                //{
                //    OEDateWanted_Beg = obj["txtOEDateWanted_Beg"].ToString();
                //    OEDateWanted_End = obj["txtOEDateWanted_End"].ToString();
                //    //beg_date = obj["DateShipped1"].ToString();
                //    //end_date = obj["DateShipped2"].ToString();
                //}
                //else
                //{
                //    OEDateWanted_Beg = obj["txtOEDateWanted_Beg"].ToString();
                //    OEDateWanted_End = obj["OEDateWanted_End"].ToString();
                //}

                ReportParameter[] myparams = new ReportParameter[13];
                myparams[0] = new ReportParameter("beg_master_part_id", MasterPartNum_Beg, false);
                myparams[1] = new ReportParameter("end_master_part_id", MasterPartNum_End, false);
                myparams[2] = new ReportParameter("beg_master_part_desc", MasterPartDesc_Beg, false);
                myparams[3] = new ReportParameter("end_master_part_desc", MasterPartDesc_End, false);
                myparams[4] = new ReportParameter("beg_fg_id", FinishGoodsID_Beg, false);
                myparams[5] = new ReportParameter("end_fg_id", FinishGoodsID_End, false);
                myparams[6] = new ReportParameter("beg_fg_desc", FinishGoodsDesc_Beg, false);
                myparams[7] = new ReportParameter("end_fg_desc", FinishGoodsDesc_End, false);
                myparams[8] = new ReportParameter("beg_customer_id", CustID_Beg, false);
                myparams[9] = new ReportParameter("end_customer_id", CustID_End, false);
                myparams[10] = new ReportParameter("beg_customer_name", CustName_Beg, false);
                myparams[11] = new ReportParameter("end_customer_name", CustName_End, false);
                //myparams[12] = new ReportParameter("beg_order_type", OEDateWanted_Beg, false);
                //myparams[13] = new ReportParameter("end_order_type", OEDateWanted_End, false);
                myparams[12] = new ReportParameter("department_choice", ddlDept, false);
                //myparams[18] = new ReportParameter("Sorting_Name", Sorting_Name, false);
                reportViewer.ServerReport.SetParameters(myparams);

                Warning[] warnings;
                string[] streamids;
                string mimeType, encoding, extension, deviceInfo;

                deviceInfo = "True";

                byte[] bytes = reportViewer.ServerReport.Render("EXCELOPENXML", null, out mimeType, out encoding, out extension, out streamids, out warnings);

                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                string FolderPath = "~/VSP";
                bool exists = System.IO.Directory.Exists(Server.MapPath(FolderPath));
                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(FolderPath));
                }

                string pdfPath = Server.MapPath("~/VSP/VSP7980." + extension);            

                System.IO.FileStream pdfFile = new System.IO.FileStream(pdfPath, System.IO.FileMode.Create);
                pdfFile.Write(bytes, 0, bytes.Length);
                pdfFile.Close();
                //Response.Flush();
                //Response.End();
                string Link = "http://10.2.0.140/VSPAPPLICATION3/VSP/VSP7980.xls";
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_AsynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(TempData["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID", 7980);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Name", "CS Schedule Report");
                    cmd.Parameters.AddWithValue("@Asyn_Report_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Link", Link);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();
                }
                string email = TempData["EmailID"].ToString();             
                Mails mail = new Mails();
                string reportName = "VSP7980";
                mail.SendPdfUrl(email, pdfPath, reportName);
                ReportSuccess = "Success";
            }
            catch (Exception e)
            {

                ReportSuccess = "Failed";
            }

            return ReportSuccess;

        }
        public async Task<string> GenerateReport()
        {
            string ReportSuccess = "";
            ViewBag.msg = "Report generation process works on background. A confirmation mail will sent to email after report generation.";
            try
            {
                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(900);
                reportViewer.Height = Unit.Percentage(900);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7150";
                string DateShipped = TempData["DateShipped"].ToString();
                string dllsorting = TempData["dllsorting"].ToString();
                FormCollection obj = (FormCollection)TempData["ReportView"];
                string beg_date = string.Empty;
                string end_date = string.Empty;
                string beg_fg_id = obj["FinishGoodsItemID"].ToString() != "" ? obj["FinishGoodsItemID"].ToString() : "0";
                string end_fg_id = obj["FinishGoodsItemID2"].ToString() != "" ? obj["FinishGoodsItemID2"].ToString() : "0";
                string beg_customer_id = obj["CustomerID1"].ToString() != "" ? obj["CustomerID1"].ToString() : "0";
                string end_customer_id = obj["CustomerID2"].ToString() != "" ? obj["CustomerID2"].ToString() : "0";
                string beg_customer_name = obj["CustomerName1"].ToString() != "" ? obj["CustomerName1"].ToString() : "0";
                string end_customer_name = obj["CustomerName2"].ToString() != "" ? obj["CustomerName2"].ToString() : "0";

                if (DateShipped == "Between Range")
                {
                    beg_date = obj["DateShipped1"].ToString();
                    end_date = obj["DateShipped2"].ToString();
                }
                else if (DateShipped == "")
                {
                    beg_date = obj["DateShipped1"].ToString();
                    end_date = obj["DateShipped2"].ToString();
                }
                else if (DateShipped == "*All Records")
                {
                    beg_date = obj["rangevaltext"].ToString();
                    end_date = obj["rangevaltext1"].ToString();
                    //beg_date = obj["DateShipped1"].ToString();
                    //end_date = obj["DateShipped2"].ToString();
                }
                else
                {
                    beg_date = obj["rangevaltext"].ToString();
                    end_date = obj["DateShipped2"].ToString();
                }
                string beg_inventory_type = obj["InventoryType1"].ToString() != "" ? obj["InventoryType1"].ToString() : "0";
                string end_inventory_type = obj["InventoryType2"].ToString() != "" ? obj["InventoryType2"].ToString() : "0";
                string beg_sales_rep = obj["SellRep1"].ToString() != "" ? obj["SellRep1"].ToString() : "0";
                string end_sales_rep = obj["SellRep2"].ToString() != "" ? obj["SellRep2"].ToString() : "0";
                string beg_shipto_id = obj["ShippingLocatoin1"].ToString() != "" ? obj["ShippingLocatoin1"].ToString() : "0";
                string end_shipto_id = obj["ShippingLocatoin2"].ToString() != "" ? obj["ShippingLocatoin2"].ToString() : "0";
                string beg_order_type = obj["OrderType1"].ToString() != "" ? obj["OrderType1"].ToString() : "0";
                string end_order_type = obj["OrderType2"].ToString() != "" ? obj["OrderType2"].ToString() : "0";
                string beg_product_code = obj["ProductCode1"].ToString() != "" ? obj["ProductCode1"].ToString() : "0";
                string end_product_code = obj["ProductCode2"].ToString() != "" ? obj["ProductCode2"].ToString() : "0";
                string Sorting_Name = String.Empty;
                if (dllsorting == "Customer Name")
                {
                    Sorting_Name = "billto_name";
                }
                else
                {
                    Sorting_Name = "type_code";
                }
                ReportParameter[] myparams = new ReportParameter[19];
                myparams[0] = new ReportParameter("beg_fg_id", beg_fg_id, false);
                myparams[1] = new ReportParameter("end_fg_id", end_fg_id, false);
                myparams[2] = new ReportParameter("beg_customer_id", beg_customer_id, false);
                myparams[3] = new ReportParameter("end_customer_id", end_customer_id, false);
                myparams[4] = new ReportParameter("beg_customer_name", beg_customer_name, false);
                myparams[5] = new ReportParameter("end_customer_name", end_customer_name, false);

                myparams[6] = new ReportParameter("beg_date", beg_date, false);

                myparams[7] = new ReportParameter("end_date", end_date, false);
                myparams[8] = new ReportParameter("beg_inventory_type", beg_inventory_type, false);
                myparams[9] = new ReportParameter("end_inventory_type", end_inventory_type, false);
                myparams[10] = new ReportParameter("beg_sales_rep", beg_sales_rep, false);
                myparams[11] = new ReportParameter("end_sales_rep", end_sales_rep, false);
                myparams[12] = new ReportParameter("beg_shipto_id", beg_shipto_id, false);
                myparams[13] = new ReportParameter("end_shipto_id", end_shipto_id, false);
                myparams[14] = new ReportParameter("beg_order_type", beg_order_type, false);
                myparams[15] = new ReportParameter("end_order_type", end_order_type, false);
                myparams[16] = new ReportParameter("beg_product_code", beg_product_code, false);
                myparams[17] = new ReportParameter("end_product_code", end_product_code, false);
                myparams[18] = new ReportParameter("Sorting_Name", Sorting_Name, false);
                reportViewer.ServerReport.SetParameters(myparams);
                Warning[] warnings;
                string[] streamids;
                string mimeType, encoding, extension, deviceInfo;

                deviceInfo = "True";

                byte[] bytes = reportViewer.ServerReport.Render("CSV", null, out mimeType, out encoding, out extension, out streamids, out warnings);

                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                string FolderPath = "~/VSP";
                bool exists = System.IO.Directory.Exists(Server.MapPath(FolderPath));
                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(FolderPath));
                }

                //string pdfPath = @"D:\Reports\VSP7150." + extension; // Path to export Report.

                string pdfPath = Server.MapPath("~/VSP/VSP7150." + extension);

                //Session["pdfPath"] = pdfPath;

                System.IO.FileStream pdfFile = new System.IO.FileStream(pdfPath, System.IO.FileMode.Create);
                pdfFile.Write(bytes, 0, bytes.Length);
                pdfFile.Close();
                //Response.Flush();
                //Response.End();
                string Link = "http://10.2.0.140/VSPAPPLICATION3/VSP/VSP7150.xls";

                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_AsynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(TempData["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID", 7150);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Name", "Open Pick Ticket Listing");
                    cmd.Parameters.AddWithValue("@Asyn_Report_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Link", Link);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();

                }
                string email = TempData["EmailID"].ToString();
                Mails mail = new Mails();
                string reportName = "VSP7150";
                mail.SendPdfUrl(email, pdfPath, reportName);
                ReportSuccess = "Success";
            }
            catch (Exception e)
            {

                ReportSuccess = "Failed";
            }

            return ReportSuccess;

        }
        public async Task<string> GenerateReport7310()
        {
            string ReportSuccess = "";
            ViewBag.msg = "Report generation process works on background. A confirmation mail will sent to email after report generation.";
            try
            {              
                FormCollection obj = (FormCollection)TempData["ReportView"];
                string DateAdjusted = obj["DateAdjusted"].ToString();
                string beg_AdjustedDate = string.Empty;
                string end_AdjustedDate = string.Empty;

                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(0);
                reportViewer.Height = Unit.Percentage(0);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7310";
                string beg_MaterialItem = obj["txtMaterialItem"].ToString() != "" ? obj["txtMaterialItem"].ToString() : "0";
                string end_MaterialItem = obj["txtMaterialItem2"].ToString() != "" ? obj["txtMaterialItem2"].ToString() : "0";
                string beg_AdjustmentCode = obj["txtAdjustmentLocBeg"].ToString() != "" ? obj["txtAdjustmentLocBeg"].ToString() : "0";
                string end_AdjustmentCode = obj["txtAdjustmentLocEnd"].ToString() != "" ? obj["txtAdjustmentLocEnd"].ToString() : "0";
                if (DateAdjusted == "Between Range")
                {
                    beg_AdjustedDate = obj["DateAdjustedBeg"].ToString();
                    end_AdjustedDate = obj["DateAdjustedEnd"].ToString();
                }
                else if (DateAdjusted == "")
                {
                    beg_AdjustedDate = obj["txtDateAdjustedBeg"].ToString();
                    end_AdjustedDate = obj["txtDateAdjustedEnd"].ToString();
                }
                else if (DateAdjusted == "*All Records")
                {
                    beg_AdjustedDate = obj["txtDateAdjustedBeg"].ToString();
                    end_AdjustedDate = obj["txtDateAdjustedEnd"].ToString();
                    //beg_date = obj["DateShipped1"].ToString();
                    //end_date = obj["DateShipped2"].ToString();
                }
                else
                {
                    beg_AdjustedDate = obj["txtDateAdjustedBeg"].ToString();
                    end_AdjustedDate = obj["DateAdjustedEnd"].ToString();
                }
                ReportParameter[] myparams = new ReportParameter[6];
                myparams[0] = new ReportParameter("beg_MaterialItem", beg_MaterialItem, false);
                myparams[1] = new ReportParameter("end_MaterialItem", end_MaterialItem, false);
                myparams[2] = new ReportParameter("beg_AdjustmentCode", beg_AdjustmentCode, false);
                myparams[3] = new ReportParameter("end_AdjustmentCode", end_AdjustmentCode, false);
                myparams[4] = new ReportParameter("beg_AdjustedDate", beg_AdjustedDate, false);
                myparams[5] = new ReportParameter("end_AdjustedDate", end_AdjustedDate, false);
                reportViewer.ServerReport.SetParameters(myparams);

                Warning[] warnings;
                string[] streamids;
                string mimeType, encoding, extension, deviceInfo;

                deviceInfo = "True";

                byte[] bytes = reportViewer.ServerReport.Render("EXCEL", null, out mimeType, out encoding, out extension, out streamids, out warnings);

                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                string FolderPath = "~/VSP";
                bool exists = System.IO.Directory.Exists(Server.MapPath(FolderPath));
                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(FolderPath));
                }

                //string pdfPath = @"D:\Reports\VSP7150." + extension; // Path to export Report.

                string pdfPath = Server.MapPath("~/VSP/VSP7310." + extension);              

                System.IO.FileStream pdfFile = new System.IO.FileStream(pdfPath, System.IO.FileMode.Create);
                pdfFile.Write(bytes, 0, bytes.Length);
                pdfFile.Close();
                //Response.Flush();
                //Response.End();
                string Link = "http://10.2.0.140/VSPAPPLICATION3/VSP/VSP7310.xls";
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_AsynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(TempData["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID", 7310);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Name", "Material Adjustments");
                    cmd.Parameters.AddWithValue("@Asyn_Report_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Link", Link);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();
                }
                string email = TempData["EmailID"].ToString();             
                Mails mail = new Mails();
                string reportName = "VSP7310";
                mail.SendPdfUrl(email, pdfPath, reportName);
                ReportSuccess = "Success";
            }
            catch (Exception e)
            {

                ReportSuccess = "Failed";
            }

            return ReportSuccess;

        }
        public async Task<string> GenerateReport7890()
        {
            string ReportSuccess = "";
            ViewBag.msg = "Report generation process works on background. A confirmation mail will sent to email after report generation.";
            try
            {
                string DateEnteredCCM = TempData["DateShipped"].ToString();

                FormCollection obj = (FormCollection)TempData["ReportView"];
                ViewBag.DateEnteredCCM1 = obj["DateEnteredCCM1"].ToString();
                ViewBag.DateEnteredCCM2 = obj["DateEnteredCCM2"].ToString();
                ViewBag.txtDateEnteredCCMrangevaltext1 = obj["txtDateEnteredCCMrangevaltext1"].ToString();
                ViewBag.txtDateEnteredCCMrangevaltext2 = obj["txtDateEnteredCCMrangevaltext2"].ToString();

                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(0);
                reportViewer.Height = Unit.Percentage(0);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7890";
                string beg_cc_id = obj["CostCenterMajor1CCM"].ToString() != "" ? obj["CostCenterMajor1CCM"].ToString() : "0";
                string end_cc_id = obj["CostCenterMajor2CCM"].ToString() != "" ? obj["CostCenterMajor2CCM"].ToString() : "0";
                string beg_date = string.Empty;
                string end_date = string.Empty;
                if (DateEnteredCCM == "Between Range")
                {
                    beg_date = obj["DateEnteredCCM1"].ToString();
                    end_date = obj["DateEnteredCCM2"].ToString();
                }
                else if (DateEnteredCCM == "")
                {
                    beg_date = obj["DateEnteredCCM1"].ToString();
                    end_date = obj["DateEnteredCCM2"].ToString();
                }
                else if (DateEnteredCCM == "*All Records")
                {
                    beg_date = obj["txtDateEnteredCCMrangevaltext1"].ToString();
                    end_date = obj["txtDateEnteredCCMrangevaltext2"].ToString();
                    //beg_date = obj["DateShipped1"].ToString();
                    //end_date = obj["DateShipped2"].ToString();
                }
                else
                {
                    beg_date = obj["txtDateEnteredCCMrangevaltext1"].ToString();
                    end_date = obj["DateEnteredCCM2"].ToString();
                }

                ReportParameter[] myparams = new ReportParameter[4];
                myparams[0] = new ReportParameter("beg_cc_id", beg_cc_id, false);
                myparams[1] = new ReportParameter("end_cc_id", end_cc_id, false);
                myparams[2] = new ReportParameter("beg_date", beg_date, false);
                myparams[3] = new ReportParameter("end_date", end_date, false);
                reportViewer.ServerReport.SetParameters(myparams);


                Warning[] warnings;
                string[] streamids;
                string mimeType, encoding, extension, deviceInfo;

                deviceInfo = "True";

                byte[] bytes = reportViewer.ServerReport.Render("EXCEL", null, out mimeType, out encoding, out extension, out streamids, out warnings);

                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                string FolderPath = "~/VSP";
                bool exists = System.IO.Directory.Exists(Server.MapPath(FolderPath));
                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(FolderPath));
                }

                //string pdfPath = @"D:\Reports\VSP7150." + extension; // Path to export Report.

                string pdfPath = Server.MapPath("~/VSP/VSP7890." + extension);

                Session["pdfPath"] = pdfPath;

                System.IO.FileStream pdfFile = new System.IO.FileStream(pdfPath, System.IO.FileMode.Create);
                pdfFile.Write(bytes, 0, bytes.Length);
                pdfFile.Close();
                //Response.Flush();
                //Response.End();

                ReportSuccess = "Success";
            }
            catch (Exception e)
            {

                ReportSuccess = "Failed";
            }

            return ReportSuccess;

        }
        public async Task<string> GenerateReport8610()
        {
            string ReportSuccess = "";
            ViewBag.msg = "Report generation process works on background. A confirmation mail will sent to email after report generation.";
            try
            {
                string DateCC = TempData["DateShipped"].ToString();

                FormCollection obj = (FormCollection)TempData["ReportView"];
                ViewBag.DateCC1 = obj["DateCC1"].ToString();
                ViewBag.DateCC2 = obj["DateCC2"].ToString();
                ViewBag.txtDateCCrangevaltext1 = obj["txtDateCCrangevaltext1"].ToString();
                ViewBag.txtDateCCrangevaltext2 = obj["txtDateCCrangevaltext2"].ToString();

                //dynamic mymodel = new ExpandoObject();
                ViewBag.CostCenter1CC = "*All Records";
                ViewBag.CostCenter2CC = "0";
                ViewBag.DateCC1 = "*All Records";
                ViewBag.DateCC2 = "0";
                ViewBag.txtDateCCrangevaltext1 = "*All Records";
                ViewBag.txtDateCCrangevaltext2 = "0";
            

                ViewBag.DateCC1 = obj["DateCC1"].ToString();
                ViewBag.DateCC2 = obj["DateCC2"].ToString();
                ViewBag.txtDateCCrangevaltext1 = obj["txtDateCCrangevaltext1"].ToString();
                ViewBag.txtDateCCrangevaltext2 = obj["txtDateCCrangevaltext2"].ToString();

                //mymodel.CostCenter = GeCostCenterMajor2();
                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(0);
                reportViewer.Height = Unit.Percentage(0);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP8610";
                string beg_cc_id = obj["CostCenter1CC"].ToString() != "" ? obj["CostCenter1CC"].ToString() : "0";
                string end_cc_id = obj["CostCenter2CC"].ToString() != "" ? obj["CostCenter2CC"].ToString() : "0";
                string beg_date = string.Empty;
                string end_date = string.Empty;

                if (DateCC == "Between Range")
                {
                    beg_date = obj["DateCC1"].ToString();
                    end_date = obj["DateCC2"].ToString();
                }
                else if (DateCC == "")
                {
                    beg_date = obj["DateCC1"].ToString();
                    end_date = obj["DateCC2"].ToString();
                }
                else if (DateCC == "*All Records")
                {
                    beg_date = obj["txtDateCCrangevaltext1"].ToString();
                    end_date = obj["txtDateCCrangevaltext2"].ToString();

                }
                else
                {
                    beg_date = obj["txtDateCCrangevaltext1"].ToString();
                    end_date = obj["DateCC2"].ToString();
                }

                ReportParameter[] myparams = new ReportParameter[4];
                myparams[0] = new ReportParameter("beg_cc_id", beg_cc_id, false);
                myparams[1] = new ReportParameter("end_cc_id", end_cc_id, false);
                myparams[2] = new ReportParameter("beg_date", beg_date, false);
                myparams[3] = new ReportParameter("end_date", end_date, false);
                reportViewer.ServerReport.SetParameters(myparams);


                Warning[] warnings;
                string[] streamids;
                string mimeType, encoding, extension, deviceInfo;

                deviceInfo = "True";

                byte[] bytes = reportViewer.ServerReport.Render("EXCEL", null, out mimeType, out encoding, out extension, out streamids, out warnings);

                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                string FolderPath = "~/VSP";
                bool exists = System.IO.Directory.Exists(Server.MapPath(FolderPath));
                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(FolderPath));
                }

                //string pdfPath = @"D:\Reports\VSP7150." + extension; // Path to export Report.

                string pdfPath = Server.MapPath("~/VSP/VSP8610." + extension);

                //Session["pdfPath"] = pdfPath;

                System.IO.FileStream pdfFile = new System.IO.FileStream(pdfPath, System.IO.FileMode.Create);
                pdfFile.Write(bytes, 0, bytes.Length);
                pdfFile.Close();
                //Response.Flush();
                //Response.End();
                string Link = "http://10.2.0.140/VSPAPPLICATION3/VSP/VSP8610.xls";
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_AsynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(TempData["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID", 8610);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Name", "Square Feet Per Hour Summery");
                    cmd.Parameters.AddWithValue("@Asyn_Report_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Link", Link);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();
                }
             
                string email = TempData["EmailID"].ToString();              
                Mails mail = new Mails();
                string reportName = "VSP8610";
                mail.SendPdfUrl(email, pdfPath, reportName);
                ReportSuccess = "Success";
            }
            catch (Exception e)
            {

                ReportSuccess = "Failed";
            }

            return ReportSuccess;

        }
        public async Task<string> GenerateReport8620()
        {            
            ViewBag.DateSFPHD = string.Empty;
            ViewBag.DateSFPHD1 = string.Empty;
            string cost = TempData["CostCenterSFPHD"].ToString();
            ViewBag.DateSFPHDrangevaltext1 = string.Empty;
            ViewBag.DateSFPHDrangevaltext2 = string.Empty;
            string ReportSuccess = "";
            ViewBag.msg = "Report generation process works on background. A confirmation mail will sent to email after report generation.";
            try
            {
                string DateSFPHD = TempData["DateShipped"].ToString();

                FormCollection obj = (FormCollection)TempData["ReportView"];
               
                dynamic mymodel = new ExpandoObject();
                ViewBag.CostCenter1 = "*All Records";
                ViewBag.CostCenter2 = "0";
                ViewBag.DateSFPHD1 = "*All Records";
                ViewBag.DateSFPHD2 = "0";
                ViewBag.DateSFPHDrangevaltext1 = "*All Records";
                ViewBag.DateSFPHDrangevaltext2 = "0";
                ViewBag.DateSFPHD1 = obj["DateSFPHD1"].ToString();
                ViewBag.DateSFPHD2 = obj["DateSFPHD2"].ToString();
                ViewBag.DateSFPHDrangevaltext1 = obj["DateSFPHDrangevaltext1"].ToString();
                ViewBag.DateSFPHDrangevaltext2 = obj["DateSFPHDrangevaltext2"].ToString();
                ViewBag.CostCenterSFPHD = cost;
                ViewBag.DateSFPHD = DateSFPHD;
                mymodel.CostCenterMajor2 = GeCostCenterMajor2();
                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(0);
                reportViewer.Height = Unit.Percentage(0);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP8620";
                string beg_cc_id = obj["CostCenter1SFPHD"].ToString() != "" ? obj["CostCenter1SFPHD"].ToString() : "0";
                string end_cc_id = obj["CostCenter2SFPHD"].ToString() != "" ? obj["CostCenter2SFPHD"].ToString() : "0";
                string beg_date = string.Empty;
                string end_date = string.Empty;
                if (DateSFPHD == "Between Range")
                {
                    beg_date = obj["DateSFPHD1"].ToString();
                    end_date = obj["DateSFPHD2"].ToString();
                }
                else if (DateSFPHD == "")
                {
                    beg_date = obj["DateSFPHD1"].ToString();
                    end_date = obj["DateSFPHD2"].ToString();
                }
                else if (DateSFPHD == "*All Records")
                {
                    beg_date = obj["DateSFPHDrangevaltext1"].ToString();
                    end_date = obj["DateSFPHDrangevaltext2"].ToString();
                    //beg_date = obj["DateShipped1"].ToString();
                    //end_date = obj["DateShipped2"].ToString();
                }
                else
                {
                    beg_date = obj["DateSFPHDrangevaltext1"].ToString();
                    end_date = obj["DateSFPHD2"].ToString();
                }

                ReportParameter[] myparams = new ReportParameter[4];
                myparams[0] = new ReportParameter("beg_cc_id", beg_cc_id, false);
                myparams[1] = new ReportParameter("end_cc_id", end_cc_id, false);
                myparams[2] = new ReportParameter("beg_date", beg_date, false);
                myparams[3] = new ReportParameter("end_date", end_date, false);
                reportViewer.ServerReport.SetParameters(myparams);


                Warning[] warnings;
                string[] streamids;
                string mimeType, encoding, extension, deviceInfo;

                deviceInfo = "True";
                //byte[] result = reportViewer.ServerReport.Render("EXCEL", out deviceInfo, out extension, out mimeType, out encoding, out warnings, out streamids);
                byte[] bytes = reportViewer.ServerReport.Render("EXCELOPENXML", null, out mimeType, out encoding, out extension, out streamids, out warnings);
                              
                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                string FolderPath = "~/VSP";
                bool exists = System.IO.Directory.Exists(Server.MapPath(FolderPath));
                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(FolderPath));
                }

                string pdfPath = Server.MapPath("~/VSP/VSP8620." + extension);              

                System.IO.FileStream pdfFile = new System.IO.FileStream(pdfPath, System.IO.FileMode.Create);
                pdfFile.Write(bytes, 0, bytes.Length);
                pdfFile.Close();
                //Response.Flush();
                //Response.End();
                string Link = "http://10.2.0.140/VSPAPPLICATION3/VSP/VSP8620.xls";
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_AsynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(TempData["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID", 8620);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Name", "Square Feet Per Hour Details");
                    cmd.Parameters.AddWithValue("@Asyn_Report_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Link", Link);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();
                }
                string email = TempData["EmailID"].ToString();              
                Mails mail = new Mails();
                string reportName = "VSP8620";
                mail.SendPdfUrl(email, pdfPath, reportName);
                ReportSuccess = "Success";
            }
            catch (Exception e)
            {

                ReportSuccess = "Failed";
            }
            return ReportSuccess;
        }
        public async Task<string> GenerateReport7820()
        {
            string ReportSuccess = "";
            ViewBag.msg = "Report generation process works on background. A confirmation mail will sent to email after report generation.";
            try
            {
                FormCollection obj = (FormCollection)TempData["ReportView"];
                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
          
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(900);
                reportViewer.Height = Unit.Percentage(900);
                
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7820_MainRep";
                string beg_mst_job = obj["txtMasterJob"].ToString() != "" ? obj["txtMasterJob"].ToString() : "0";
                string end_mst_job = obj["txtMasterJob2"].ToString() != "" ? obj["txtMasterJob2"].ToString() : "0";

                ReportParameter[] myparams = new ReportParameter[2];
                myparams[0] = new ReportParameter("beg_mst_job", beg_mst_job, false);
                myparams[1] = new ReportParameter("end_mst_job", end_mst_job, false);
                reportViewer.ServerReport.SetParameters(myparams);
                Warning[] warnings;
                string[] streamids;
                string mimeType, encoding, extension, deviceInfo;

                deviceInfo = "True";

                byte[] bytes = reportViewer.ServerReport.Render("EXCEL", null, out mimeType, out encoding, out extension, out streamids, out warnings);
                
               
                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                string FolderPath = "~/VSP";
                bool exists = System.IO.Directory.Exists(Server.MapPath(FolderPath));
                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(FolderPath));
                }             

                string pdfPath = Server.MapPath("~/VSP/VSP7820." + extension);              

                System.IO.FileStream pdfFile = new System.IO.FileStream(pdfPath, System.IO.FileMode.Create);
                pdfFile.Write(bytes, 0, bytes.Length);
                pdfFile.Close();
                //Response.Flush();
                //Response.End();

                string Link = "http://10.2.0.140/VSPAPPLICATION3/VSP/VSP7820.xls";

                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_AsynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(TempData["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID", 7820);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Name", "Profit Detail");
                    cmd.Parameters.AddWithValue("@Asyn_Report_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Link", Link);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();

                }
                string email = TempData["EmailID"].ToString();
                Mails mail = new Mails();
                string reportName = "VSP7820";
                mail.SendPdfUrl(email, pdfPath, reportName);
                ReportSuccess = "Success";
            }
            catch (Exception e)
            {
                ReportSuccess = "Failed";
            }

            return ReportSuccess;

        }
        public async Task<string> GenerateReport7330()
        {
            string ReportSuccess = "";
            ViewBag.msg = "Report generation process works on background. A confirmation mail will sent to email after report generation.";
            try
            {
                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(900);
                reportViewer.Height = Unit.Percentage(900);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7330";
                FormCollection obj = (FormCollection)TempData["ReportView"];
                string beg_box_set = obj["BoxSetID1BL"].ToString() != "" ? obj["BoxSetID1BL"].ToString() : "0";
                string end_box_set = obj["BoxSetID2BL"].ToString() != "" ? obj["BoxSetID2BL"].ToString() : "0";

                ReportParameter[] myparams = new ReportParameter[2];
                myparams[0] = new ReportParameter("beg_box_set", beg_box_set, false);
                myparams[1] = new ReportParameter("end_box_set", end_box_set, false);
                reportViewer.ServerReport.SetParameters(myparams);
                Warning[] warnings;
                string[] streamids;
                string mimeType, encoding, extension, deviceInfo;

                deviceInfo = "True";

                byte[] bytes = reportViewer.ServerReport.Render("EXCEL", null, out mimeType, out encoding, out extension, out streamids, out warnings);

                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                string FolderPath = "~/VSP/";
                bool exists = System.IO.Directory.Exists(Server.MapPath(FolderPath));
                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(FolderPath));
                }              

                string pdfPath = Server.MapPath("~/VSP/VSP7330." + extension);

                Session["pdfPath"] = pdfPath;

                System.IO.FileStream pdfFile = new System.IO.FileStream(pdfPath, System.IO.FileMode.Create);
                pdfFile.Write(bytes, 0, bytes.Length);
                pdfFile.Close();
                //Response.Flush();
                //Response.End();

                ReportSuccess = "Success";
            }
            catch (Exception e)
            {
                ReportSuccess = "Failed";
            }
            return ReportSuccess;

        }
        public async Task<string> GenerateReport9170()
        {
            string ReportSuccess = "";
            ViewBag.msg = "Report generation process works on background. A confirmation mail will sent to email after report generation.";
            try
            {
                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(900);
                reportViewer.Height = Unit.Percentage(900);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP9170";
                FormCollection obj = (FormCollection)TempData["ReportView"];
                string DatetoShip_Beg = string.Empty;
                string DatetoShip_End = string.Empty;
                string DateOrdered_Beg = string.Empty;
                string DateOrdered_End = string.Empty;
              
                string DatetoShip = obj["DatetoShip"].ToString();
                string DateOrdered = obj["DateOrdered"].ToString();
                string FinishGoodsID_Beg = obj["FinishGoodsID_Beg"].ToString() != "" ? obj["FinishGoodsID_Beg"].ToString() : "0";
                string FinishGoodsID_End = obj["FinishGoodsID_End"].ToString() != "" ? obj["FinishGoodsID_End"].ToString() : "0";
                string CustomerID_Beg = obj["CustomerID_Beg"].ToString() != "" ? obj["CustomerID_Beg"].ToString() : "0";
                string CustomerID_End = obj["CustomerID_End"].ToString() != "" ? obj["CustomerID_End"].ToString() : "0";
                if (DatetoShip == "Between Range")
                {
                    DatetoShip_Beg = obj["DatetoShip_Beg"].ToString();
                    DatetoShip_End = obj["DatetoShip_End"].ToString();
                }
                else if (DatetoShip == "")
                {
                    DatetoShip_Beg = obj["txtDatetoShip_Beg"].ToString();
                    DatetoShip_End = obj["txtDatetoShip_End"].ToString();
                }
                else if (DatetoShip == "*All Records")
                {
                    DatetoShip_Beg = obj["txtDatetoShip_Beg"].ToString();
                    DatetoShip_End = obj["txtDatetoShip_End"].ToString();

                }
                else
                {
                    DatetoShip_Beg = obj["txtDatetoShip_Beg"].ToString();
                    DatetoShip_End = obj["DatetoShip_End"].ToString();
                }

                if (DateOrdered == "Between Range")
                {
                    DateOrdered_Beg = obj["DateOrdered_Beg"].ToString();
                    DateOrdered_End = obj["DateOrdered_End"].ToString();
                }
                else if (DateOrdered == "")
                {
                    DateOrdered_Beg = obj["txtDateOrdered_Beg"].ToString();
                    DateOrdered_End = obj["txtDateOrdered_End"].ToString();
                }
                else if (DateOrdered == "*All Records")
                {
                    DateOrdered_Beg = obj["txtDateOrdered_Beg"].ToString();
                    DateOrdered_End = obj["txtDateOrdered_End"].ToString();

                }
                else
                {
                    DateOrdered_Beg = obj["txtDateOrdered_Beg"].ToString();
                    DateOrdered_End = obj["DateOrdered_End"].ToString();
                }
                string CustomerPo_Beg = obj["CustomerPo_Beg"].ToString() != "" ? obj["CustomerPo_Beg"].ToString() : "0";
                string CustomerPo_End = obj["CustomerPo_End"].ToString() != "" ? obj["CustomerPo_End"].ToString() : "0";
                string ShippingLocatoin_Beg = obj["ShippingLocatoin_Beg"].ToString() != "" ? obj["ShippingLocatoin_Beg"].ToString() : "0";
                string ShippingLocatoin_End = obj["ShippingLocatoin_End"].ToString() != "" ? obj["ShippingLocatoin_End"].ToString() : "0";
                string OrderType_Beg = obj["OrderType_Beg"].ToString() != "" ? obj["OrderType_Beg"].ToString() : "0";
                string OrderType_End = obj["OrderType_End"].ToString() != "" ? obj["OrderType_End"].ToString() : "0";
                string ProductCode_Beg = obj["ProductCode_Beg"].ToString() != "" ? obj["ProductCode_Beg"].ToString() : "0";
                string ProductCode_End = obj["ProductCode_End"].ToString() != "" ? obj["ProductCode_End"].ToString() : "0";
                //string beg_product_code = obj["ProductCode1"].ToString() != "" ? obj["ProductCode1"].ToString() : "0"; 
                //string end_product_code = obj["ProductCode2"].ToString() != "" ? obj["ProductCode2"].ToString() : "0"; 
                //string dllCustPoNo = obj["dllCustPoNo"].ToString();
                ReportParameter[] myparams = new ReportParameter[16];
                myparams[0] = new ReportParameter("BegFGItem", FinishGoodsID_Beg, false);
                myparams[1] = new ReportParameter("EndFGItem", FinishGoodsID_End, false);
                myparams[2] = new ReportParameter("BegCust", CustomerID_Beg, false);
                myparams[3] = new ReportParameter("EndCust", CustomerID_End, false);
                myparams[4] = new ReportParameter("BegShipDate", DatetoShip_Beg, false);
                myparams[5] = new ReportParameter("EndShipDate", DatetoShip_End, false);
                myparams[6] = new ReportParameter("BegCustomerPO", CustomerPo_Beg, false);
                myparams[7] = new ReportParameter("EndCustomerPO", CustomerPo_End, false);
                myparams[8] = new ReportParameter("BegShipLocation", ShippingLocatoin_Beg, false);
                myparams[9] = new ReportParameter("EndShipLocation", ShippingLocatoin_End, false);
                myparams[10] = new ReportParameter("BegOrderType", OrderType_Beg, false);
                myparams[11] = new ReportParameter("EndOrderType", OrderType_End, false);
                myparams[12] = new ReportParameter("BegProductCode", ProductCode_Beg, false);
                myparams[13] = new ReportParameter("EndProductCode", ProductCode_End, false);
                myparams[14] = new ReportParameter("BegOrderedDate", DateOrdered_Beg, false);
                myparams[15] = new ReportParameter("EndOrderedDate", DateOrdered_End, false);
                //myparams[16] = new ReportParameter("Sorting_Name", dllCustPoNo, false);
                reportViewer.ServerReport.SetParameters(myparams);
                Warning[] warnings;
                string[] streamids;
                string mimeType, encoding, extension, deviceInfo;

                deviceInfo = "True";

                byte[] bytes = reportViewer.ServerReport.Render("EXCEL", null, out mimeType, out encoding, out extension, out streamids, out warnings);

                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                string FolderPath = "~/VSP";
                bool exists = System.IO.Directory.Exists(Server.MapPath(FolderPath));
                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(FolderPath));
                }              

                string pdfPath = Server.MapPath("~/VSP/VSP9170." + extension);             

                System.IO.FileStream pdfFile = new System.IO.FileStream(pdfPath, System.IO.FileMode.Create);
                pdfFile.Write(bytes, 0, bytes.Length);
                pdfFile.Close();
                //Response.Flush();
                //Response.End();
                string Link = "http://10.2.0.140/VSPAPPLICATION3/VSP/VSP9170.xls";
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_AsynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(TempData["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID", 9170);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Name", "Open Pick Ticket Listing");
                    cmd.Parameters.AddWithValue("@Asyn_Report_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Link", Link);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();
                }
                string email = TempData["EmailID"].ToString();           
                Mails mail = new Mails();
                string reportName = "VSP9170";
                mail.SendPdfUrl(email, pdfPath, reportName);
                ReportSuccess = "Success";
            }
            catch (Exception e)
            {
                ReportSuccess = "Failed";
            }
            return ReportSuccess;

        }
        public async Task<string> GenerateReport7160()
        {
            string ReportSuccess = "";
            ViewBag.msg = "Report generation process works on background. A confirmation mail will sent to email after report generation.";
            try
            {
                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(900);
                reportViewer.Height = Unit.Percentage(900);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7160";
                FormCollection obj = (FormCollection)TempData["ReportView"];
                string beg_material_id = obj["MaterialID1MU"].ToString() != "" ? obj["MaterialID1MU"].ToString() : "0";
                string end_material_id = obj["MaterialID2MU1"].ToString() != "" ? obj["MaterialID2MU1"].ToString() : "0";
                string beg_size_code = obj["SizeCode1MU"].ToString() != "" ? obj["SizeCode1MU"].ToString() : "0";
                string end_size_code = obj["SizeCode2MU"].ToString() != "" ? obj["SizeCode2MU"].ToString() : "0";
                string beg_date = string.Empty;
                string end_date = string.Empty;
                string DateShipped = obj["DateShipped"].ToString();
                if (DateShipped == "Between Range")
                {
                    beg_date = obj["DateShipped1"].ToString();
                    end_date = obj["DateShipped2"].ToString();
                }
                else if (DateShipped == "")
                {
                    beg_date = obj["DateShipped1"].ToString();
                    end_date = obj["DateShipped2"].ToString();
                }
                else if (DateShipped == "*All Records")
                {
                    beg_date = obj["rangevaltext"].ToString();
                    end_date = obj["rangevaltext1"].ToString();
                    //beg_date = obj["DateShipped1"].ToString();
                    //end_date = obj["DateShipped2"].ToString();
                }
                else
                {
                    beg_date = obj["rangevaltext"].ToString();
                    end_date = obj["DateShipped2"].ToString();
                }
                string beg_fg_id = obj["FinishGoodItem1MU"].ToString() != "" ? obj["FinishGoodItem1MU"].ToString() : "0";
                string end_fg_id = obj["FinishGoodItem2MU"].ToString() != "" ? obj["FinishGoodItem2MU"].ToString() : "0";
                string beg_inventory_type = obj["InventoryType1MU"].ToString() != "" ? obj["InventoryType1MU"].ToString() : "0";
                string end_inventory_type = obj["InventoryType2MU"].ToString() != "" ? obj["InventoryType2MU"].ToString() : "0";
                string beg_customer_id = obj["CustomerID1MU"].ToString() != "" ? obj["CustomerID1MU"].ToString() : "0";
                string end_customer_id = obj["CustomerID2MU"].ToString() != "" ? obj["CustomerID2MU"].ToString() : "0";
                string beg_customer_name = obj["CustomerName1MU"].ToString() != "" ? obj["CustomerName1MU"].ToString() : "0";
                string end_customer_name = obj["CustomerName2MU"].ToString() != "" ? obj["CustomerName2MU"].ToString() : "0";
                string Sorting_Name = String.Empty;
                if (obj["dllsorting"].ToString() == "Inventory Type")
                {
                    Sorting_Name = "Inventory Type";
                }
                else
                {
                    Sorting_Name = "Sheet Size";
                }
                ReportParameter[] myparams = new ReportParameter[15];
                myparams[0] = new ReportParameter("beg_material_id", beg_material_id, false);
                myparams[1] = new ReportParameter("end_material_id", end_material_id, false);
                myparams[2] = new ReportParameter("beg_size_code", beg_size_code, false);
                myparams[3] = new ReportParameter("end_size_code", end_size_code, false);
                myparams[4] = new ReportParameter("beg_date", beg_date, false);
                myparams[5] = new ReportParameter("end_date", end_date, false);
                myparams[6] = new ReportParameter("beg_fg_id", beg_fg_id, false);
                myparams[7] = new ReportParameter("end_fg_id", end_fg_id, false);
                myparams[8] = new ReportParameter("beg_inventory_type", beg_inventory_type, false);
                myparams[9] = new ReportParameter("end_inventory_type", end_inventory_type, false);
                myparams[10] = new ReportParameter("beg_customer_id", beg_customer_id, false);
                myparams[11] = new ReportParameter("end_customer_id", end_customer_id, false);
                myparams[12] = new ReportParameter("beg_customer_name", beg_customer_name, false);
                myparams[13] = new ReportParameter("end_customer_name", end_customer_name, false);
                myparams[14] = new ReportParameter("Sorting_Name", Sorting_Name, false);
                reportViewer.ServerReport.SetParameters(myparams);
                Warning[] warnings;
                string[] streamids;
                string mimeType, encoding, extension, deviceInfo;

                deviceInfo = "True";

                byte[] bytes = reportViewer.ServerReport.Render("EXCELOPENXML", null, out mimeType, out encoding, out extension, out streamids, out warnings);

                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                string FolderPath = "~/VSP";
                bool exists = System.IO.Directory.Exists(Server.MapPath(FolderPath));
                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(FolderPath));
                }

                //string pdfPath = @"D:\Reports\VSP7150." + extension; // Path to export Report.

                string pdfPath = Server.MapPath("~/VSP/VSP7160." + extension);              

                System.IO.FileStream pdfFile = new System.IO.FileStream(pdfPath, System.IO.FileMode.Create);
                pdfFile.Write(bytes, 0, bytes.Length);
                pdfFile.Close();
                //Response.Flush();
                //Response.End();
                string Link = "http://10.2.0.140/VSPAPPLICATION3/VSP/VSP7160.xls";
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_AsynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(TempData["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID", 7160);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Name", "Material Usage");
                    cmd.Parameters.AddWithValue("@Asyn_Report_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Link", Link);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();

                }
                string email = TempData["EmailID"].ToString();             
                Mails mail = new Mails();
                string reportName = "VSP7160";
                mail.SendPdfUrl(email, pdfPath, reportName);
                ReportSuccess = "Success";
            }
            catch (Exception e)
            {
                ReportSuccess = "Failed";
            }
            return ReportSuccess;

        }
        public async Task<string> GenerateReport7830()
        {
            string ReportSuccess = "";
            ViewBag.msg = "Report generation process works on background. A confirmation mail will sent to email after report generation.";
            try
            {
                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(900);
                reportViewer.Height = Unit.Percentage(900);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7830";
                string DateShipped = TempData["DateShipped"].ToString();
                FormCollection obj = (FormCollection)TempData["ReportView"];
                string beg_date = string.Empty;
                string end_date = string.Empty;
                string beg_industry = obj["IndustryCode1SBP"].ToString() != "" ? obj["IndustryCode1SBP"].ToString() : "0";
                string end_industry = obj["IndustryCode2SBP"].ToString() != "" ? obj["IndustryCode2SBP"].ToString() : "0";
                string beg_product = obj["ProductCode1SBP"].ToString() != "" ? obj["ProductCode1SBP"].ToString() : "0";
                string end_product = obj["ProductCode2SBP"].ToString() != "" ? obj["ProductCode2SBP"].ToString() : "0";
                string beg_product_desc = obj["ProductDescription1SBP"].ToString() != "" ? obj["ProductDescription1SBP"].ToString() : "0";
                string end_product_desc = obj["ProductDescription2SBP"].ToString() != "" ? obj["ProductDescription2SBP"].ToString() : "0";
                string beg_sales = obj["SalesRepID1SBP"].ToString() != "" ? obj["SalesRepID1SBP"].ToString() : "0";
                string end_sales = obj["SalesRepID2SBP"].ToString() != "" ? obj["SalesRepID2SBP"].ToString() : "0";

                if (DateShipped == "Between Range")
                {
                    beg_date = obj["DateShipped1"].ToString();
                    end_date = obj["DateShipped2"].ToString();
                }
                else if (DateShipped == "")
                {
                    beg_date = obj["DateShipped1"].ToString();
                    end_date = obj["DateShipped2"].ToString();
                }
                else if (DateShipped == "*All Records")
                {
                    beg_date = obj["rangevaltext"].ToString();
                    end_date = obj["rangevaltext1"].ToString();
                    //beg_date = obj["DateShipped1"].ToString();
                    //end_date = obj["DateShipped2"].ToString();
                }
                else
                {
                    beg_date = obj["rangevaltext"].ToString();
                    end_date = obj["DateShipped2"].ToString();
                }

                //string end_date_wanted = obj["DateShipped2"].ToString();
                ReportParameter[] myparams = new ReportParameter[10];
                myparams[0] = new ReportParameter("beg_industry", beg_industry, false);
                myparams[1] = new ReportParameter("end_industry", end_industry, false);
                myparams[2] = new ReportParameter("beg_product", beg_product, false);
                myparams[3] = new ReportParameter("end_product", end_product, false);
                myparams[4] = new ReportParameter("beg_product_desc", beg_product_desc, false);
                myparams[5] = new ReportParameter("end_product_desc", end_product_desc, false);
                myparams[6] = new ReportParameter("beg_sales", beg_sales, false);
                myparams[7] = new ReportParameter("end_sales", end_sales, false);
                myparams[8] = new ReportParameter("beg_date_wanted", beg_date, false);
                myparams[9] = new ReportParameter("end_date_wanted", end_date, false);
                reportViewer.ServerReport.SetParameters(myparams);
                Warning[] warnings;
                string[] streamids;
                string mimeType, encoding, extension, deviceInfo;

                deviceInfo = "True";

                byte[] bytes = reportViewer.ServerReport.Render("EXCEL", null, out mimeType, out encoding, out extension, out streamids, out warnings);

                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                string FolderPath = "~/VSP";
                bool exists = System.IO.Directory.Exists(Server.MapPath(FolderPath));
                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(FolderPath));
                }

                //string pdfPath = @"D:\Reports\VSP7150." + extension; // Path to export Report.

                string pdfPath = Server.MapPath("~/VSP/VSP7830." + extension);             

                System.IO.FileStream pdfFile = new System.IO.FileStream(pdfPath, System.IO.FileMode.Create);
                pdfFile.Write(bytes, 0, bytes.Length);
                pdfFile.Close();
                //Response.Flush();
                //Response.End();
                string Link = "http://10.2.0.140/VSPAPPLICATION3/VSP/VSP7830.xls";
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_AsynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(TempData["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID", 7830);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Name", "Sales By Product");
                    cmd.Parameters.AddWithValue("@Asyn_Report_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Link", Link);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();
                }
                string email = TempData["EmailID"].ToString();             
                Mails mail = new Mails();
                string reportName = "VSP7830";
                mail.SendPdfUrl(email, pdfPath, reportName);
                ReportSuccess = "Success";
            }
            catch (Exception e)
            {
                ReportSuccess = "Failed";
            }
            return ReportSuccess;

        }
        public async Task<string> GenerateReport9160()
        {
            string ReportSuccess = "";
            ViewBag.msg = "Report generation process works on background. A confirmation mail will sent to email after report generation.";
            try
            {
                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(900);
                reportViewer.Height = Unit.Percentage(900);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP9160";
                string DateLastActivity = TempData["DateLastActivity"].ToString();
                string DateLastRecieved = TempData["DateLastRecieved"].ToString();
                string DateLastShiped = TempData["DateLastShiped"].ToString();
                string DateLastAdjusted = TempData["DateLastAdjusted"].ToString();
                FormCollection obj = (FormCollection)TempData["ReportView"];
                string beg_date_activity = string.Empty;
                string end_date_activity = string.Empty;
                string beg_date_received = string.Empty;
                string end_date_received = string.Empty;
                string beg_date_shipped = string.Empty;
                string end_date_shipped = string.Empty;
                string beg_date_adjusted = string.Empty;
                string end_date_adjusted = string.Empty;

                string beg_finish_goods_id = obj["FinishGoodsIDFGCC"].ToString() != "" ? obj["FinishGoodsIDFGCC"].ToString() : "0";
                string end_finish_goods_id = obj["FinishGoodsID2FGCC"].ToString() != "" ? obj["FinishGoodsID2FGCC"].ToString() : "0";
                string beg_finish_goods_name = obj["Description1FGCC"].ToString() != "" ? obj["Description1FGCC"].ToString() : "0";
                string end_finish_goods_name = obj["Description2FGCC"].ToString() != "" ? obj["Description2FGCC"].ToString() : "0";
                string beg_inventory_type = obj["InventoryType1FGCC"].ToString() != "" ? obj["InventoryType1FGCC"].ToString() : "0";
                string end_inventory_type = obj["InventoryType2FGCC"].ToString() != "" ? obj["InventoryType2FGCC"].ToString() : "0";
                string beg_kind = obj["Kindcode1FGCC"].ToString() != "" ? obj["Kindcode1FGCC"].ToString() : "0";
                string end_kind = obj["Kindcode2FGCC"].ToString() != "" ? obj["Kindcode2FGCC"].ToString() : "0";
                string beg_warehouse = obj["Warehouse1FGCC"].ToString() != "" ? obj["Warehouse1FGCC"].ToString() : "0";
                string end_warehouse = obj["Warehouse2FGCC"].ToString() != "" ? obj["Warehouse2FGCC"].ToString() : "0";
                string beg_location = obj["Location1FGCC"].ToString() != "" ? obj["Location1FGCC"].ToString() : "0";
                string end_location = obj["Location2FGCC"].ToString() != "" ? obj["Location2FGCC"].ToString() : "0";
                //Date Last Activity
                if (DateLastActivity == "Between Range")
                {
                    beg_date_activity = obj["DateLastActivity1FGCC"].ToString();
                    end_date_activity = obj["DateLastActivity2FGCC"].ToString();
                }
                else if (DateLastActivity == "")
                {
                    beg_date_activity = obj["DateLastActivity1FGCC"].ToString();
                    end_date_activity = obj["DateLastActivity2FGCC"].ToString();
                }
                else if (DateLastActivity == "*All Records")
                {
                    beg_date_activity = obj["DateLastActivity1FGCC"].ToString();
                    end_date_activity = obj["DateLastActivity2FGCC"].ToString();
                }
                else
                {
                    beg_date_activity = obj["rangevalDateLastActivity1FGCC"].ToString();
                    end_date_activity = obj["DateLastActivity2FGCC"].ToString();
                }
                //Date Last Recieved
                if (DateLastRecieved == "Between Range")
                {
                    beg_date_received = obj["DateLastRecieved1FGCC"].ToString();
                    end_date_received = obj["DateLastRecieved2FGCC"].ToString();
                }
                else if (DateLastRecieved == "")
                {
                    beg_date_received = obj["DateLastRecieved1FGCC"].ToString();
                    end_date_received = obj["DateLastRecieved2FGCC"].ToString();
                }
                else if (DateLastRecieved == "*All Records")
                {
                    beg_date_received = obj["DateLastRecieved1FGCC"].ToString();
                    end_date_received = obj["DateLastRecieved2FGCC"].ToString();
                }
                else
                {
                    beg_date_received = obj["rangevalDateLastRecieved1FGCC"].ToString();
                    end_date_received = obj["DateLastRecieved2FGCC"].ToString();
                }

                //Date Last Shiped
                if (DateLastShiped == "Between Range")
                {
                    beg_date_shipped = obj["DateLastShiped1FGCC"].ToString();
                    end_date_shipped = obj["DateLastShiped2FGCC"].ToString();
                }
                else if (DateLastShiped == "")
                {
                    beg_date_shipped = obj["DateLastShiped1FGCC"].ToString();
                    end_date_shipped = obj["DateLastShiped2FGCC"].ToString();
                }
                else if (DateLastShiped == "*All Records")
                {
                    beg_date_shipped = obj["DateLastShiped1FGCC"].ToString();
                    end_date_shipped = obj["DateLastShiped2FGCC"].ToString();
                }
                else
                {
                    beg_date_shipped = obj["rangevalDateLastShiped1FGCC"].ToString();
                    end_date_shipped = obj["DateLastShiped2FGCC"].ToString();
                }

                //Date Last Adjusted
                if (DateLastAdjusted == "Between Range")
                {
                    beg_date_adjusted = obj["DateLastAdjusted1FGCC"].ToString();
                    end_date_adjusted = obj["DateLastAdjusted2FGCC"].ToString();
                }
                else if (DateLastAdjusted == "")
                {
                    beg_date_adjusted = obj["DateLastAdjusted1FGCC"].ToString();
                    end_date_adjusted = obj["DateLastAdjusted2FGCC"].ToString();
                }
                else if (DateLastAdjusted == "*All Records")
                {
                    beg_date_adjusted = obj["DateLastAdjusted1FGCC"].ToString();
                    end_date_adjusted = obj["DateLastAdjusted2FGCC"].ToString();
                }
                else
                {
                    beg_date_adjusted = obj["rangevalDateLastAdjusted1FGCC"].ToString();
                    end_date_adjusted = obj["DateLastAdjusted2FGCC"].ToString();
                }


                string skip_zeros = obj["dllskip"].ToString();
                string quantity_type = obj["dllQuantityType"].ToString();
                string Sorting_Name = obj["dllsorting"].ToString();
                if (Sorting_Name == "Location")
                {
                    Sorting_Name = "loc";
                }
                else
                {
                    Sorting_Name = "item_numb";
                }
                ReportParameter[] myparams = new ReportParameter[23];
                myparams[0] = new ReportParameter("beg_finish_goods_id", beg_finish_goods_id, false);
                myparams[1] = new ReportParameter("end_finish_goods_id", end_finish_goods_id, false);
                myparams[2] = new ReportParameter("beg_finish_goods_name", beg_finish_goods_name, false);
                myparams[3] = new ReportParameter("end_finish_goods_name", end_finish_goods_name, false);
                myparams[4] = new ReportParameter("beg_kind", beg_kind, false);
                myparams[5] = new ReportParameter("end_kind", end_kind, false);
                myparams[6] = new ReportParameter("beg_inventory_type", beg_inventory_type, false);
                myparams[7] = new ReportParameter("end_inventory_type", end_inventory_type, false);
                myparams[8] = new ReportParameter("beg_warehouse", beg_warehouse, false);
                myparams[9] = new ReportParameter("end_warehouse", end_warehouse, false);
                myparams[10] = new ReportParameter("beg_location", beg_location, false);
                myparams[11] = new ReportParameter("end_location", end_location, false);
                myparams[12] = new ReportParameter("beg_date_activity", beg_date_activity, false);
                myparams[13] = new ReportParameter("end_date_activity", end_date_activity, false);
                myparams[14] = new ReportParameter("beg_date_received", beg_date_received, false);
                myparams[15] = new ReportParameter("end_date_received", end_date_received, false);
                myparams[16] = new ReportParameter("beg_date_shipped", beg_date_shipped, false);
                myparams[17] = new ReportParameter("end_date_shipped", end_date_shipped, false);
                myparams[18] = new ReportParameter("beg_date_adjusted", beg_date_adjusted, false);
                myparams[19] = new ReportParameter("end_date_adjusted", end_date_adjusted, false);
                myparams[20] = new ReportParameter("skip_zeros", skip_zeros, false);
                myparams[21] = new ReportParameter("quantity_type", quantity_type, false);
                myparams[22] = new ReportParameter("Sorting_Name", Sorting_Name, false);
                reportViewer.ServerReport.SetParameters(myparams);
                Warning[] warnings;
                string[] streamids;
                string mimeType, encoding, extension, deviceInfo;

                deviceInfo = "True";

                byte[] bytes = reportViewer.ServerReport.Render("EXCEL", null, out mimeType, out encoding, out extension, out streamids, out warnings);

                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                string FolderPath = "~/VSP";
                bool exists = System.IO.Directory.Exists(Server.MapPath(FolderPath));
                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(FolderPath));
                }              

                string pdfPath = Server.MapPath("~/VSP/VSP9160." + extension);             

                System.IO.FileStream pdfFile = new System.IO.FileStream(pdfPath, System.IO.FileMode.Create);
                pdfFile.Write(bytes, 0, bytes.Length);
                pdfFile.Close();
                //Response.Flush();
                //Response.End();
                string Link = "http://10.2.0.140/VSPAPPLICATION3/VSP/VSP9160.xls";
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_AsynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(TempData["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID", 9160);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Name", "FG Cycle Count");
                    cmd.Parameters.AddWithValue("@Asyn_Report_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Link", Link);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();
                }
                string email = TempData["EmailID"].ToString();         
                Mails mail = new Mails();
                string reportName = "VSP9160";
                mail.SendPdfUrl(email, pdfPath, reportName);
                ReportSuccess = "Success";
            }
            catch (Exception e)
            {
                ReportSuccess = "Failed";
            }
            return ReportSuccess;

        }
        public async Task<string> GenerateReport8400()
        {
            string ReportSuccess = "";
            ViewBag.msg = "Report generation process works on background. A confirmation mail will sent to email after report generation.";
            try
            {
                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(900);
                reportViewer.Height = Unit.Percentage(900);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP8400";

                FormCollection obj = (FormCollection)TempData["ReportView"];
                string beg_finish_goods_id = obj["FinishGoodsItem1FGDV"].ToString() != "" ? obj["FinishGoodsItem1FGDV"].ToString() : "0";
                string end_finish_goods_id = obj["FinishGoodsItem2FGDV"].ToString() != "" ? obj["FinishGoodsItem2FGDV"].ToString() : "0";
                string beg_finish_goods_name = obj["FinishGoodsName1FGDV"].ToString() != "" ? obj["FinishGoodsName1FGDV"].ToString() : "0";
                string end_finish_goods_name = obj["FinishGoodsName2FGDV"].ToString() != "" ? obj["FinishGoodsName2FGDV"].ToString() : "0";
                string beg_kind = obj["Kind1FGDV"].ToString() != "" ? obj["Kind1FGDV"].ToString() : "0";
                string end_kind = obj["Kind2FGDV"].ToString() != "" ? obj["Kind2FGDV"].ToString() : "0";
                string beg_inventory_type = obj["InventoryType1FGDV"].ToString() != "" ? obj["InventoryType1FGDV"].ToString() : "0";
                string end_inventory_type = obj["InventoryType2FGDV"].ToString() != "" ? obj["InventoryType2FGDV"].ToString() : "0";
                string beg_sub_type_1 = obj["SubType1_1FGDV"].ToString() != "" ? obj["SubType1_1FGDV"].ToString() : "0";
                string end_sub_type_1 = obj["SubType1_2FGDV"].ToString() != "" ? obj["SubType1_2FGDV"].ToString() : "0";
                string beg_sub_type_2 = obj["SubType2_1FGDV"].ToString() != "" ? obj["SubType2_1FGDV"].ToString() : "0";
                string end_sub_type_2 = obj["SubType2_2FGDV"].ToString() != "" ? obj["SubType2_2FGDV"].ToString() : "0";
                string beg_sub_type_3 = obj["SubType3_1FGDV"].ToString() != "" ? obj["SubType3_1FGDV"].ToString() : "0";
                string end_sub_type_3 = obj["SubType3_2FGDV"].ToString() != "" ? obj["SubType3_2FGDV"].ToString() : "0";

                string skipzeroquantity = obj["dllskipzeroquantity"].ToString();
                string skipzerocost = obj["dllskipzerocost"].ToString();
                string skip_zeros = String.Empty;
                string skip_nodollars = String.Empty;
                if (skipzeroquantity == "Yes")
                {
                    skip_zeros = "Yes";
                }
                else
                {
                    skip_zeros = "No";
                }
                if (skipzerocost == "Yes")
                {
                    skip_nodollars = "Yes";
                }
                else
                {
                    skip_nodollars = "No";
                }

                ReportParameter[] myparams = new ReportParameter[16];
                myparams[0] = new ReportParameter("beg_finish_goods_id", beg_finish_goods_id, false);
                myparams[1] = new ReportParameter("end_finish_goods_id", end_finish_goods_id, false);
                myparams[2] = new ReportParameter("beg_finish_goods_name", beg_finish_goods_name, false);
                myparams[3] = new ReportParameter("end_finish_goods_name", end_finish_goods_name, false);
                myparams[4] = new ReportParameter("beg_kind", beg_kind, false);
                myparams[5] = new ReportParameter("end_kind", end_kind, false);
                myparams[6] = new ReportParameter("beg_inventory_type", beg_inventory_type, false);
                myparams[7] = new ReportParameter("end_inventory_type", end_inventory_type, false);
                myparams[8] = new ReportParameter("beg_sub_type_1", beg_sub_type_1, false);
                myparams[9] = new ReportParameter("end_sub_type_1", end_sub_type_1, false);
                myparams[10] = new ReportParameter("beg_sub_type_2", beg_sub_type_2, false);
                myparams[11] = new ReportParameter("end_sub_type_2", end_sub_type_2, false);
                myparams[12] = new ReportParameter("beg_sub_type_3", beg_sub_type_3, false);
                myparams[13] = new ReportParameter("end_sub_type_3", end_sub_type_3, false);
                myparams[14] = new ReportParameter("skip_zeros", skip_zeros, false);
                myparams[15] = new ReportParameter("skip_nodollars", skip_nodollars, false);
                reportViewer.ServerReport.SetParameters(myparams);
                Warning[] warnings;
                string[] streamids;
                string mimeType, encoding, extension, deviceInfo;

                deviceInfo = "True";

                byte[] bytes = reportViewer.ServerReport.Render("EXCEL", null, out mimeType, out encoding, out extension, out streamids, out warnings);

                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                string FolderPath = "~/VSP";
                bool exists = System.IO.Directory.Exists(Server.MapPath(FolderPath));
                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(FolderPath));
                }              

                string pdfPath = Server.MapPath("~/VSP/VSP8400." + extension);

                Session["pdfPath"] = pdfPath;

                System.IO.FileStream pdfFile = new System.IO.FileStream(pdfPath, System.IO.FileMode.Create);
                pdfFile.Write(bytes, 0, bytes.Length);
                pdfFile.Close();
                //Response.Flush();
                //Response.End();

                ReportSuccess = "Success";
            }
            catch (Exception e)
            {
                ReportSuccess = "Failed";
            }
            return ReportSuccess;

        }
        public async Task<string> GenerateReport7910()
        {
            string ReportSuccess = "";
            ViewBag.msg = "Report generation process works on background. A confirmation mail will sent to email after report generation.";
            try
            {
                string DateShipped7910 = TempData["DateShipped"].ToString();

                FormCollection obj = (FormCollection)TempData["ReportView"];
                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(0);
                reportViewer.Height = Unit.Percentage(0);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7910";
                string beg_date = string.Empty;
                string end_date = string.Empty;
                string beg_customer_id = obj["CustomerID1"].ToString() != "" ? obj["CustomerID1"].ToString() : "0";
                string end_customer_id = obj["CustomerID2"].ToString() != "" ? obj["CustomerID2"].ToString() : "0";
                string beg_customer_name = obj["CustomerName1"].ToString() != "" ? obj["CustomerName1"].ToString() : "0";
                string end_customer_name = obj["CustomerName2"].ToString() != "" ? obj["CustomerName2"].ToString() : "0";
                if (DateShipped7910 == "Between Range")
                {
                    beg_date = obj["DateShipped1"].ToString();
                    end_date = obj["DateShipped2"].ToString();
                }
                else if (DateShipped7910 == "")
                {
                    beg_date = obj["DateShipped1"].ToString();
                    end_date = obj["DateShipped2"].ToString();
                }
                else if (DateShipped7910 == "*All Records")
                {
                    beg_date = obj["rangevaltext"].ToString();
                    end_date = obj["rangevaltext1"].ToString();

                }
                else
                {
                    beg_date = obj["rangevaltext"].ToString();
                    end_date = obj["DateShipped2"].ToString();
                }
                string skip_nodollars = obj["dllRemoveCost7910"].ToString();



                ReportParameter[] myparams = new ReportParameter[7];

                myparams[0] = new ReportParameter("beg_customer_id", beg_customer_id, false);
                myparams[1] = new ReportParameter("end_customer_id", end_customer_id, false);
                myparams[2] = new ReportParameter("beg_customer_name", beg_customer_name, false);
                myparams[3] = new ReportParameter("end_customer_name", end_customer_name, false);

                myparams[4] = new ReportParameter("beg_date", beg_date, false);

                myparams[5] = new ReportParameter("end_date", end_date, false);
                myparams[6] = new ReportParameter("skip_nodollars", skip_nodollars, false);
                reportViewer.ServerReport.SetParameters(myparams);


                Warning[] warnings;
                string[] streamids;
                string mimeType, encoding, extension, deviceInfo;

                deviceInfo = "True";

                byte[] bytes = reportViewer.ServerReport.Render("EXCEL", null, out mimeType, out encoding, out extension, out streamids, out warnings);

                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                string FolderPath = "~/VSP";
                bool exists = System.IO.Directory.Exists(Server.MapPath(FolderPath));
                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(FolderPath));
                }              

                string pdfPath = Server.MapPath("~/VSP/VSP7910." + extension);

                Session["pdfPath"] = pdfPath;

                System.IO.FileStream pdfFile = new System.IO.FileStream(pdfPath, System.IO.FileMode.Create);
                pdfFile.Write(bytes, 0, bytes.Length);
                pdfFile.Close();
                //Response.Flush();
                //Response.End();

                ReportSuccess = "Success";
            }
            catch (Exception e)
            {
                ReportSuccess = "Failed";
            }
            return ReportSuccess;

        }
        public async Task<string> GenerateReport7180()
        {
            string ReportSuccess = "";
            ViewBag.msg = "Report generation process works on background. A confirmation mail will sent to email after report generation.";
            try
            {
                FormCollection obj = (FormCollection)TempData["ReportView"];
                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(0);
                reportViewer.Height = Unit.Percentage(0);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7180";
                string DateExpiration = obj["DateExpiration"].ToString();
                string beg_date = string.Empty;
                string end_date = string.Empty;
                string beg_fg_id = obj["txtFinishGoodsItemBlanket"].ToString() != "" ? obj["txtFinishGoodsItemBlanket"].ToString() : "0";
                string end_fg_id = obj["txtFinishGoodsItemBlanket2"].ToString() != "" ? obj["txtFinishGoodsItemBlanket2"].ToString() : "0";
                string beg_customer_id = obj["txtCustNumberBlanket"].ToString() != "" ? obj["txtCustNumberBlanket"].ToString() : "0";
                string end_customer_id = obj["txtCustNumberBlanket2"].ToString() != "" ? obj["txtCustNumberBlanket2"].ToString() : "0";
                string beg_customer_po = obj["txtCustomerPo"].ToString() != "" ? obj["txtCustomerPo"].ToString() : "0";
                string end_customer_po = obj["txtCustomerPo2"].ToString() != "" ? obj["txtCustomerPo2"].ToString() : "0";
                if (DateExpiration == "Between Range")
                {
                    beg_date = obj["DateExp"].ToString();
                    end_date = obj["DateExp2"].ToString();
                }
                else if (DateExpiration == "")
                {
                    beg_date = obj["txtDateExp"].ToString();
                    end_date = obj["txtDateExp2"].ToString();
                }
                else if (DateExpiration == "*All Records")
                {
                    beg_date = obj["txtDateExp"].ToString();
                    end_date = obj["txtDateExp2"].ToString();
                    //beg_date = obj["DateShipped1"].ToString();
                    //end_date = obj["DateShipped2"].ToString();
                }
                else
                {
                    beg_date = obj["txtDateExp"].ToString();
                    end_date = obj["DateExp2"].ToString();
                }

                string beg_inventory_type = obj["txtInventoryTypeBlanket"].ToString() != "" ? obj["txtInventoryTypeBlanket"].ToString() : "0";
                string end_inventory_type = obj["txtInventoryTypeBlanket2"].ToString() != "" ? obj["txtInventoryTypeBlanket2"].ToString() : "0";
                string beg_sub_type_2 = obj["txtSubType2Blanket"].ToString() != "" ? obj["txtSubType2Blanket"].ToString() : "0";
                string end_sub_type_2 = obj["txtSubType2Blanket2"].ToString() != "" ? obj["txtSubType2Blanket2"].ToString() : "0";
                string job_status = obj["dllJobStatus"].ToString();
                string pull_qty = obj["dllQtyLevel"].ToString();

                ReportParameter[] myparams = new ReportParameter[14];
                myparams[0] = new ReportParameter("beg_fg_id", beg_fg_id, false);
                myparams[1] = new ReportParameter("end_fg_id", end_fg_id, false);
                myparams[2] = new ReportParameter("beg_customer_id", beg_customer_id, false);
                myparams[3] = new ReportParameter("end_customer_id", end_customer_id, false);
                myparams[4] = new ReportParameter("beg_customer_po", beg_customer_po, false);
                myparams[5] = new ReportParameter("end_customer_po", end_customer_po, false);
                myparams[6] = new ReportParameter("beg_date", beg_date, false);
                myparams[7] = new ReportParameter("end_date", end_date, false);
                myparams[8] = new ReportParameter("beg_inventory_type", beg_inventory_type, false);
                myparams[9] = new ReportParameter("end_inventory_type", end_inventory_type, false);
                myparams[10] = new ReportParameter("beg_sub_type_2", beg_sub_type_2, false);
                myparams[11] = new ReportParameter("end_sub_type_2", end_sub_type_2, false);
                myparams[12] = new ReportParameter("job_status", job_status, false);
                myparams[13] = new ReportParameter("pull_qty", pull_qty, false);
                reportViewer.ServerReport.SetParameters(myparams);

                Warning[] warnings;
                string[] streamids;
                string mimeType, encoding, extension, deviceInfo;

                deviceInfo = "True";

                byte[] bytes = reportViewer.ServerReport.Render("EXCEL", null, out mimeType, out encoding, out extension, out streamids, out warnings);

                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                string FolderPath = "~/VSP";
                bool exists = System.IO.Directory.Exists(Server.MapPath(FolderPath));
                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(FolderPath));
                }
                           

                string pdfPath = Server.MapPath("~/VSP/VSP7180." + extension);            

                System.IO.FileStream pdfFile = new System.IO.FileStream(pdfPath, System.IO.FileMode.Create);
                pdfFile.Write(bytes, 0, bytes.Length);
                pdfFile.Close();
                //Response.Flush();
                //Response.End();
                string Link = "http://10.2.0.140/VSPAPPLICATION3/VSP/VSP7180.xls";
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_AsynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(TempData["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID", 7180);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Name", "Blanket Report");
                    cmd.Parameters.AddWithValue("@Asyn_Report_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Link", Link);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();
                }

                string email = TempData["EmailID"].ToString();          
                Mails mail = new Mails();
                string reportName = "VSP7180";
                mail.SendPdfUrl(email, pdfPath, reportName);
                ReportSuccess = "Success";
            }
            catch (Exception e)
            {
                ReportSuccess = "Failed";
            }

            return ReportSuccess;

        }       
        public async Task<string> GenerateReport7140()
        {
            string ReportSuccess = "";
            ViewBag.msg = "Report generation process works on background. A confirmation mail will sent to email after report generation.";
            try
            {
                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(900);
                reportViewer.Height = Unit.Percentage(900);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7140";
                FormCollection obj = (FormCollection)TempData["ReportView"];
                string beg_customer_id = obj["CustomerID1CYSBM"].ToString() != "" ? obj["CustomerID1CYSBM"].ToString() : "0";
                string end_customer_id = obj["CustomerID2CYSBM"].ToString() != "" ? obj["CustomerID2CYSBM"].ToString() : "0";
                string beg_customer_name = obj["CustomerName1CYSBM"].ToString() != "" ? obj["CustomerName1CYSBM"].ToString() : "0";
                string end_customer_name = obj["CustomerName2CYSBM"].ToString() != "" ? obj["CustomerName2CYSBM"].ToString() : "0";
                string beg_inventory_type = obj["InventoryType1CYSBM"].ToString() != "" ? obj["InventoryType1CYSBM"].ToString() : "0";
                string end_inventory_type = obj["InventoryType2CYSBM"].ToString() != "" ? obj["InventoryType2CYSBM"].ToString() : "0";
                string beg_kind = obj["KindCode1CYSBM"].ToString() != "" ? obj["KindCode1CYSBM"].ToString() : "0";
                string end_kind = obj["KindCode2CYSBM"].ToString() != "" ? obj["KindCode2CYSBM"].ToString() : "0";
                string ddlSort = obj["dllsorting"].ToString();
                string Sorting_Name = String.Empty;
                if (ddlSort == "Customer Name")
                {
                    Sorting_Name = "customer_id";
                }
                else if (ddlSort == "Inventory Type")
                {
                    Sorting_Name = "type_id";
                }
                else
                {
                    Sorting_Name = "kind_code";
                }

                ReportParameter[] myparams = new ReportParameter[9];
                myparams[0] = new ReportParameter("beg_customer_id", beg_customer_id, false);
                myparams[1] = new ReportParameter("end_customer_id", end_customer_id, false);
                myparams[2] = new ReportParameter("beg_customer_name", beg_customer_name, false);
                myparams[3] = new ReportParameter("end_customer_name", end_customer_name, false);
                myparams[4] = new ReportParameter("beg_inventory_type", beg_inventory_type, false);
                myparams[5] = new ReportParameter("end_inventory_type", end_inventory_type, false);
                myparams[6] = new ReportParameter("beg_kind", beg_kind, false);
                myparams[7] = new ReportParameter("end_kind", end_kind, false);
                myparams[8] = new ReportParameter("Sorting_Name", Sorting_Name, false);
                reportViewer.ServerReport.SetParameters(myparams);
                Warning[] warnings;
                string[] streamids;
                string mimeType, encoding, extension, deviceInfo;

                deviceInfo = "True";

                byte[] bytes = reportViewer.ServerReport.Render("EXCEL", null, out mimeType, out encoding, out extension, out streamids, out warnings);

                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                string FolderPath = "~/VSP";
                bool exists = System.IO.Directory.Exists(Server.MapPath(FolderPath));
                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(FolderPath));
                }             

                string pdfPath = Server.MapPath("~/VSP/VSP7140." + extension);             

                System.IO.FileStream pdfFile = new System.IO.FileStream(pdfPath, System.IO.FileMode.Create);
                pdfFile.Write(bytes, 0, bytes.Length);
                pdfFile.Close();
                //Response.Flush();
                //Response.End();
                string Link = "http://10.2.0.140/VSPAPPLICATION3/VSP/VSP7140.xls";
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_AsynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(TempData["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID", 7140);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Name", "Calendar year sales by month");
                    cmd.Parameters.AddWithValue("@Asyn_Report_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Link", Link);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();
                }

                string email = TempData["EmailID"].ToString();
                Mails mail = new Mails();
                string reportName = "VSP7140";
                mail.SendPdfUrl(email, pdfPath, reportName);
                ReportSuccess = "Success";
            }
            catch (Exception e)
            {
                ReportSuccess = "Failed";
            }

            return ReportSuccess;

        }
        public async Task<string> GenerateReport7810()
        {
            string ReportSuccess = "";
            ViewBag.msg = "Report generation process works on background. A confirmation mail will sent to email after report generation.";
            try
            {
                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(900);
                reportViewer.Height = Unit.Percentage(900);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7810";
                FormCollection obj = (FormCollection)TempData["ReportView"];
                string LastReceiptDatePS = obj["LastReceiptDatePS"].ToString();
                string beg_date_rec = string.Empty;
                string end_date_rec = string.Empty;
                string beg_customer_id = obj["CustomerID1PS"].ToString() != "" ? obj["CustomerID1PS"].ToString() : "0";
                string end_customer_id = obj["CustomerID2PS"].ToString() != "" ? obj["CustomerID2PS"].ToString() : "0";
                string beg_customer_name = obj["CustomerName1PS"].ToString() != "" ? obj["CustomerName1PS"].ToString() : "0";
                string end_customer_name = obj["CustomerName2PS"].ToString() != "" ? obj["CustomerName2PS"].ToString() : "0";
                string beg_mst_part_id = obj["MasterPart1PS"].ToString() != "" ? obj["MasterPart1PS"].ToString() : "0";
                string end_mst_part_id = obj["MasterPart2PS"].ToString() != "" ? obj["MasterPart2PS"].ToString() : "0";
                string beg_code_2 = obj["Jobcode2_1PS"].ToString() != "" ? obj["Jobcode2_1PS"].ToString() : "0";
                string end_code_2 = obj["Jobcode2_2PS"].ToString() != "" ? obj["Jobcode2_2PS"].ToString() : "0";
                string beg_fg_type_code = obj["InventoryType1PS"].ToString() != "" ? obj["InventoryType1PS"].ToString() : "0";
                string end_fg_type_code = obj["InventoryType2PS"].ToString() != "" ? obj["InventoryType2PS"].ToString() : "0";
                if (LastReceiptDatePS == "Between Range")
                {
                    beg_date_rec = obj["LastReceiptDate1PS"].ToString();
                    end_date_rec = obj["LastReceiptDate2PS"].ToString();
                }
                else if (LastReceiptDatePS == "")
                {
                    beg_date_rec = obj["rangevalLastReceiptDate1PS"].ToString();
                    end_date_rec = obj["rangevalLastReceiptDate2PS"].ToString();
                }
                else if (LastReceiptDatePS == "*All Records")
                {
                    beg_date_rec = obj["rangevalLastReceiptDate1PS"].ToString();
                    end_date_rec = obj["rangevalLastReceiptDate2PS"].ToString();
                    //beg_date = obj["DateShipped1"].ToString();
                    //end_date = obj["DateShipped2"].ToString();
                }
                else
                {
                    beg_date_rec = obj["rangevalLastReceiptDate1PS"].ToString();
                    end_date_rec = obj["LastReceiptDate2PS"].ToString();
                }
                string Sorting_AscendingName = string.Empty;
                if (obj["dllSortReportByAccending"].ToString() == "Master Job")
                {
                    Sorting_AscendingName = "master_job";
                }
                else if (obj["dllSortReportByAccending"].ToString() == "Customer Name")
                {
                    Sorting_AscendingName = "cust_name";
                }
                else if (obj["dllSortReportByAccending"].ToString() == "Job Code 2")
                {
                    Sorting_AscendingName = "job_code2";
                }
                else if (obj["dllSortReportByAccending"].ToString() == "Maste Part")
                {
                    Sorting_AscendingName = "master_part_id";
                }
                else if (obj["dllSortReportByAccending"].ToString() == "Receipt Date")
                {
                    Sorting_AscendingName = "date_shipped";
                }
                else
                {
                    Sorting_AscendingName = "job_code2";
                }
                string Sorting_DescendingName = string.Empty;
                if (obj["dllSortReportByDescending"].ToString() == "Master Job")
                {
                    Sorting_DescendingName = "master_job";
                }
                else if (obj["dllSortReportByDescending"].ToString() == "Customer Name")
                {
                    Sorting_DescendingName = "cust_name";
                }
                else if (obj["dllSortReportByDescending"].ToString() == "Job Code 2")
                {
                    Sorting_DescendingName = "job_code2";
                }
                else if (obj["dllSortReportByDescending"].ToString() == "Maste Part")
                {
                    Sorting_DescendingName = "master_part_id";
                }
                else if (obj["dllSortReportByDescending"].ToString() == "Receipt Date")
                {
                    Sorting_DescendingName = "date_shipped";
                }
                else
                {
                    Sorting_DescendingName = "master_job";
                }

                ReportParameter[] myparams = new ReportParameter[14];
                myparams[0] = new ReportParameter("beg_customer_id", beg_customer_id, false);
                myparams[1] = new ReportParameter("end_customer_id", end_customer_id, false);
                myparams[2] = new ReportParameter("beg_customer_name", beg_customer_name, false);
                myparams[3] = new ReportParameter("end_customer_name", end_customer_name, false);
                myparams[4] = new ReportParameter("beg_mst_part_id", beg_mst_part_id, false);
                myparams[5] = new ReportParameter("end_mst_part_id", end_mst_part_id, false);
                myparams[6] = new ReportParameter("beg_date_rec", beg_date_rec, false);
                myparams[7] = new ReportParameter("end_date_rec", end_date_rec, false);
                myparams[8] = new ReportParameter("beg_code_2", beg_code_2, false);
                myparams[9] = new ReportParameter("end_code_2", end_code_2, false);
                myparams[10] = new ReportParameter("beg_fg_type_code", beg_fg_type_code, false);
                myparams[11] = new ReportParameter("end_fg_type_code", end_fg_type_code, false);
                myparams[12] = new ReportParameter("Sorting_AscendingName", Sorting_AscendingName, false);
                myparams[13] = new ReportParameter("Sorting_DescendingName", Sorting_DescendingName, false);
                reportViewer.ServerReport.SetParameters(myparams); Warning[] warnings;
                string[] streamids;
                string mimeType, encoding, extension, deviceInfo;

                deviceInfo = "True";

                byte[] bytes = reportViewer.ServerReport.Render("EXCEL", null, out mimeType, out encoding, out extension, out streamids, out warnings);

                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                string FolderPath = "~/VSP";
                bool exists = System.IO.Directory.Exists(Server.MapPath(FolderPath));
                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(FolderPath));
                }             

                string pdfPath = Server.MapPath("~/VSP/VSP7810." + extension);               

                System.IO.FileStream pdfFile = new System.IO.FileStream(pdfPath, System.IO.FileMode.Create);
                pdfFile.Write(bytes, 0, bytes.Length);
                pdfFile.Close();
                //Response.Flush();
                //Response.End();
                string Link = "http://10.2.0.140/VSPAPPLICATION3/VSP/VSP7810.xls";
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_AsynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(TempData["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID", 7810);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Name", "Profit Summary");
                    cmd.Parameters.AddWithValue("@Asyn_Report_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Link", Link);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();
                }
             
                string email = TempData["EmailID"].ToString();

                Mails mail = new Mails();
                string reportName = "VSP7810";
                mail.SendPdfUrl(email, pdfPath, reportName);
                ReportSuccess = "Success";
            }
            catch (Exception e)
            {
                ReportSuccess = "Failed";
            }

            return ReportSuccess;

        }
        public async Task<string> GenerateReportFilter7150(FormCollection obj, string filter, string DateShipped)
        {
            string ReportSuccess = "";
            string beg_date = string.Empty;
            ViewBag.msg = "Report generation process works on background. A confirmation mail will sent to email after report generation.";
            try
            {
                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(900);
                reportViewer.Height = Unit.Percentage(900);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7150";

                string beg_fg_id = obj["FinishGoodsItemID"].ToString(); 
                string end_fg_id = obj["FinishGoodsItemID2"].ToString(); 
                string beg_customer_id = obj["CustomerID1"].ToString();
                string end_customer_id = obj["CustomerID2"].ToString();
                string beg_customer_name = obj["CustomerName1"].ToString();
                string end_customer_name = obj["CustomerName2"].ToString();
                if (DateShipped == "Between Range")
                {
                    beg_date = obj["DateShipped1"].ToString();
                }
                else if (DateShipped == "")
                {
                    beg_date = obj["DateShipped1"].ToString();
                }
                else
                {
                    beg_date = obj["rangevaltext"].ToString();
                }
                string end_date = obj["DateShipped2"].ToString();
                string beg_inventory_type = obj["InventoryType1"].ToString(); 
                string end_inventory_type = obj["InventoryType2"].ToString();
                string beg_sales_rep = obj["SellRep1"].ToString();
                string end_sales_rep = obj["SellRep2"].ToString();
                string beg_shipto_id = obj["ShippingLocatoin1"].ToString(); 
                string end_shipto_id = obj["ShippingLocatoin2"].ToString();
                string beg_order_type = obj["OrderType1"].ToString();
                string end_order_type = obj["OrderType2"].ToString();
                string beg_product_code = obj["ProductCode1"].ToString();
                string end_product_code = obj["ProductCode2"].ToString(); 
                ReportParameter[] myparams = new ReportParameter[18];
                myparams[0] = new ReportParameter("beg_fg_id", beg_fg_id, false);
                myparams[1] = new ReportParameter("end_fg_id", end_fg_id, false);
                myparams[2] = new ReportParameter("beg_customer_id", beg_customer_id, false);
                myparams[3] = new ReportParameter("end_customer_id", end_customer_id, false);
                myparams[4] = new ReportParameter("beg_customer_name", beg_customer_name, false);
                myparams[5] = new ReportParameter("end_customer_name", end_customer_name, false);
                myparams[6] = new ReportParameter("beg_date", beg_date, false);
                myparams[7] = new ReportParameter("end_date", end_date, false);
                myparams[8] = new ReportParameter("beg_inventory_type", beg_inventory_type, false);
                myparams[9] = new ReportParameter("end_inventory_type", end_inventory_type, false);
                myparams[10] = new ReportParameter("beg_sales_rep", beg_sales_rep, false);
                myparams[11] = new ReportParameter("end_sales_rep", end_sales_rep, false);
                myparams[12] = new ReportParameter("beg_shipto_id", beg_shipto_id, false);
                myparams[13] = new ReportParameter("end_shipto_id", end_shipto_id, false);
                myparams[14] = new ReportParameter("beg_order_type", beg_order_type, false);
                myparams[15] = new ReportParameter("end_order_type", end_order_type, false);
                myparams[16] = new ReportParameter("beg_product_code", beg_product_code, false);
                myparams[17] = new ReportParameter("end_product_code", end_product_code, false);
                reportViewer.ServerReport.SetParameters(myparams);
                Warning[] warnings;
                string[] streamids;
                string mimeType, encoding, extension, deviceInfo;

                deviceInfo = "True";

                byte[] bytes = reportViewer.ServerReport.Render("EXCEL", null, out mimeType, out encoding, out extension, out streamids, out warnings);

                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                string FolderPath = "~/VSP";
                bool exists = System.IO.Directory.Exists(Server.MapPath(FolderPath));
                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(FolderPath));
                }              

                string pdfPath = Server.MapPath("~/VSP/VSP7150." + extension);

                Session["pdfPath"] = pdfPath;

                System.IO.FileStream pdfFile = new System.IO.FileStream(pdfPath, System.IO.FileMode.Create);
                pdfFile.Write(bytes, 0, bytes.Length);
                pdfFile.Close();
                //Response.Flush();
                //Response.End();

                ReportSuccess = "Success";
            }
            catch (Exception e)
            {
                ReportSuccess = "Failed";
            }

            return ReportSuccess;

        }
        public async Task<string> GenerateReport7170()
        {
            string ReportSuccess = "";
            ViewBag.msg = "Report generation process works on background. A confirmation mail will sent to email after report generation.";
            try
            {
                string Date7170 = TempData["DateShipped"].ToString();
                FormCollection obj = (FormCollection)TempData["ReportView"];              
                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(0);
                reportViewer.Height = Unit.Percentage(0);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7170";
                string beg_date = string.Empty;
                string end_date = string.Empty;

                if (Date7170 == "Between Range")
                {
                    beg_date = obj["DateMaterialCut1"].ToString();
                    end_date = obj["DateMaterialCut2"].ToString();
                }
                else if (Date7170 == "")
                {
                    beg_date = obj["DateMaterialCut1"].ToString();
                    end_date = obj["DateMaterialCut2"].ToString();
                }
                else if (Date7170 == "*All Records")
                {
                    beg_date = obj["txtDateMaterialCut1"].ToString();
                    end_date = obj["txtDateMaterialCut2"].ToString();

                }
                else
                {
                    beg_date = obj["txtDateMaterialCut1"].ToString();
                    end_date = obj["DateMaterialCut2"].ToString();
                }

                ReportParameter[] myparams = new ReportParameter[2];

                myparams[0] = new ReportParameter("beg_date", beg_date, false);
                myparams[1] = new ReportParameter("end_date", end_date, false);
                reportViewer.ServerReport.SetParameters(myparams);


                Warning[] warnings;
                string[] streamids;
                string mimeType, encoding, extension, deviceInfo;

                deviceInfo = "True";

                byte[] bytes = reportViewer.ServerReport.Render("EXCEL", null, out mimeType, out encoding, out extension, out streamids, out warnings);

                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                string FolderPath = "~/VSP";
                bool exists = System.IO.Directory.Exists(Server.MapPath(FolderPath));
                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(FolderPath));
                }            

                string pdfPath = Server.MapPath("~/VSP/VSP7170." + extension);             

                System.IO.FileStream pdfFile = new System.IO.FileStream(pdfPath, System.IO.FileMode.Create);
                pdfFile.Write(bytes, 0, bytes.Length);
                pdfFile.Close();
                //Response.Flush();
                //Response.End();
                string Link = "http://10.2.0.140/VSPAPPLICATION3/VSP/VSP7170.xls";
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_AsynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(TempData["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID", 7170);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Name", "Material Cut");
                    cmd.Parameters.AddWithValue("@Asyn_Report_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Link", Link);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();
                }

                string email = TempData["EmailID"].ToString();              
                Mails mail = new Mails();
                string reportName = "VSP7170";
                mail.SendPdfUrl(email, pdfPath, reportName);
                ReportSuccess = "Success";
            }
            catch (Exception e)
            {
                ReportSuccess = "Failed";
            }

            return ReportSuccess;

        }
        public async Task<string> GenerateReport7110()
        {
            string ReportSuccess = "";
            ViewBag.msg = "Report generation process works on background. A confirmation mail will sent to email after report generation.";
            try
            {
                FormCollection obj = (FormCollection)TempData["ReportView"];
                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(900);
                reportViewer.Height = Unit.Percentage(900);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7110";
                string beg_est_id = obj["EstimateId_Beg"].ToString() != "" ? obj["EstimateId_Beg"].ToString() : "0";
                string end_est_id = obj["EstimateId_End"].ToString() != "" ? obj["EstimateId_End"].ToString() : "0";
                string beg_master_part = obj["MasterPart_Beg"].ToString() != "" ? obj["MasterPart_Beg"].ToString() : "0";
                string end_master_part = obj["MasterPart_End"].ToString() != "" ? obj["MasterPart_End"].ToString() : "0";
                string beg_customer_id = obj["CustomerId_Beg"].ToString() != "" ? obj["CustomerId_Beg"].ToString() : "0";
                string end_customer_id = obj["CustomerId_End"].ToString() != "" ? obj["CustomerId_End"].ToString() : "0";
                string beg_customer_name = obj["CustLeadName_Beg"].ToString() != "" ? obj["CustLeadName_Beg"].ToString() : "0";
                string end_customer_name = obj["CustLeadName_End"].ToString() != "" ? obj["CustLeadName_End"].ToString() : "0";
                string beg_material_id = obj["Material_ID_Beg"].ToString() != "" ? obj["Material_ID_Beg"].ToString() : "0";
                string end_material_id = obj["Material_ID_End"].ToString() != "" ? obj["Material_ID_End"].ToString() : "0";
                string beg_product_code = obj["ProductCode_Beg"].ToString() != "" ? obj["ProductCode_Beg"].ToString() : "0";
                string end_product_code = obj["ProductCode_End"].ToString() != "" ? obj["ProductCode_End"].ToString() : "0";

                ReportParameter[] myparams = new ReportParameter[12];
                myparams[0] = new ReportParameter("beg_est_id", beg_est_id, false);
                myparams[1] = new ReportParameter("end_est_id", end_est_id, false);
                myparams[2] = new ReportParameter("beg_master_part", beg_master_part, false);
                myparams[3] = new ReportParameter("end_master_part", end_master_part, false);
                myparams[4] = new ReportParameter("beg_customer_id", beg_customer_id, false);
                myparams[5] = new ReportParameter("end_customer_id", end_customer_id, false);
                myparams[6] = new ReportParameter("beg_customer_name", beg_customer_name, false);
                myparams[7] = new ReportParameter("end_customer_name", beg_material_id, false);
                myparams[8] = new ReportParameter("beg_material_id", beg_material_id, false);
                myparams[9] = new ReportParameter("end_material_id", end_material_id, false);
                myparams[10] = new ReportParameter("beg_product_code", beg_product_code, false);
                myparams[11] = new ReportParameter("end_product_code", end_product_code, false);
                reportViewer.ServerReport.SetParameters(myparams);
                Warning[] warnings;
                string[] streamids;
                string mimeType, encoding, extension, deviceInfo;

                deviceInfo = "True";

                byte[] bytes = reportViewer.ServerReport.Render("Excel", null, out mimeType, out encoding, out extension, out streamids, out warnings);

                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                string FolderPath = "~/VSP";
                bool exists = System.IO.Directory.Exists(Server.MapPath(FolderPath));
                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(FolderPath));
                }             
                string pdfPath = Server.MapPath("~/VSP/VSP7110." + extension);       

                System.IO.FileStream pdfFile = new System.IO.FileStream(pdfPath, System.IO.FileMode.Create);
                pdfFile.Write(bytes, 0, bytes.Length);
                pdfFile.Close();
                //Response.Flush();
                //Response.End();
                string Link = "http://10.2.0.140/VSPAPPLICATION3/VSP/VSP7110.xls";
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_AsynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(TempData["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID", 7110);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Name", "Sell Price Per Sq.Ft.");
                    cmd.Parameters.AddWithValue("@Asyn_Report_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Link", Link);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();

                }
                string email = TempData["EmailID"].ToString();
                Mails mail = new Mails();
                string reportName = "VSP7110";
                mail.SendPdfUrl(email, pdfPath, reportName);
                ReportSuccess = "Success";
            }
            catch (Exception e)
            {
                ReportSuccess = "Failed";
            }

            return ReportSuccess;

        }
        public async Task<string> GenerateReport7950()
        {
            string ReportSuccess = "";
            ViewBag.msg = "Report generation process works on background. A confirmation mail will sent to email after report generation.";
            try
            {
                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(900);
                reportViewer.Height = Unit.Percentage(900);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7950_new";
                FormCollection obj = (FormCollection)TempData["ReportView"];
                string GenricJobNum_Beg = obj["GenricJobNum_Beg"].ToString() != "" ? obj["GenricJobNum_Beg"].ToString() : "0";
                string GenricJobNum_End = obj["GenricJobNum_End"].ToString() != "" ? obj["GenricJobNum_End"].ToString() : "0";
                ReportParameter[] myparams = new ReportParameter[2];
                myparams[0] = new ReportParameter("beg_generic_job", GenricJobNum_Beg, false);
                myparams[1] = new ReportParameter("end_generic_job", GenricJobNum_End, false);

                reportViewer.ServerReport.SetParameters(myparams);
                Warning[] warnings;
                string[] streamids;
                string mimeType, encoding, extension, deviceInfo;

                deviceInfo = "True";

                byte[] bytes = reportViewer.ServerReport.Render("EXCEL", null, out mimeType, out encoding, out extension, out streamids, out warnings);

                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                string FolderPath = "~/VSP/";
                bool exists = System.IO.Directory.Exists(Server.MapPath(FolderPath));
                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(FolderPath));
                }          

                string pdfPath = Server.MapPath("~/VSP/VSP7950." + extension);             

                System.IO.FileStream pdfFile = new System.IO.FileStream(pdfPath, System.IO.FileMode.Create);
                pdfFile.Write(bytes, 0, bytes.Length);
                pdfFile.Close();
                //Response.Flush();
                //Response.End();
                string Link = "http://10.2.0.140/VSPAPPLICATION3/VSP/VSP7950.xls";
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_AsynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(TempData["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID", 7950);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Name", "Generic ID Tag");
                    cmd.Parameters.AddWithValue("@Asyn_Report_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Link", Link);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();
                }
                string email = TempData["EmailID"].ToString();               
                Mails mail = new Mails();
                string reportName = "VSP7950";
                mail.SendPdfUrl(email, pdfPath, reportName);
                ReportSuccess = "Success";
            }
            catch (Exception e)
            {
                ReportSuccess = "Failed";
            }

            return ReportSuccess;

        }

        public ActionResult FilterOption(FormCollection obj, string filter, string DateShipped, string dllsorting, string FinishGoodsItem, string ddlCustomerID, string ddlCustomerName, string InventoryType, string SellRep, string ShippingLocatoin, string OrderType, string ProductCode)
        {
            Session["ReportName"] = "Open Pick Ticket Listing (7150)";
            Session["ReportID"] = "7150";
            ViewBag.DateShipped1 = string.Empty;
            ViewBag.DateShipped2 = string.Empty;
            ViewBag.rangevaltext = string.Empty;
            ViewBag.rangevaltext2 = string.Empty;
            if (filter == "Run as a Job and Notify")
            {

               // string Link = "<a href='"+"http://10.2.0.140/VSPAPPLICATION3/VSP/7150.xls"+"' >click to download report</a>";
             
                TempData["ReportView"] = obj;
                TempData["DateShipped"] = DateShipped;
                TempData["dllsorting"] = dllsorting;
                TempData["EmailID"] = Session["EmailID"].ToString();
                TempData["UserID"] = Session["UserID"].ToString();
                List<string> _pagecontent = new List<string>();
                return RedirectToAction("RunReportAsyn", "Report");
            }
            if (filter != "Run Report Now")
            {
                
                ViewBag.FinishGoodItems = "*All Records";
                ViewBag.FinishGoodItems1 = "0";

                ViewBag.CustomerId = "*All Records";
                ViewBag.CustomerId1 = "0";

                ViewBag.CustomerName = "*All Records";
                ViewBag.CustomerName1 = "0";

                ViewBag.DateShipped1 = "*All Records";
                ViewBag.DateShipped2 = "0";

                ViewBag.Inventory_Type = "*All Records";
                ViewBag.Inventory_Type1 = "0";

                ViewBag.Inventory_Type = "*All Records";
                ViewBag.Inventory_Type1 = "0";

                ViewBag.Sell_Rep = "*All Records";
                ViewBag.Sell_Rep1 = "0";

                ViewBag.Shipping_Locatoin = "*All Records";
                ViewBag.Shipping_Locatoin1 = "0";

                ViewBag.Order_Type = "*All Records";
                ViewBag.Order_Type1 = "0";

                ViewBag.Product_Code = "*All Records";
                ViewBag.Product_Code1 = "0";
                ViewBag.rangevaltext = "*All Records";
                ViewBag.rangevaltext2 = "0";
            }

            dynamic mymodel = new ExpandoObject();


            string name = obj["filter"];
            ViewBag.Filter = name;
            if (name == "Run Report Now")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_SynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID", 7150);
                    cmd.Parameters.AddWithValue("@Syn_Report_Name", "Open Pick Ticket Listing");
                    cmd.Parameters.AddWithValue("@Syn_Report_Date", DateTime.Now);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();
                   
                }
                ViewBag.DateShipped1 = obj["DateShipped1"].ToString();
                ViewBag.DateShipped2 = obj["DateShipped2"].ToString();
                ViewBag.rangevaltext = obj["rangevaltext"].ToString();
                ViewBag.rangevaltext2 = obj["rangevaltext1"].ToString();

                ViewBag.FinishGoodsItem = FinishGoodsItem;
                ViewBag.ddlCustomerID = ddlCustomerID;
                ViewBag.ddlCustomerName = ddlCustomerName;
                ViewBag.InventoryType = InventoryType;
                ViewBag.DateShipped = DateShipped;
                ViewBag.SellRep = SellRep;
                ViewBag.ShippingLocatoin = ShippingLocatoin;
                ViewBag.OrderType = OrderType;
                ViewBag.ProductCode = ProductCode;
                ViewBag.dllsorting = dllsorting;

                string beg_date = string.Empty;
                string end_date = string.Empty;
                ViewBag.btn = "filter";
                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(1900);
                reportViewer.Height = Unit.Percentage(1900);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7150";
                string beg_fg_id = obj["FinishGoodsItemID"].ToString() != "" ? obj["FinishGoodsItemID"].ToString() : "0";          
                string end_fg_id = obj["FinishGoodsItemID2"].ToString() != "" ? obj["FinishGoodsItemID2"].ToString() : "0";            
                string beg_customer_id = obj["CustomerID1"].ToString() != "" ? obj["CustomerID1"].ToString() : "0";           
                string end_customer_id = obj["CustomerID2"].ToString() != "" ? obj["CustomerID2"].ToString() : "0";               
                string beg_customer_name = obj["CustomerName1"].ToString() != "" ? obj["CustomerName1"].ToString() : "0";
                string end_customer_name = obj["CustomerName2"].ToString() != "" ? obj["CustomerName2"].ToString() : "0";
               
                if (DateShipped == "Between Range")
                {
                    beg_date = obj["DateShipped1"].ToString();
                    end_date = obj["DateShipped2"].ToString();
                }
                else if (DateShipped == "")
                {
                    beg_date = obj["DateShipped1"].ToString();
                    end_date = obj["DateShipped2"].ToString();
                }
                else if (DateShipped == "*All Records")
                {
                    beg_date = obj["rangevaltext"].ToString();
                    end_date = obj["rangevaltext1"].ToString();
                    //beg_date = obj["DateShipped1"].ToString();
                    //end_date = obj["DateShipped2"].ToString();
                }
                else
                {
                    beg_date = obj["rangevaltext"].ToString();
                    end_date = obj["DateShipped2"].ToString();
                }
                string beg_inventory_type = obj["InventoryType1"].ToString() != "" ? obj["InventoryType1"].ToString() : "0";
                string end_inventory_type = obj["InventoryType2"].ToString() != "" ? obj["InventoryType2"].ToString() : "0";
                string beg_sales_rep = obj["SellRep1"].ToString() != "" ? obj["SellRep1"].ToString() : "0";
                string end_sales_rep = obj["SellRep2"].ToString() != "" ? obj["SellRep2"].ToString() : "0";
                string beg_shipto_id = obj["ShippingLocatoin1"].ToString() != "" ? obj["ShippingLocatoin1"].ToString() : "0";
                string end_shipto_id = obj["ShippingLocatoin2"].ToString() != "" ? obj["ShippingLocatoin2"].ToString() : "0";
                string beg_order_type = obj["OrderType1"].ToString() != "" ? obj["OrderType1"].ToString() : "0";
                string end_order_type = obj["OrderType2"].ToString() != "" ? obj["OrderType2"].ToString() : "0";
                string beg_product_code = obj["ProductCode1"].ToString() != "" ? obj["ProductCode1"].ToString() : "0";
                string end_product_code = obj["ProductCode2"].ToString() != "" ? obj["ProductCode2"].ToString() : "0";
               
               
                string Sorting_Name = String.Empty;
                if (dllsorting == "Customer Name")
                {
                    Sorting_Name = "billto_name";
                }
                else
                {
                    Sorting_Name = "type_code";
                }
                ReportParameter[] myparams = new ReportParameter[19];
                myparams[0] = new ReportParameter("beg_fg_id", beg_fg_id, false);
                myparams[1] = new ReportParameter("end_fg_id", end_fg_id, false);
                myparams[2] = new ReportParameter("beg_customer_id", beg_customer_id, false);
                myparams[3] = new ReportParameter("end_customer_id", end_customer_id, false);
                myparams[4] = new ReportParameter("beg_customer_name", beg_customer_name, false);
                myparams[5] = new ReportParameter("end_customer_name", end_customer_name, false);

                myparams[6] = new ReportParameter("beg_date", beg_date, false);

                myparams[7] = new ReportParameter("end_date", end_date, false);
                myparams[8] = new ReportParameter("beg_inventory_type", beg_inventory_type, false);
                myparams[9] = new ReportParameter("end_inventory_type", end_inventory_type, false);
                myparams[10] = new ReportParameter("beg_sales_rep", beg_sales_rep, false);
                myparams[11] = new ReportParameter("end_sales_rep", end_sales_rep, false);
                myparams[12] = new ReportParameter("beg_shipto_id", beg_shipto_id, false);
                myparams[13] = new ReportParameter("end_shipto_id", end_shipto_id, false);
                myparams[14] = new ReportParameter("beg_order_type", beg_order_type, false);
                myparams[15] = new ReportParameter("end_order_type", end_order_type, false);
                myparams[16] = new ReportParameter("beg_product_code", beg_product_code, false);
                myparams[17] = new ReportParameter("end_product_code", end_product_code, false);
                myparams[18] = new ReportParameter("Sorting_Name", Sorting_Name, false);
                reportViewer.ServerReport.SetParameters(myparams);

                reportViewer.ServerReport.Refresh();
                ViewBag.ReportViewer = reportViewer;

                mymodel.FinishGoodItem = GetFinishGoodItem();
                mymodel.CustomerIDs = GetCustomerIDs();
                mymodel.CustomerName2 = GetCustomerName2();
                mymodel.InventoryType2 = GetInventoryType2();
                mymodel.SalesRep2 = GetSalesRep2();
                mymodel.ShippingLocation2 = GetShippingLocation2();
                mymodel.OrderType2 = GetOrderType2();
                mymodel.ProductCode2 = GetProductCode2();
                return View(mymodel);
            }

           
            mymodel.FinishGoodItem = GetFinishGoodItem();
            mymodel.CustomerIDs = GetCustomerIDs();
            mymodel.CustomerName2 = GetCustomerName2();
            mymodel.InventoryType2 = GetInventoryType2();
            mymodel.SalesRep2 = GetSalesRep2();
            mymodel.ShippingLocation2 = GetShippingLocation2();
            mymodel.OrderType2 = GetOrderType2();
            mymodel.ProductCode2 = GetProductCode2();



            return View(mymodel);

        }
        public ActionResult FilterOption7160(FormCollection obj, string filter, string DateShipped, string MaterialID, string SizeCode, string FinishGoodItemMU, string CustomerID, string CustomerName, string InventoryType, string dllsorting)
        {
            Session["ReportName"] = "Material Usage (7160)";
            ViewBag.DateShipped1 = string.Empty;
            ViewBag.DateShipped2 = string.Empty;
            ViewBag.rangevaltext = string.Empty;
            ViewBag.rangevaltext2 = string.Empty;
            ViewBag.MaterialID = string.Empty;
            dynamic mymodel = new ExpandoObject();
            string name = obj["filter"];
            ViewBag.Filter = name;
            if (filter == "Run as a Job and Notify")
            {
               
                TempData["ReportView"] = obj;
                TempData["DateShipped"] = DateShipped;
                TempData["dllsorting"] = dllsorting;
                TempData["EmailID"] = Session["EmailID"].ToString();
                TempData["UserID"] = Session["UserID"].ToString();
                List<string> _pagecontent = new List<string>();
                return RedirectToAction("RunReportAsyn7160", "Report");
            }
            if (filter != "Run Report Now")
            {

                ViewBag.MaterialID1MU = "*All Records";
                ViewBag.MaterialID1MU1 = "0";

                ViewBag.CustomerId = "*All Records";
                ViewBag.CustomerId1 = "0";

                ViewBag.CustomerName = "*All Records";
                ViewBag.CustomerName1 = "0";

                ViewBag.DateShipped1 = "*All Records";
                ViewBag.DateShipped2 = "0";

                ViewBag.SizeCode1MU = "*All Records";
                ViewBag.SizeCode1MU1 = "0";

                ViewBag.Inventory_Type = "*All Records";
                ViewBag.Inventory_Type1 = "0";

                ViewBag.FinishGoodItem1MU = "*All Records";
                ViewBag.FinishGoodItem1MU1 = "0";

                ViewBag.Shipping_Locatoin = "*All Records";
                ViewBag.Shipping_Locatoin1 = "0";
                ViewBag.rangevaltext = "*All Records";
                ViewBag.rangevaltext2 = "0";



            }
            if (name == "Run Report Now")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_SynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID",7160);
                    cmd.Parameters.AddWithValue("@Syn_Report_Name", "Material Usage");
                    cmd.Parameters.AddWithValue("@Syn_Report_Date", DateTime.Now);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();

                }
                ViewBag.DateShipped1 = obj["DateShipped1"].ToString();
                ViewBag.DateShipped2 = obj["DateShipped2"].ToString();
                ViewBag.rangevaltext = obj["rangevaltext"].ToString();
                ViewBag.rangevaltext2 = obj["rangevaltext1"].ToString();
                ViewBag.MaterialID = obj["MaterialID1MU"].ToString();
                ViewBag.SizeCode = SizeCode;
                ViewBag.FinishGoodItemMU = FinishGoodItemMU;
                ViewBag.DateShipped = DateShipped;
                ViewBag.CustomerID = CustomerID;
                ViewBag.CustomerName = CustomerName;
                ViewBag.InventoryType = InventoryType;
                ViewBag.dllsorting = dllsorting;
                ViewBag.DateShipped = DateShipped;
                mymodel.SizeCode2 = GetSizeCode2();
                mymodel.MaterialID2 = GetMaterialID2();
                mymodel.FinishGoodItem2 = GetFinishGoodItem();
                mymodel.CustomerID2 = GetCustomerIDs();
                mymodel.CustomerName2 = GetCustomerName2();
                mymodel.InventoryType2 = GetInventoryType2();
                //ViewBag.DateShipped1 = obj["DateShipped1"].ToString();
                //ViewBag.DateShipped2 = obj["DateShipped2"].ToString();
                string beg_date = string.Empty;
                string end_date = string.Empty;
                ViewBag.btn = "filter";

                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(900);
                reportViewer.Height = Unit.Percentage(900);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7160";
                string beg_material_id = obj["MaterialID1MU"].ToString() != "" ? obj["MaterialID1MU"].ToString() : "0";
                string end_material_id = obj["MaterialID2MU1"].ToString() != "" ? obj["MaterialID2MU1"].ToString() : "0"; 
                string beg_size_code = obj["SizeCode1MU"].ToString() != "" ? obj["SizeCode1MU"].ToString() : "0"; 
                string end_size_code = obj["SizeCode2MU"].ToString() != "" ? obj["SizeCode2MU"].ToString() : "0"; 
                //beg_date = obj["DateShipped1"].ToString();
                //end_date = obj["DateShipped2"].ToString();
                if (DateShipped == "Between Range")
                {
                    beg_date = obj["DateShipped1"].ToString();
                    end_date = obj["DateShipped2"].ToString();
                }
                else if (DateShipped == "")
                {
                    beg_date = obj["DateShipped1"].ToString();
                    end_date = obj["DateShipped2"].ToString();
                }
                else if (DateShipped == "*All Records")
                {
                    beg_date = obj["rangevaltext"].ToString();
                    end_date = obj["rangevaltext1"].ToString();
                    //beg_date = obj["DateShipped1"].ToString();
                    //end_date = obj["DateShipped2"].ToString();
                }
                else
                {
                    beg_date = obj["rangevaltext"].ToString();
                    end_date = obj["DateShipped2"].ToString();
                }
                string beg_fg_id = obj["FinishGoodItem1MU"].ToString() != "" ? obj["FinishGoodItem1MU"].ToString() : "0";
                string end_fg_id = obj["FinishGoodItem2MU"].ToString() != "" ? obj["FinishGoodItem2MU"].ToString() : "0";
                string beg_inventory_type = obj["InventoryType1MU"].ToString() != "" ? obj["InventoryType1MU"].ToString() : "0";
                string end_inventory_type = obj["InventoryType2MU"].ToString() != "" ? obj["InventoryType2MU"].ToString() : "0";
                string beg_customer_id = obj["CustomerID1MU"].ToString() != "" ? obj["CustomerID1MU"].ToString() : "0";
                string end_customer_id = obj["CustomerID2MU"].ToString() != "" ? obj["CustomerID2MU"].ToString() : "0";
                string beg_customer_name = obj["CustomerName1MU"].ToString() != "" ? obj["CustomerName1MU"].ToString() : "0";
                string end_customer_name = obj["CustomerName2MU"].ToString() != "" ? obj["CustomerName2MU"].ToString() : "0";
                 string Sorting_Name = String.Empty;
                if (dllsorting== "Inventory Type")
                {
                    Sorting_Name = "Inventory Type";
                }
                else
                {
                    Sorting_Name = "Sheet Size";
                }
                ReportParameter[] myparams = new ReportParameter[15];
                myparams[0] = new ReportParameter("beg_material_id", beg_material_id, false);
                myparams[1] = new ReportParameter("end_material_id", end_material_id, false);
                myparams[2] = new ReportParameter("beg_size_code", beg_size_code, false);
                myparams[3] = new ReportParameter("end_size_code", end_size_code, false);
                myparams[4] = new ReportParameter("beg_date", beg_date, false);
                myparams[5] = new ReportParameter("end_date", end_date, false);
                myparams[6] = new ReportParameter("beg_fg_id", beg_fg_id, false);
                myparams[7] = new ReportParameter("end_fg_id", end_fg_id, false);
                myparams[8] = new ReportParameter("beg_inventory_type", beg_inventory_type, false);
                myparams[9] = new ReportParameter("end_inventory_type", end_inventory_type, false);
                myparams[10] = new ReportParameter("beg_customer_id", beg_customer_id, false);
                myparams[11] = new ReportParameter("end_customer_id", end_customer_id, false);
                myparams[12] = new ReportParameter("beg_customer_name", beg_customer_name, false);
                myparams[13] = new ReportParameter("end_customer_name", end_customer_name, false);
                myparams[14] = new ReportParameter("Sorting_Name", Sorting_Name, false);
                reportViewer.ServerReport.SetParameters(myparams);

                reportViewer.ServerReport.Refresh();
                ViewBag.ReportViewer = reportViewer;
                //return View(mymodel);
            }
            mymodel.SizeCode2 = GetSizeCode2();
            mymodel.MaterialID2 = GetMaterialID2();
            mymodel.FinishGoodItem2 = GetFinishGoodItem();
            mymodel.CustomerID2 = GetCustomerIDs();
            mymodel.CustomerName2 = GetCustomerName2();
            mymodel.InventoryType2 = GetInventoryType2();       
          
            return View(mymodel);
        }
        public ActionResult FilterOption7820(FormCollection obj,string filter)
        {
            try
            {
                Session["ReportName"] = "Profit Detail (7820)";
                ViewBag.Filter = filter;
                dynamic mymodel = new ExpandoObject();
                if (filter == "Run as a Job and Notify")
                {
                    
                    TempData["ReportView"] = obj;
                    TempData["EmailID"] = Session["EmailID"].ToString();
                    TempData["UserID"] = Session["UserID"].ToString();
                    List<string> _pagecontent = new List<string>();
                    return RedirectToAction("RunReportAsyn7820", "Report");
                }
                //mymodel.MasterJob2 = GetMasterJob2();
                int id = Convert.ToInt32(Session["id"]);
                ViewBag.txtMasterJob = "*All Records";
                ViewBag.txtMasterJob2 = "0";
             
                if (filter == "Run Report Now")
                {
                    using (cn = new SqlConnection(connString))
                    {
                        cn.Open();
                        cmd = new SqlCommand("sp_Insert_Update_SynReport", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                        cmd.Parameters.AddWithValue("@Report_ID", 7820);
                        cmd.Parameters.AddWithValue("@Syn_Report_Name", "Profit Detail");
                        cmd.Parameters.AddWithValue("@Syn_Report_Date", DateTime.Now);
                        cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                        int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                        int res = cmd.ExecuteNonQuery();
                        cn.Close();

                    }
                    ViewBag.masterJob= obj["MasterJob"].ToString();

                    string UrlReportServer = "http://ts2pw8vv/ReportServer";
                    ReportViewer reportViewer = new ReportViewer();
                    reportViewer.ProcessingMode = ProcessingMode.Remote;
                    reportViewer.AsyncRendering = true;
                    reportViewer.SizeToReportContent = true;
                    reportViewer.Width = Unit.Percentage(0);
                    reportViewer.Height = Unit.Percentage(0);
                    reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                    reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7820_MainRep";
                    string beg_mst_job = obj["txtMasterJob"].ToString() != "" ? obj["txtMasterJob"].ToString() : "0";
                    string end_mst_job = obj["txtMasterJob2"].ToString() != "" ? obj["txtMasterJob2"].ToString() : "0";
                   
                    ReportParameter[] myparams = new ReportParameter[2];
                    myparams[0] = new ReportParameter("beg_mst_job", beg_mst_job, false);
                    myparams[1] = new ReportParameter("end_mst_job", end_mst_job, false);
                    reportViewer.ServerReport.SetParameters(myparams);
                    reportViewer.ServerReport.Refresh();
                    ViewBag.ReportViewer = reportViewer;
                    mymodel.MasterJob2 = GetMasterJob2();
                    return View(mymodel);
                }
                mymodel.MasterJob2 = GetMasterJob2();
                return View(mymodel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult FilterOption7330(FormCollection obj, string filter, string BoxSetID)
        {
            try
            {
                Session["ReportName"] = "Box Label (7330)";
                dynamic mymodel = new ExpandoObject();
                mymodel.BoxSetID2 = GetBoxSetID2();
                string name = obj["filter"];
                ViewBag.Filter = name;
                ViewBag.BoxSetID1BL = "*All Records";
                ViewBag.BoxSetID2BL = "0";
                if (filter == "Run as a Job and Notify")
                {
                    string Link = "http://10.2.0.140/VSPAPPLICATION3/VSP/VSP7330.xls";

                    using (cn = new SqlConnection(connString))
                    {
                        cn.Open();
                        cmd = new SqlCommand("sp_Insert_Update_AsynReport", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                        cmd.Parameters.AddWithValue("@Report_ID", 7330);
                        cmd.Parameters.AddWithValue("@Asyn_Report_Name", "Box Label");
                        cmd.Parameters.AddWithValue("@Asyn_Report_Date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Asyn_Report_Link", Link);
                        cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                        int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                        int res = cmd.ExecuteNonQuery();
                        cn.Close();

                    }
                    TempData["ReportView"] = obj;
                    List<string> _pagecontent = new List<string>();
                    return RedirectToAction("RunReportAsyn7330", "Report");
                }
                if (filter == "Run Report Now")
                {
                    using (cn = new SqlConnection(connString))
                    {
                        cn.Open();
                        cmd = new SqlCommand("sp_Insert_Update_SynReport", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                        cmd.Parameters.AddWithValue("@Report_ID", 7330);
                        cmd.Parameters.AddWithValue("@Syn_Report_Name", "Box Label");
                        cmd.Parameters.AddWithValue("@Syn_Report_Date", DateTime.Now);
                        cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                        int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                        int res = cmd.ExecuteNonQuery();
                        cn.Close();

                    }
                    ViewBag.BoxSetID = BoxSetID;
                    string beg_date = string.Empty;
                    ViewBag.btn = "filter";

                    string UrlReportServer = "http://ts2pw8vv/ReportServer";
                    ReportViewer reportViewer = new ReportViewer();
                    reportViewer.ProcessingMode = ProcessingMode.Remote;
                    reportViewer.AsyncRendering = true;
                    reportViewer.SizeToReportContent = true;
                    reportViewer.Width = Unit.Percentage(900);
                    reportViewer.Height = Unit.Percentage(900);
                    reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                    reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7330";
                    string beg_box_set = obj["BoxSetID1BL"].ToString() != "" ? obj["BoxSetID1BL"].ToString() : "0";
                    string end_box_set = obj["BoxSetID2BL"].ToString() != "" ? obj["BoxSetID2BL"].ToString() : "0";
                   
                    ReportParameter[] myparams = new ReportParameter[2];
                    myparams[0] = new ReportParameter("beg_box_set", beg_box_set, false);
                    myparams[1] = new ReportParameter("end_box_set", end_box_set, false);

                    reportViewer.ServerReport.SetParameters(myparams);

                    reportViewer.ServerReport.Refresh();
                    ViewBag.ReportViewer = reportViewer;

                    return View(mymodel);
                }


                int id = Convert.ToInt32(Session["id"]);
                ViewBag.ReportName = string.Empty;
                ViewBag.ReportName = "Box Label(VSP7330)";


                return View(mymodel);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public ActionResult FilterOption7110(FormCollection obj, string filter)
        {
            Session["ReportName"] = "Sell Price Per Sq.Ft. (7110)";
            ViewBag.EstimateId_Beg = "*All Records";
            ViewBag.EstimateId_End = "0";

            ViewBag.MasterPart_Beg = "*All Records";
            ViewBag.MasterPart_End = "0";

            ViewBag.CustomerId_Beg = "*All Records";
            ViewBag.CustomerId_End = "0";

            ViewBag.CustLeadName_Beg = "*All Records";
            ViewBag.CustLeadName_End = "0";

            ViewBag.Material_ID_Beg = "*All Records";
            ViewBag.Material_ID_End = "0";

            ViewBag.ProductCode_Beg = "*All Records";
            ViewBag.ProductCode_End = "0";
            ViewBag.Filter = filter;
            dynamic mymodel = new ExpandoObject();
            if (filter == "Run as a Job and Notify")
            {
                
                TempData["ReportView"] = obj;
                TempData["EmailID"] = Session["EmailID"].ToString();
                TempData["UserID"] = Session["UserID"].ToString();
                List<string> _pagecontent = new List<string>();
                return RedirectToAction("RunReportAsyn7110", "Report");
            }
            if (filter == "Run Report Now")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_SynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID",7110);
                    cmd.Parameters.AddWithValue("@Syn_Report_Name", "Sell Price Per Sq.Ft.");
                    cmd.Parameters.AddWithValue("@Syn_Report_Date", DateTime.Now);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();

                }
                ViewBag.EstimateId = obj["EstimateId"].ToString();
                ViewBag.MasterPart = obj["MasterPart"].ToString();

                ViewBag.CustomerLeadId = obj["CustomerLeadId"].ToString();
                ViewBag.CustLeadName = obj["CustLeadName"].ToString();

                ViewBag.Material_ID = obj["Material_ID"].ToString();
                ViewBag.ProductCode = obj["ProductCode"].ToString();
                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(0);
                reportViewer.Height = Unit.Percentage(0);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7110";
                string beg_est_id = obj["EstimateId_Beg"].ToString() != "" ? obj["EstimateId_Beg"].ToString() : "0";
                string end_est_id = obj["EstimateId_End"].ToString() != "" ? obj["EstimateId_End"].ToString() : "0";
                string beg_master_part = obj["MasterPart_Beg"].ToString() != "" ? obj["MasterPart_Beg"].ToString() : "0";
                string end_master_part = obj["MasterPart_End"].ToString() != "" ? obj["MasterPart_End"].ToString() : "0";
                string beg_customer_id = obj["CustomerId_Beg"].ToString() != "" ? obj["CustomerId_Beg"].ToString() : "0";
                string end_customer_id = obj["CustomerId_End"].ToString() != "" ? obj["CustomerId_End"].ToString() : "0";
                string beg_customer_name = obj["CustLeadName_Beg"].ToString() != "" ? obj["CustLeadName_Beg"].ToString() : "0";
                string end_customer_name = obj["CustLeadName_End"].ToString() != "" ? obj["CustLeadName_End"].ToString() : "0";
                string beg_material_id = obj["Material_ID_Beg"].ToString() != "" ? obj["Material_ID_Beg"].ToString() : "0";
                string end_material_id = obj["Material_ID_End"].ToString() != "" ? obj["Material_ID_End"].ToString() : "0";
                string beg_product_code = obj["ProductCode_Beg"].ToString() != "" ? obj["ProductCode_Beg"].ToString() : "0";
                string end_product_code = obj["ProductCode_End"].ToString() != "" ? obj["ProductCode_End"].ToString() : "0";
               
                ReportParameter[] myparams = new ReportParameter[12];
                myparams[0] = new ReportParameter("beg_est_id", beg_est_id, false);
                myparams[1] = new ReportParameter("end_est_id", end_est_id, false);
                myparams[2] = new ReportParameter("beg_master_part", beg_master_part, false);
                myparams[3] = new ReportParameter("end_master_part", end_master_part, false);
                myparams[4] = new ReportParameter("beg_customer_id", beg_customer_id, false);
                myparams[5] = new ReportParameter("end_customer_id", end_customer_id, false);
                myparams[6] = new ReportParameter("beg_customer_name", beg_customer_name, false);
                myparams[7] = new ReportParameter("end_customer_name", beg_material_id, false);
                myparams[8] = new ReportParameter("beg_material_id", beg_material_id, false);
                myparams[9] = new ReportParameter("end_material_id", end_material_id, false);
                myparams[10] = new ReportParameter("beg_product_code", beg_product_code, false);
                myparams[11] = new ReportParameter("end_product_code", end_product_code, false);

                reportViewer.ServerReport.SetParameters(myparams);
                reportViewer.ServerReport.Refresh();
                ViewBag.ReportViewer = reportViewer;
                //return View(mymodel);
            }
            mymodel.ProductCode = GetProductCode2();
            mymodel.CutomerLead = GetCutomerLead();
            mymodel.Masterpart = GetMasterpart();
            mymodel.MaterialID = GetMaterialID2();
            mymodel.Estimate_id = GetEstimate_id();
            return View(mymodel);
        }
        public ActionResult FilterOption7830(FormCollection obj, string filter, string IndustryCode, string ProductCode, string ProductDescription, string SalesRepID, string DateShipped)
        {
            Session["ReportName"] = "Sales By Product (7830)";
            ViewBag.DateShipped1 = string.Empty;
            ViewBag.DateShipped2 = string.Empty;
            ViewBag.rangevaltext = string.Empty;
            ViewBag.rangevaltext2 = string.Empty;
            //ViewBag.IndustryCode2 = string.Empty;
            //ViewBag.ProductCode2 = string.Empty;
            ViewBag.DateShippedValue = string.Empty;
            string name = obj["filter"];
            ViewBag.Filter = name;
            if (filter == "Run as a Job and Notify")
            {
                
                TempData["ReportView"] = obj;
                TempData["DateShipped"] = DateShipped;
                TempData["EmailID"] = Session["EmailID"].ToString();
                TempData["UserID"] = Session["UserID"].ToString();
                List<string> _pagecontent = new List<string>();
                return RedirectToAction("RunReportAsyn7830", "Report");
            }
            if (filter != "Run Report Now")
            {
                ViewBag.IndustryCode = "*All Records";
                ViewBag.IndustryCode2 = "0";
                ViewBag.ProductCode = "*All Records";
                ViewBag.ProductCode2 = "0";
                ViewBag.ProductDescription = "*All Records";
                ViewBag.ProductDescription2 = "0";
                ViewBag.SalesRepID = "*All Records";
                ViewBag.SalesRepID2 = "0";
                ViewBag.DateShipped1 = "*All Records";
                ViewBag.DateShipped2 = "0";
                ViewBag.rangevaltext = "*All Records";
                ViewBag.rangevaltext2 = "0";
            }
            ViewBag.Message = "Welcome to my demo!";
            dynamic mymodel = new ExpandoObject();
            if (filter == "Run Report Now")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_SynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID", 7830);
                    cmd.Parameters.AddWithValue("@Syn_Report_Name", "Sales By Product");
                    cmd.Parameters.AddWithValue("@Syn_Report_Date", DateTime.Now);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();

                }
                ViewBag.DateShipped1 = obj["DateShipped1"].ToString();
                ViewBag.DateShipped2 = obj["DateShipped2"].ToString();
                ViewBag.rangevaltext = obj["rangevaltext"].ToString();
                ViewBag.rangevaltext2 = obj["rangevaltext1"].ToString();
                string beg_date = string.Empty;
                string end_date = string.Empty;
                ViewBag.IndustryCode = IndustryCode;
                ViewBag.ProductCode = ProductCode;
                ViewBag.ProductDescription = ProductDescription;

                ViewBag.SalesRepID = SalesRepID;
                ViewBag.DateShipped = DateShipped;

                //2nd textbox getting value
                ViewBag.IndustryCode2 = obj["IndustryCode2SBP"].ToString();
                ViewBag.ProductCode2 = obj["ProductCode2SBP"].ToString();
                ViewBag.ProductDescription2 = obj["ProductDescription2SBP"].ToString();
                ViewBag.SalesRepID2 = obj["SalesRepID2SBP"].ToString();
                //ViewBag.DateShipped = obj["DateShipped1"].ToString();
                ViewBag.DateShipped12 = obj["DateShipped2"].ToString();
                mymodel.IndustryCode2 = GetIndustryCode2();
                mymodel.ProductCode2 = GetProductCode2();
                mymodel.ProductDescription2 = GetProductDescription2();
                mymodel.SalesRep2 = GetSalesRep2();
                int id = Convert.ToInt32(Session["id"]);
                ViewBag.ReportName = string.Empty;

                ViewBag.ReportName = "Sales By Product(VSP7830)";

                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(0);
                reportViewer.Height = Unit.Percentage(0);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7830";
                string beg_industry = obj["IndustryCode1SBP"].ToString() != "" ? obj["IndustryCode1SBP"].ToString() : "0";
                string end_industry = obj["IndustryCode2SBP"].ToString() != "" ? obj["IndustryCode2SBP"].ToString() : "0";
                string beg_product = obj["ProductCode1SBP"].ToString() != "" ? obj["ProductCode1SBP"].ToString() : "0";
                string end_product = obj["ProductCode2SBP"].ToString() != "" ? obj["ProductCode2SBP"].ToString() : "0";
                string beg_product_desc = obj["ProductDescription1SBP"].ToString() != "" ? obj["ProductDescription1SBP"].ToString() : "0";
                string end_product_desc = obj["ProductDescription2SBP"].ToString() != "" ? obj["ProductDescription2SBP"].ToString() : "0";
                string beg_sales = obj["SalesRepID1SBP"].ToString() != "" ? obj["SalesRepID1SBP"].ToString() : "0";
                string end_sales = obj["SalesRepID2SBP"].ToString() != "" ? obj["SalesRepID2SBP"].ToString() : "0";
                
                if (DateShipped == "Between Range")
                {
                    beg_date = obj["DateShipped1"].ToString();
                    end_date = obj["DateShipped2"].ToString();
                }
                else if (DateShipped == "")
                {
                    beg_date = obj["DateShipped1"].ToString();
                    end_date = obj["DateShipped2"].ToString();
                }
                else if (DateShipped == "*All Records")
                {
                    beg_date = obj["rangevaltext"].ToString();
                    end_date = obj["rangevaltext1"].ToString();
                    //beg_date = obj["DateShipped1"].ToString();
                    //end_date = obj["DateShipped2"].ToString();
                }
                else
                {
                    beg_date = obj["rangevaltext"].ToString();
                    end_date = obj["DateShipped2"].ToString();
                }

                //string end_date_wanted = obj["DateShipped2"].ToString();
                ReportParameter[] myparams = new ReportParameter[10];
                myparams[0] = new ReportParameter("beg_industry", beg_industry, false);
                myparams[1] = new ReportParameter("end_industry", end_industry, false);
                myparams[2] = new ReportParameter("beg_product", beg_product, false);
                myparams[3] = new ReportParameter("end_product", end_product, false);
                myparams[4] = new ReportParameter("beg_product_desc", beg_product_desc, false);
                myparams[5] = new ReportParameter("end_product_desc", end_product_desc, false);
                myparams[6] = new ReportParameter("beg_sales", beg_sales, false);
                myparams[7] = new ReportParameter("end_sales", end_sales, false);
                myparams[8] = new ReportParameter("beg_date_wanted", beg_date, false);
                myparams[9] = new ReportParameter("end_date_wanted", end_date, false);
                reportViewer.ServerReport.SetParameters(myparams);
                reportViewer.ServerReport.Refresh();
                ViewBag.ReportViewer = reportViewer;
                return View(mymodel);
            }
            mymodel.IndustryCode2 = GetIndustryCode2();
            mymodel.ProductCode2 = GetProductCode2();
            mymodel.ProductDescription2 = GetProductDescription2();
            mymodel.SalesRep2 = GetSalesRep2();
            return View(mymodel);
        }
        public ActionResult FilterOption7140(string filter, FormCollection obj, string InventoryTypeCYSBM, string KindCodeCYSBM, string CustomerNameCYSBM, string CustomerIDCYSBM, string dllsorting)
        {
            Session["ReportName"] = "Calendar year sales by month (7140)";
            ViewBag.Filter = filter;
            ViewBag.CustomerId = string.Empty;
            ViewBag.CustomerId1 = string.Empty;

            ViewBag.CustomerName = string.Empty;
            ViewBag.CustomerName1 = string.Empty;

            ViewBag.InventoryType1CYSBM = string.Empty;
            ViewBag.InventoryType2CYSBM = string.Empty;

            ViewBag.KindCode1CYSBM = string.Empty;
            ViewBag.KindCode2CYSBM = string.Empty;
            try
            {
                if (filter == "Run as a Job and Notify")
                {
                   
                    TempData["ReportView"] = obj;
                    TempData["EmailID"] = Session["EmailID"].ToString();
                    TempData["UserID"] = Session["UserID"].ToString();
                    List<string> _pagecontent = new List<string>();
                    return RedirectToAction("RunReportAsyn7140", "Report");
                }

                dynamic mymodel = new ExpandoObject();

                if (filter == "Run Report Now")
                {
                    using (cn = new SqlConnection(connString))
                    {
                        cn.Open();
                        cmd = new SqlCommand("sp_Insert_Update_SynReport", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                        cmd.Parameters.AddWithValue("@Report_ID", 7140);
                        cmd.Parameters.AddWithValue("@Syn_Report_Name", "Calendar year sales by month");
                        cmd.Parameters.AddWithValue("@Syn_Report_Date", DateTime.Now);
                        cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                        int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                        int res = cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                    ViewBag.InventoryTypeCYSBM = InventoryTypeCYSBM;
                    ViewBag.KindCodeCYSBM = KindCodeCYSBM;

                    ViewBag.CustomerNameCYSBM = CustomerNameCYSBM;
                    ViewBag.CustomerIDCYSBM = CustomerIDCYSBM;
                    ViewBag.dllsortingCYSBM = dllsorting;
                    mymodel.CustomerID2 = GetCustomerIDs();
                    mymodel.CustomerName2 = GetCustomerName2();
                    mymodel.InventoryType2 = GetInventoryType2();
                    mymodel.KindCode2 = GeKindCode2();
                    string UrlReportServer = "http://ts2pw8vv/ReportServer";
                    ReportViewer reportViewer = new ReportViewer();
                    reportViewer.ProcessingMode = ProcessingMode.Remote;
                    reportViewer.AsyncRendering = true;
                    reportViewer.SizeToReportContent = true;
                    reportViewer.Width = Unit.Percentage(0);
                    reportViewer.Height = Unit.Percentage(0);
                    reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                    reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7140";
                    string beg_customer_id = obj["CustomerID1CYSBM"].ToString() != "" ? obj["CustomerID1CYSBM"].ToString() : "0";
                    string end_customer_id = obj["CustomerID2CYSBM"].ToString() != "" ? obj["CustomerID2CYSBM"].ToString() : "0";
                    string beg_customer_name = obj["CustomerName1CYSBM"].ToString() != "" ? obj["CustomerName1CYSBM"].ToString() : "0";
                    string end_customer_name = obj["CustomerName2CYSBM"].ToString() != "" ? obj["CustomerName2CYSBM"].ToString() : "0";
                    string beg_inventory_type = obj["InventoryType1CYSBM"].ToString() != "" ? obj["InventoryType1CYSBM"].ToString() : "0";
                    string end_inventory_type = obj["InventoryType2CYSBM"].ToString() != "" ? obj["InventoryType2CYSBM"].ToString() : "0";
                    string beg_kind = obj["KindCode1CYSBM"].ToString() != "" ? obj["KindCode1CYSBM"].ToString() : "0";
                    string end_kind = obj["KindCode2CYSBM"].ToString() != "" ? obj["KindCode2CYSBM"].ToString() : "0";
                    string ddlSort = obj["dllsorting"].ToString();
                    string Sorting_Name = String.Empty;
                    if (ddlSort == "Customer Name")
                    {
                        Sorting_Name = "customer_id";
                    }
                    else if (ddlSort == "Inventory Type")
                    {
                        Sorting_Name = "type_id";
                    }
                    else
                    {
                        Sorting_Name = "kind_code";
                    }

                    ReportParameter[] myparams = new ReportParameter[9];
                    myparams[0] = new ReportParameter("beg_customer_id", beg_customer_id, false);
                    myparams[1] = new ReportParameter("end_customer_id", end_customer_id, false);
                    myparams[2] = new ReportParameter("beg_customer_name", beg_customer_name, false);
                    myparams[3] = new ReportParameter("end_customer_name", end_customer_name, false);
                    myparams[4] = new ReportParameter("beg_inventory_type", beg_inventory_type, false);
                    myparams[5] = new ReportParameter("end_inventory_type", end_inventory_type, false);
                    myparams[6] = new ReportParameter("beg_kind", beg_kind, false);
                    myparams[7] = new ReportParameter("end_kind", end_kind, false);
                    myparams[8] = new ReportParameter("Sorting_Name", Sorting_Name, false);

                    reportViewer.ServerReport.SetParameters(myparams);
                    reportViewer.ServerReport.Refresh();
                    ViewBag.ReportViewer = reportViewer;
                    return View(mymodel);
                }
                ViewBag.CustomerId = "*All Records";
                ViewBag.CustomerId1 = "0";

                ViewBag.CustomerName = "*All Records";
                ViewBag.CustomerName1 = "0";

                ViewBag.InventoryType1CYSBM = "*All Records";
                ViewBag.InventoryType2CYSBM = "0";

                ViewBag.KindCode1CYSBM = "*All Records";
                ViewBag.KindCode2CYSBM = "0";

                mymodel.CustomerID2 = GetCustomerIDs();
                mymodel.CustomerName2 = GetCustomerName2();
                mymodel.InventoryType2 = GetInventoryType2();
                mymodel.KindCode2 = GeKindCode2();

                int id = Convert.ToInt32(Session["id"]);
                ViewBag.ReportName = string.Empty;

                ViewBag.ReportName = "Profit Detail(VSP7140)";

                return View(mymodel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult FilterOption9160(FormCollection obj, string filter, string DateLastActivity, string DateLastRecieved, string DateLastShiped, string DateLastAdjusted, string LocationFGCC, string Warehouse, string Kindcode, string InventoryType, string DescriptionFGCC, string FinishGoods)
        {

            try
            {
                Session["ReportName"] = "FG Cycle Count (9160)";
                if (filter == "Run as a Job and Notify")
                {
                   
                    TempData["ReportView"] = obj;
                    TempData["DateLastActivity"] = DateLastActivity;
                    TempData["DateLastRecieved"] = DateLastRecieved;
                    TempData["DateLastShiped"] = DateLastShiped;
                    TempData["DateLastAdjusted"] = DateLastAdjusted;
                    TempData["EmailID"] = Session["EmailID"].ToString();
                    TempData["UserID"] = Session["UserID"].ToString();
                    List<string> _pagecontent = new List<string>();
                    return RedirectToAction("RunReportAsyn9160", "Report");
                }
                string beg_date_activity = string.Empty;
                string end_date_activity = string.Empty;
                string beg_date_received = string.Empty;
                string end_date_received = string.Empty;
                string beg_date_shipped = string.Empty;
                string end_date_shipped = string.Empty;
                string beg_date_adjusted = string.Empty;
                string end_date_adjusted = string.Empty;

                ViewBag.DateLastActivity1FGCC = string.Empty;
                ViewBag.DateLastRecieved1FGCC = string.Empty;
                ViewBag.DateLastShiped1FGCC = string.Empty;
                ViewBag.DateLastAdjusted1FGCC = string.Empty;
                ViewBag.DateLastActivity2FGCC = string.Empty;
                ViewBag.DateLastRecieved2FGCC = string.Empty;
                ViewBag.DateLastShiped2FGCC = string.Empty;
                ViewBag.DateLastAdjusted2FGCC = string.Empty;
                ViewBag.rangevalDateLastActivity1FGCC = string.Empty;
                ViewBag.rangevalDateLastRecieved1FGCC = string.Empty;
                ViewBag.rangevalDateLastShiped1FGCC = string.Empty;
                ViewBag.rangevalDateLastAdjusted1FGCC = string.Empty;

                ViewBag.rangevalDateLastActivity2FGCC = string.Empty;
                ViewBag.rangevalDateLastRecieved2FGCC = string.Empty;
                ViewBag.rangevalDateLastShiped2FGCC = string.Empty;
                ViewBag.rangevalDateLastActivity2FGCC = string.Empty;

                dynamic mymodel = new ExpandoObject();
                if (filter == "Run Report Now")
                {
                    using (cn = new SqlConnection(connString))
                    {
                        cn.Open();
                        cmd = new SqlCommand("sp_Insert_Update_SynReport", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                        cmd.Parameters.AddWithValue("@Report_ID", 9160);
                        cmd.Parameters.AddWithValue("@Syn_Report_Name", "FG Cycle Count");
                        cmd.Parameters.AddWithValue("@Syn_Report_Date", DateTime.Now);
                        cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                        int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                        int res = cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                    ViewBag.dllskip = obj["dllskip"].ToString();
                    ViewBag.dllQuantityType = obj["dllQuantityType"].ToString();
                    ViewBag.dllsorting7160 = obj["dllsorting"].ToString();
                    ViewBag.Filter = "Run Report Now";
                    ViewBag.LocationFGCC = LocationFGCC;
                    ViewBag.Warehouse = Warehouse;
                    ViewBag.Kindcode = Kindcode;
                    ViewBag.InventoryType = InventoryType;

                    ViewBag.DescriptionFGCC = DescriptionFGCC;
                    ViewBag.FinishGoodsIDFGCC = FinishGoods;
                    ViewBag.DateLastActivity = DateLastActivity;
                    ViewBag.DateLastRecieved = DateLastRecieved;
                    ViewBag.DateLastShiped = DateLastShiped;
                    ViewBag.DateLastAdjusted = DateLastAdjusted;

                    ViewBag.DateLastActivity1FGCC = obj["DateLastActivity1FGCC"].ToString();
                    ViewBag.DateLastRecieved1FGCC = obj["DateLastRecieved1FGCC"].ToString();
                    ViewBag.DateLastShiped1FGCC = obj["DateLastShiped1FGCC"].ToString();
                    ViewBag.DateLastAdjusted1FGCC = obj["DateLastAdjusted1FGCC"].ToString();

                    ViewBag.DateLastActivity2FGCC = obj["DateLastActivity2FGCC"].ToString();
                    ViewBag.DateLastRecieved2FGCC = obj["DateLastRecieved2FGCC"].ToString();
                    ViewBag.DateLastShiped2FGCC = obj["DateLastShiped2FGCC"].ToString();
                    ViewBag.DateLastAdjusted2FGCC = obj["DateLastAdjusted2FGCC"].ToString();
                    ViewBag.rangevalDateLastActivity1FGCC = obj["rangevalDateLastActivity1FGCC"].ToString();
                    ViewBag.rangevalDateLastRecieved1FGCC = obj["rangevalDateLastRecieved1FGCC"].ToString();
                    ViewBag.rangevalDateLastShiped1FGCC = obj["rangevalDateLastShiped1FGCC"].ToString();
                    ViewBag.rangevalDateLastAdjusted1FGCC = obj["rangevalDateLastAdjusted1FGCC"].ToString();

                    ViewBag.rangevalDateLastActivity2FGCC = obj["rangevalDateLastActivity2FGCC"].ToString();
                    ViewBag.rangevalDateLastRecieved2FGCC = obj["rangevalDateLastRecieved2FGCC"].ToString();
                    ViewBag.rangevalDateLastShiped2FGCC = obj["rangevalDateLastShiped2FGCC"].ToString();
                    ViewBag.rangevalDateLastAdjusted2FGCC = obj["rangevalDateLastAdjusted2FGCC"].ToString();
                    mymodel.FinishGoodID2 = GetFinishGoodID2();
                    mymodel.FinishGoodDescription2 = GeFinishGoodDescription2();
                    mymodel.InventoryType2 = GetInventoryType2();
                    mymodel.KindCode2 = GeKindCode2();
                    mymodel.WareHouse2 = GeWareHouse2();
                    mymodel.Location2 = GeLocation2();
                    int id = Convert.ToInt32(Session["id"]);
                    ViewBag.ReportName = string.Empty;

                    ViewBag.ReportName = "FG Cycle Count(VSP9160)";

                    string UrlReportServer = "http://ts2pw8vv/ReportServer";
                    ReportViewer reportViewer = new ReportViewer();
                    reportViewer.ProcessingMode = ProcessingMode.Remote;
                    reportViewer.AsyncRendering = true;
                    reportViewer.SizeToReportContent = true;
                    reportViewer.Width = Unit.Percentage(0);
                    reportViewer.Height = Unit.Percentage(0);
                    reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                    reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP9160";
                    string beg_finish_goods_id = obj["FinishGoodsIDFGCC"].ToString() != "" ? obj["FinishGoodsIDFGCC"].ToString() : "0";
                    string end_finish_goods_id = obj["FinishGoodsID2FGCC"].ToString() != "" ? obj["FinishGoodsID2FGCC"].ToString() : "0";
                    string beg_finish_goods_name = obj["Description1FGCC"].ToString() != "" ? obj["Description1FGCC"].ToString() : "0";
                    string end_finish_goods_name = obj["Description2FGCC"].ToString() != "" ? obj["Description2FGCC"].ToString() : "0";
                    string beg_inventory_type = obj["InventoryType1FGCC"].ToString() != "" ? obj["InventoryType1FGCC"].ToString() : "0";
                    string end_inventory_type = obj["InventoryType2FGCC"].ToString() != "" ? obj["InventoryType2FGCC"].ToString() : "0";
                    string beg_kind = obj["Kindcode1FGCC"].ToString() != "" ? obj["Kindcode1FGCC"].ToString() : "0";
                    string end_kind = obj["Kindcode2FGCC"].ToString() != "" ? obj["Kindcode2FGCC"].ToString() : "0";
                    string beg_warehouse = obj["Warehouse1FGCC"].ToString() != "" ? obj["Warehouse1FGCC"].ToString() : "0";
                    string end_warehouse = obj["Warehouse2FGCC"].ToString() != "" ? obj["Warehouse2FGCC"].ToString() : "0";
                    string beg_location = obj["Location1FGCC"].ToString() != "" ? obj["Location1FGCC"].ToString() : "0";
                    string end_location = obj["Location2FGCC"].ToString() != "" ? obj["Location2FGCC"].ToString() : "0";
                    //Date Last Activity
                    if (DateLastActivity == "Between Range")
                    {
                        beg_date_activity = obj["DateLastActivity1FGCC"].ToString();
                        end_date_activity = obj["DateLastActivity2FGCC"].ToString();
                    }
                    else if (DateLastActivity == "")
                    {
                        beg_date_activity = obj["DateLastActivity1FGCC"].ToString();
                        end_date_activity = obj["DateLastActivity2FGCC"].ToString();
                    }
                    else if (DateLastActivity == "*All Records")
                    {
                        beg_date_activity = obj["DateLastActivity1FGCC"].ToString();
                        end_date_activity = obj["DateLastActivity2FGCC"].ToString();
                    }
                    else
                    {
                        beg_date_activity = obj["rangevalDateLastActivity1FGCC"].ToString();
                        end_date_activity = obj["DateLastActivity2FGCC"].ToString();
                    }
                    //Date Last Recieved
                    if (DateLastRecieved == "Between Range")
                    {
                        beg_date_received = obj["DateLastRecieved1FGCC"].ToString();
                        end_date_received = obj["DateLastRecieved2FGCC"].ToString();
                    }
                    else if (DateLastRecieved == "")
                    {
                        beg_date_received = obj["DateLastRecieved1FGCC"].ToString();
                        end_date_received = obj["DateLastRecieved2FGCC"].ToString();
                    }
                    else if (DateLastRecieved == "*All Records")
                    {
                        beg_date_received = obj["DateLastRecieved1FGCC"].ToString();
                        end_date_received = obj["DateLastRecieved2FGCC"].ToString();
                    }
                    else
                    {
                        beg_date_received = obj["rangevalDateLastRecieved1FGCC"].ToString();
                        end_date_received = obj["DateLastRecieved2FGCC"].ToString();
                    }

                    //Date Last Shiped
                    if (DateLastShiped == "Between Range")
                    {
                        beg_date_shipped = obj["DateLastShiped1FGCC"].ToString();
                        end_date_shipped = obj["DateLastShiped2FGCC"].ToString();
                    }
                    else if (DateLastShiped == "")
                    {
                        beg_date_shipped = obj["DateLastShiped1FGCC"].ToString();
                        end_date_shipped = obj["DateLastShiped2FGCC"].ToString();
                    }
                    else if (DateLastShiped == "*All Records")
                    {
                        beg_date_shipped = obj["DateLastShiped1FGCC"].ToString();
                        end_date_shipped = obj["DateLastShiped2FGCC"].ToString();
                    }
                    else
                    {
                        beg_date_shipped = obj["rangevalDateLastShiped1FGCC"].ToString();
                        end_date_shipped = obj["DateLastShiped2FGCC"].ToString();
                    }

                    //Date Last Adjusted
                    if (DateLastAdjusted == "Between Range")
                    {
                        beg_date_adjusted = obj["DateLastAdjusted1FGCC"].ToString();
                        end_date_adjusted = obj["DateLastAdjusted2FGCC"].ToString();
                    }
                    else if (DateLastAdjusted == "")
                    {
                        beg_date_adjusted = obj["DateLastAdjusted1FGCC"].ToString();
                        end_date_adjusted = obj["DateLastAdjusted2FGCC"].ToString();
                    }
                    else if (DateLastAdjusted == "*All Records")
                    {
                        beg_date_adjusted = obj["DateLastAdjusted1FGCC"].ToString();
                        end_date_adjusted = obj["DateLastAdjusted2FGCC"].ToString();
                    }
                    else
                    {
                        beg_date_adjusted = obj["rangevalDateLastAdjusted1FGCC"].ToString();
                        end_date_adjusted = obj["DateLastAdjusted2FGCC"].ToString();
                    }


                    string skip_zeros = obj["dllskip"].ToString();
                    string quantity_type = obj["dllQuantityType"].ToString();
                    string Sorting_Name = obj["dllsorting"].ToString();
                    if (Sorting_Name == "Location")
                    {
                        Sorting_Name = "loc";
                    }
                    else
                    {
                        Sorting_Name = "item_numb";
                    }                  
                    ReportParameter[] myparams = new ReportParameter[23];
                    myparams[0] = new ReportParameter("beg_finish_goods_id", beg_finish_goods_id, false);
                    myparams[1] = new ReportParameter("end_finish_goods_id", end_finish_goods_id, false);
                    myparams[2] = new ReportParameter("beg_finish_goods_name", beg_finish_goods_name, false);
                    myparams[3] = new ReportParameter("end_finish_goods_name", end_finish_goods_name, false);
                    myparams[4] = new ReportParameter("beg_kind", beg_kind, false);
                    myparams[5] = new ReportParameter("end_kind", end_kind, false);
                    myparams[6] = new ReportParameter("beg_inventory_type", beg_inventory_type, false);
                    myparams[7] = new ReportParameter("end_inventory_type", end_inventory_type, false);
                    myparams[8] = new ReportParameter("beg_warehouse", beg_warehouse, false);
                    myparams[9] = new ReportParameter("end_warehouse", end_warehouse, false);
                    myparams[10] = new ReportParameter("beg_location", beg_location, false);
                    myparams[11] = new ReportParameter("end_location", end_location, false);
                    myparams[12] = new ReportParameter("beg_date_activity", beg_date_activity, false);
                    myparams[13] = new ReportParameter("end_date_activity", end_date_activity, false);
                    myparams[14] = new ReportParameter("beg_date_received", beg_date_received, false);
                    myparams[15] = new ReportParameter("end_date_received", end_date_received, false);
                    myparams[16] = new ReportParameter("beg_date_shipped", beg_date_shipped, false);
                    myparams[17] = new ReportParameter("end_date_shipped", end_date_shipped, false);
                    myparams[18] = new ReportParameter("beg_date_adjusted", beg_date_adjusted, false);
                    myparams[19] = new ReportParameter("end_date_adjusted", end_date_adjusted, false);
                    myparams[20] = new ReportParameter("skip_zeros", skip_zeros, false);
                    myparams[21] = new ReportParameter("quantity_type", quantity_type, false);
                    myparams[22] = new ReportParameter("Sorting_Name", Sorting_Name, false);
                    reportViewer.ServerReport.SetParameters(myparams);
                    reportViewer.ServerReport.Refresh();
                    ViewBag.ReportViewer = reportViewer;
                    return View(mymodel);
                }
                else
                {

                    ViewBag.beg_finish_goods_id = "*All Records";
                    ViewBag.end_finish_goods_id = "0";
                    ViewBag.beg_finish_goods_name = "*All Records";
                    ViewBag.end_finish_goods_name = "0";
                    ViewBag.beg_inventory_type = "*All Records";
                    ViewBag.end_inventory_type = "0";
                    ViewBag.beg_kind = "*All Records";
                    ViewBag.end_kind = "0";
                    ViewBag.beg_warehouse = "*All Records";
                    ViewBag.end_warehouse = "0";
                    ViewBag.beg_location = "*All Records";
                    ViewBag.end_location = "0";
                    ViewBag.DateLastActivity1FGCC = "*All Records";
                    ViewBag.DateLastActivity2FGCC = "0";
                    ViewBag.DateLastRecieved1FGCC = "*All Records";
                    ViewBag.DateLastRecieved2FGCC = "0";

                    ViewBag.DateLastShiped1FGCC = "*All Records";
                    ViewBag.DateLastShiped2FGCC = "0";
                    ViewBag.DateLastAdjusted1FGCC = "*All Records";
                    ViewBag.DateLastAdjusted2FGCC = "0";

                    ViewBag.rangevalDateLastActivity1FGCC = "*All Records";
                    ViewBag.rangevalDateLastRecieved1FGCC = "*All Records";
                    ViewBag.rangevalDateLastShiped1FGCC = "*All Records";
                    ViewBag.rangevalDateLastAdjusted1FGCC = "*All Records";

                    ViewBag.rangevalDateLastActivity2FGCC = "0";
                    ViewBag.rangevalDateLastRecieved2FGCC = "0";
                    ViewBag.rangevalDateLastShiped2FGCC = "0";
                    ViewBag.rangevalDateLastAdjusted2FGCC = "0";
                }
                mymodel.FinishGoodID2 = GetFinishGoodID2();
                mymodel.FinishGoodDescription2 = GeFinishGoodDescription2();
                mymodel.InventoryType2 = GetInventoryType2();
                mymodel.KindCode2 = GeKindCode2();
                mymodel.WareHouse2 = GeWareHouse2();
                mymodel.Location2 = GeLocation2();
                return View(mymodel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult FilterOption7890(string filter, FormCollection obj, string CostCenterMajor, string DateEnteredCCM)
        {
            Session["ReportName"] = "Press Sheet Statistics (7890)";
            if (filter == "Run as a Job and Notify")
            {
                string Link = "http://10.2.0.140/VSPAPPLICATION3/VSP/VSP7890.xls";
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_AsynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID", 7890);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Name", "Press Sheet Statistics");
                    cmd.Parameters.AddWithValue("@Asyn_Report_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Link", Link);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();
                }
                TempData["ReportView"] = obj;
                TempData["DateShipped"] = DateEnteredCCM;

                List<string> _pagecontent = new List<string>();
                return RedirectToAction("RunReportAsyn7890", "Report");
            }
            ViewBag.Filter = filter;
            ViewBag.DateEnteredCCM1 = string.Empty;
            ViewBag.DateEnteredCCM2 = string.Empty;
            ViewBag.txtDateEnteredCCMrangevaltext1 = string.Empty;
            ViewBag.txtDateEnteredCCMrangevaltext2 = string.Empty;
            try
            {
                dynamic mymodel = new ExpandoObject();
                ViewBag.CostCenterMajor1CCM = "*All Records";
                ViewBag.CostCenterMajor2CCM = "0";
                ViewBag.DateEnteredCCM1 = "*All Records";
                ViewBag.DateEnteredCCM2 = "0";
                ViewBag.txtDateEnteredCCMrangevaltext1 = "*All Records";
                ViewBag.txtDateEnteredCCMrangevaltext2 = "0";            
               
                if (filter == "Run Report Now")
                {
                    using (cn = new SqlConnection(connString))
                    {
                        cn.Open();
                        cmd = new SqlCommand("sp_Insert_Update_SynReport", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                        cmd.Parameters.AddWithValue("@Report_ID", 7890);
                        cmd.Parameters.AddWithValue("@Syn_Report_Name", "Press Sheet Statistics");
                        cmd.Parameters.AddWithValue("@Syn_Report_Date", DateTime.Now);
                        cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                        int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                        int res = cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                    ViewBag.DateEnteredCCM1 = obj["DateEnteredCCM1"].ToString();
                    ViewBag.DateEnteredCCM2 = obj["DateEnteredCCM2"].ToString();
                    ViewBag.txtDateEnteredCCMrangevaltext1 = obj["txtDateEnteredCCMrangevaltext1"].ToString();
                    ViewBag.txtDateEnteredCCMrangevaltext2 = obj["txtDateEnteredCCMrangevaltext2"].ToString();
                    ViewBag.CostCenterMajor = CostCenterMajor;
                    ViewBag.DateEnteredCCM = DateEnteredCCM;
                    mymodel.CostCenterMajor2 = GeCostCenterMajor2();
                    string UrlReportServer = "http://ts2pw8vv/ReportServer";
                    ReportViewer reportViewer = new ReportViewer();
                    reportViewer.ProcessingMode = ProcessingMode.Remote;
                    reportViewer.AsyncRendering = true;
                    reportViewer.SizeToReportContent = true;
                    reportViewer.Width = Unit.Percentage(0);
                    reportViewer.Height = Unit.Percentage(0);
                    reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                    reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7890";
                    string beg_cc_id = obj["CostCenterMajor1CCM"].ToString() != "" ? obj["CostCenterMajor1CCM"].ToString() : "0";                   
                    string end_cc_id = obj["CostCenterMajor2CCM"].ToString() != "" ? obj["CostCenterMajor2CCM"].ToString() : "0";                   
                    string beg_date = string.Empty;
                    string end_date = string.Empty;
                    if (DateEnteredCCM == "Between Range")
                    {
                        beg_date = obj["DateEnteredCCM1"].ToString();
                        end_date = obj["DateEnteredCCM2"].ToString();
                    }
                    else if (DateEnteredCCM == "")
                    {
                        beg_date = obj["DateEnteredCCM1"].ToString();
                        end_date = obj["DateEnteredCCM2"].ToString();
                    }
                    else if (DateEnteredCCM == "*All Records")
                    {
                        beg_date = obj["txtDateEnteredCCMrangevaltext1"].ToString();
                        end_date = obj["txtDateEnteredCCMrangevaltext2"].ToString();
                        //beg_date = obj["DateShipped1"].ToString();
                        //end_date = obj["DateShipped2"].ToString();
                    }
                    else
                    {
                        beg_date = obj["txtDateEnteredCCMrangevaltext1"].ToString();
                        end_date = obj["DateEnteredCCM2"].ToString();
                    }

                    ReportParameter[] myparams = new ReportParameter[4];
                    myparams[0] = new ReportParameter("beg_cc_id", beg_cc_id, false);
                    myparams[1] = new ReportParameter("end_cc_id", end_cc_id, false);
                    myparams[2] = new ReportParameter("beg_date", beg_date, false);
                    myparams[3] = new ReportParameter("end_date", end_date, false);
                    reportViewer.ServerReport.SetParameters(myparams);
                    reportViewer.ServerReport.Refresh();
                    ViewBag.ReportViewer = reportViewer;
                    return View(mymodel);
                }
                mymodel.CostCenterMajor2 = GeCostCenterMajor2();
                return View(mymodel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult FilterOption8620(string filter, FormCollection obj, string CostCenterSFPHD, string DateSFPHD, string filterJob)
        {
            Session["ReportName"] = "Square Feet Per Hour Details (8620)";
            if (filter == "Run as a Job and Notify")
            {
                
                TempData["ReportView"] = obj;
                TempData["DateShipped"] = DateSFPHD;
                //TempData["filter"] = filterJob;
                TempData["CostCenterSFPHD"] = CostCenterSFPHD;
                TempData["EmailID"] = Session["EmailID"].ToString();
                TempData["UserID"] = Session["UserID"].ToString();
                List<string> _pagecontent = new List<string>();
                return RedirectToAction("RunReportAsyn8620", "Report");
            }
            ViewBag.Filter = filter;
            ViewBag.DateSFPHD = string.Empty;
            ViewBag.DateSFPHD1 = string.Empty;
            ViewBag.DateSFPHDrangevaltext1 = string.Empty;
            ViewBag.DateSFPHDrangevaltext2 = string.Empty;
            try
            {
                dynamic mymodel = new ExpandoObject();
                ViewBag.CostCenter1 = "*All Records";
                ViewBag.CostCenter2 = "0";
                ViewBag.DateSFPHD1 = "*All Records";
                ViewBag.DateSFPHD2 = "0";
                ViewBag.DateSFPHDrangevaltext1 = "*All Records";
                ViewBag.DateSFPHDrangevaltext2 = "0";
               
                if (filter == "Run Report Now")
                {
                    using (cn = new SqlConnection(connString))
                    {
                        cn.Open();
                        cmd = new SqlCommand("sp_Insert_Update_SynReport", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                        cmd.Parameters.AddWithValue("@Report_ID", 8620);
                        cmd.Parameters.AddWithValue("@Syn_Report_Name", "Square Feet Per Hour Details");
                        cmd.Parameters.AddWithValue("@Syn_Report_Date", DateTime.Now);
                        cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                        int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                        int res = cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                    ViewBag.DateSFPHD1 = obj["DateSFPHD1"].ToString();
                    ViewBag.DateSFPHD2 = obj["DateSFPHD2"].ToString();
                    ViewBag.DateSFPHDrangevaltext1 = obj["DateSFPHDrangevaltext1"].ToString();
                    ViewBag.DateSFPHDrangevaltext2 = obj["DateSFPHDrangevaltext2"].ToString();
                    ViewBag.CostCenterSFPHD = CostCenterSFPHD;
                    ViewBag.DateSFPHD = DateSFPHD;
                    mymodel.CostCenterMajor2 = GeCostCenterMajor2();
                    string UrlReportServer = "http://ts2pw8vv/ReportServer";
                    ReportViewer reportViewer = new ReportViewer();
                    //reportViewer.LocalReport.DataSources.Clear();
                    reportViewer.ProcessingMode = ProcessingMode.Remote;
                    reportViewer.AsyncRendering = true;
                    reportViewer.SizeToReportContent = true;
                    reportViewer.Width = Unit.Percentage(0);
                    reportViewer.Height = Unit.Percentage(0);
                    reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                    reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP8620";
                    string beg_cc_id = obj["CostCenter1SFPHD"].ToString() != "" ? obj["CostCenter1SFPHD"].ToString() : "0";                    
                    string end_cc_id = obj["CostCenter2SFPHD"].ToString() != "" ? obj["CostCenter2SFPHD"].ToString() : "0";                                   
                    string beg_date = string.Empty;
                    string end_date = string.Empty;
                    if (DateSFPHD == "Between Range")
                    {
                        beg_date = obj["DateSFPHD1"].ToString();
                        end_date = obj["DateSFPHD2"].ToString();
                    }
                    else if (DateSFPHD == "")
                    {
                        beg_date = obj["DateSFPHD1"].ToString();
                        end_date = obj["DateSFPHD2"].ToString();
                    }
                    else if (DateSFPHD == "*All Records")
                    {
                        beg_date = obj["DateSFPHDrangevaltext1"].ToString();
                        end_date = obj["DateSFPHDrangevaltext2"].ToString();
                        //beg_date = obj["DateShipped1"].ToString();
                        //end_date = obj["DateShipped2"].ToString();
                    }
                    else
                    {
                        beg_date = obj["DateSFPHDrangevaltext1"].ToString();
                        end_date = obj["DateSFPHD2"].ToString();
                    }

                    ReportParameter[] myparams = new ReportParameter[4];
                    myparams[0] = new ReportParameter("beg_cc_id", beg_cc_id, false);
                    myparams[1] = new ReportParameter("end_cc_id", end_cc_id, false);
                    myparams[2] = new ReportParameter("beg_date", beg_date, false);
                    myparams[3] = new ReportParameter("end_date", end_date, false);
                    reportViewer.ServerReport.SetParameters(myparams);
                    reportViewer.LocalReport.Refresh();
                    ViewBag.ReportViewer = reportViewer;
                    return View(mymodel);
                }
                mymodel.CostCenterMajor2 = GeCostCenterMajor2();
                return View(mymodel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult FilterOption8400(string filter, FormCollection obj)
        {
            Session["ReportName"] = "Finish Good Details Val.. (8400)";
            if (filter == "Run as a Job and Notify")
            {
                string Link = "http://10.2.0.140/VSPAPPLICATION3/VSP/VSP8400.xls";
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_AsynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID", 8400);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Name", "Finish Good Details Val..");
                    cmd.Parameters.AddWithValue("@Asyn_Report_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Link", Link);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();
                }
                TempData["ReportView"] = obj;
                List<string> _pagecontent = new List<string>();
                return RedirectToAction("RunReportAsyn8400", "Report");
            }
            dynamic mymodel = new ExpandoObject();
            mymodel.FinishGoodItem2 = GetFinishGoodItem();
            mymodel.FinishGoodName2 = GetFinishGoodItem();
            mymodel.KindCode2 = GeKindCode2();
            mymodel.InventoryType2 = GetInventoryType2();
            mymodel.SubType_1 = GetSubType_1();
            mymodel.SubType_2 = GetSubType_2();
            mymodel.SubType_3 = GetSubType_3();
         
            ViewBag.Filter = filter;
            ViewBag.FinishGoodsItem1FGDV = "*All Records";
            ViewBag.FinishGoodsItem2FGDV = "0";
            ViewBag.FinishGoodsName1FGDV = "*All Records";
            ViewBag.FinishGoodsName2FGDV = "0";
            ViewBag.Kind1FGDV = "*All Records";
            ViewBag.Kind2FGDV = "0";
            ViewBag.InventoryType1FGDV = "*All Records";
            ViewBag.InventoryType2FGDV = "0";
            ViewBag.SubType1_1FGDV = "*All Records";
            ViewBag.SubType1_2FGDV = "0";
            ViewBag.SubType2_1FGDV = "*All Records";
            ViewBag.SubType2_2FGDV = "0";
            ViewBag.SubType3_1FGDV = "*All Records";
            ViewBag.SubType3_2FGDV = "0";
            try
            {
                if (filter == "Run Report Now")
                {
                    using (cn = new SqlConnection(connString))
                    {
                        cn.Open();
                        cmd = new SqlCommand("sp_Insert_Update_SynReport", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                        cmd.Parameters.AddWithValue("@Report_ID", 8400);
                        cmd.Parameters.AddWithValue("@Syn_Report_Name", "Finish Good Details Val..");
                        cmd.Parameters.AddWithValue("@Syn_Report_Date", DateTime.Now);
                        cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                        int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                        int res = cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                    ViewBag.FinishGoodsItemFGDV = obj["FinishGoodsItemFGDV"].ToString();
                    ViewBag.FinishGoodsNameFGDV = obj["FinishGoodsNameFGDV"].ToString();
                    ViewBag.KindFGDV = obj["KindFGDV"].ToString();

                    ViewBag.InventoryTypeFGDV = obj["InventoryTypeFGDV"].ToString();
                    ViewBag.SubType1FGDV = obj["SubType1FGDV"].ToString();
                    ViewBag.SubType2FGDV = obj["SubType2FGDV"].ToString();
                    ViewBag.SubType3FGDV = obj["SubType3FGDV"].ToString();
                    ViewBag.dllskipzeroquantity = obj["dllskipzeroquantity"].ToString();
                    ViewBag.dllskipzerocost = obj["dllskipzerocost"].ToString();
                    string UrlReportServer = "http://ts2pw8vv/ReportServer";
                    ReportViewer reportViewer = new ReportViewer();
                    reportViewer.ProcessingMode = ProcessingMode.Remote;
                    reportViewer.AsyncRendering = true;
                    reportViewer.SizeToReportContent = true;
                    reportViewer.Width = Unit.Percentage(0);
                    reportViewer.Height = Unit.Percentage(0);
                    reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                    reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP8400";
                    string beg_finish_goods_id = obj["FinishGoodsItem1FGDV"].ToString() != "" ? obj["FinishGoodsItem1FGDV"].ToString() : "0";                   
                    string end_finish_goods_id = obj["FinishGoodsItem2FGDV"].ToString() != "" ? obj["FinishGoodsItem2FGDV"].ToString() : "0";                  
                    string beg_finish_goods_name = obj["FinishGoodsName1FGDV"].ToString() != "" ? obj["FinishGoodsName1FGDV"].ToString() : "0";                    
                    string end_finish_goods_name = obj["FinishGoodsName2FGDV"].ToString() != "" ? obj["FinishGoodsName2FGDV"].ToString() : "0";                  
                    string beg_kind = obj["Kind1FGDV"].ToString() != "" ? obj["Kind1FGDV"].ToString() : "0";
                    string end_kind = obj["Kind2FGDV"].ToString() != "" ? obj["Kind2FGDV"].ToString() : "0";                    
                    string beg_inventory_type = obj["InventoryType1FGDV"].ToString() != "" ? obj["InventoryType1FGDV"].ToString() : "0";                   
                    string end_inventory_type = obj["InventoryType2FGDV"].ToString() != "" ? obj["InventoryType2FGDV"].ToString() : "0";                   
                    string beg_sub_type_1 = obj["SubType1_1FGDV"].ToString() != "" ? obj["SubType1_1FGDV"].ToString() : "0";                   
                    string end_sub_type_1 = obj["SubType1_2FGDV"].ToString() != "" ? obj["SubType1_2FGDV"].ToString() : "0";                    
                    string beg_sub_type_2 = obj["SubType2_1FGDV"].ToString() != "" ? obj["SubType2_1FGDV"].ToString() : "0";                   
                    string end_sub_type_2 = obj["SubType2_2FGDV"].ToString() != "" ? obj["SubType2_2FGDV"].ToString() : "0";                   
                    string beg_sub_type_3 = obj["SubType3_1FGDV"].ToString() != "" ? obj["SubType3_1FGDV"].ToString() : "0";
                    string end_sub_type_3 = obj["SubType3_2FGDV"].ToString() != "" ? obj["SubType3_2FGDV"].ToString() : "0";
                    
                    string skipzeroquantity = obj["dllskipzeroquantity"].ToString();
                    string skipzerocost = obj["dllskipzerocost"].ToString();
                    string skip_zeros = String.Empty;
                    string skip_nodollars = String.Empty;
                    if (skipzeroquantity == "Yes")
                    {
                        skip_zeros = "Yes";
                    }
                    else
                    {
                        skip_zeros = "No";
                    }
                    if (skipzerocost == "Yes")
                    {
                        skip_nodollars = "Yes";
                    }
                    else
                    {
                        skip_nodollars = "No";
                    }

                    ReportParameter[] myparams = new ReportParameter[16];
                    myparams[0] = new ReportParameter("beg_finish_goods_id", beg_finish_goods_id, false);
                    myparams[1] = new ReportParameter("end_finish_goods_id", end_finish_goods_id, false);
                    myparams[2] = new ReportParameter("beg_finish_goods_name", beg_finish_goods_name, false);
                    myparams[3] = new ReportParameter("end_finish_goods_name", end_finish_goods_name, false);
                    myparams[4] = new ReportParameter("beg_kind", beg_kind, false);
                    myparams[5] = new ReportParameter("end_kind", end_kind, false);
                    myparams[6] = new ReportParameter("beg_inventory_type", beg_inventory_type, false);
                    myparams[7] = new ReportParameter("end_inventory_type", end_inventory_type, false);
                    myparams[8] = new ReportParameter("beg_sub_type_1", beg_sub_type_1, false);
                    myparams[9] = new ReportParameter("end_sub_type_1", end_sub_type_1, false);
                    myparams[10] = new ReportParameter("beg_sub_type_2", beg_sub_type_2, false);
                    myparams[11] = new ReportParameter("end_sub_type_2", end_sub_type_2, false);
                    myparams[12] = new ReportParameter("beg_sub_type_3", beg_sub_type_3, false);
                    myparams[13] = new ReportParameter("end_sub_type_3", end_sub_type_3, false);
                    myparams[14] = new ReportParameter("skip_zeros", skip_zeros, false);
                    myparams[15] = new ReportParameter("skip_nodollars", skip_nodollars, false);

                    reportViewer.ServerReport.SetParameters(myparams);
                    reportViewer.ServerReport.Refresh();
                    ViewBag.ReportViewer = reportViewer;
                    return View(mymodel);
                }
                return View(mymodel);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public ActionResult FilterOption7910(FormCollection obj, string filter, string DateShipped7910, string dllsorting7910, string dllRemoveCost7910, string CustomerID7910, string CustomerName7910)
        {
            Session["ReportName"] = "Cost of Goods Sold (7910)";
            ViewBag.ReportName = string.Empty;
            ViewBag.ReportName = "Cost of Goods Sold(VSP7910)";
            ViewBag.Filter = string.Empty;
            ViewBag.DateShipped1 = string.Empty;
            ViewBag.DateShipped2 = string.Empty;
            ViewBag.rangevaltext = string.Empty;
            ViewBag.rangevaltext2 = string.Empty;
            if (filter == "Run as a Job and Notify")
            {
                string Link = "http://10.2.0.140/VSPAPPLICATION3/VSP/VSP7910.xls";
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_AsynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID", 7910);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Name", "Cost of Goods Sold");
                    cmd.Parameters.AddWithValue("@Asyn_Report_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Asyn_Report_Link", Link);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();
                }
                TempData["ReportView"] = obj;
                TempData["DateShipped"] = DateShipped7910;
                List<string> _pagecontent = new List<string>();
                return RedirectToAction("RunReportAsyn7910", "Report");
            }
            if (filter != "Run Report Now")
            {

                ViewBag.CustomerId = "*All Records";
                ViewBag.CustomerId1 = "0";

                ViewBag.CustomerName = "*All Records";
                ViewBag.CustomerName1 = "0";

                ViewBag.DateShipped1 = "*All Records";
                ViewBag.DateShipped2 = "0";

                ViewBag.rangevaltext = "*All Records";
                ViewBag.rangevaltext2 = "0";
            }

            dynamic mymodel = new ExpandoObject();


            string name = obj["filter"];
            ViewBag.Filter = name;
            if (name == "Run Report Now")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_SynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID", 7910);
                    cmd.Parameters.AddWithValue("@Syn_Report_Name", "Cost of Goods Sold");
                    cmd.Parameters.AddWithValue("@Syn_Report_Date", DateTime.Now);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();
                }
                ViewBag.DateShippedCostOfGood1 = obj["DateShipped1"].ToString();
                ViewBag.DateShippedCostOfGood2 = obj["DateShipped2"].ToString();
                ViewBag.rangevaltextCostOfGood = obj["rangevaltext"].ToString();
                ViewBag.rangevaltextCostOfGood2 = obj["rangevaltext1"].ToString();


                ViewBag.CustomerID7910 = CustomerID7910;
                ViewBag.CustomerName7910 = CustomerName7910;

                ViewBag.DateShippedCostOfGood = DateShipped7910;

                ViewBag.dllsorting7910 = dllsorting7910;
                ViewBag.dllRemoveCost7910 = dllRemoveCost7910;
                string beg_date = string.Empty;
                string end_date = string.Empty;
                ViewBag.btn = "filter";
                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(1900);
                reportViewer.Height = Unit.Percentage(1900);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7910";
                string beg_customer_id = obj["CustomerID1"].ToString() != "" ? obj["CustomerID1"].ToString() : "0";               
                string end_customer_id = obj["CustomerID2"].ToString() != "" ? obj["CustomerID2"].ToString() : "0";              
                string beg_customer_name = obj["CustomerName1"].ToString() != "" ? obj["CustomerName1"].ToString() : "0";               
                string end_customer_name = obj["CustomerName2"].ToString() != "" ? obj["CustomerName2"].ToString() : "0";                
                if (DateShipped7910 == "Between Range")
                {
                    beg_date = obj["DateShipped1"].ToString();
                    end_date = obj["DateShipped2"].ToString();
                }
                else if (DateShipped7910 == "")
                {
                    beg_date = obj["DateShipped1"].ToString();
                    end_date = obj["DateShipped2"].ToString();
                }
                else if (DateShipped7910 == "*All Records")
                {
                    beg_date = obj["rangevaltext"].ToString();
                    end_date = obj["rangevaltext1"].ToString();

                }
                else
                {
                    beg_date = obj["rangevaltext"].ToString();
                    end_date = obj["DateShipped2"].ToString();
                }
                string skip_nodollars = obj["dllRemoveCost7910"].ToString();



                ReportParameter[] myparams = new ReportParameter[7];

                myparams[0] = new ReportParameter("beg_customer_id", beg_customer_id, false);
                myparams[1] = new ReportParameter("end_customer_id", end_customer_id, false);
                myparams[2] = new ReportParameter("beg_customer_name", beg_customer_name, false);
                myparams[3] = new ReportParameter("end_customer_name", end_customer_name, false);

                myparams[4] = new ReportParameter("beg_date", beg_date, false);

                myparams[5] = new ReportParameter("end_date", end_date, false);
                myparams[6] = new ReportParameter("skip_nodollars", skip_nodollars, false);
                reportViewer.ServerReport.SetParameters(myparams);

                reportViewer.ServerReport.Refresh();
                ViewBag.ReportViewer = reportViewer;


                mymodel.CustomerIDs = GetCustomerIDs();
                mymodel.CustomerName2 = GetCustomerName2();

                return View(mymodel);
            }

            ViewBag.Message = "Welcome to my demo!";
            mymodel.FinishGoodItem = GetFinishGoodItem();
            mymodel.CustomerIDs = GetCustomerIDs();
            mymodel.CustomerName2 = GetCustomerName2();
            mymodel.InventoryType2 = GetInventoryType2();
            mymodel.SalesRep2 = GetSalesRep2();
            mymodel.ShippingLocation2 = GetShippingLocation2();
            mymodel.OrderType2 = GetOrderType2();
            mymodel.ProductCode2 = GetProductCode2();
            return View(mymodel);

        }
        public ActionResult FilterOption8610(string filter, FormCollection obj, string CostCenter, string DateCC)
        {
            Session["ReportName"] = "Square Feet Per Hour Summery (8610)";
           
            if (filter == "Run as a Job and Notify")
            {
               
                TempData["ReportView"] = obj;
                TempData["DateShipped"] = DateCC;
                TempData["EmailID"] = Session["EmailID"].ToString();
                TempData["UserID"] = Session["UserID"].ToString();
                List<string> _pagecontent = new List<string>();
                return RedirectToAction("RunReportAsyn8610", "Report");
            }
            ViewBag.Filter = filter;
            ViewBag.DateCC1 = string.Empty;
            ViewBag.DateCC2 = string.Empty;
            ViewBag.txtDateCCrangevaltext1 = string.Empty;
            ViewBag.txtDateCCrangevaltext2 = string.Empty;
            try
            {
                dynamic mymodel = new ExpandoObject();
                ViewBag.CostCenter1CC = "*All Records";
                ViewBag.CostCenter2CC = "0";
                ViewBag.DateCC1 = "*All Records";
                ViewBag.DateCC2 = "0";
                ViewBag.txtDateCCrangevaltext1 = "*All Records";
                ViewBag.txtDateCCrangevaltext2 = "0";
                int id = Convert.ToInt32(Session["id"]);

                if (filter == "Run Report Now")
                {
                    using (cn = new SqlConnection(connString))
                    {
                        cn.Open();
                        cmd = new SqlCommand("sp_Insert_Update_SynReport", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                        cmd.Parameters.AddWithValue("@Report_ID", 8610);
                        cmd.Parameters.AddWithValue("@Syn_Report_Name", "Square Feet Per Hour Summery");
                        cmd.Parameters.AddWithValue("@Syn_Report_Date", DateTime.Now);
                        cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                        int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                        int res = cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                    ViewBag.DateCC1 = obj["DateCC1"].ToString();
                    ViewBag.DateCC2 = obj["DateCC2"].ToString();
                    ViewBag.txtDateCCrangevaltext1 = obj["txtDateCCrangevaltext1"].ToString();
                    ViewBag.txtDateCCrangevaltext2 = obj["txtDateCCrangevaltext2"].ToString();
                    ViewBag.CostCenter = CostCenter;
                    ViewBag.DateCC = DateCC;
                    mymodel.CostCenter = GeCostCenterMajor2();
                    string UrlReportServer = "http://ts2pw8vv/ReportServer";
                    ReportViewer reportViewer = new ReportViewer();
                    reportViewer.LocalReport.DataSources.Clear();
                    reportViewer.ProcessingMode = ProcessingMode.Remote;
                    reportViewer.AsyncRendering = true;
                    reportViewer.SizeToReportContent = true;
                    reportViewer.Width = Unit.Percentage(0);
                    reportViewer.Height = Unit.Percentage(0);
                    reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                    reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP8610";
                    string beg_cc_id = obj["CostCenter1CC"].ToString() != "" ? obj["CostCenter1CC"].ToString() : "0";                   
                    string end_cc_id = obj["CostCenter2CC"].ToString() != "" ? obj["CostCenter2CC"].ToString() : "0";                   
                    string beg_date = string.Empty;
                    string end_date = string.Empty;

                    if (DateCC == "Between Range")
                    {
                        beg_date = obj["DateCC1"].ToString();
                        end_date = obj["DateCC2"].ToString();
                    }
                    else if (DateCC == "")
                    {
                        beg_date = obj["DateCC1"].ToString();
                        end_date = obj["DateCC2"].ToString();
                    }
                    else if (DateCC == "*All Records")
                    {
                        beg_date = obj["txtDateCCrangevaltext1"].ToString();
                        end_date = obj["txtDateCCrangevaltext2"].ToString();

                    }
                    else
                    {
                        beg_date = obj["txtDateCCrangevaltext1"].ToString();
                        end_date = obj["DateCC2"].ToString();
                    }

                    ReportParameter[] myparams = new ReportParameter[4];
                    myparams[0] = new ReportParameter("beg_cc_id", beg_cc_id, false);
                    myparams[1] = new ReportParameter("end_cc_id", end_cc_id, false);
                    myparams[2] = new ReportParameter("beg_date", beg_date, false);
                    myparams[3] = new ReportParameter("end_date", end_date, false);
                    reportViewer.ServerReport.SetParameters(myparams);
                    reportViewer.ServerReport.Refresh();
                    ViewBag.ReportViewer = reportViewer;
                    return View(mymodel);
                }
                mymodel.CostCenter = GeCostCenterMajor2();
                return View(mymodel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult FilterOption7170(string filter, FormCollection obj, string DateMaterialCut)
        {
            Session["ReportName"] = "Material Cut (7170)";
          
            string Date7170 = DateMaterialCut;
            if (filter == "Run as a Job and Notify")
            {
               
                TempData["ReportView"] = obj;
                TempData["DateShipped"] = Date7170;
                TempData["EmailID"] = Session["EmailID"].ToString();
                TempData["UserID"] = Session["UserID"].ToString();
                List<string> _pagecontent = new List<string>();
                return RedirectToAction("RunReportAsyn7170", "Report");
            }
            ViewBag.Filter = filter;
            ViewBag.DateMaterialCut1 = string.Empty;
            ViewBag.Date2_7170 = string.Empty;
            ViewBag.txtDate1_7170 = string.Empty;
            ViewBag.txtDateMaterialCut2 = string.Empty;
            try
            {
                ViewBag.DateMaterialCut1 = "*All Records";
                ViewBag.DateMaterialCut2 = "0";
                ViewBag.txtDateMaterialCut1 = "*All Records";
                ViewBag.txtDate2_7170 = "0";


                if (filter == "Run Report Now")
                {
                    using (cn = new SqlConnection(connString))
                    {
                        cn.Open();
                        cmd = new SqlCommand("sp_Insert_Update_SynReport", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                        cmd.Parameters.AddWithValue("@Report_ID", 7170);
                        cmd.Parameters.AddWithValue("@Syn_Report_Name", "Material Cut");
                        cmd.Parameters.AddWithValue("@Syn_Report_Date", DateTime.Now);
                        cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                        int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                        int res = cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                    ViewBag.DateMaterialCut1 = obj["DateMaterialCut1"].ToString();
                    ViewBag.DateMaterialCut2 = obj["DateMaterialCut2"].ToString();
                    ViewBag.txtDateMaterialCut1 = obj["txtDateMaterialCut1"].ToString();
                    ViewBag.txtDateMaterialCut2 = obj["txtDateMaterialCut2"].ToString();

                    ViewBag.Date7170 = Date7170;

                    string UrlReportServer = "http://ts2pw8vv/ReportServer";
                    ReportViewer reportViewer = new ReportViewer();
                    reportViewer.ProcessingMode = ProcessingMode.Remote;
                    reportViewer.AsyncRendering = true;
                    reportViewer.SizeToReportContent = true;
                    reportViewer.Width = Unit.Percentage(0);
                    reportViewer.Height = Unit.Percentage(0);
                    reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                    reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7170";

                    string beg_date = string.Empty;
                    string end_date = string.Empty;

                    if (Date7170 == "Between Range")
                    {
                        beg_date = obj["DateMaterialCut1"].ToString();
                        end_date = obj["DateMaterialCut2"].ToString();
                    }
                    else if (Date7170 == "")
                    {
                        beg_date = obj["DateMaterialCut1"].ToString();
                        end_date = obj["DateMaterialCut2"].ToString();
                    }
                    else if (Date7170 == "*All Records")
                    {
                        beg_date = obj["txtDateMaterialCut1"].ToString();
                        end_date = obj["txtDateMaterialCut2"].ToString();

                    }
                    else
                    {
                        beg_date = obj["txtDateMaterialCut1"].ToString();
                        end_date = obj["DateMaterialCut2"].ToString();
                    }

                    ReportParameter[] myparams = new ReportParameter[2];

                    myparams[0] = new ReportParameter("beg_date", beg_date, false);
                    myparams[1] = new ReportParameter("end_date", end_date, false);
                    reportViewer.ServerReport.SetParameters(myparams);
                    reportViewer.ServerReport.Refresh();
                    ViewBag.ReportViewer = reportViewer;

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }
        public ActionResult FilterOption7180(FormCollection obj, string filter)
        {
            Session["ReportName"] = "Blanket Report (7180)";
            ViewBag.ReportName = string.Empty;
            ViewBag.ReportName = "Blanket Report(VSP7180)";
            ViewBag.Filter = filter;
            if (filter == "Run as a Job and Notify")
            {
               
                TempData["ReportView"] = obj;
                TempData["EmailID"] = Session["EmailID"].ToString();
                TempData["UserID"] = Session["UserID"].ToString();
                List<string> _pagecontent = new List<string>();
                return RedirectToAction("RunReportAsyn7180", "Report");
            }
            ViewBag.DateExp = string.Empty;
            ViewBag.txtDateExp = string.Empty;
            ViewBag.txtDateExp2 = string.Empty;
            ViewBag.DateExp2 = string.Empty;
            dynamic mymodel = new ExpandoObject();
            if (filter == "Run Report Now")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_SynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID", 7180);
                    cmd.Parameters.AddWithValue("@Syn_Report_Name", "Blanket Report");
                    cmd.Parameters.AddWithValue("@Syn_Report_Date", DateTime.Now);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();
                }
                ViewBag.FinishGoodsItemBlanket = obj["FinishGoodsItemBlanket"].ToString();
                ViewBag.CustNumberBlanket = obj["CustNumberBlanket"].ToString();
                ViewBag.DateExpiration = obj["DateExpiration"].ToString();
                ViewBag.CustomerPo = obj["CustomerPo"].ToString();
                ViewBag.InventoryTypeBlanket = obj["InventoryTypeBlanket"].ToString();
                ViewBag.SubType2Blanket = obj["SubType2Blanket"].ToString();
                ViewBag.DateExp = obj["DateExp"].ToString();
                ViewBag.txtDateExp = obj["txtDateExp"].ToString();
                ViewBag.DateExp2 = obj["DateExp2"].ToString();
                ViewBag.txtDateExp2 = obj["txtDateExp2"].ToString();
                ViewBag.dllStyleReport = obj["dllStyleReport"].ToString();
                ViewBag.dllQtyLevel = obj["dllQtyLevel"].ToString();
                ViewBag.dllJobStatus = obj["dllJobStatus"].ToString();
                ViewBag.dllSorting = obj["dllSorting"].ToString();

                string DateExpiration = obj["DateExpiration"].ToString();
                string beg_date = string.Empty;
                string end_date = string.Empty;

                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(1900);
                reportViewer.Height = Unit.Percentage(1900);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7180";
                string beg_fg_id = obj["txtFinishGoodsItemBlanket"].ToString() != "" ? obj["txtFinishGoodsItemBlanket"].ToString() : "0";               
                string end_fg_id = obj["txtFinishGoodsItemBlanket2"].ToString() != "" ? obj["txtFinishGoodsItemBlanket2"].ToString() : "0";               
                string beg_customer_id = obj["txtCustNumberBlanket"].ToString() != "" ? obj["txtCustNumberBlanket"].ToString() : "0";                
                string end_customer_id = obj["txtCustNumberBlanket2"].ToString() != "" ? obj["txtCustNumberBlanket2"].ToString() : "0";                
                string beg_customer_po = obj["txtCustomerPo"].ToString() != "" ? obj["txtCustomerPo"].ToString() : "0";
                string end_customer_po = obj["txtCustomerPo2"].ToString() != "" ? obj["txtCustomerPo2"].ToString() : "0";             
                if (DateExpiration == "Between Range")
                {
                    beg_date = obj["DateExp"].ToString();
                    end_date = obj["DateExp2"].ToString();
                }
                else if (DateExpiration == "")
                {
                    beg_date = obj["txtDateExp"].ToString();
                    end_date = obj["txtDateExp2"].ToString();
                }
                else if (DateExpiration == "*All Records")
                {
                    beg_date = obj["txtDateExp"].ToString();
                    end_date = obj["txtDateExp2"].ToString();
                    //beg_date = obj["DateShipped1"].ToString();
                    //end_date = obj["DateShipped2"].ToString();
                }
                else
                {
                    beg_date = obj["txtDateExp"].ToString();
                    end_date = obj["DateExp2"].ToString();
                }

                string beg_inventory_type = obj["txtInventoryTypeBlanket"].ToString() != "" ? obj["txtInventoryTypeBlanket"].ToString() : "0";
                string end_inventory_type = obj["txtInventoryTypeBlanket2"].ToString() != "" ? obj["txtInventoryTypeBlanket2"].ToString() : "0"; 
                string beg_sub_type_2 = obj["txtSubType2Blanket"].ToString() != "" ? obj["txtSubType2Blanket"].ToString() : "0"; 
                string end_sub_type_2 = obj["txtSubType2Blanket2"].ToString() != "" ? obj["txtSubType2Blanket2"].ToString() : "0"; 
                string job_status = obj["dllJobStatus"].ToString();
                string pull_qty = obj["dllQtyLevel"].ToString();
                string ReportType = obj["dllStyleReport"].ToString();
                string dllSorting = obj["dllSorting"].ToString();

                ReportParameter[] myparams = new ReportParameter[16];
                myparams[0] = new ReportParameter("beg_fg_id", beg_fg_id, false);
                myparams[1] = new ReportParameter("end_fg_id", end_fg_id, false);
                myparams[2] = new ReportParameter("beg_customer_id", beg_customer_id, false);
                myparams[3] = new ReportParameter("end_customer_id", end_customer_id, false);
                myparams[4] = new ReportParameter("beg_customer_po", beg_customer_po, false);
                myparams[5] = new ReportParameter("end_customer_po", end_customer_po, false);
                myparams[6] = new ReportParameter("beg_date", beg_date, false);
                myparams[7] = new ReportParameter("end_date", end_date, false);
                myparams[8] = new ReportParameter("beg_inventory_type", beg_inventory_type, false);
                myparams[9] = new ReportParameter("end_inventory_type", end_inventory_type, false);
                myparams[10] = new ReportParameter("beg_sub_type_2", beg_sub_type_2, false);
                myparams[11] = new ReportParameter("end_sub_type_2", end_sub_type_2, false);
                myparams[12] = new ReportParameter("job_status", job_status, false);
                myparams[13] = new ReportParameter("pull_qty", pull_qty, false);
                myparams[14] = new ReportParameter("ReportType", ReportType, false);
                myparams[15] = new ReportParameter("Sort", dllSorting, false);
                reportViewer.ServerReport.SetParameters(myparams);
                reportViewer.ServerReport.Refresh();
                ViewBag.ReportViewer = reportViewer;
            }
            //else
            //{
                ViewBag.txtFinishGoodsItemBlanket = "*All Records";
                ViewBag.txtFinishGoodsItemBlanket2 = "0";
                ViewBag.txtCustNumberBlanket = "*All Records";
                ViewBag.txtCustNumberBlanket2 = "0";
                ViewBag.txtCustomerPo = "*All Records";
                ViewBag.txtCustomerPo2 = "0";
                ViewBag.txtInventoryTypeBlanket = "*All Records";
                ViewBag.txtInventoryTypeBlanket2 = "0";
                ViewBag.txtSubType2Blanket = "*All Records";
                ViewBag.txtSubType2Blanket2 = "0";

                ViewBag.DateExp = "*All Records";
                ViewBag.DateExp2 = "0";
                ViewBag.txtDateExp = "*All Records";
                ViewBag.txtDateExp2 = "0";
                //return View(mymodel);
            //}
            mymodel.FinishGoodItem2 = GetFinishGoodItem();
            mymodel.InventoryType2 = GetInventoryType2();
            mymodel.SubType_2 = GetSubType_2();
            mymodel.CustomerPo = GetCustomerPo();
            mymodel.CustomerIDs = GetCustomerIDs();
            return View(mymodel);
        }
        public ActionResult FilterOption7310(FormCollection obj, string filter)
        {
            Session["ReportName"] = "Material Adjustments (7310)";
            ViewBag.Filter = filter;
            if (filter == "Run as a Job and Notify")
            {
               
                TempData["ReportView"] = obj;
                TempData["EmailID"] = Session["EmailID"].ToString();
                TempData["UserID"] = Session["UserID"].ToString();
                List<string> _pagecontent = new List<string>();
                return RedirectToAction("RunReportAsyn7310", "Report");
            }
            ViewBag.DateExp = string.Empty;
            ViewBag.txtDateExp = string.Empty;
            ViewBag.txtDateExp2 = string.Empty;
            ViewBag.DateExp2 = string.Empty;
            dynamic mymodel = new ExpandoObject();
            if (filter == "Run Report Now")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_SynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID", 7310);
                    cmd.Parameters.AddWithValue("@Syn_Report_Name", "Material Adjustments");
                    cmd.Parameters.AddWithValue("@Syn_Report_Date", DateTime.Now);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();
                }
                ViewBag.dllMaterialItem = obj["MaterialItem"].ToString();
                ViewBag.txtMaterialItem = obj["txtMaterialItem"].ToString();
                ViewBag.txtMaterialItem2 = obj["txtMaterialItem2"].ToString();

                ViewBag.dllDateAdjusted = obj["DateAdjusted"].ToString();
                ViewBag.DateAdjustedBeg = obj["DateAdjustedBeg"].ToString();
                ViewBag.txtDateAdjustedBeg = obj["txtDateAdjustedBeg"].ToString();
                ViewBag.DateAdjustedEnd = obj["DateAdjustedEnd"].ToString();
                ViewBag.txtDateAdjustedEnd = obj["txtDateAdjustedEnd"].ToString();

                ViewBag.dllAdjustmentLocCode = obj["AdjustmentLocCode"].ToString();
                ViewBag.txtAdjustmentLocBeg = obj["txtAdjustmentLocBeg"].ToString();              
                ViewBag.txtAdjustmentLocEnd = obj["txtAdjustmentLocEnd"].ToString();
                

                string DateAdjusted = obj["DateAdjusted"].ToString();
                string beg_AdjustedDate = string.Empty;
                string end_AdjustedDate = string.Empty;

                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(1900);
                reportViewer.Height = Unit.Percentage(1900);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7310";
                string beg_MaterialItem = obj["txtMaterialItem"].ToString() != "" ? obj["txtMaterialItem"].ToString() : "0";                
                string end_MaterialItem = obj["txtMaterialItem2"].ToString() != "" ? obj["txtMaterialItem2"].ToString() : "0";
                string beg_AdjustmentCode =obj["txtAdjustmentLocBeg"].ToString() != "" ? obj["txtAdjustmentLocBeg"].ToString() : "0";
                string end_AdjustmentCode = obj["txtAdjustmentLocEnd"].ToString() != "" ? obj["txtAdjustmentLocEnd"].ToString() : "0";               
                if (DateAdjusted == "Between Range")
                {
                    beg_AdjustedDate = obj["DateAdjustedBeg"].ToString();
                    end_AdjustedDate = obj["DateAdjustedEnd"].ToString();
                }
                else if (DateAdjusted == "")
                {
                    beg_AdjustedDate = obj["txtDateAdjustedBeg"].ToString();
                    end_AdjustedDate = obj["txtDateAdjustedEnd"].ToString();
                }
                else if (DateAdjusted == "*All Records")
                {
                    beg_AdjustedDate = obj["txtDateAdjustedBeg"].ToString();
                    end_AdjustedDate = obj["txtDateAdjustedEnd"].ToString();
                    //beg_date = obj["DateShipped1"].ToString();
                    //end_date = obj["DateShipped2"].ToString();
                }
                else
                {
                    beg_AdjustedDate = obj["txtDateAdjustedBeg"].ToString();
                    end_AdjustedDate = obj["DateAdjustedEnd"].ToString();
                }             
                ReportParameter[] myparams = new ReportParameter[6];
                myparams[0] = new ReportParameter("beg_MaterialItem", beg_MaterialItem, false);
                myparams[1] = new ReportParameter("end_MaterialItem", end_MaterialItem, false);
                myparams[2] = new ReportParameter("beg_AdjustmentCode", beg_AdjustmentCode, false);
                myparams[3] = new ReportParameter("end_AdjustmentCode", end_AdjustmentCode, false);
                myparams[4] = new ReportParameter("beg_AdjustedDate", beg_AdjustedDate, false);
                myparams[5] = new ReportParameter("end_AdjustedDate", end_AdjustedDate, false);               

                reportViewer.ServerReport.SetParameters(myparams);

                reportViewer.ServerReport.Refresh();
                ViewBag.ReportViewer = reportViewer;
            }
            else
            {

                ViewBag.txtMaterialItem = "*All Records";
                ViewBag.txtMaterialItem2 = "0";
               
                ViewBag.DateAdjustedBeg = "*All Records";
                ViewBag.txtDateAdjustedBeg = "*All Records";
                ViewBag.DateAdjustedEnd = "0";
                ViewBag.txtDateAdjustedEnd = "0";
              
                ViewBag.txtAdjustmentLocBeg = "*All Records";
                ViewBag.txtAdjustmentLocEnd = "0";

            }
            mymodel.MaterialID2 = GetMaterialID2();
            mymodel.AdjustmentLocationCode = GetAdjustmentLocationCode();
          
            return View(mymodel);
        }
        public ActionResult FilterOption7810(string filter, FormCollection obj)
        {
            Session["ReportName"] = "Profit Summary (7810)";
            ViewBag.LastReceiptDate1PS = string.Empty;
            ViewBag.rangevalLastReceiptDate1PS = string.Empty;
            ViewBag.rangevalLastReceiptDate2PS = string.Empty;
            ViewBag.LastReceiptDate2PS = string.Empty;
            if (filter == "Run as a Job and Notify")
            {
                TempData["ReportView"] = obj;
                TempData["EmailID"] = Session["EmailID"].ToString();
                TempData["UserID"] = Session["UserID"].ToString();
                List<string> _pagecontent = new List<string>();
                return RedirectToAction("RunReportAsyn7810", "Report");
            }
            dynamic mymodel = new ExpandoObject();
            mymodel.CustomerID2 = GetCustomerIDs();
            mymodel.CustomerName2 = GetCustomerName2(); 
            mymodel.Masterpart = GetMasterpart();
            mymodel.JobCode2 = GetJobCode2();
            mymodel.InventoryType2 = GetInventoryType2();
          
            int id = Convert.ToInt32(Session["id"]);
            ViewBag.Filter = filter;
            ViewBag.CustomerID1PS = "*All Records";
            ViewBag.CustomerID2PS = "0";
            ViewBag.CustomerName1PS = "*All Records";
            ViewBag.CustomerName2PS = "0";
            ViewBag.MasterPart1PS = "*All Records";
            ViewBag.MasterPart2PS = "0";
            ViewBag.Jobcode2_1PS = "*All Records";
            ViewBag.Jobcode2_2PS = "0";
            ViewBag.InventoryType1PS = "*All Records";
            ViewBag.InventoryType2PS = "0";
            ViewBag.LastReceiptDate1PS = "*All Records";
            ViewBag.rangevalLastReceiptDate1PS = "*All Records";
            ViewBag.rangevalLastReceiptDate2PS = "0";
            ViewBag.LastReceiptDate2PS = "0";
            try
            {
                if (filter == "Run Report Now")
                {
                    using (cn = new SqlConnection(connString))
                    {
                        cn.Open();
                        cmd = new SqlCommand("sp_Insert_Update_SynReport", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                        cmd.Parameters.AddWithValue("@Report_ID", 7810);
                        cmd.Parameters.AddWithValue("@Syn_Report_Name", "Profit Summary");
                        cmd.Parameters.AddWithValue("@Syn_Report_Date", DateTime.Now);
                        cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                        int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                        int res = cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                    ViewBag.LastReceiptDate1PS = obj["LastReceiptDate1PS"].ToString();
                    ViewBag.rangevalLastReceiptDate1PS = obj["rangevalLastReceiptDate1PS"].ToString();
                    ViewBag.rangevalLastReceiptDate2PS = obj["rangevalLastReceiptDate2PS"].ToString();
                    ViewBag.LastReceiptDate2PS = obj["LastReceiptDate2PS"].ToString();

                    ViewBag.CustomerIDPS = obj["CustomerIDPS"].ToString();
                    ViewBag.CustomerNamePS = obj["CustomerNamePS"].ToString();
                    ViewBag.MasterPartPS = obj["MasterPartPS"].ToString();
                    ViewBag.LastReceiptDatePS = obj["LastReceiptDatePS"].ToString();
                    ViewBag.Jobcode2PS = obj["Jobcode2PS"].ToString();
                    ViewBag.InventoryTypePS = obj["InventoryTypePS"].ToString();
                    string LastReceiptDatePS= obj["LastReceiptDatePS"].ToString();
                    ViewBag.dllSortReportByAccending = obj["dllSortReportByAccending"].ToString();
                    ViewBag.dllSortReportByDescending = obj["dllSortReportByDescending"].ToString();

                    string UrlReportServer = "http://ts2pw8vv/ReportServer";
                    ReportViewer reportViewer = new ReportViewer();
                    reportViewer.ProcessingMode = ProcessingMode.Remote;
                    reportViewer.AsyncRendering = true;
                    reportViewer.SizeToReportContent = true;
                    reportViewer.Width = Unit.Percentage(0);
                    reportViewer.Height = Unit.Percentage(0);
                    reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                    string beg_date_rec = string.Empty;
                    string end_date_rec = string.Empty;
                    reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7810";
                    string beg_customer_id = obj["CustomerID1PS"].ToString() != "" ? obj["CustomerID1PS"].ToString() : "0";
                    string end_customer_id = obj["CustomerID2PS"].ToString() != "" ? obj["CustomerID2PS"].ToString() : "0";
                    string beg_customer_name = obj["CustomerName1PS"].ToString() != "" ? obj["CustomerName1PS"].ToString() : "0";
                    string end_customer_name = obj["CustomerName2PS"].ToString() != "" ? obj["CustomerName2PS"].ToString() : "0";                   
                    string beg_mst_part_id = obj["MasterPart1PS"].ToString() != "" ? obj["MasterPart1PS"].ToString() : "0";                   
                    string end_mst_part_id = obj["MasterPart2PS"].ToString() != "" ? obj["MasterPart2PS"].ToString() : "0";                    
                    string beg_code_2 = obj["Jobcode2_1PS"].ToString() != "" ? obj["Jobcode2_1PS"].ToString() : "0";                  
                    string end_code_2 = obj["Jobcode2_2PS"].ToString() != "" ? obj["Jobcode2_2PS"].ToString() : "0";                   
                    string beg_fg_type_code = obj["InventoryType1PS"].ToString() != "" ? obj["InventoryType1PS"].ToString() : "0";                   
                    string end_fg_type_code = obj["InventoryType2PS"].ToString() != "" ? obj["InventoryType2PS"].ToString() : "0";                   
                    if (LastReceiptDatePS == "Between Range")
                    {
                        beg_date_rec = obj["LastReceiptDate1PS"].ToString();
                        end_date_rec = obj["LastReceiptDate2PS"].ToString();
                    }
                    else if (LastReceiptDatePS == "")
                    {
                        beg_date_rec = obj["rangevalLastReceiptDate1PS"].ToString();
                        end_date_rec = obj["rangevalLastReceiptDate2PS"].ToString();
                    }
                    else if (LastReceiptDatePS == "*All Records")
                    {
                        beg_date_rec = obj["rangevalLastReceiptDate1PS"].ToString();
                        end_date_rec = obj["rangevalLastReceiptDate2PS"].ToString();
                        //beg_date = obj["DateShipped1"].ToString();
                        //end_date = obj["DateShipped2"].ToString();
                    }
                    else
                    {
                        beg_date_rec = obj["rangevalLastReceiptDate1PS"].ToString();
                        end_date_rec = obj["LastReceiptDate2PS"].ToString();
                    }
                    string Sorting_AscendingName = string.Empty;
                    if (obj["dllSortReportByAccending"].ToString()== "Master Job")
                    {
                        Sorting_AscendingName = "master_job";
                    }
                    else if(obj["dllSortReportByAccending"].ToString() == "Customer Name")
                    {
                        Sorting_AscendingName = "cust_name";
                    }
                    else if (obj["dllSortReportByAccending"].ToString() == "Job Code 2")
                    {
                        Sorting_AscendingName = "job_code2";
                    }
                    else if (obj["dllSortReportByAccending"].ToString() == "Maste Part")
                    {
                        Sorting_AscendingName = "master_part_id";
                    }
                    else if (obj["dllSortReportByAccending"].ToString() == "Receipt Date") 
                    {
                        Sorting_AscendingName = "date_shipped";
                    }
                    else
                    {
                        Sorting_AscendingName = "sort_coll";
                    }
                    string Sorting_DescendingName = string.Empty;
                    if (obj["dllSortReportByDescending"].ToString() == "Master Job")
                    {
                        Sorting_DescendingName = "master_job";
                    }
                    else if (obj["dllSortReportByDescending"].ToString() == "Customer Name")
                    {
                        Sorting_DescendingName = "cust_name";
                    }
                    else if (obj["dllSortReportByDescending"].ToString() == "Job Code 2")
                    {
                        Sorting_DescendingName = "job_code2";
                    }
                    else if (obj["dllSortReportByDescending"].ToString() == "Maste Part")
                    {
                        Sorting_DescendingName = "master_part_id";
                    }
                    else if (obj["dllSortReportByDescending"].ToString() == "Receipt Date")
                    {
                        Sorting_DescendingName = "date_shipped";
                    }
                    else
                    {
                        Sorting_DescendingName = "master_job";
                    }

                    ReportParameter[] myparams = new ReportParameter[14];
                    myparams[0] = new ReportParameter("beg_customer_id", beg_customer_id, false);
                    myparams[1] = new ReportParameter("end_customer_id", end_customer_id, false);
                    myparams[2] = new ReportParameter("beg_customer_name", beg_customer_name, false);
                    myparams[3] = new ReportParameter("end_customer_name", end_customer_name, false);
                    myparams[4] = new ReportParameter("beg_mst_part_id", beg_mst_part_id, false);
                    myparams[5] = new ReportParameter("end_mst_part_id", end_mst_part_id, false);
                    myparams[6] = new ReportParameter("beg_date_rec", beg_date_rec, false);
                    myparams[7] = new ReportParameter("end_date_rec", end_date_rec, false);
                    myparams[8] = new ReportParameter("beg_code_2", beg_code_2, false);
                    myparams[9] = new ReportParameter("end_code_2", end_code_2, false);
                    myparams[10] = new ReportParameter("beg_fg_type_code", beg_fg_type_code, false);
                    myparams[11] = new ReportParameter("end_fg_type_code", end_fg_type_code, false);
                    myparams[12] = new ReportParameter("Sorting_AscendingName", Sorting_AscendingName, false);
                    myparams[13] = new ReportParameter("Sorting_DescendingName", Sorting_DescendingName, false);

                    reportViewer.ServerReport.SetParameters(myparams);
                    reportViewer.ServerReport.Refresh();
                    ViewBag.ReportViewer = reportViewer;
                    return View(mymodel);
                }
                return View(mymodel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult FilterOption9170(string filter, FormCollection obj)
        {
            Session["ReportName"] = "Open Pick Ticket Listing (9170)";
            ViewBag.DatetoShip_Beg = string.Empty;
            ViewBag.txtDatetoShip_Beg = string.Empty;
            ViewBag.DatetoShip_End = string.Empty;
            ViewBag.txtDatetoShip_End = string.Empty;

            ViewBag.DateOrdered_Beg = string.Empty;
            ViewBag.txtDateOrdered_Beg = string.Empty;
            ViewBag.DateOrdered_End = string.Empty;
            ViewBag.txtDateOrdered_End = string.Empty;
            if (filter == "Run as a Job and Notify")
            {
               
                TempData["ReportView"] = obj;
                TempData["EmailID"] = Session["EmailID"].ToString();
                TempData["UserID"] = Session["UserID"].ToString();
                List<string> _pagecontent = new List<string>();
                return RedirectToAction("RunReportAsyn9170", "Report");
            }
            if (filter != "Run Report Now")
            {
                ViewBag.FinishGoodsID_Beg = "*All Records";
                ViewBag.FinishGoodsID_End = "0";

                ViewBag.CustomerID_Beg = "*All Records";
                ViewBag.CustomerID_End = "0";

                ViewBag.CustomerPo_Beg = "*All Records";
                ViewBag.CustomerPo_End = "0";

                ViewBag.ShippingLocatoin_Beg = "*All Records";
                ViewBag.ShippingLocatoin_End = "0";

                ViewBag.OrderType_Beg = "*All Records";
                ViewBag.OrderType_End = "0";

                ViewBag.ProductCode_Beg = "*All Records";
                ViewBag.ProductCode_End = "0";

                ViewBag.DatetoShip_Beg = "*All Records";
                ViewBag.txtDatetoShip_Beg = "*All Records";
                ViewBag.DatetoShip_End = "0";
                ViewBag.txtDatetoShip_End = "0";

                ViewBag.DateOrdered_Beg = "*All Records";
                ViewBag.txtDateOrdered_Beg = "*All Records";
                ViewBag.DateOrdered_End = "0";
                ViewBag.txtDateOrdered_End = "0";

            }

            dynamic mymodel = new ExpandoObject();


            string name = obj["filter"];
            ViewBag.Filter = name;
            ViewBag.Filter = filter;
            if (name == "Run Report Now")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_SynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID", 9170);
                    cmd.Parameters.AddWithValue("@Syn_Report_Name", "Open Pick Ticket Listing");
                    cmd.Parameters.AddWithValue("@Syn_Report_Date", DateTime.Now);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();
                }
                //Get Datefilter value
                ViewBag.DatetoShip_Beg = obj["DatetoShip_Beg"].ToString();
                ViewBag.txtDatetoShip_Beg = obj["txtDatetoShip_Beg"].ToString();
                ViewBag.DatetoShip_End = obj["DatetoShip_End"].ToString();
                ViewBag.txtDatetoShip_End = obj["txtDatetoShip_End"].ToString();
                ViewBag.DateOrdered_Beg = obj["DateOrdered_Beg"].ToString();
                ViewBag.txtDateOrdered_Beg = obj["txtDateOrdered_Beg"].ToString();
                ViewBag.DateOrdered_End = obj["DateOrdered_End"].ToString();
                ViewBag.txtDateOrdered_End = obj["txtDateOrdered_End"].ToString();


                //DropDown value get
                ViewBag.FinishGoodsID = obj["FinishGoodsID"].ToString();
                ViewBag.CustomerID = obj["CustomerID"].ToString();
                ViewBag.DatetoShip = obj["DatetoShip"].ToString();
                string DatetoShip = obj["DatetoShip"].ToString();
                ViewBag.DateOrdered = obj["DateOrdered"].ToString();
                string DateOrdered = obj["DateOrdered"].ToString();
                ViewBag.CustomerPo9170 = obj["CustomerPo9170"].ToString();
                ViewBag.ShippingLocatoin9170 = obj["ShippingLocatoin9170"].ToString();
                ViewBag.OrderType9170 = obj["OrderType9170"].ToString();
                ViewBag.ProductCode9170 = obj["ProductCode9170"].ToString();
                ViewBag.dllCustPoNo = obj["dllCustPoNo"].ToString();


                string DatetoShip_Beg = string.Empty;
                string DatetoShip_End = string.Empty;
                string DateOrdered_Beg = string.Empty;
                string DateOrdered_End = string.Empty;
                ViewBag.btn = "filter";
                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(1900);
                reportViewer.Height = Unit.Percentage(1900);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP9170";
                string FinishGoodsID_Beg = obj["FinishGoodsID_Beg"].ToString() != "" ? obj["FinishGoodsID_Beg"].ToString() : "0";
                string FinishGoodsID_End = obj["FinishGoodsID_End"].ToString() != "" ? obj["FinishGoodsID_End"].ToString() : "0";
                string CustomerID_Beg = obj["CustomerID_Beg"].ToString() != "" ? obj["CustomerID_Beg"].ToString() : "0";
                string CustomerID_End = obj["CustomerID_End"].ToString() != "" ? obj["CustomerID_End"].ToString() : "0";                         
                if (DatetoShip == "Between Range")
                {
                    DatetoShip_Beg = obj["DatetoShip_Beg"].ToString();
                    DatetoShip_End = obj["DatetoShip_End"].ToString();
                }
                else if (DatetoShip == "")
                {
                    DatetoShip_Beg = obj["txtDatetoShip_Beg"].ToString();
                    DatetoShip_End = obj["txtDatetoShip_End"].ToString();
                }
                else if (DatetoShip == "*All Records")
                {
                    DatetoShip_Beg = obj["txtDatetoShip_Beg"].ToString();
                    DatetoShip_End = obj["txtDatetoShip_End"].ToString();

                }
                else
                {
                    DatetoShip_Beg = obj["txtDatetoShip_Beg"].ToString();
                    DatetoShip_End = obj["DatetoShip_End"].ToString();
                }

                if (DateOrdered == "Between Range")
                {
                    DateOrdered_Beg = obj["DateOrdered_Beg"].ToString();
                    DateOrdered_End = obj["DateOrdered_End"].ToString();
                }
                else if (DateOrdered == "")
                {
                    DateOrdered_Beg = obj["txtDateOrdered_Beg"].ToString();
                    DateOrdered_End = obj["txtDateOrdered_End"].ToString();
                }
                else if (DateOrdered == "*All Records")
                {
                    DateOrdered_Beg = obj["txtDateOrdered_Beg"].ToString();
                    DateOrdered_End = obj["txtDateOrdered_End"].ToString();

                }
                else
                {
                    DateOrdered_Beg = obj["txtDateOrdered_Beg"].ToString();
                    DateOrdered_End = obj["DateOrdered_End"].ToString();
                }
                string CustomerPo_Beg = obj["CustomerPo_Beg"].ToString() != "" ? obj["CustomerPo_Beg"].ToString() : "0"; 
                string CustomerPo_End = obj["CustomerPo_End"].ToString() != "" ? obj["CustomerPo_End"].ToString() : "0"; 
                string ShippingLocatoin_Beg = obj["ShippingLocatoin_Beg"].ToString() != "" ? obj["ShippingLocatoin_Beg"].ToString() : "0"; 
                string ShippingLocatoin_End = obj["ShippingLocatoin_End"].ToString() != "" ? obj["ShippingLocatoin_End"].ToString() : "0";
                string OrderType_Beg = obj["OrderType_Beg"].ToString() != "" ? obj["OrderType_Beg"].ToString() : "0"; 
                string OrderType_End = obj["OrderType_End"].ToString() != "" ? obj["OrderType_End"].ToString() : "0"; 
                string ProductCode_Beg = obj["ProductCode_Beg"].ToString() != "" ? obj["ProductCode_Beg"].ToString() : "0"; 
                string ProductCode_End = obj["ProductCode_End"].ToString() != "" ? obj["ProductCode_End"].ToString() : "0"; 
                //string beg_product_code = obj["ProductCode1"].ToString() != "" ? obj["ProductCode1"].ToString() : "0"; 
                //string end_product_code = obj["ProductCode2"].ToString() != "" ? obj["ProductCode2"].ToString() : "0"; 
                //string dllCustPoNo = obj["dllCustPoNo"].ToString();
                ReportParameter[] myparams = new ReportParameter[16];
                myparams[0] = new ReportParameter("BegFGItem", FinishGoodsID_Beg, false);
                myparams[1] = new ReportParameter("EndFGItem", FinishGoodsID_End, false);
                myparams[2] = new ReportParameter("BegCust", CustomerID_Beg, false);
                myparams[3] = new ReportParameter("EndCust", CustomerID_End, false);
                myparams[4] = new ReportParameter("BegShipDate", DatetoShip_Beg, false);
                myparams[5] = new ReportParameter("EndShipDate", DatetoShip_End, false);
                myparams[6] = new ReportParameter("BegCustomerPO", CustomerPo_Beg, false);
                myparams[7] = new ReportParameter("EndCustomerPO", CustomerPo_End, false);
                myparams[8] = new ReportParameter("BegShipLocation", ShippingLocatoin_Beg, false);
                myparams[9] = new ReportParameter("EndShipLocation", ShippingLocatoin_End, false);
                myparams[10] = new ReportParameter("BegOrderType", OrderType_Beg, false);
                myparams[11] = new ReportParameter("EndOrderType", OrderType_End, false);          
                myparams[12] = new ReportParameter("BegProductCode", ProductCode_Beg, false);
                myparams[13] = new ReportParameter("EndProductCode", ProductCode_End, false);
                myparams[14] = new ReportParameter("BegOrderedDate", DateOrdered_Beg, false);
                myparams[15] = new ReportParameter("EndOrderedDate", DateOrdered_End, false);
                //myparams[16] = new ReportParameter("Sorting_Name", dllCustPoNo, false);
                reportViewer.ServerReport.SetParameters(myparams);

                reportViewer.ServerReport.Refresh();
                ViewBag.ReportViewer = reportViewer;

                mymodel.FinishGoodItem = GetFinishGoodItem();
                mymodel.CustomerIDs = GetCustomerIDs();

                mymodel.ShippingLocation2 = GetShippingLocation2();
                mymodel.OrderType2 = GetOrderType2();
                mymodel.ProductCode = GetProductCode2();
                mymodel.CustomerPo = GetCustomerPo();
                return View(mymodel);
            }





            mymodel.FinishGoodItem = GetFinishGoodItem();
            mymodel.CustomerIDs = GetCustomerIDs();
            mymodel.CustomerPo = GetCustomerPo();
            mymodel.ShippingLocation2 = GetShippingLocation2();
            mymodel.OrderType2 = GetOrderType2();
            mymodel.ProductCode = GetProductCode2();



            return View(mymodel);
        }
        public ActionResult FilterOption7950(FormCollection obj, string filter)
        {
            try
            {
                Session["ReportName"] = "Generic ID Tag (7950)";
                dynamic mymodel = new ExpandoObject();
                mymodel.GenericJobNum = GetGenericJobNum();

                ViewBag.Filter = filter;
                ViewBag.GenricJobNum_Beg = "*All Records";
                ViewBag.GenricJobNum_End = "0";
                if (filter == "Run as a Job and Notify")
                {
                    
                    TempData["ReportView"] = obj;
                    TempData["EmailID"] = Session["EmailID"].ToString();
                    TempData["UserID"] = Session["UserID"].ToString();
                    List<string> _pagecontent = new List<string>();
                    return RedirectToAction("RunReportAsyn7950", "Report");
                }
                if (filter == "Run Report Now")
                {
                    using (cn = new SqlConnection(connString))
                    {
                        cn.Open();
                        cmd = new SqlCommand("sp_Insert_Update_SynReport", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                        cmd.Parameters.AddWithValue("@Report_ID", 7950);
                        cmd.Parameters.AddWithValue("@Syn_Report_Name", "Generic ID Tag");
                        cmd.Parameters.AddWithValue("@Syn_Report_Date", DateTime.Now);
                        cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                        int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                        int res = cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                    ViewBag.GenricJobNum_Beg = obj["GenricJobNum_Beg"].ToString();
                    ViewBag.GenricJobNum_End = obj["GenricJobNum_End"].ToString();
                    ViewBag.GenricJobNum = obj["GenricJobNum"].ToString();
                    string UrlReportServer = "http://ts2pw8vv/ReportServer";
                    ReportViewer reportViewer = new ReportViewer();
                    reportViewer.ProcessingMode = ProcessingMode.Remote;
                    reportViewer.AsyncRendering = true;
                    reportViewer.SizeToReportContent = true;
                    reportViewer.Width = Unit.Percentage(900);
                    reportViewer.Height = Unit.Percentage(900);
                    reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                    reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7950_new";
                    string GenricJobNum_Beg = obj["GenricJobNum_Beg"].ToString() != "" ? obj["GenricJobNum_Beg"].ToString() : "0";
                    string GenricJobNum_End = obj["GenricJobNum_End"].ToString() != "" ? obj["GenricJobNum_End"].ToString() : "0";                  
                    ReportParameter[] myparams = new ReportParameter[2];
                    myparams[0] = new ReportParameter("beg_generic_job", GenricJobNum_Beg, false);
                    myparams[1] = new ReportParameter("end_generic_job", GenricJobNum_End, false);

                    reportViewer.ServerReport.SetParameters(myparams);

                    reportViewer.ServerReport.Refresh();
                    ViewBag.ReportViewer = reportViewer;
                    mymodel.GenericJobNum = GetGenericJobNum();
                    return View(mymodel);
                }

                return View(mymodel);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public ActionResult FilterOption7980(FormCollection obj, string filter)
        {
            Session["ReportName"] = "CS Schedule Report (7980)";
            ViewBag.Filter = filter;
            ViewBag.OEDateWanted_Beg = string.Empty;
            ViewBag.txtOEDateWanted_Beg = string.Empty;
            ViewBag.OEDateWanted_End = string.Empty;
            ViewBag.txtOEDateWanted_End = string.Empty;
            if (filter == "Run as a Job and Notify")
            {
              
                TempData["ReportView"] = obj;
                TempData["EmailID"] = Session["EmailID"].ToString();
                TempData["UserID"] = Session["UserID"].ToString();
                List<string> _pagecontent = new List<string>();
                return RedirectToAction("RunReportAsyn7980", "Report");
            }
            if (filter != "Run Report Now")
            {
                ViewBag.MasterPartNum_Beg = "*All Records";
                ViewBag.MasterPartNum_End = "0";

                ViewBag.MasterPartDesc_Beg = "*All Records";
                ViewBag.MasterPartDesc_End = "0";

                ViewBag.FinishGoodsID_Beg = "*All Records";
                ViewBag.FinishGoodsID_End = "0";

                ViewBag.FinishGoodsDesc_Beg = "*All Records";
                ViewBag.FinishGoodsDesc_End = "0";



                ViewBag.CustID_Beg = "*All Records";
                ViewBag.CustID_End = "0";

                ViewBag.CustName_Beg = "*All Records";
                ViewBag.CustName_End = "0";

                ViewBag.OEDateWanted_Beg = "*All Records";
                ViewBag.OEDateWanted_End = "0";

                ViewBag.txtOEDateWanted_Beg = "*All Records";
                ViewBag.txtOEDateWanted_End = "0";


            }

            dynamic mymodel = new ExpandoObject();


            string name = obj["filter"];
            ViewBag.Filter = name;
            if (name == "Run Report Now")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_SynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID", 7980);
                    cmd.Parameters.AddWithValue("@Syn_Report_Name", "CS Schedule Report");
                    cmd.Parameters.AddWithValue("@Syn_Report_Date", DateTime.Now);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();
                }
                ViewBag.OEDateWanted_Beg = obj["OEDateWanted_Beg"].ToString();
                ViewBag.OEDateWanted_End = obj["OEDateWanted_End"].ToString();
                ViewBag.txtOEDateWanted_Beg = obj["txtOEDateWanted_Beg"].ToString();
                ViewBag.txtOEDateWanted_End = obj["txtOEDateWanted_End"].ToString();

                ViewBag.MasterPartNum = obj["MasterPartNum"].ToString();
                ViewBag.MasterPartDesc = obj["MasterPartDesc"].ToString();
                ViewBag.FinishGoodsID = obj["FinishGoodsID"].ToString();
                ViewBag.FinishGoodsDesc = obj["FinishGoodsDesc"].ToString();
                ViewBag.CustID = obj["CustID"].ToString();
                ViewBag.CustName = obj["CustName"].ToString();
                ViewBag.OEDateWanted = obj["OEDateWanted"].ToString();
                ViewBag.dllDept = obj["dllDept"].ToString();

                string OEDateWanted = obj["OEDateWanted"].ToString();
                string OEDateWanted_Beg = string.Empty;
                string OEDateWanted_End = string.Empty;

                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;               
                reportViewer.Width = Unit.Percentage(1900);
                reportViewer.Height = Unit.Percentage(1900);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7980";
                string MasterPartNum_Beg = obj["MasterPartNum_Beg"].ToString() != "" ? obj["MasterPartNum_Beg"].ToString() : "0";               
                string MasterPartNum_End = obj["MasterPartNum_End"].ToString() != "" ? obj["MasterPartNum_End"].ToString() : "0";               
                string MasterPartDesc_Beg = obj["MasterPartDesc_Beg"].ToString() != "" ? obj["MasterPartDesc_Beg"].ToString() : "0";               
                string MasterPartDesc_End = obj["MasterPartDesc_End"].ToString() != "" ? obj["MasterPartDesc_End"].ToString() : "0";              
                string FinishGoodsID_Beg = obj["FinishGoodsID_Beg"].ToString() != "" ? obj["FinishGoodsID_Beg"].ToString() : "0";              
                string FinishGoodsID_End = obj["FinishGoodsID_End"].ToString() != "" ? obj["FinishGoodsID_End"].ToString() : "0";              
                string FinishGoodsDesc_Beg = obj["FinishGoodsDesc_Beg"].ToString() != "" ? obj["FinishGoodsDesc_Beg"].ToString() : "0";               
                string FinishGoodsDesc_End = obj["FinishGoodsDesc_End"].ToString() != "" ? obj["FinishGoodsDesc_End"].ToString() : "0";               
                string CustID_Beg = obj["CustID_Beg"].ToString() != "" ? obj["CustID_Beg"].ToString() : "0";               
                string CustID_End = obj["CustID_End"].ToString() != "" ? obj["CustID_End"].ToString() : "0";               
                string CustName_Beg = obj["CustName_Beg"].ToString() != "" ? obj["CustName_Beg"].ToString() : "0";               
                string CustName_End = obj["CustName_End"].ToString() != "" ? obj["CustName_End"].ToString() : "0";              
                string ddlDept = obj["dllDept"].ToString();
                //beg_date = obj["DateShipped1"].ToString();
                //end_date = obj["DateShipped2"].ToString();
                //if (OEDateWanted == "Between Range")
                //{
                //    OEDateWanted_Beg = obj["OEDateWanted_Beg"].ToString();
                //    OEDateWanted_End = obj["OEDateWanted_End"].ToString();
                //}
                //else if (OEDateWanted == "")
                //{
                //    OEDateWanted_Beg = obj["txtOEDateWanted_Beg"].ToString();
                //    OEDateWanted_End = obj["txtOEDateWanted_End"].ToString(); ;
                //}
                //else if (OEDateWanted == "*All Records")
                //{
                //    OEDateWanted_Beg = obj["txtOEDateWanted_Beg"].ToString();
                //    OEDateWanted_End = obj["txtOEDateWanted_End"].ToString();
                //    //beg_date = obj["DateShipped1"].ToString();
                //    //end_date = obj["DateShipped2"].ToString();
                //}
                //else
                //{
                //    OEDateWanted_Beg = obj["txtOEDateWanted_Beg"].ToString();
                //    OEDateWanted_End = obj["OEDateWanted_End"].ToString();
                //}



                ReportParameter[] myparams = new ReportParameter[13];
                myparams[0] = new ReportParameter("beg_master_part_id", MasterPartNum_Beg, false);
                myparams[1] = new ReportParameter("end_master_part_id", MasterPartNum_End, false);
                myparams[2] = new ReportParameter("beg_master_part_desc", MasterPartDesc_Beg, false);
                myparams[3] = new ReportParameter("end_master_part_desc", MasterPartDesc_End, false);
                myparams[4] = new ReportParameter("beg_fg_id", FinishGoodsID_Beg, false);
                myparams[5] = new ReportParameter("end_fg_id", FinishGoodsID_End, false);
                myparams[6] = new ReportParameter("beg_fg_desc", FinishGoodsDesc_Beg, false);
                myparams[7] = new ReportParameter("end_fg_desc", FinishGoodsDesc_End, false);
                myparams[8] = new ReportParameter("beg_customer_id", CustID_Beg, false);
                myparams[9] = new ReportParameter("end_customer_id", CustID_End, false);
                myparams[10] = new ReportParameter("beg_customer_name", CustName_Beg, false);
                myparams[11] = new ReportParameter("end_customer_name", CustName_End, false);
                //myparams[12] = new ReportParameter("beg_order_type", OEDateWanted_Beg, false);
                //myparams[13] = new ReportParameter("end_order_type", OEDateWanted_End, false);
                myparams[12] = new ReportParameter("department_choice", ddlDept, false);
                //myparams[18] = new ReportParameter("Sorting_Name", Sorting_Name, false);
                reportViewer.ServerReport.SetParameters(myparams);

                reportViewer.ServerReport.Refresh();
                ViewBag.ReportViewer = reportViewer;

                mymodel.FinishGoodItem = GetFinishGoodItem();
                mymodel.FinishGoodItemDesc = GeFinishGoodDescription2();
                mymodel.CustomerIDs = GetCustomerIDs();
                mymodel.CustomerName2 = GetCustomerName2();
                mymodel.MasterPart = GetMasterpart();
                mymodel.MasterPartDescription = GetMasterpartDescription();
                return View(mymodel);
            }
            mymodel.FinishGoodItem = GetFinishGoodItem();
            mymodel.FinishGoodItemDesc = GeFinishGoodDescription2();
            mymodel.CustomerIDs = GetCustomerIDs();
            mymodel.CustomerName2 = GetCustomerName2();
            mymodel.MasterPart = GetMasterpart();
            mymodel.MasterPartDescription = GetMasterpartDescription();
            return View(mymodel);
        }
        public ActionResult FilterOption7990(FormCollection obj, string filter)
        {
            Session["ReportName"] = "Material Allocations Report (7990)";
            ViewBag.Filter = filter;
            if (filter == "Run as a Job and Notify")
            {
                
                TempData["ReportView"] = obj;
                TempData["EmailID"] = Session["EmailID"].ToString();
                TempData["UserID"] = Session["UserID"].ToString();
                List<string> _pagecontent = new List<string>();
                return RedirectToAction("RunReportAsyn7990", "Report");
            }
            dynamic mymodel = new ExpandoObject();
            ViewBag.MaterialID_Beg = "*All Records";
            ViewBag.MaterialID_End = "0";
            ViewBag.MaterilaDesc_Beg = "*All Records";
            ViewBag.MaterilaDesc_End = "0";

            ViewBag.VendorId_Beg = "*All Records";
            ViewBag.VendorId_End = "0";
            ViewBag.VendorName_Beg = "*All Records";
            ViewBag.VendorName_End = "0";
            ViewBag.CustId_Material_Beg = "*All Records";
            ViewBag.CustId_Material_End = "0";
            ViewBag.CustName_Material_Beg = "*All Records";
            ViewBag.CustName_Material_End = "0";
            if (filter == "Run Report Now")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_SynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID", 7990);
                    cmd.Parameters.AddWithValue("@Syn_Report_Name", "Material Allocations Report");
                    cmd.Parameters.AddWithValue("@Syn_Report_Date", DateTime.Now);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();
                }
                ViewBag.MaterialID = obj["MaterialID"].ToString();
                ViewBag.MaterilaDesc = obj["MaterilaDesc"].ToString();
                ViewBag.VendorId = obj["VendorId"].ToString();
                ViewBag.VendorName = obj["VendorName"].ToString();
                ViewBag.CustId_Material = obj["CustId_Material"].ToString();
                ViewBag.CustName_Material = obj["CustName_Material"].ToString();

                string OEDateWanted_Beg = string.Empty;
                string OEDateWanted_End = string.Empty;

                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(1900);
                reportViewer.Height = Unit.Percentage(1900);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7990";
                string MaterialID_Beg = obj["MaterialID_Beg"].ToString() != "" ? obj["MaterialID_Beg"].ToString() : "0";               
                string MaterialID_End = obj["MaterialID_End"].ToString() != "" ? obj["MaterialID_End"].ToString() : "0";               
                string MaterilaDesc_Beg = obj["MaterilaDesc_Beg"].ToString() != "" ? obj["MaterilaDesc_Beg"].ToString() : "0";               
                string MaterilaDesc_End = obj["MaterilaDesc_End"].ToString() != "" ? obj["MaterilaDesc_End"].ToString() : "0";               
                string VendorId_Beg = obj["VendorId_Beg"].ToString() != "" ? obj["VendorId_Beg"].ToString() : "0";
                string VendorId_End = obj["VendorId_End"].ToString() != "" ? obj["VendorId_End"].ToString() : "0";              
                string VendorName_Beg = obj["VendorName_Beg"].ToString() != "" ? obj["VendorName_Beg"].ToString() : "0";              
                string VendorName_End = obj["VendorName_End"].ToString() != "" ? obj["VendorName_End"].ToString() : "0";
              
                ReportParameter[] myparams = new ReportParameter[8];
                myparams[0] = new ReportParameter("beg_material_id", MaterialID_Beg, false);
                myparams[1] = new ReportParameter("end_material_id", MaterialID_End, false);
                myparams[2] = new ReportParameter("beg_material_desc", MaterilaDesc_Beg, false);
                myparams[3] = new ReportParameter("end_material_desc", MaterilaDesc_End, false);
                myparams[4] = new ReportParameter("beg_vendor_id", VendorId_Beg, false);
                myparams[5] = new ReportParameter("end_vendor_id", VendorId_End, false);
                myparams[6] = new ReportParameter("beg_vendor_name", VendorName_Beg, false);
                myparams[7] = new ReportParameter("end_vendor_name", VendorName_End, false);               

                reportViewer.ServerReport.SetParameters(myparams);
                reportViewer.ServerReport.Refresh();
                ViewBag.ReportViewer = reportViewer;              
                //return View(mymodel);
            }
            mymodel.CustomerIDs = GetCustomerIDs();
            mymodel.CustomerName2 = GetCustomerName2();
            mymodel.vendor = GetVendorID();
            mymodel.vendorName = GetVendorName();
            mymodel.Material = GetMaterialID2();
            return View(mymodel);
        }
        public ActionResult FilterOption7190(FormCollection obj, string filter)
        {
            Session["ReportName"] = "Customer Order Summery (7190)";
            ViewBag.DateShipped_Ord_Sum_Beg = string.Empty;
            ViewBag.DateShipped_Ord_Sum_End = string.Empty;
            ViewBag.txtDateShipped_Ord_Sum_Beg = string.Empty;
            ViewBag.txtDateShipped_Ord_Sum_End = string.Empty;
            if (filter == "Run as a Job and Notify")
            {
               
                TempData["ReportView"] = obj;
                TempData["EmailID"] = Session["EmailID"].ToString();
                TempData["UserID"] = Session["UserID"].ToString();
                List<string> _pagecontent = new List<string>();
                return RedirectToAction("RunReportAsyn7190", "Report");
            }
            //if (filter != "Run Report Now")
            //{
                ViewBag.FinishGoodsId_OrdSum_Beg = "*All Records";
                ViewBag.FinishGoodsId_OrdSum_End = "0";

                ViewBag.CustomerID_Ord_Sum_Beg = "*All Records";
                ViewBag.CustomerID_Ord_Sum_End = "0";



                ViewBag.DateShipped_Ord_Sum_Beg = "*All Records";
                ViewBag.DateShipped_Ord_Sum_End = "0";

                ViewBag.txtDateShipped_Ord_Sum_Beg = "*All Records";
                ViewBag.txtDateShipped_Ord_Sum_End = "0";

                ViewBag.InventoryType_Ord_Sum_Beg = "*All Records";
                ViewBag.InventoryType_Ord_Sum_End = "0";

                ViewBag.SubType2_Ord_Sum_Beg = "*All Records";
                ViewBag.SubType2_Ord_Sum_End = "0";

                ViewBag.SubType3_Ord_Sum_Beg = "*All Records";
                ViewBag.SubType3_Ord_Sum_End = "0";

                ViewBag.InvoiceIdNum_Beg = "*All Records";
                ViewBag.InvoiceIdNum_End = "0";
                ViewBag.DateShipped_Ord_Sum = string.Empty;
            //}

            dynamic mymodel = new ExpandoObject();
            mymodel.FinishGoodItem = GetFinishGoodItem();
            mymodel.CustomerIDs = GetCustomerIDs();
            mymodel.SubType_2 = GetSubType_2();
            mymodel.SubType_3 = GetSubType_3();
            mymodel.InventoryType2 = GetInventoryType2();
            mymodel.Invoice = InvoiceIdNum();

            string name = obj["filter"];
            ViewBag.Filter = name;
            if (name == "Run Report Now")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_SynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID", 7190);
                    cmd.Parameters.AddWithValue("@Syn_Report_Name", "Customer Order Summery");
                    cmd.Parameters.AddWithValue("@Syn_Report_Date", DateTime.Now);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();
                }
                ViewBag.DateShipped_Ord_Sum_Beg = obj["DateShipped_Ord_Sum_Beg"].ToString();
                ViewBag.DateShipped_Ord_Sum_End = obj["DateShipped_Ord_Sum_End"].ToString();
                ViewBag.txtDateShipped_Ord_Sum_Beg = obj["txtDateShipped_Ord_Sum_Beg"].ToString();
                ViewBag.txtDateShipped_Ord_Sum_End = obj["txtDateShipped_Ord_Sum_End"].ToString();

                ViewBag.FinishGoodsId_OrdSum = obj["FinishGoodsId_OrdSum"].ToString();
                ViewBag.CustomerID_Ord_Sum = obj["CustomerID_Ord_Sum"].ToString();
                ViewBag.DateShipped_Ord_Sum = obj["DateShipped_Ord_Sum"].ToString();

                string DateShipped = obj["DateShipped_Ord_Sum"].ToString();
                ViewBag.InventoryType_Ord_Sum = obj["InventoryType_Ord_Sum"].ToString();
                ViewBag.SubType2_Ord_Sum = obj["SubType2_Ord_Sum"].ToString();
                ViewBag.SubType3_Ord_Sum = obj["SubType3_Ord_Sum"].ToString();
                ViewBag.InvoiceIdNum = obj["InvoiceIdNum"].ToString();

                string beg_date = string.Empty;
                string end_date = string.Empty;
                ViewBag.btn = "filter";
                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(1900);
                reportViewer.Height = Unit.Percentage(1900);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7190";
                string FinishGoodsId_OrdSum_Beg = obj["FinishGoodsId_OrdSum_Beg"].ToString() != "" ? obj["FinishGoodsId_OrdSum_Beg"].ToString() : "0";               
                string FinishGoodsId_OrdSum_End = obj["FinishGoodsId_OrdSum_End"].ToString() != "" ? obj["FinishGoodsId_OrdSum_End"].ToString() : "0";             
                string CustomerID_Ord_Sum_Beg = obj["CustomerID_Ord_Sum_Beg"].ToString() != "" ? obj["CustomerID_Ord_Sum_Beg"].ToString() : "0";               
                string CustomerID_Ord_Sum_End = obj["CustomerID_Ord_Sum_End"].ToString() != "" ? obj["CustomerID_Ord_Sum_End"].ToString() : "0";
              
                if (DateShipped == "Between Range")
                {
                    beg_date = obj["DateShipped_Ord_Sum_Beg"].ToString();
                    end_date = obj["DateShipped_Ord_Sum_End"].ToString();
                }
                else if (DateShipped == "")
                {
                    beg_date = obj["txtDateShipped_Ord_Sum_Beg"].ToString();
                    end_date = obj["txtDateShipped_Ord_Sum_End"].ToString();
                }
                else if (DateShipped == "*All Records")
                {
                    beg_date = obj["txtDateShipped_Ord_Sum_Beg"].ToString();
                    end_date = obj["txtDateShipped_Ord_Sum_End"].ToString();
                }
                else
                {
                    beg_date = obj["txtDateShipped_Ord_Sum_Beg"].ToString();
                    end_date = obj["DateShipped_Ord_Sum_End"].ToString();
                }

                string beg_inventory_type = obj["InventoryType_Ord_Sum_Beg"].ToString() != "" ? obj["InventoryType_Ord_Sum_Beg"].ToString() : "0"; 
                string end_inventory_type = obj["InventoryType_Ord_Sum_End"].ToString() != "" ? obj["InventoryType_Ord_Sum_End"].ToString() : "0"; 
                string SubType2_Ord_Sum_Beg = obj["SubType2_Ord_Sum_Beg"].ToString() != "" ? obj["SubType2_Ord_Sum_Beg"].ToString() : "0"; 
                string SubType2_Ord_Sum_End = obj["SubType2_Ord_Sum_End"].ToString() != "" ? obj["SubType2_Ord_Sum_End"].ToString() : "0"; 
                string SubType3_Ord_Sum_Beg = obj["SubType3_Ord_Sum_Beg"].ToString() != "" ? obj["SubType3_Ord_Sum_Beg"].ToString() : "0"; 
                string SubType3_Ord_Sum_End = obj["SubType3_Ord_Sum_End"].ToString() != "" ? obj["SubType3_Ord_Sum_End"].ToString() : "0"; 
                string InvoiceIdNum_Beg = obj["InvoiceIdNum_Beg"].ToString() != "" ? obj["InvoiceIdNum_Beg"].ToString() : "0";
                string InvoiceIdNum_End = obj["InvoiceIdNum_End"].ToString() != "" ? obj["InvoiceIdNum_End"].ToString() : "0";           

                ReportParameter[] myparams = new ReportParameter[14];
                myparams[0] = new ReportParameter("beg_fg_id", FinishGoodsId_OrdSum_Beg, false);
                myparams[1] = new ReportParameter("end_fg_id", FinishGoodsId_OrdSum_End, false);
                myparams[2] = new ReportParameter("beg_customer_id", CustomerID_Ord_Sum_Beg, false);
                myparams[3] = new ReportParameter("end_customer_id", CustomerID_Ord_Sum_End, false);
                myparams[4] = new ReportParameter("beg_date", beg_date, false);
                myparams[5] = new ReportParameter("end_date", end_date, false);
                myparams[6] = new ReportParameter("beg_inventory_type", beg_inventory_type, false);
                myparams[7] = new ReportParameter("end_inventory_type", end_inventory_type, false);
                myparams[8] = new ReportParameter("beg_sub_type_2", SubType2_Ord_Sum_Beg, false);
                myparams[9] = new ReportParameter("end_sub_type_2", SubType2_Ord_Sum_End, false);
                myparams[10] = new ReportParameter("beg_sub_type_3", SubType3_Ord_Sum_Beg, false);
                myparams[11] = new ReportParameter("end_sub_type_3", SubType3_Ord_Sum_End, false);
                myparams[12] = new ReportParameter("Beg_Invoice_ID", InvoiceIdNum_Beg, false);
                myparams[13] = new ReportParameter("End_Invoice_ID", InvoiceIdNum_End, false);

                reportViewer.ServerReport.SetParameters(myparams);        

                reportViewer.ServerReport.Refresh();
                ViewBag.ReportViewer = reportViewer;              
            }    
           return View(mymodel);

        }
        public ActionResult FilterOption7130(FormCollection obj, string filter)
        {
            Session["ReportName"] = "Finish Goods Expiration (7130)";
            ViewBag.DateExpiration_Beg = string.Empty;
            ViewBag.DateExpiration_End = string.Empty;
            ViewBag.txtDateExpiration_Beg = string.Empty;
            ViewBag.txtDateExpiration_End = string.Empty;
            ViewBag.DateExpiration = string.Empty;
            if (filter == "Run as a Job and Notify")
            {
               
                TempData["ReportView"] = obj;
                TempData["EmailID"] = Session["EmailID"].ToString();
                TempData["UserID"] = Session["UserID"].ToString();
                List<string> _pagecontent = new List<string>();
                return RedirectToAction("RunReportAsyn7130", "Report");
            }
            if (filter != "Run Report Now")
            {
                ViewBag.FinishGoodsItems_Exp_Beg = "*All Records";
                ViewBag.FinishGoodsItems_Exp_End = "0";

                ViewBag.Customer_Beg = "*All Records";
                ViewBag.Customer_End = "0";



                ViewBag.DateExpiration_Beg = "*All Records";
                ViewBag.DateExpiration_End = "0";

                ViewBag.txtDateExpiration_Beg = "*All Records";
                ViewBag.txtDateExpiration_End = "0";

                ViewBag.InventoryType_exp_Beg = "*All Records";
                ViewBag.InventoryType_exp_End = "0";

                ViewBag.StandardClassification_Beg = "*All Records";
                ViewBag.StandardClassification_End = "0";
               //ViewBag.DateExpiration = obj["DateExpiration"].ToString();


            }

            dynamic mymodel = new ExpandoObject();


            string name = obj["filter"];
            ViewBag.Filter = name;
            if (name == "Run Report Now")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_Insert_Update_SynReport", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                    cmd.Parameters.AddWithValue("@Report_ID", 7130);
                    cmd.Parameters.AddWithValue("@Syn_Report_Name", "Finish Goods Expiration");
                    cmd.Parameters.AddWithValue("@Syn_Report_Date", DateTime.Now);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    int res = cmd.ExecuteNonQuery();
                    cn.Close();
                }
                ViewBag.FinishGoodsItems_Exp_Beg = obj["FinishGoodsItems_Exp_Beg"].ToString();
                ViewBag.Customer = obj["Customer"].ToString();
                ViewBag.DateExpiration_Beg = obj["DateExpiration_Beg"].ToString();
                ViewBag.txtDateExpiration_Beg = obj["txtDateExpiration_Beg"].ToString();
                ViewBag.DateExpiration_End = obj["DateExpiration_End"].ToString();
                ViewBag.txtDateExpiration_End = obj["txtDateExpiration_End"].ToString();

                ViewBag.DateExpiration = obj["DateExpiration"].ToString();

                string DateExpiration = obj["DateExpiration"].ToString();
                ViewBag.InventoryType_exp = obj["InventoryType_exp"].ToString();
                ViewBag.StandardClassification = obj["StandardClassification"].ToString();
                ViewBag.dllDiscontuned_Item = obj["dllDiscontuned_Item"].ToString();
                ViewBag.dllsorting7130 = obj["dllsorting7130"].ToString();

                string beg_date = string.Empty;
                string end_date = string.Empty;
                ViewBag.btn = "filter";
                string UrlReportServer = "http://ts2pw8vv/ReportServer";
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.AsyncRendering = true;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(1900);
                reportViewer.Height = Unit.Percentage(1900);
                reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP7130";
                string FinishGoodsItems_Exp_Beg = obj["FinishGoodsItems_Exp_Beg"].ToString() != "" ? obj["FinishGoodsItems_Exp_Beg"].ToString() : "0";
                string FinishGoodsItems_Exp_End = obj["FinishGoodsItems_Exp_End"].ToString() != "" ? obj["FinishGoodsItems_Exp_End"].ToString() : "0";
                string Customer_Beg = obj["Customer_Beg"].ToString() != "" ? obj["Customer_Beg"].ToString() : "0";               
                string Customer_End = obj["Customer_End"].ToString() != "" ? obj["Customer_End"].ToString() : "0";
               
                //string beg_customer_name = string.Empty;
                //if (obj["CustomerName1"].ToString() != "")
                //{
                //    beg_customer_name = obj["CustomerName1"].ToString();
                //}
                //else
                //{
                //    beg_customer_name = "0";
                //}
                //string end_customer_name = string.Empty;
                //if (obj["CustomerName2"].ToString() != "")
                //{
                //    end_customer_name = obj["CustomerName2"].ToString();
                //}
                //else
                //{
                //    end_customer_name = "0";
                //}
              
                if (DateExpiration == "Between Range")
                {
                    beg_date = obj["DateExpiration_Beg"].ToString();
                    end_date = obj["DateExpiration_End"].ToString();
                }
                else if (DateExpiration == "")
                {
                    beg_date = obj["txtDateExpiration_Beg"].ToString();
                    end_date = obj["txtDateExpiration_End"].ToString();
                }
                else if (DateExpiration == "*All Records")
                {
                    beg_date = obj["txtDateExpiration_Beg"].ToString();
                    end_date = obj["txtDateExpiration_End"].ToString();
                }
                else
                {
                    beg_date = obj["txtDateExpiration_Beg"].ToString();
                    end_date = obj["DateExpiration_End"].ToString();
                }

                string InventoryType_exp_Beg = obj["InventoryType_exp_Beg"].ToString() != "" ? obj["InventoryType_exp_Beg"].ToString() : "0"; 
                string InventoryType_exp_End = obj["InventoryType_exp_End"].ToString() != "" ? obj["InventoryType_exp_End"].ToString() : "0"; 
                string StandardClassification_Beg = obj["StandardClassification_Beg"].ToString() != "" ? obj["StandardClassification_Beg"].ToString() : "0"; 
                string StandardClassification_End = obj["StandardClassification_End"].ToString() != "" ? obj["StandardClassification_End"].ToString() : "0"; 
                string dllsorting7130 = obj["dllsorting7130"].ToString();
                string dllDiscontuned_Item = obj["dllDiscontuned_Item"].ToString();
                ReportParameter[] myparams = new ReportParameter[12];
                myparams[0] = new ReportParameter("beg_fg_id", FinishGoodsItems_Exp_Beg, false);
                myparams[1] = new ReportParameter("end_fg_id", FinishGoodsItems_Exp_End, false);
                myparams[2] = new ReportParameter("beg_cust_id", Customer_Beg, false);
                myparams[3] = new ReportParameter("end_cust_id", Customer_End, false);
                myparams[4] = new ReportParameter("beg_dis_date", beg_date, false);
                myparams[5] = new ReportParameter("end_dis_date", end_date, false);

                myparams[6] = new ReportParameter("beg_inventory_type", InventoryType_exp_Beg, false);
                myparams[7] = new ReportParameter("end_inventory_type", InventoryType_exp_End, false);
                myparams[8] = new ReportParameter("Standard_Classification_Beg", StandardClassification_Beg, false);
                myparams[9] = new ReportParameter("Standard_Classification_End", StandardClassification_End, false);
                myparams[10] = new ReportParameter("sort", dllsorting7130, false);
                myparams[11] = new ReportParameter("discont_items", dllDiscontuned_Item, false);

                reportViewer.ServerReport.SetParameters(myparams);            

                reportViewer.ServerReport.Refresh();
                ViewBag.ReportViewer = reportViewer;

                mymodel.FinishGoodItem = GetFinishGoodItem();
                mymodel.CustomerIDs = GetCustomerIDs();

                mymodel.InventoryType2 = GetInventoryType2();
                mymodel.Invoice = InvoiceIdNum();
                mymodel.StandardClassification = GetStandardClassification();

                //return View(mymodel);
            }

            mymodel.FinishGoodItem = GetFinishGoodItem();
            mymodel.CustomerIDs = GetCustomerIDs();
            mymodel.InventoryType2 = GetInventoryType2();
            mymodel.StandardClassification = GetStandardClassification();
            return View(mymodel);


        }
        public ActionResult FilterOption8880(string filter, FormCollection obj)
        {
            Session["ReportName"] = "ECL Cost (8880)";
          

            if (filter == "Run as a Job and Notify")
            {
                
                TempData["ReportView"] = obj;
                TempData["EmailID"] = Session["EmailID"].ToString();
                TempData["UserID"] = Session["UserID"].ToString();
                List<string> _pagecontent = new List<string>();
                return RedirectToAction("RunReportAsyn8880", "Report");
            }
            ViewBag.Filter = filter;
            ViewBag.DateFirstCost_Beg = string.Empty;
            ViewBag.DateFirstCost_End = string.Empty;
            ViewBag.txtDateFirstCost_Beg = string.Empty;
            ViewBag.txtDateFirstCost_End = string.Empty;
            try
            {
                ViewBag.DateFirstCost_Beg = "*All Records";
                ViewBag.DateFirstCost_End = "0";
                ViewBag.txtDateFirstCost_Beg = "*All Records";
                ViewBag.txtDateFirstCost_End = "0";

                if (filter == "Run Report Now")
                {
                    using (cn = new SqlConnection(connString))
                    {
                        cn.Open();
                        cmd = new SqlCommand("sp_Insert_Update_SynReport", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                        cmd.Parameters.AddWithValue("@Report_ID", 8880);
                        cmd.Parameters.AddWithValue("@Syn_Report_Name", "ECL Cost");
                        cmd.Parameters.AddWithValue("@Syn_Report_Date", DateTime.Now);
                        cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;
                        int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                        int res = cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                    ViewBag.DateFirstCost_Beg = obj["DateFirstCost_Beg"].ToString();
                    ViewBag.DateFirstCost_End = obj["DateFirstCost_End"].ToString();
                    ViewBag.txtDateFirstCost_Beg = obj["txtDateFirstCost_Beg"].ToString();
                    ViewBag.txtDateFirstCost_End = obj["txtDateFirstCost_End"].ToString();

                    string Date = obj["DateFirstCost"].ToString();
                    ViewBag.DateFirstCost = obj["DateFirstCost"].ToString();
                    string UrlReportServer = "http://ts2pw8vv/ReportServer";
                    ReportViewer reportViewer = new ReportViewer();
                    reportViewer.ProcessingMode = ProcessingMode.Remote;
                    reportViewer.AsyncRendering = true;
                    reportViewer.SizeToReportContent = true;
                    reportViewer.Width = Unit.Percentage(0);
                    reportViewer.Height = Unit.Percentage(0);
                    reportViewer.ServerReport.ReportServerUrl = new Uri(UrlReportServer);
                    reportViewer.ServerReport.ReportPath = "/VSPReports/rpt_VSP8880";

                    string beg_date = string.Empty;
                    string end_date = string.Empty;

                    if (Date == "Between Range")
                    {
                        beg_date = obj["DateFirstCost_Beg"].ToString();
                        end_date = obj["DateFirstCost_End"].ToString();
                    }
                    else if (Date == "")
                    {
                        beg_date = obj["txtDateFirstCost_Beg"].ToString();
                        end_date = obj["txtDateFirstCost_End"].ToString();
                    }
                    else if (Date == "*All Records")
                    {
                        beg_date = obj["txtDateFirstCost_Beg"].ToString();
                        end_date = obj["txtDateFirstCost_End"].ToString();

                    }
                    else
                    {
                        beg_date = obj["txtDateFirstCost_Beg"].ToString();
                        end_date = obj["DateFirstCost_End"].ToString();
                    }

                    ReportParameter[] myparams = new ReportParameter[2];

                    myparams[0] = new ReportParameter("beg_date", beg_date, false);
                    myparams[1] = new ReportParameter("end_date", end_date, false);
                    reportViewer.ServerReport.SetParameters(myparams);
                    reportViewer.ServerReport.Refresh();
                    ViewBag.ReportViewer = reportViewer;

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }

        private List<BO_FilterOption> GetStandardClassification()
        {
            List<BO_FilterOption> lstStandard_classification = new List<BO_FilterOption>();
            try
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_standard_classification order by [Standard]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Standard = dr["Standard"].ToString();
                        obj.Description = dr["Description"].ToString();

                        lstStandard_classification.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstStandard_classification;
        }
        private List<BO_FilterOption> InvoiceIdNum()
        {
            List<BO_FilterOption> lstInvoiceIdNum = new List<BO_FilterOption>();
            try
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_invoice_id order by [Invoice ID]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.InvoiceId = dr["Invoice ID"].ToString();
                        obj.InvoiceDate = dr["Invoice Date"].ToString();
                        obj.JobOrderId = dr["Job/Order ID"].ToString();
                        obj.JobOrderDesc = dr["Job/Order Desc"].ToString();
                        obj.BillTo = dr["Bill To #"].ToString();
                        obj.BillToName = dr["Bill To Name"].ToString();
                        obj.CustomerPO = dr["Customer PO"].ToString();
                        lstInvoiceIdNum.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstInvoiceIdNum;
        }
        private List<BO_FilterOption> GetVendorID()
        {
            List<BO_FilterOption> lstVendorId = new List<BO_FilterOption>();
            try
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_vendor_id order by [Vendor ID]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.VendorID = dr["Vendor ID"].ToString();
                        obj.VendorName = dr["Vendor Name"].ToString();
                        obj.City = dr["City"].ToString();
                        obj.State = dr["State"].ToString();

                        lstVendorId.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstVendorId;
        }
        private List<BO_FilterOption> GetVendorName()
        {
            List<BO_FilterOption> lstVendorName = new List<BO_FilterOption>();
            try
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_vendor_name order by [Vendor Name]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.VendorName = dr["Vendor Name"].ToString();
                        obj.VendorID = dr["Vendor ID"].ToString();

                        obj.City = dr["City"].ToString();
                        obj.State = dr["State"].ToString();

                        lstVendorName.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstVendorName;
        }
        private List<BO_FilterOption> GetGenericJobNum()
        {
            List<BO_FilterOption> lstGenericJobNub = new List<BO_FilterOption>();
            try
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_generic_job order by [Generic Job ID]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.GenericJobID = dr["Generic Job ID"].ToString();
                        obj.Description = dr["Description"].ToString();
                        obj.DateOrdered = dr["Date Ordered"].ToString();
                        obj.BillTo = dr["Bill To #"].ToString();
                        obj.CustomerPO = dr["Customer PO"].ToString();
                        lstGenericJobNub.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstGenericJobNub;
        }
        private List<BO_FilterOption> GetEstimate_id()
        {
            List<BO_FilterOption> lstEstimate_id = new List<BO_FilterOption>();
            try
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_estimate_id order by [Estimate ID]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.EstimateId = dr["Estimate ID"].ToString();
                        obj.Title = dr["Title"].ToString();
                        obj.CustomerID = dr["Customer ID"].ToString();
                        obj.MasterPartID = dr["Master Part"].ToString();
                        obj.DateEntered = dr["Date Entered"].ToString();
                        lstEstimate_id.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstEstimate_id;
        }
        private List<BO_FilterOption> GetCutomerLead()
        {
            List<BO_FilterOption> lstCutomerLead = new List<BO_FilterOption>();
            try
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from customer_lead order by [name]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.CustomerID = dr["id"].ToString();
                        obj.CustomerName = dr["name"].ToString();
                        obj.RecordType = dr["record_type"].ToString();
                        lstCutomerLead.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstCutomerLead;
        }
        private List<BO_FilterOption> GetMasterpart()
        {
            List<BO_FilterOption> lstMasterPartID = new List<BO_FilterOption>();
            try
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_master_part_id order by [Master Part ID]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.MasterPartID = dr["Master Part ID"].ToString();
                        obj.Description = dr["Description"].ToString();
                        obj.CustomerName = dr["Customer Name"].ToString();
                        lstMasterPartID.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstMasterPartID;
        }
        private List<BO_FilterOption> GetMasterpartDescription()
        {
            List<BO_FilterOption> lstMasterPartID = new List<BO_FilterOption>();
            try
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_master_part_desc order by [Description]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.MasterPartID = dr["Master Part ID"].ToString();
                        obj.Description = dr["Description"].ToString();
                        obj.CustomerName = dr["Customer Name"].ToString();
                        lstMasterPartID.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstMasterPartID;
        }
        private List<BO_FilterOption> GetAdjustmentLocationCode()
        {
            List<BO_FilterOption> lstAdjustmentLocationCode = new List<BO_FilterOption>();
            try
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_location_code order by [ID]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption adjLocCode = new BO_FilterOption();
                        adjLocCode.AdjustmentLocCode = dr["ID"].ToString();
                        adjLocCode.Description = dr["Description"].ToString();
                        
                        lstAdjustmentLocationCode.Add(adjLocCode);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstAdjustmentLocationCode;

        }
        private List<BO_FilterOption> GetCustomerPo()
        {
            List<BO_FilterOption> lstCustomerPo = new List<BO_FilterOption>();
            try
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from [lkup_customer_po] order by [Customer PO]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objlstCustomerPo = new BO_FilterOption();
                        objlstCustomerPo.CustomerPO = dr["Customer PO"].ToString();
                        objlstCustomerPo.BillToName = dr["Bill To Name"].ToString();
                        objlstCustomerPo.BillToNumb = dr["Bill To Numb"].ToString();
                        objlstCustomerPo.Status = dr["Status"].ToString();
                        objlstCustomerPo.JCOEDescription = dr["JC/OE Description"].ToString();
                        lstCustomerPo.Add(objlstCustomerPo);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //Response.Redirect(String.Format("~/Error/{0}/?message={1}", "HttpError404", ex.Message));
            }
            return lstCustomerPo;
        }
        private List<BO_FilterOption> GetFinishGoodItem()
        {
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            try
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_finish_goods_id ORDER BY [Finished Good] ", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.FinishedGood = dr["Finished Good"].ToString();
                        objFinishGoodItem.CustomerPart = dr["Customer Part"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //Response.Redirect(String.Format("~/Error/{0}/?message={1}", "HttpError404", ex.Message));
            }
            return lstFinishGoodItem;
        }
        private List<BO_FilterOption> GetCustomerIDs()
        {
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            try
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_customer_id ORDER BY [Customer ID]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstFinishGoodItem;
        }
        private List<BO_FilterOption> GetCustomerName2()
        {
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            try
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_customer_name ORDER BY [Name]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.CustomerName = dr["Name"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstFinishGoodItem;

        }
        private List<BO_FilterOption> GetInventoryType2()
        {
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            try
            {

                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_inventory_type order by [Inventory Type]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.InventoryType = dr["Inventory Type"].ToString();
                        objFinishGoodItem.ModelName = dr["Model Name"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstFinishGoodItem;

        }
        private List<BO_FilterOption> GetSalesRep2()
        {
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            try
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_sales_rep_id order by [Sales Rep.]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.SalesRep = dr["Sales Rep."].ToString();
                        objFinishGoodItem.FirstName = dr["First Name"].ToString();
                        objFinishGoodItem.LastName = dr["Last Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstFinishGoodItem;

        }
        private List<BO_FilterOption> GetShippingLocation2()
        {
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            try
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_shipto_id order by [Shipping Location]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.ShippingLocation = dr["Shipping Location"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        objFinishGoodItem.ContactName = dr["Contact Name"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.Address = dr["Address"].ToString();
                        objFinishGoodItem.City = dr["City"].ToString();
                        objFinishGoodItem.State = dr["State"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstFinishGoodItem;

        }
        private List<BO_FilterOption> GetOrderType2()
        {
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            try
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_order_type order by [Code]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Code = dr["Code"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstFinishGoodItem;

        }
        private List<BO_FilterOption> GetProductCode2()
        {
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            try
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_product_code order by [Code]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Code = dr["Code"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstFinishGoodItem;

        }
        private List<BO_FilterOption> GetMaterialID2()
        {
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            try
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_material_id order by [Material ID]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.MaterialID = dr["Material ID"].ToString();
                        objFinishGoodItem.MaterialName = dr["Material Name"].ToString();
                        objFinishGoodItem.VendorID = dr["Vendor ID"].ToString();
                        objFinishGoodItem.VendorItem = dr["Vendor Item"].ToString();
                        objFinishGoodItem.SizeCode = dr["Size Code"].ToString();
                        objFinishGoodItem.TypeCode = dr["Type Code"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstFinishGoodItem;

        }
        private List<BO_FilterOption> GetSizeCode2()
        {
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            try
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_material_size_code order by [Size Code]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.SizeCode = dr["Size Code"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstFinishGoodItem;

        }
        private List<BO_FilterOption> GetBoxSetID2()
        {
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            try
            {

                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select * from lkup_box_label_set", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.BoxSetID = dr["Box Set ID"].ToString();
                        objFinishGoodItem.ShipToName = dr["Ship To Name"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.CustomerPO = dr["Customer PO"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstFinishGoodItem;
        }
        private List<BO_FilterOption> GetMasterJob2()
        {
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            try
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_master_job order by [Master Job ID]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.JobID = dr["Master Job ID"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.DateOrdered = dr["Date Ordered"].ToString();
                        objFinishGoodItem.BillTo = dr["Bill To #"].ToString();
                        objFinishGoodItem.BillToName = dr["Bill To Name"].ToString();
                        objFinishGoodItem.CustomerPO = dr["Customer PO"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstFinishGoodItem;
        }
        private List<BO_FilterOption> GetIndustryCode2()
        {
            List<BO_FilterOption> lstIndustryCode = new List<BO_FilterOption>();
            try
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_industry_code order by [Code]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstIndustryCode.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstIndustryCode;
        }
        private List<BO_FilterOption> GetProductDescription2()
        {
            List<BO_FilterOption> lstProductDescription = new List<BO_FilterOption>();
            try
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_product_desc order by [Code]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstProductDescription.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProductDescription;
        }
        private List<BO_FilterOption> GetFinishGoodID2()
        {
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            try
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_finish_goods_id order by [Finished Good]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.FinishedGood = dr["Finished Good"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.CustomerPart = dr["Customer Part"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //Response.Redirect(String.Format("~/Error/{0}/?message={1}", "HttpError404", ex.Message));
            }
            return lstFinishGoodItem;
        }
        private List<BO_FilterOption> GeFinishGoodDescription2()
        {
            List<BO_FilterOption> lstFinishGoodDescription = new List<BO_FilterOption>();
            try
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_finish_goods_desc order by [Description]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Description = dr["Description"].ToString();
                        obj.FinishedGood = dr["Finished Good"].ToString();
                        obj.CustomerPart = dr["Customer Part"].ToString();
                        obj.CustomerID = dr["Customer ID"].ToString();
                        obj.CustomerName = dr["Customer Name"].ToString();
                        lstFinishGoodDescription.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstFinishGoodDescription;
        }
        private List<BO_FilterOption> GeKindCode2()
        {
            List<BO_FilterOption> lstKindCode = new List<BO_FilterOption>();
            try
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_kind_code order by [Kind Code]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.KindCode = dr["Kind Code"].ToString();
                        obj.CustomerName = dr["Customer Name"].ToString();
                        lstKindCode.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstKindCode;
        }
        private List<BO_FilterOption> GeWareHouse2()
        {
            List<BO_FilterOption> lstWarehouse = new List<BO_FilterOption>();
            try
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_fg_warehouse order by [Warehouse]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Warehouse = dr["Warehouse"].ToString();
                        obj.WarehouseName = dr["Name"].ToString();
                        lstWarehouse.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstWarehouse;
        }
        private List<BO_FilterOption> GeLocation2()
        {
            List<BO_FilterOption> lstLocation = new List<BO_FilterOption>();
            try
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_fg_location order by [Location]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Location = dr["Location"].ToString();
                        obj.Shelf = dr["Shelf"].ToString();
                        obj.Section = dr["Section"].ToString();
                        obj.Bin = dr["Bin"].ToString();
                        lstLocation.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstLocation;
        }
        private List<BO_FilterOption> GeCostCenterMajor2()
        {
            List<BO_FilterOption> lstCostCenterMajor = new List<BO_FilterOption>();
            try
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_cc_major order by [Cost Center ID]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.CostCenterID = dr["Cost Center ID"].ToString();
                        obj.CostCenterName = dr["Cost Center Name"].ToString();
                        obj.Class = dr["Class"].ToString();
                        obj.Department = dr["Department"].ToString();
                        lstCostCenterMajor.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstCostCenterMajor;
        }
        private List<BO_FilterOption> GetSubType_1()
        {
            List<BO_FilterOption> lstsubtype1 = new List<BO_FilterOption>();
            try
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select * from lkup_sub_type_1", cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstsubtype1.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstsubtype1;
        }
        private List<BO_FilterOption> GetSubType_2()
        {
            List<BO_FilterOption> lstsubtype2 = new List<BO_FilterOption>();
            try
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10  * from lkup_sub_type_2 order by[Code]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstsubtype2.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstsubtype2;
        }
        private List<BO_FilterOption> GetSubType_3()
        {
            List<BO_FilterOption> lstsubtype3 = new List<BO_FilterOption>();
            try
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_sub_type_3 order by [Code]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstsubtype3.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstsubtype3;
        }
        private List<BO_FilterOption> GetJobCode2()
        {
            List<BO_FilterOption> lstJobcode = new List<BO_FilterOption>();
            try
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_job_code_2 order by[Code]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString(); 
                        obj.ProductionType = dr["Production Type"].ToString();
                        obj.Days = dr["Days"].ToString();
                        lstJobcode.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstJobcode;
        }

        public JsonResult ModelFinishGood(string finishGood, string finishGood1, string txtData)
        {
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_finish_goods_id ORDER BY [Finished Good] ", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.FinishedGood = dr["Finished Good"].ToString();
                        objFinishGoodItem.CustomerPart = dr["Customer Part"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (finishGood == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_finish_goods_id where [" + finishGood1 + "] like '" + txtData + "%' ORDER BY [Finished Good]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.FinishedGood = dr["Finished Good"].ToString();
                        objFinishGoodItem.CustomerPart = dr["Customer Part"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            else if (finishGood == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_finish_goods_id where [" + finishGood1 + "] like '%" + txtData + "' ORDER BY [Finished Good]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.FinishedGood = dr["Finished Good"].ToString();
                        objFinishGoodItem.CustomerPart = dr["Customer Part"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            else if (finishGood == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_finish_goods_id where [" + finishGood1 + "] like '%" + txtData + "%' ORDER BY [Finished Good]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.FinishedGood = dr["Finished Good"].ToString();
                        objFinishGoodItem.CustomerPart = dr["Customer Part"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModelFinishGoodDescription(string finishGood, string finishGood1, string txtData)
        {
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            
            if (finishGood == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_finish_goods_desc where [" + finishGood1 + "] like '" + txtData + "%' ORDER BY [Description]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.FinishedGood = dr["Finished Good"].ToString();
                        objFinishGoodItem.CustomerPart = dr["Customer Part"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            else if (finishGood == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_finish_goods_desc where [" + finishGood1 + "] like '%" + txtData + "' ORDER BY [Description]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.FinishedGood = dr["Finished Good"].ToString();
                        objFinishGoodItem.CustomerPart = dr["Customer Part"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            else if (finishGood == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_finish_goods_desc where [" + finishGood1 + "] like '%" + txtData + "%' ORDER BY [Description]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.FinishedGood = dr["Finished Good"].ToString();
                        objFinishGoodItem.CustomerPart = dr["Customer Part"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModelCustomerId(string customerId1, string customerId2, string txtData)
        {
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (customerId1 == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_customer_id where [" + customerId2 + "] like '" + txtData + "%' order by [Customer ID] ", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }



            else if (customerId1 == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_customer_id where  [" + customerId2 + "] like '%" + txtData + "' order by [Customer ID]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();

                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }



            else if (customerId1 == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_customer_id where  [" + customerId2 + "] like '%" + txtData + "%' order by [Customer ID]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();

                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModelCustName(string customerId1, string customerId2, string txtData)
        { 
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if(customerId1 == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_customer_name where  [" + customerId2 + "] like '" + txtData + "%' order by [Name]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (customerId1 == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_customer_name where  [" + customerId2 + "] like '%" + txtData + "' order by [Name]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.CustomerName = dr["Name"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();

                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (customerId1 == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_customer_name where  [" + customerId2 + "] like '%" + txtData + "%' order by [Name]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.CustomerName = dr["Name"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();

                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                }
            }
            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModelInventoryType(string customerId1, string customerId2, string txtData)
        {
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (customerId1 == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_inventory_type where [" + customerId2 + "] like '" + txtData + "%' order by [Inventory Type]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.InventoryType = dr["Inventory Type"].ToString();
                        objFinishGoodItem.ModelName = dr["Model Name"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


           else if (customerId1 == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_inventory_type where  [" + customerId2 + "] like '%" + txtData + "' order by [Inventory Type]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.InventoryType = dr["Inventory Type"].ToString();
                        objFinishGoodItem.ModelName = dr["Model Name"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            else if (customerId1 == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_inventory_type where  [" + customerId2 + "] like '%" + txtData + "%' order by [Inventory Type]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.InventoryType = dr["Inventory Type"].ToString();
                        objFinishGoodItem.ModelName = dr["Model Name"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);

        }
        public JsonResult ModelSearchSalesRep(string customerId1, string customerId2, string txtData)
        {
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (customerId1 == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_sales_rep_id where [" + customerId2 + "] like '" + txtData + "%' order by [Sales Rep.]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.SalesRep = dr["Sales Rep."].ToString();
                        objFinishGoodItem.FirstName = dr["First Name"].ToString();
                        objFinishGoodItem.LastName = dr["Last Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }



            if (customerId1 == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_sales_rep_id where [" + customerId2 + "] like '%" + txtData + "' order by [Sales Rep.]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.SalesRep = dr["Sales Rep."].ToString();
                        objFinishGoodItem.FirstName = dr["First Name"].ToString();
                        objFinishGoodItem.LastName = dr["Last Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            else if (customerId1 == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_sales_rep_id where [" + customerId2 + "] like '%" + txtData + "%' order by [Sales Rep.]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.SalesRep = dr["Sales Rep."].ToString();
                        objFinishGoodItem.FirstName = dr["First Name"].ToString();
                        objFinishGoodItem.LastName = dr["Last Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);

        }
        public JsonResult ModelshippingLocation(string customerId1, string customerId2, string txtData)
        {
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (customerId1 == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10  * from lkup_shipto_id where [" + customerId2 + "] like '" + txtData + "%' ORDER BY [Shipping Location]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.ShippingLocation = dr["Shipping Location"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        objFinishGoodItem.ContactName = dr["Contact Name"].ToString();
                        objFinishGoodItem.Address = dr["Address"].ToString();
                        objFinishGoodItem.City = dr["City"].ToString();
                        objFinishGoodItem.State = dr["State"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (customerId1 == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_shipto_id where [" + customerId2 + "] like '%" + txtData + "' ORDER BY [Shipping Location]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.ShippingLocation = dr["Shipping Location"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        objFinishGoodItem.ContactName = dr["Contact Name"].ToString();
                        objFinishGoodItem.Address = dr["Address"].ToString();
                        objFinishGoodItem.City = dr["City"].ToString();
                        objFinishGoodItem.State = dr["State"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (customerId1 == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_shipto_id where [" + customerId2 + "] like '%" + txtData + "%' ORDER BY [Shipping Location]", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.ShippingLocation = dr["Shipping Location"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        objFinishGoodItem.ContactName = dr["Contact Name"].ToString();
                        objFinishGoodItem.Address = dr["Address"].ToString();
                        objFinishGoodItem.City = dr["City"].ToString();
                        objFinishGoodItem.State = dr["State"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModeloderType(string customerId1, string customerId2, string txtData)
        {
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (customerId1 == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select  * from lkup_order_type where [" + customerId2 + "] like '" + txtData + "%'", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Code = dr["Code"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (customerId1 == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select  * from lkup_order_type where [" + customerId2 + "] like '%" + txtData + "'", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Code = dr["Code"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (customerId1 == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select  * from lkup_order_type where [" + customerId2 + "] like '%" + txtData + "%'", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Code = dr["Code"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModelProductCode(string customerId1, string customerId2, string txtData)
        {
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (customerId1 == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_product_code where [" + customerId2 + "] like '" + txtData + "%'  order by [Code] ", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Code = dr["Code"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (customerId1 == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_product_code where [" + customerId2 + "] like '%" + txtData + "' order by [Code]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Code = dr["Code"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (customerId1 == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_product_code where [" + customerId2 + "] like '%" + txtData + "%' order by [Code]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Code = dr["Code"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
          
            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModelMaterialID(string MaterialId, string MaterialID1, string txtData)
        {
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();           
            if (MaterialId == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_material_id where [" + MaterialID1 + "] like '" + txtData + "%' order by [Material ID]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.MaterialID = dr["Material ID"].ToString();
                        objFinishGoodItem.MaterialName = dr["Material Name"].ToString();
                        objFinishGoodItem.VendorID = dr["Vendor ID"].ToString();
                        objFinishGoodItem.VendorItem = dr["Vendor Item"].ToString();
                        objFinishGoodItem.SizeCode = dr["Size Code"].ToString();
                        objFinishGoodItem.TypeCode = dr["Type Code"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (MaterialId == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_material_id where [" + MaterialID1 + "] like '%" + txtData + "' order by [Material ID]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.MaterialID = dr["Material ID"].ToString();
                        objFinishGoodItem.MaterialName = dr["Material Name"].ToString();
                        objFinishGoodItem.VendorID = dr["Vendor ID"].ToString();
                        objFinishGoodItem.VendorItem = dr["Vendor Item"].ToString();
                        objFinishGoodItem.SizeCode = dr["Size Code"].ToString();
                        objFinishGoodItem.TypeCode = dr["Type Code"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (MaterialId == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_material_id where [" + MaterialID1 + "] like '%" + txtData + "%' order by [Material ID]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.MaterialID = dr["Material ID"].ToString();
                        objFinishGoodItem.MaterialName = dr["Material Name"].ToString();
                        objFinishGoodItem.VendorID = dr["Vendor ID"].ToString();
                        objFinishGoodItem.VendorItem = dr["Vendor Item"].ToString();
                        objFinishGoodItem.SizeCode = dr["Size Code"].ToString();
                        objFinishGoodItem.TypeCode = dr["Type Code"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModelSizeCode(string MaterialId, string MaterialID1, string txtData)
        {
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (MaterialId == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_material_size_code where [" + MaterialID1 + "] like '" + txtData + "%' order by [Size Code]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.SizeCode = dr["Size Code"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (MaterialId == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_material_size_code where [" + MaterialID1 + "] like '%" + txtData + "' order by [Size Code]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.SizeCode = dr["Size Code"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (MaterialId == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_material_size_code where [" + MaterialID1 + "] like '%" + txtData + "%' order by [Size Code]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.SizeCode = dr["Size Code"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);


        }
        public JsonResult ModelSizModelFinishGoodItemeCode(string MaterialId, string MaterialID1, string txtData)
        {
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_finish_goods_id ORDER BY [Finished Good] ", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.FinishedGood = dr["Finished Good"].ToString();
                        objFinishGoodItem.CustomerPart = dr["Customer Part"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                }
            }
            else if (MaterialId == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_finish_goods_id where [" + MaterialID1 + "] like '" + txtData + "%' ORDER BY [Finished Good]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.FinishedGood = dr["Finished Good"].ToString();
                        objFinishGoodItem.CustomerPart = dr["Customer Part"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                }
            }


            else if (MaterialId == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_finish_goods_id where [" + MaterialID1 + "] like '%" + txtData + "' ORDER BY [Finished Good]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.FinishedGood = dr["Finished Good"].ToString();
                        objFinishGoodItem.CustomerPart = dr["Customer Part"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                }
            }


            else if (MaterialId == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_finish_goods_id where [" + MaterialID1 + "] like '%" + txtData + "%' ORDER BY [Finished Good]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.FinishedGood = dr["Finished Good"].ToString();
                        objFinishGoodItem.CustomerPart = dr["Customer Part"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                }
            }

            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModelBoxSetID(string BoxSetId, string BoxSetId1, string txtData)
        {
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (BoxSetId == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_box_label_set where [" + BoxSetId1 + "] like '" + txtData + "%'", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.BoxSetID = dr["Box Set ID"].ToString();
                        objFinishGoodItem.ShipToName = dr["Ship To Name"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.CustomerPO = dr["Customer PO"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            else if (BoxSetId == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select  * from lkup_box_label_set where [" + BoxSetId1 + "] like '%" + txtData + "'", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.BoxSetID = dr["Box Set ID"].ToString();
                        objFinishGoodItem.ShipToName = dr["Ship To Name"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.CustomerPO = dr["Customer PO"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            else if (BoxSetId == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_box_label_set where [" + BoxSetId1 + "] like '%" + txtData + "%'", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.BoxSetID = dr["Box Set ID"].ToString();
                        objFinishGoodItem.ShipToName = dr["Ship To Name"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.CustomerPO = dr["Customer PO"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModellIndustryCode2SBPP(string IndustryCode, string IndustryCode2, string txtData)
        {
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (IndustryCode == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_industry_code where [" + IndustryCode2 + "] like '" + txtData + "%' order by [Code]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            else if (IndustryCode == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_industry_code where [" + IndustryCode2 + "] like '%" + txtData + "' order by [Code]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            else if (IndustryCode == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_industry_code where [" + IndustryCode2 + "] like '%" + txtData + "%' order by [Code]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModelProductCode1SBPP(string ProductCode1SBPP, string ProductCode1SBPP1, string txtData)
        {
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (ProductCode1SBPP == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_product_code where [" + ProductCode1SBPP1 + "] like '" + txtData + "%' order by [Code]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            else if (ProductCode1SBPP == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_product_code where [" + ProductCode1SBPP1 + "] like '%" + txtData + "' order by [Code]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            else if (ProductCode1SBPP == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_product_code where [" + ProductCode1SBPP1 + "] like '%" + txtData + "%' order by [Code]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModelProductDescription(string ProductDescription, string ProductDescription1, string txtData)
        {
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (ProductDescription == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_product_desc where [" + ProductDescription1 + "] like '" + txtData + "%' order by [Code]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            else if (ProductDescription == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_product_desc where [" + ProductDescription1 + "] like '%" + txtData + "' order by [Code]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            else if (ProductDescription == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_product_desc where [" + ProductDescription1 + "] like '%" + txtData + "%' order by [Code]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModelKindcode(string Kindcode, string Kindcode1, string txtData)
        {
            List<BO_FilterOption> lstKindCode = new List<BO_FilterOption>();
            if (Kindcode == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_kind_code where [" + Kindcode1 + "] like '" + txtData + "%' ORDER BY [Kind Code]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.KindCode = dr["Kind Code"].ToString();
                        obj.CustomerName = dr["Customer Name"].ToString();
                        lstKindCode.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }
            }


            else if (Kindcode == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_kind_code where [" + Kindcode1 + "] like '%" + txtData + "' ORDER BY [Kind Code]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.KindCode = dr["Kind Code"].ToString();
                        obj.CustomerName = dr["Customer Name"].ToString();
                        lstKindCode.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }
            }


            else if (Kindcode == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_kind_code where [" + Kindcode1 + "] like '%" + txtData + "%' ORDER BY [Kind Code]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.KindCode = dr["Kind Code"].ToString();
                        obj.CustomerName = dr["Customer Name"].ToString();
                        lstKindCode.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }
            }

            return Json(lstKindCode, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModelWarehouse(string Warehouse, string Warehouse1, string txtData)
        {
            List<BO_FilterOption> lstWarehouse = new List<BO_FilterOption>();
            if (Warehouse == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_fg_warehouse where [" + Warehouse1 + "] like '" + txtData + "%' order by [Warehouse]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Warehouse = dr["Warehouse"].ToString();
                        obj.WarehouseName = dr["Name"].ToString();
                        lstWarehouse.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }
            }


            else if (Warehouse == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_fg_warehouse where [" + Warehouse1 + "] like '%" + txtData + "' order by [Warehouse]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Warehouse = dr["Warehouse"].ToString();
                        obj.WarehouseName = dr["Name"].ToString();
                        lstWarehouse.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }
            }


            else if (Warehouse == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_fg_warehouse where [" + Warehouse1 + "] like '%" + txtData + "%' order by [Warehouse]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Warehouse = dr["Warehouse"].ToString();
                        obj.WarehouseName = dr["Name"].ToString();
                        lstWarehouse.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }
            }

            return Json(lstWarehouse, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModelLocation(string Location, string Location1, string txtData)
        {
            List<BO_FilterOption> lstLocation = new List<BO_FilterOption>();
            if (Location == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_fg_location where [" + Location1 + "] like '" + txtData + "%' order by [Location]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Location = dr["Location"].ToString();
                        obj.Shelf = dr["Shelf"].ToString();
                        obj.Section = dr["Section"].ToString();
                        obj.Bin = dr["Bin"].ToString();
                        lstLocation.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }
            }


            else if (Location == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_fg_location where [" + Location1 + "] like '%" + txtData + "' order by [Location]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Location = dr["Location"].ToString();
                        obj.Shelf = dr["Shelf"].ToString();
                        obj.Section = dr["Section"].ToString();
                        obj.Bin = dr["Bin"].ToString();
                        lstLocation.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }
            }


            else if (Location == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_fg_location where [" + Location1 + "] like '%" + txtData + "%' order by [Location]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Location = dr["Location"].ToString();
                        obj.Shelf = dr["Shelf"].ToString();
                        obj.Section = dr["Section"].ToString();
                        obj.Bin = dr["Bin"].ToString();
                        lstLocation.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }
            }

            return Json(lstLocation, JsonRequestBehavior.AllowGet);
        }
        //report 7890
        public JsonResult ModelCostCenterMajor(string CostCenterMajor, string CostCenterMajor1, string txtData)
        {
            List<BO_FilterOption> lstCostCenterMajor = new List<BO_FilterOption>();
            if (CostCenterMajor == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_cc_major where [" + CostCenterMajor1 + "] like '" + txtData + "%' order by [Cost Center ID]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.CostCenterID = dr["Cost Center ID"].ToString();
                        obj.CostCenterName = dr["Cost Center Name"].ToString();
                        obj.Class = dr["Class"].ToString();
                        obj.Department = dr["Department"].ToString();
                        lstCostCenterMajor.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }
            }


            else if (CostCenterMajor == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_cc_major where [" + CostCenterMajor1 + "] like '%" + txtData + "' order by [Cost Center ID]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.CostCenterID = dr["Cost Center ID"].ToString();
                        obj.CostCenterName = dr["Cost Center Name"].ToString();
                        obj.Class = dr["Class"].ToString();
                        obj.Department = dr["Department"].ToString();
                        lstCostCenterMajor.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }
            }


            else if (CostCenterMajor == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_cc_major where [" + CostCenterMajor1 + "] like '%" + txtData + "%' order by [Cost Center ID]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.CostCenterID = dr["Cost Center ID"].ToString();
                        obj.CostCenterName = dr["Cost Center Name"].ToString();
                        obj.Class = dr["Class"].ToString();
                        obj.Department = dr["Department"].ToString();
                        lstCostCenterMajor.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }
            }

            return Json(lstCostCenterMajor, JsonRequestBehavior.AllowGet);
        }
        //report 8400
        public JsonResult ModelSubType1(string SubType1FGDV1PU, string SubType1FGDV2PU, string txtData)
        {
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (SubType1FGDV1PU == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_sub_type_1 where [" + SubType1FGDV2PU + "] like '" + txtData + "%'", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            if (SubType1FGDV1PU == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_sub_type_1 where  [" + SubType1FGDV2PU + "] like '%" + txtData + "'", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            else if (SubType1FGDV1PU == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_sub_type_1 where  [" + SubType1FGDV2PU + "] like '%" + txtData + "%'", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);

        }
        public JsonResult ModelSubType2(string SubType1FGDV1PU, string SubType1FGDV2PU, string txtData)
        {
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (SubType1FGDV1PU == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_sub_type_2 where [" + SubType1FGDV2PU + "] like '" + txtData + "%' order by [Code]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            if (SubType1FGDV1PU == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_sub_type_2 where  [" + SubType1FGDV2PU + "] like '%" + txtData + "' order by [Code]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            else if (SubType1FGDV1PU == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_sub_type_2 where  [" + SubType1FGDV2PU + "] like '%" + txtData + "%' order by [Code]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);

        }
        public JsonResult ModelSubType3(string SubType1FGDV1PU, string SubType1FGDV2PU, string txtData)
        {
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (SubType1FGDV1PU == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_sub_type_3 where [" + SubType1FGDV2PU + "] like '" + txtData + "%' order by [Code]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            if (SubType1FGDV1PU == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_sub_type_3 where  [" + SubType1FGDV2PU + "] like '%" + txtData + "' order by [Code]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            else if (SubType1FGDV1PU == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_sub_type_3 where  [" + SubType1FGDV2PU + "] like '%" + txtData + "%' order by [Code]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);

        }
        //Report 7178 Customer PO
        public JsonResult ModelCustomerPO(string CustomerPO, string CustomerPO2, string txtData)
        {
            List<BO_FilterOption> lstCustomerPo = new List<BO_FilterOption>();

            if (CustomerPO == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10  * from [lkup_customer_po] where [" + CustomerPO2 + "] like '" + txtData + "%' order by [Customer PO]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objlstCustomerPo = new BO_FilterOption();
                        objlstCustomerPo.CustomerPO = dr["Customer PO"].ToString();
                        objlstCustomerPo.BillToName = dr["Bill To Name"].ToString();
                        objlstCustomerPo.BillToNumb = dr["Bill To Numb"].ToString();
                        objlstCustomerPo.Status = dr["Status"].ToString();
                        objlstCustomerPo.JCOEDescription = dr["JC/OE Description"].ToString();
                        lstCustomerPo.Add(objlstCustomerPo);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            else if (CustomerPO == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from [lkup_customer_po] where  [" + CustomerPO2 + "] like '%" + txtData + "' order by [Customer PO]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objlstCustomerPo = new BO_FilterOption();
                        objlstCustomerPo.CustomerPO = dr["Customer PO"].ToString();
                        objlstCustomerPo.BillToName = dr["Bill To Name"].ToString();
                        objlstCustomerPo.BillToNumb = dr["Bill To Numb"].ToString();
                        objlstCustomerPo.Status = dr["Status"].ToString();
                        objlstCustomerPo.JCOEDescription = dr["JC/OE Description"].ToString();
                        lstCustomerPo.Add(objlstCustomerPo);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            else if (CustomerPO == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from [lkup_customer_po] where  [" + CustomerPO2 + "] like '%" + txtData + "%' order by [Customer PO]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objlstCustomerPo = new BO_FilterOption();
                        objlstCustomerPo.CustomerPO = dr["Customer PO"].ToString();
                        objlstCustomerPo.BillToName = dr["Bill To Name"].ToString();
                        objlstCustomerPo.BillToNumb = dr["Bill To Numb"].ToString();
                        objlstCustomerPo.Status = dr["Status"].ToString();
                        objlstCustomerPo.JCOEDescription = dr["JC/OE Description"].ToString();
                        lstCustomerPo.Add(objlstCustomerPo);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            return Json(lstCustomerPo, JsonRequestBehavior.AllowGet);

        }
        // Report 7820 
        public JsonResult ModelMaterial7820(string MaterialID, string MaterialID1, string txtData)
        {
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (MaterialID == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_master_job where [" + MaterialID1 + "] like '" + txtData + "%' order by [Master Job ID]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.JobID = dr["Master Job ID"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.DateOrdered = dr["Date Ordered"].ToString();
                        objFinishGoodItem.BillTo = dr["Bill To #"].ToString();
                        objFinishGoodItem.BillToName = dr["Bill To Name"].ToString();
                        objFinishGoodItem.CustomerPO = dr["Customer PO"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


           else if (MaterialID == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_master_job where  [" + MaterialID1 + "] like '%" + txtData + "' order by [Master Job ID]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.JobID = dr["Master Job ID"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.DateOrdered = dr["Date Ordered"].ToString();
                        objFinishGoodItem.BillTo = dr["Bill To #"].ToString();
                        objFinishGoodItem.BillToName = dr["Bill To Name"].ToString();
                        objFinishGoodItem.CustomerPO = dr["Customer PO"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            else if (MaterialID == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_master_job where  [" + MaterialID1 + "] like '%" + txtData + "%' order by [Master Job ID]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.JobID = dr["Master Job ID"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.DateOrdered = dr["Date Ordered"].ToString();
                        objFinishGoodItem.BillTo = dr["Bill To #"].ToString();
                        objFinishGoodItem.BillToName = dr["Bill To Name"].ToString();
                        objFinishGoodItem.CustomerPO = dr["Customer PO"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);

        }
        //Report 7310 
        public JsonResult ModelAdjustmentLoc(string AdjustmentLoc, string AdjustmentLoc2, string txtData)
        {
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (AdjustmentLoc == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_location_code where [" + AdjustmentLoc2 + "] like '" + txtData + "%' order by [ID]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.AdjustmentLocCode = dr["ID"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                       
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


           else if (AdjustmentLoc == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_location_code where  [" + AdjustmentLoc2 + "] like '%" + txtData + "' order by [ID]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.AdjustmentLocCode = dr["ID"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            else if (AdjustmentLoc == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_location_code where  [" + AdjustmentLoc2 + "] like '%" + txtData + "%' order by [ID]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.AdjustmentLocCode = dr["ID"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);

        }
        public JsonResult ModelMasterPart(string MasterPart1PSPU, string MasterPart2PSPU, string txtData)
        {
            List<BO_FilterOption> lstMasterPartID = new List<BO_FilterOption>();           
           if (MasterPart1PSPU == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_master_part_id where [" + MasterPart2PSPU + "] like '" + txtData + "%' order by [Master Part ID]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.MasterPartID = dr["Master Part ID"].ToString();
                        obj.Description = dr["Description"].ToString();
                        obj.CustomerName = dr["Customer Name"].ToString();
                        lstMasterPartID.Add(obj);

                       
                    }
                    dr.Close();
                    cn.Close();
                }
            }            
            else if (MasterPart1PSPU == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_master_part_id where  [" + MasterPart2PSPU + "] like '%" + txtData + "' order by [Master Part ID]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.MasterPartID = dr["Master Part ID"].ToString();
                        obj.Description = dr["Description"].ToString();
                        obj.CustomerName = dr["Customer Name"].ToString();
                        lstMasterPartID.Add(obj);
                    }
                        dr.Close();
                    cn.Close();
                }
            }

            else if (MasterPart1PSPU == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_master_part_id where  [" + MasterPart2PSPU + "] like '%" + txtData + "%' order by [Master Part ID]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.MasterPartID = dr["Master Part ID"].ToString();
                        obj.Description = dr["Description"].ToString();
                        obj.CustomerName = dr["Customer Name"].ToString();
                        lstMasterPartID.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            return Json(lstMasterPartID, JsonRequestBehavior.AllowGet);

        }
        public JsonResult ModelMasterPartDescription(string MasterPart1PSPU, string MasterPart2PSPU, string txtData)
        {
            List<BO_FilterOption> lstMasterPartID = new List<BO_FilterOption>();
            if (MasterPart1PSPU == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_master_part_desc where [" + MasterPart2PSPU + "] like '" + txtData + "%' order by [Description]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.MasterPartID = dr["Master Part ID"].ToString();
                        obj.Description = dr["Description"].ToString();
                        obj.CustomerName = dr["Customer Name"].ToString();
                        lstMasterPartID.Add(obj);


                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (MasterPart1PSPU == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_master_part_desc where  [" + MasterPart2PSPU + "] like '%" + txtData + "' order by [Description]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.MasterPartID = dr["Master Part ID"].ToString();
                        obj.Description = dr["Description"].ToString();
                        obj.CustomerName = dr["Customer Name"].ToString();
                        lstMasterPartID.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            else if (MasterPart1PSPU == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_master_part_desc where  [" + MasterPart2PSPU + "] like '%" + txtData + "%' order by [Description]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.MasterPartID = dr["Master Part ID"].ToString();
                        obj.Description = dr["Description"].ToString();
                        obj.CustomerName = dr["Customer Name"].ToString();
                        lstMasterPartID.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            return Json(lstMasterPartID, JsonRequestBehavior.AllowGet);

        }
        public JsonResult ModelJobCode2(string JobCode2_1PSPU, string JobCode2_2PSPU, string txtData)
        {
            List<BO_FilterOption> lstJobcode = new List<BO_FilterOption>();
            if (JobCode2_1PSPU == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_job_code_2 where [" + JobCode2_2PSPU + "] like '" + txtData + "%' order by [Code]", cn);
                 

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.ProductionType = dr["Production Type"].ToString();
                        obj.Days = dr["Days"].ToString();
                        lstJobcode.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }



            else if (JobCode2_1PSPU == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select top 10 * from lkup_job_code_2 where  [" + JobCode2_2PSPU + "] like '%" + txtData + "' order by [Code]", cn);
                  
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();

                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.ProductionType = dr["Production Type"].ToString();
                        obj.Days = dr["Days"].ToString();
                        lstJobcode.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }



            else if (JobCode2_1PSPU == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_job_code_2 where  [" + JobCode2_2PSPU + "] like '%" + txtData + "%' order by [Code]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();

                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.ProductionType = dr["Production Type"].ToString();
                        obj.Days = dr["Days"].ToString();
                        lstJobcode.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            return Json(lstJobcode, JsonRequestBehavior.AllowGet);
        }
        //Report 7110        
        public JsonResult ModelCustLead(string CustLead, string CustLead2, string txtData)
        {
            List<BO_FilterOption> lstCutomerLead = new List<BO_FilterOption>();
            if (CustLead == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from customer_lead where [" + CustLead2 + "] like '" + txtData + "%' order by [name]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.CustomerID = dr["id"].ToString();
                        obj.CustomerName = dr["name"].ToString();
                        obj.RecordType = dr["record_type"].ToString();
                        lstCutomerLead.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            if (CustLead == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from customer_lead where  [" + CustLead2 + "] like '%" + txtData + "' order by [name]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.CustomerID = dr["id"].ToString();
                        obj.CustomerName = dr["name"].ToString();
                        obj.RecordType = dr["record_type"].ToString();
                        lstCutomerLead.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            else if (CustLead == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from customer_lead where  [" + CustLead2 + "] like '%" + txtData + "%' order by [name]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.CustomerID = dr["id"].ToString();
                        obj.CustomerName = dr["name"].ToString();
                        obj.RecordType = dr["record_type"].ToString();
                        lstCutomerLead.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            return Json(lstCutomerLead, JsonRequestBehavior.AllowGet);

        }
        public JsonResult ModelEstimate(string Estimate, string Estimate2, string txtData)
        {
            List<BO_FilterOption> lstEstimate_id = new List<BO_FilterOption>();
            if (Estimate == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_estimate_id where [" + Estimate2 + "] like '" + txtData + "%' order by [Estimate ID]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.EstimateId = dr["Estimate ID"].ToString();
                        obj.Title = dr["Title"].ToString();
                        obj.CustomerID = dr["Customer ID"].ToString();
                        obj.MasterPartID = dr["Master Part"].ToString();
                        obj.DateEntered = dr["Date Entered"].ToString();
                        lstEstimate_id.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            if (Estimate == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_estimate_id where  [" + Estimate2 + "] like '%" + txtData + "' order by [Estimate ID]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.EstimateId = dr["Estimate ID"].ToString();
                        obj.Title = dr["Title"].ToString();
                        obj.CustomerID = dr["Customer ID"].ToString();
                        obj.MasterPartID = dr["Master Part"].ToString();
                        obj.DateEntered = dr["Date Entered"].ToString();
                        lstEstimate_id.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            else if (Estimate == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_estimate_id where  [" + Estimate2 + "] like '%" + txtData + "%' order by [Estimate ID]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.EstimateId = dr["Estimate ID"].ToString();
                        obj.Title = dr["Title"].ToString();
                        obj.CustomerID = dr["Customer ID"].ToString();
                        obj.MasterPartID = dr["Master Part"].ToString();
                        obj.DateEntered = dr["Date Entered"].ToString();
                        lstEstimate_id.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            return Json(lstEstimate_id, JsonRequestBehavior.AllowGet);

        }
        //Report 7950 
        public JsonResult ModelGenericJobNum(string GenricJob_Beg, string GenricJob_end, string txtData)
        {
            List<BO_FilterOption> lstGenericJobNub = new List<BO_FilterOption>();
            if (GenricJob_Beg == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_generic_job where [" + GenricJob_end + "] like '" + txtData + "%' order by [Generic Job ID]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.GenericJobID = dr["Generic Job ID"].ToString();
                        obj.Description = dr["Description"].ToString();
                        obj.DateOrdered = dr["Date Ordered"].ToString();
                        obj.BillTo = dr["Bill To #"].ToString();
                        obj.CustomerPO = dr["Customer PO"].ToString();
                        lstGenericJobNub.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


           else if (GenricJob_Beg == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_generic_job where  [" + GenricJob_end + "] like '%" + txtData + "' order by [Generic Job ID]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.GenericJobID = dr["Generic Job ID"].ToString();
                        obj.Description = dr["Description"].ToString();
                        obj.DateOrdered = dr["Date Ordered"].ToString();
                        obj.BillTo = dr["Bill To #"].ToString();
                        obj.CustomerPO = dr["Customer PO"].ToString();
                        lstGenericJobNub.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            else if (GenricJob_Beg == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_generic_job where  [" + GenricJob_end + "] like '%" + txtData + "%' order by [Generic Job ID]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.GenericJobID = dr["Generic Job ID"].ToString();
                        obj.Description = dr["Description"].ToString();
                        obj.DateOrdered = dr["Date Ordered"].ToString();
                        obj.BillTo = dr["Bill To #"].ToString();
                        obj.CustomerPO = dr["Customer PO"].ToString();
                        lstGenericJobNub.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            return Json(lstGenericJobNub, JsonRequestBehavior.AllowGet);

        }
        //Report 7990
        public JsonResult ModelVendor(string Vendor_ID_Beg, string Vendor_ID_End, string txtData)
        {
            List<BO_FilterOption> lstVendorId = new List<BO_FilterOption>();
            if (Vendor_ID_Beg == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_vendor_id where [" + Vendor_ID_End + "] like '" + txtData + "%' order by [Vendor ID]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.VendorID = dr["Vendor ID"].ToString();
                        obj.VendorName = dr["Vendor Name"].ToString();
                        obj.City = dr["City"].ToString();
                        obj.State = dr["State"].ToString();

                        lstVendorId.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


           else if (Vendor_ID_Beg == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_vendor_id where  [" + Vendor_ID_End + "] like '%" + txtData + "' order by [Vendor ID]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.VendorID = dr["Vendor ID"].ToString();
                        obj.VendorName = dr["Vendor Name"].ToString();
                        obj.City = dr["City"].ToString();
                        obj.State = dr["State"].ToString();

                        lstVendorId.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            else if (Vendor_ID_Beg == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_vendor_id where  [" + Vendor_ID_End + "] like '%" + txtData + "%' order by [Vendor ID]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.VendorID = dr["Vendor ID"].ToString();
                        obj.VendorName = dr["Vendor Name"].ToString();
                        obj.City = dr["City"].ToString();
                        obj.State = dr["State"].ToString();

                        lstVendorId.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            return Json(lstVendorId, JsonRequestBehavior.AllowGet);

        }
        // Report 7190 ModelInvoiceIdNum StandardClassification
        public JsonResult ModelInvoiceIdNum(string InvoiceIdNum, string InvoiceIdNum2, string txtData)
        {
            List<BO_FilterOption> lstInvoiceIdNum = new List<BO_FilterOption>();
            if (InvoiceIdNum == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_invoice_id where [" + InvoiceIdNum2 + "] like '" + txtData + "%' order by [Invoice ID]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.InvoiceId = dr["Invoice ID"].ToString();
                        obj.InvoiceDate = dr["Invoice Date"].ToString();
                        obj.JobOrderId = dr["Job/Order ID"].ToString();
                        obj.JobOrderDesc = dr["Job/Order Desc"].ToString();
                        obj.BillTo = dr["Bill To #"].ToString();
                        obj.BillToName = dr["Bill To Name"].ToString();
                        obj.CustomerPO = dr["Customer PO"].ToString();
                        lstInvoiceIdNum.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


           else if (InvoiceIdNum == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_invoice_id where  [" + InvoiceIdNum2 + "] like '%" + txtData + "' order by [Invoice ID]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.InvoiceId = dr["Invoice ID"].ToString();
                        obj.InvoiceDate = dr["Invoice Date"].ToString();
                        obj.JobOrderId = dr["Job/Order ID"].ToString();
                        obj.JobOrderDesc = dr["Job/Order Desc"].ToString();
                        obj.BillTo = dr["Bill To #"].ToString();
                        obj.BillToName = dr["Bill To Name"].ToString();
                        obj.CustomerPO = dr["Customer PO"].ToString();
                        lstInvoiceIdNum.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            else if (InvoiceIdNum == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_invoice_id where  [" + InvoiceIdNum2 + "] like '%" + txtData + "%' order by [Invoice ID]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.InvoiceId = dr["Invoice ID"].ToString();
                        obj.InvoiceDate = dr["Invoice Date"].ToString();
                        obj.JobOrderId = dr["Job/Order ID"].ToString();
                        obj.JobOrderDesc = dr["Job/Order Desc"].ToString();
                        obj.BillTo = dr["Bill To #"].ToString();
                        obj.BillToName = dr["Bill To Name"].ToString();
                        obj.CustomerPO = dr["Customer PO"].ToString();
                        lstInvoiceIdNum.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            return Json(lstInvoiceIdNum, JsonRequestBehavior.AllowGet);

        }
        // Report 7130  
        public JsonResult ModelStandardClassification(string StandarClass, string StandarClass2, string txtData)
        {
            List<BO_FilterOption> lstStandard_classification = new List<BO_FilterOption>();
            if (StandarClass == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_standard_classification where [" + StandarClass2 + "] like '" + txtData + "%' order by [Standard]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Standard = dr["Standard"].ToString();
                        obj.Description = dr["Description"].ToString();

                        lstStandard_classification.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            if (StandarClass == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_standard_classification where  [" + StandarClass2 + "] like '%" + txtData + "' order by [Standard]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Standard = dr["Standard"].ToString();
                        obj.Description = dr["Description"].ToString();

                        lstStandard_classification.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            else if (StandarClass == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select top 10 * from lkup_standard_classification where  [" + StandarClass2 + "] like '%" + txtData + "%' order by [Standard]", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Standard = dr["Standard"].ToString();
                        obj.Description = dr["Description"].ToString();

                        lstStandard_classification.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            return Json(lstStandard_classification, JsonRequestBehavior.AllowGet);

        }


      
        public JsonResult TotalRowCount(string Condition, string ColumnName, string txtData, string ReportID,string TableName)
        {            
            int data = 0;           
          
                if (txtData == "")
                {
                    using (cn = new SqlConnection(connString))
                    {

                        cmd = new SqlCommand("sp_TotalRowCount", cn);

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ReportID", ReportID);
                        cmd.Parameters.AddWithValue("@TableName", TableName);
                        cmd.Parameters.AddWithValue("@Condition", Condition);
                        cmd.Parameters.AddWithValue("@ColumnName", ColumnName);
                        cmd.Parameters.AddWithValue("@TextData", txtData);
                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        DataTable dt = ds.Tables[0];
                        data = dt.Rows.Count;


                    }
                }
                else
                {
                    using (cn = new SqlConnection(connString))
                    {

                        cmd = new SqlCommand("sp_TotalRowCount", cn);

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ReportID", ReportID);
                        cmd.Parameters.AddWithValue("@TableName", TableName);
                        cmd.Parameters.AddWithValue("@Condition", Condition);
                        cmd.Parameters.AddWithValue("@ColumnName", ColumnName);
                        cmd.Parameters.AddWithValue("@TextData", txtData);
                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        DataTable dt = ds.Tables[0];
                        data = dt.Rows.Count;

                    }
                }

          

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult TotalRowCount2(string Condition, string ColumnName, string txtData, string ReportID, string TableName)
        {
            int data = 0;

            if (txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {

                    cmd = new SqlCommand("sp_TotalRowCount2", cn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ReportID", ReportID);
                    cmd.Parameters.AddWithValue("@TableName", TableName);
                    cmd.Parameters.AddWithValue("@Condition", Condition);
                    cmd.Parameters.AddWithValue("@ColumnName", ColumnName);
                    cmd.Parameters.AddWithValue("@TextData", txtData);
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    data = dt.Rows.Count;


                }
            }
            else
            {
                using (cn = new SqlConnection(connString))
                {

                    cmd = new SqlCommand("sp_TotalRowCount2", cn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ReportID", ReportID);
                    cmd.Parameters.AddWithValue("@TableName", TableName);
                    cmd.Parameters.AddWithValue("@Condition", Condition);
                    cmd.Parameters.AddWithValue("@ColumnName", ColumnName);
                    cmd.Parameters.AddWithValue("@TextData", txtData);
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    data = dt.Rows.Count;

                }
            }



            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult TotalRowCount3(string Condition, string ColumnName, string txtData, string ReportID, string TableName)
        {
            int data = 0;

            if (txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {

                    cmd = new SqlCommand("sp_TotalRowCount3", cn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ReportID", ReportID);
                    cmd.Parameters.AddWithValue("@TableName", TableName);
                    cmd.Parameters.AddWithValue("@Condition", Condition);
                    cmd.Parameters.AddWithValue("@ColumnName", ColumnName);
                    cmd.Parameters.AddWithValue("@TextData", txtData);
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    data = dt.Rows.Count;


                }
            }
            else
            {
                using (cn = new SqlConnection(connString))
                {

                    cmd = new SqlCommand("sp_TotalRowCount3", cn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ReportID", ReportID);
                    cmd.Parameters.AddWithValue("@TableName", TableName);
                    cmd.Parameters.AddWithValue("@Condition", Condition);
                    cmd.Parameters.AddWithValue("@ColumnName", ColumnName);
                    cmd.Parameters.AddWithValue("@TextData", txtData);
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    data = dt.Rows.Count;

                }
            }



            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult TotalRowCount4(string Condition, string ColumnName, string txtData, string ReportID, string TableName)
        {
            int data = 0;

            if (txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {

                    cmd = new SqlCommand("sp_TotalRowCount4", cn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ReportID", ReportID);
                    cmd.Parameters.AddWithValue("@TableName", TableName);
                    cmd.Parameters.AddWithValue("@Condition", Condition);
                    cmd.Parameters.AddWithValue("@ColumnName", ColumnName);
                    cmd.Parameters.AddWithValue("@TextData", txtData);
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    data = dt.Rows.Count;


                }
            }
            else
            {
                using (cn = new SqlConnection(connString))
                {

                    cmd = new SqlCommand("sp_TotalRowCount4", cn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ReportID", ReportID);
                    cmd.Parameters.AddWithValue("@TableName", TableName);
                    cmd.Parameters.AddWithValue("@Condition", Condition);
                    cmd.Parameters.AddWithValue("@ColumnName", ColumnName);
                    cmd.Parameters.AddWithValue("@TextData", txtData);
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    data = dt.Rows.Count;

                }
            }



            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult TotalPageCount(string ReportID,string TableName)
        {
            int data = 0;
            
                using (cn = new SqlConnection(connString))
                {                   
                    cmd = new SqlCommand("sp_TotalPageCount", cn);

                    cmd.CommandType = CommandType.StoredProcedure;                  
                    cmd.Parameters.AddWithValue("@ReportID", ReportID);
                    cmd.Parameters.AddWithValue("@TableName", TableName);
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    int Totalrow = dt.Rows.Count;
                    if(Totalrow<10)
                        data = 1;
                    else if((Totalrow %10)==0)
                        data = Totalrow / 10;
                    else
                        data = Totalrow / 10 + 1;

               
            }        
                    


            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult TotalPageCount2(string ReportID, string TableName)
        {
            int data = 0;
            using (cn = new SqlConnection(connString))
            {
                cmd = new SqlCommand("sp_TotalPageCount2", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ReportID", ReportID);
                cmd.Parameters.AddWithValue("@TableName", TableName);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                int Totalrow = dt.Rows.Count;
                if (Totalrow < 10)
                    data = 1;
                else if ((Totalrow % 10) == 0)
                    data = Totalrow / 10;
                else
                    data = Totalrow / 10 + 1;


            }



            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult TotalPageCount3(string ReportID, string TableName)
        {
            int data = 0;
            using (cn = new SqlConnection(connString))
            {
                cmd = new SqlCommand("sp_TotalPageCount3", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ReportID", ReportID);
                cmd.Parameters.AddWithValue("@TableName", TableName);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                int Totalrow = dt.Rows.Count;
                if (Totalrow < 10)
                    data = 1;
                else if ((Totalrow % 10) == 0)
                    data = Totalrow / 10;
                else
                    data = Totalrow / 10 + 1;

            }

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult TotalPageCount4(string ReportID, string TableName)
        {
            int data = 0;
            using (cn = new SqlConnection(connString))
            {
                cmd = new SqlCommand("sp_TotalPageCount4", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ReportID", ReportID);
                cmd.Parameters.AddWithValue("@TableName", TableName);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                int Totalrow = dt.Rows.Count;
                if (Totalrow < 10)
                    data = 1;
                else if ((Totalrow % 10) == 0)
                    data = Totalrow / 10;
                else
                    data = Totalrow / 10 + 1;

            }

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ModelFinishGood2(string finishGood, string finishGood1, string txtData, string rowcount)
        {
            int rowcountno = 0;
            if (Convert.ToInt32(rowcount) < 0)
                rowcountno = 0;
            else
                rowcountno = Convert.ToInt32(rowcount);
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (rowcount != "" && txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand(" SELECT * FROM lkup_finish_goods_id  ORDER BY [Finished Good] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.FinishedGood = dr["Finished Good"].ToString();
                        objFinishGoodItem.CustomerPart = dr["Customer Part"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (finishGood == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_finish_goods_id where [" + finishGood1 + "] like '" + txtData + "%'  ORDER BY [Finished Good] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.FinishedGood = dr["Finished Good"].ToString();
                        objFinishGoodItem.CustomerPart = dr["Customer Part"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            else if (finishGood == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select  * from lkup_finish_goods_id where [" + finishGood1 + "] like '%" + txtData + "' ORDER BY [Finished Good] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.FinishedGood = dr["Finished Good"].ToString();
                        objFinishGoodItem.CustomerPart = dr["Customer Part"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            else if (finishGood == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_finish_goods_id where [" + finishGood1 + "] like '%" + txtData + "%' ORDER BY [Finished Good] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.FinishedGood = dr["Finished Good"].ToString();
                        objFinishGoodItem.CustomerPart = dr["Customer Part"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModelFinishGoodDescription2(string finishGood, string finishGood1, string txtData, string rowcount)
        {
            int rowcountno = 0;
            if (Convert.ToInt32(rowcount) < 0)
                rowcountno = 0;
            else
                rowcountno = Convert.ToInt32(rowcount);
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (rowcount != "" && txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand(" SELECT * FROM lkup_finish_goods_desc  ORDER BY [Description] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.FinishedGood = dr["Finished Good"].ToString();
                        objFinishGoodItem.CustomerPart = dr["Customer Part"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (finishGood == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_finish_goods_desc where [" + finishGood1 + "] like '" + txtData + "%'  ORDER BY [Description] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.FinishedGood = dr["Finished Good"].ToString();
                        objFinishGoodItem.CustomerPart = dr["Customer Part"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            else if (finishGood == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select  * from lkup_finish_goods_desc where [" + finishGood1 + "] like '%" + txtData + "' ORDER BY [Description] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.FinishedGood = dr["Finished Good"].ToString();
                        objFinishGoodItem.CustomerPart = dr["Customer Part"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            else if (finishGood == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_finish_goods_desc where [" + finishGood1 + "] like '%" + txtData + "%' ORDER BY [Description] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.FinishedGood = dr["Finished Good"].ToString();
                        objFinishGoodItem.CustomerPart = dr["Customer Part"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModelCustomerId2(string customerId1, string customerId2, string txtData, string rowcount)
        {
            int rowcountno = 0;
            if (Convert.ToInt32(rowcount) < 0)
                rowcountno = 0;
            else
                rowcountno = Convert.ToInt32(rowcount);
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (rowcount != "" && txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("SELECT * FROM lkup_customer_id  ORDER BY [Customer ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }          
            else if (customerId1 == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_customer_id where [" + customerId2 + "] like '" + txtData + "%' ORDER BY [Customer ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }



            else if (customerId1 == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select  * from lkup_customer_id where  [" + customerId2 + "] like '%" + txtData + "' ORDER BY [Customer ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();

                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }



            else if (customerId1 == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select  * from lkup_customer_id where  [" + customerId2 + "] like '%" + txtData + "%' ORDER BY [Customer ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();

                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModelCustName2(string customerId1, string customerId2, string txtData, string rowcount)
        {
            int rowcountno = 0;
            if (Convert.ToInt32(rowcount) < 0)
                rowcountno = 0;
            else
                rowcountno = Convert.ToInt32(rowcount);
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (rowcount != "" && txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("SELECT * FROM lkup_customer_name  ORDER BY [Name] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if(customerId1 == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_customer_name where  [" + customerId2 + "] like '" + txtData + "%' ORDER BY [Name] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (customerId1 == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select  * from lkup_customer_name where  [" + customerId2 + "] like '%" + txtData + "' ORDER BY [Name] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.CustomerName = dr["Name"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();

                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (customerId1 == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select  * from lkup_customer_name where  [" + customerId2 + "] like '%" + txtData + "%' ORDER BY [Name] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.CustomerName = dr["Name"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();

                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                }
            }
            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModelInventoryType2(string customerId1, string customerId2, string txtData, string rowcount)
        {
            int rowcountno = 0;
            if (Convert.ToInt32(rowcount) < 0)
                rowcountno = 0;
            else
                 rowcountno = Convert.ToInt32(rowcount);
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (rowcount != "" && txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("SELECT * FROM lkup_inventory_type  ORDER BY [Inventory Type] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.InventoryType = dr["Inventory Type"].ToString();
                        objFinishGoodItem.ModelName = dr["Model Name"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
           else if (customerId1 == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_inventory_type where [" + customerId2 + "] like '" + txtData + "%' ORDER BY [Inventory Type] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.InventoryType = dr["Inventory Type"].ToString();
                        objFinishGoodItem.ModelName = dr["Model Name"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


           else if (customerId1 == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_inventory_type where  [" + customerId2 + "] like '%" + txtData + "' ORDER BY [Inventory Type] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.InventoryType = dr["Inventory Type"].ToString();
                        objFinishGoodItem.ModelName = dr["Model Name"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            else if (customerId1 == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_inventory_type where  [" + customerId2 + "] like '%" + txtData + "%' ORDER BY [Inventory Type] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.InventoryType = dr["Inventory Type"].ToString();
                        objFinishGoodItem.ModelName = dr["Model Name"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);

        }
        public JsonResult ModelSearchSalesRep2(string customerId1, string customerId2, string txtData, string rowcount)
        {
            int rowcountno = 0;
            if (Convert.ToInt32(rowcount) < 0)
                rowcountno = 0;
            else
                rowcountno = Convert.ToInt32(rowcount);
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (rowcount != "" && txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("SELECT * FROM lkup_sales_rep_id  ORDER BY [Sales Rep.] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.SalesRep = dr["Sales Rep."].ToString();
                        objFinishGoodItem.FirstName = dr["First Name"].ToString();
                        objFinishGoodItem.LastName = dr["Last Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
           else if (customerId1 == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select * from lkup_sales_rep_id where [" + customerId2 + "] like '" + txtData + "%'  ORDER BY [Sales Rep.] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.SalesRep = dr["Sales Rep."].ToString();
                        objFinishGoodItem.FirstName = dr["First Name"].ToString();
                        objFinishGoodItem.LastName = dr["Last Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }



           else if (customerId1 == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select  * from lkup_sales_rep_id where [" + customerId2 + "] like '%" + txtData + "' ORDER BY [Sales Rep.] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.SalesRep = dr["Sales Rep."].ToString();
                        objFinishGoodItem.FirstName = dr["First Name"].ToString();
                        objFinishGoodItem.LastName = dr["Last Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            else if (customerId1 == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select  * from lkup_sales_rep_id where [" + customerId2 + "] like '%" + txtData + "%'  ORDER BY [Sales Rep.] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.SalesRep = dr["Sales Rep."].ToString();
                        objFinishGoodItem.FirstName = dr["First Name"].ToString();
                        objFinishGoodItem.LastName = dr["Last Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);

        }
        public JsonResult ModelProductCode2(string customerId1, string customerId2, string txtData, string rowcount)
        {
            int rowcountno = 0;
            if (Convert.ToInt32(rowcount) < 0)
                rowcountno = 0;
            else
                rowcountno = Convert.ToInt32(rowcount);
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (rowcount != "" && txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("SELECT * FROM lkup_product_code  ORDER BY [Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Code = dr["Code"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (customerId1 == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select * from lkup_product_code where [" + customerId2 + "] like '" + txtData + "%'  ORDER BY [Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Code = dr["Code"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (customerId1 == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select  * from lkup_product_code where [" + customerId2 + "] like '%" + txtData + "'  ORDER BY [Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Code = dr["Code"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (customerId1 == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select  * from lkup_product_code where [" + customerId2 + "] like '%" + txtData + "%'  ORDER BY [Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Code = dr["Code"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModeloderType2(string customerId1, string customerId2, string txtData, string rowcount)
        {
            int rowcountno = 0;
            if (Convert.ToInt32(rowcount) < 0)
                rowcountno = 0;
            else
                rowcountno = Convert.ToInt32(rowcount);
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (rowcount != "" && txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("SELECT * FROM lkup_order_type  ORDER BY [Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Code = dr["Code"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (customerId1 == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select  * from lkup_order_type where [" + customerId2 + "] like '" + txtData + "%' ORDER BY [Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Code = dr["Code"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (customerId1 == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select  * from lkup_order_type where [" + customerId2 + "] like '%" + txtData + "' ORDER BY [Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Code = dr["Code"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (customerId1 == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select  * from lkup_order_type where [" + customerId2 + "] like '%" + txtData + "%' ORDER BY [Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Code = dr["Code"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModelshippingLocation2(string customerId1, string customerId2, string txtData, string rowcount)
        {
            int rowcountno = 0;
            if (Convert.ToInt32(rowcount) < 0)
                rowcountno = 0;
            else
                rowcountno = Convert.ToInt32(rowcount);
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (rowcount != "" && txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("SELECT * FROM lkup_shipto_id  ORDER BY [Shipping Location] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.ShippingLocation = dr["Shipping Location"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        objFinishGoodItem.ContactName = dr["Contact Name"].ToString();
                        objFinishGoodItem.Address = dr["Address"].ToString();
                        objFinishGoodItem.City = dr["City"].ToString();
                        objFinishGoodItem.State = dr["State"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (customerId1 == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select  * from lkup_shipto_id where [" + customerId2 + "] like '" + txtData + "%' ORDER BY [Shipping Location] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.ShippingLocation = dr["Shipping Location"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        objFinishGoodItem.ContactName = dr["Contact Name"].ToString();
                        objFinishGoodItem.Address = dr["Address"].ToString();
                        objFinishGoodItem.City = dr["City"].ToString();
                        objFinishGoodItem.State = dr["State"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (customerId1 == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select  * from lkup_shipto_id where [" + customerId2 + "] like '%" + txtData + "' ORDER BY [Shipping Location] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.ShippingLocation = dr["Shipping Location"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        objFinishGoodItem.ContactName = dr["Contact Name"].ToString();
                        objFinishGoodItem.Address = dr["Address"].ToString();
                        objFinishGoodItem.City = dr["City"].ToString();
                        objFinishGoodItem.State = dr["State"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (customerId1 == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select  * from lkup_shipto_id where [" + customerId2 + "] like '%" + txtData + "%' ORDER BY [Shipping Location] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.ShippingLocation = dr["Shipping Location"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        objFinishGoodItem.ContactName = dr["Contact Name"].ToString();
                        objFinishGoodItem.Address = dr["Address"].ToString();
                        objFinishGoodItem.City = dr["City"].ToString();
                        objFinishGoodItem.State = dr["State"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModelKindcode2(string Kindcode, string Kindcode1, string txtData, string rowcount)
        {
            int rowcountno = 0;
            if (Convert.ToInt32(rowcount) < 0)
                rowcountno = 0;
            else
                rowcountno = Convert.ToInt32(rowcount);
            List<BO_FilterOption> lstKindCode = new List<BO_FilterOption>();
            if (rowcount != "" && txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("SELECT * FROM lkup_kind_code  ORDER BY [Kind Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.KindCode = dr["Kind Code"].ToString();
                        obj.CustomerName = dr["Customer Name"].ToString();
                        lstKindCode.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
           else if (Kindcode == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_kind_code where [" + Kindcode1 + "] like '" + txtData + "%' ORDER BY [Kind Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.KindCode = dr["Kind Code"].ToString();
                        obj.CustomerName = dr["Customer Name"].ToString();
                        lstKindCode.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }
            }


            else if (Kindcode == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select  * from lkup_kind_code where [" + Kindcode1 + "] like '%" + txtData + "' ORDER BY [Kind Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.KindCode = dr["Kind Code"].ToString();
                        obj.CustomerName = dr["Customer Name"].ToString();
                        lstKindCode.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }
            }


            else if (Kindcode == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_kind_code where [" + Kindcode1 + "] like '%" + txtData + "%' ORDER BY [Kind Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.KindCode = dr["Kind Code"].ToString();
                        obj.CustomerName = dr["Customer Name"].ToString();
                        lstKindCode.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }
            }

            return Json(lstKindCode, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModelEstimate2(string Estimate, string Estimate2, string txtData, string rowcount)
        {
            int rowcountno = 0;
            if (Convert.ToInt32(rowcount) < 0)
                rowcountno = 0;
            else
                rowcountno = Convert.ToInt32(rowcount);
            List<BO_FilterOption> lstEstimate_id = new List<BO_FilterOption>();
            if (rowcount != "" && txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("SELECT * FROM lkup_estimate_id  ORDER BY [Estimate ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.EstimateId = dr["Estimate ID"].ToString();
                        obj.Title = dr["Title"].ToString();
                        obj.CustomerID = dr["Customer ID"].ToString();
                        obj.MasterPartID = dr["Master Part"].ToString();
                        obj.DateEntered = dr["Date Entered"].ToString();
                        lstEstimate_id.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
           else if (Estimate == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_estimate_id where [" + Estimate2 + "] like '" + txtData + "%' ORDER BY [Estimate ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.EstimateId = dr["Estimate ID"].ToString();
                        obj.Title = dr["Title"].ToString();
                        obj.CustomerID = dr["Customer ID"].ToString();
                        obj.MasterPartID = dr["Master Part"].ToString();
                        obj.DateEntered = dr["Date Entered"].ToString();
                        lstEstimate_id.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


           else if (Estimate == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_estimate_id where  [" + Estimate2 + "] like '%" + txtData + "' ORDER BY [Estimate ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.EstimateId = dr["Estimate ID"].ToString();
                        obj.Title = dr["Title"].ToString();
                        obj.CustomerID = dr["Customer ID"].ToString();
                        obj.MasterPartID = dr["Master Part"].ToString();
                        obj.DateEntered = dr["Date Entered"].ToString();
                        lstEstimate_id.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            else if (Estimate == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_estimate_id where  [" + Estimate2 + "] like '%" + txtData + "%' ORDER BY [Estimate ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.EstimateId = dr["Estimate ID"].ToString();
                        obj.Title = dr["Title"].ToString();
                        obj.CustomerID = dr["Customer ID"].ToString();
                        obj.MasterPartID = dr["Master Part"].ToString();
                        obj.DateEntered = dr["Date Entered"].ToString();
                        lstEstimate_id.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            return Json(lstEstimate_id, JsonRequestBehavior.AllowGet);

        }
        public JsonResult ModelMasterPart2(string MasterPart1PSPU, string MasterPart2PSPU, string txtData, string rowcount)
        {
            int rowcountno = 0;
            if (Convert.ToInt32(rowcount) < 0)
                rowcountno = 0;
            else
                rowcountno = Convert.ToInt32(rowcount);
            List<BO_FilterOption> lstMasterPartID = new List<BO_FilterOption>();
            if (rowcount != "" && txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("SELECT * FROM lkup_master_part_id  ORDER BY [Master Part ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.MasterPartID = dr["Master Part ID"].ToString();
                        obj.Description = dr["Description"].ToString();
                        obj.CustomerName = dr["Customer Name"].ToString();
                        lstMasterPartID.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }          
            else if (MasterPart1PSPU == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_master_part_id where [" + MasterPart2PSPU + "] like '" + txtData + "%'  ORDER BY [Master Part ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.MasterPartID = dr["Master Part ID"].ToString();
                        obj.Description = dr["Description"].ToString();
                        obj.CustomerName = dr["Customer Name"].ToString();
                        lstMasterPartID.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (MasterPart1PSPU == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_master_part_id where  [" + MasterPart2PSPU + "] like '%" + txtData + "'  ORDER BY [Master Part ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.MasterPartID = dr["Master Part ID"].ToString();
                        obj.Description = dr["Description"].ToString();
                        obj.CustomerName = dr["Customer Name"].ToString();
                        lstMasterPartID.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            else if (MasterPart1PSPU == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_master_part_id where  [" + MasterPart2PSPU + "] like '%" + txtData + "%'  ORDER BY [Master Part ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.MasterPartID = dr["Master Part ID"].ToString();
                        obj.Description = dr["Description"].ToString();
                        obj.CustomerName = dr["Customer Name"].ToString();
                        lstMasterPartID.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            return Json(lstMasterPartID, JsonRequestBehavior.AllowGet);

        }
        public JsonResult ModelMasterPartDescription2(string MasterPart1PSPU, string MasterPart2PSPU, string txtData, string rowcount)
        {
            int rowcountno = 0;
            if (Convert.ToInt32(rowcount) < 0)
                rowcountno = 0;
            else
                rowcountno = Convert.ToInt32(rowcount);
            List<BO_FilterOption> lstMasterPartID = new List<BO_FilterOption>();
            if (rowcount != "" && txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("SELECT * FROM lkup_master_part_desc  ORDER BY [Description] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.MasterPartID = dr["Master Part ID"].ToString();
                        obj.Description = dr["Description"].ToString();
                        obj.CustomerName = dr["Customer Name"].ToString();
                        lstMasterPartID.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (MasterPart1PSPU == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_master_part_desc where [" + MasterPart2PSPU + "] like '" + txtData + "%'  ORDER BY [Description] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.MasterPartID = dr["Master Part ID"].ToString();
                        obj.Description = dr["Description"].ToString();
                        obj.CustomerName = dr["Customer Name"].ToString();
                        lstMasterPartID.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (MasterPart1PSPU == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_master_part_desc where  [" + MasterPart2PSPU + "] like '%" + txtData + "'  ORDER BY [Description] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.MasterPartID = dr["Master Part ID"].ToString();
                        obj.Description = dr["Description"].ToString();
                        obj.CustomerName = dr["Customer Name"].ToString();
                        lstMasterPartID.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            else if (MasterPart1PSPU == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_master_part_desc where  [" + MasterPart2PSPU + "] like '%" + txtData + "%'  ORDER BY [Description] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.MasterPartID = dr["Master Part ID"].ToString();
                        obj.Description = dr["Description"].ToString();
                        obj.CustomerName = dr["Customer Name"].ToString();
                        lstMasterPartID.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            return Json(lstMasterPartID, JsonRequestBehavior.AllowGet);

        }
        public JsonResult ModelCustLead2(string CustLead, string CustLead2, string txtData, string rowcount)
        {
            int rowcountno = 0;
            if (Convert.ToInt32(rowcount) < 0)
                rowcountno = 0;
            else
                rowcountno = Convert.ToInt32(rowcount);
           List<BO_FilterOption> lstCutomerLead = new List<BO_FilterOption>();
           if (rowcount != "" && txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("SELECT * FROM customer_lead  ORDER BY [name] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.CustomerID = dr["id"].ToString();
                        obj.CustomerName = dr["name"].ToString();
                        obj.RecordType = dr["record_type"].ToString();
                        lstCutomerLead.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
           else if (CustLead == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from customer_lead where [" + CustLead2 + "] like '" + txtData + "%'  ORDER BY [name] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.CustomerID = dr["id"].ToString();
                        obj.CustomerName = dr["name"].ToString();
                        obj.RecordType = dr["record_type"].ToString();
                        lstCutomerLead.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


           else if (CustLead == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from customer_lead where  [" + CustLead2 + "] like '%" + txtData + "'  ORDER BY [name] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.CustomerID = dr["id"].ToString();
                        obj.CustomerName = dr["name"].ToString();
                        obj.RecordType = dr["record_type"].ToString();
                        lstCutomerLead.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            else if (CustLead == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from customer_lead where  [" + CustLead2 + "] like '%" + txtData + "%'  ORDER BY [name] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.CustomerID = dr["id"].ToString();
                        obj.CustomerName = dr["name"].ToString();
                        obj.RecordType = dr["record_type"].ToString();
                        lstCutomerLead.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            return Json(lstCutomerLead, JsonRequestBehavior.AllowGet);

        }
        public JsonResult ModelMaterialID2(string MaterialId, string MaterialID1, string txtData, string rowcount)
        {
            int rowcountno = 0;
            if (Convert.ToInt32(rowcount) < 0)
                rowcountno = 0;
            else
                rowcountno = Convert.ToInt32(rowcount);
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (rowcount != "" && txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("SELECT * FROM lkup_material_id  ORDER BY [Material ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.MaterialID = dr["Material ID"].ToString();
                        objFinishGoodItem.MaterialName = dr["Material Name"].ToString();
                        objFinishGoodItem.VendorID = dr["Vendor ID"].ToString();
                        objFinishGoodItem.VendorItem = dr["Vendor Item"].ToString();
                        objFinishGoodItem.SizeCode = dr["Size Code"].ToString();
                        objFinishGoodItem.TypeCode = dr["Type Code"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (MaterialId == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select  * from lkup_material_id where [" + MaterialID1 + "] like '" + txtData + "%'  ORDER BY [Material ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.MaterialID = dr["Material ID"].ToString();
                        objFinishGoodItem.MaterialName = dr["Material Name"].ToString();
                        objFinishGoodItem.VendorID = dr["Vendor ID"].ToString();
                        objFinishGoodItem.VendorItem = dr["Vendor Item"].ToString();
                        objFinishGoodItem.SizeCode = dr["Size Code"].ToString();
                        objFinishGoodItem.TypeCode = dr["Type Code"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (MaterialId == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select  * from lkup_material_id where [" + MaterialID1 + "] like '%" + txtData + "' ORDER BY [Material ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.MaterialID = dr["Material ID"].ToString();
                        objFinishGoodItem.MaterialName = dr["Material Name"].ToString();
                        objFinishGoodItem.VendorID = dr["Vendor ID"].ToString();
                        objFinishGoodItem.VendorItem = dr["Vendor Item"].ToString();
                        objFinishGoodItem.SizeCode = dr["Size Code"].ToString();
                        objFinishGoodItem.TypeCode = dr["Type Code"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (MaterialId == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select  * from lkup_material_id where [" + MaterialID1 + "] like '%" + txtData + "%' ORDER BY [Material ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.MaterialID = dr["Material ID"].ToString();
                        objFinishGoodItem.MaterialName = dr["Material Name"].ToString();
                        objFinishGoodItem.VendorID = dr["Vendor ID"].ToString();
                        objFinishGoodItem.VendorItem = dr["Vendor Item"].ToString();
                        objFinishGoodItem.SizeCode = dr["Size Code"].ToString();
                        objFinishGoodItem.TypeCode = dr["Type Code"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModelSizModelFinishGoodItemeCode2(string MaterialId, string MaterialID1, string txtData, string rowcount)
        {
            int rowcountno = 0;
            if (Convert.ToInt32(rowcount) < 0)
                rowcountno = 0;
            else
                rowcountno = Convert.ToInt32(rowcount);
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (rowcount != "" && txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("SELECT * FROM lkup_finish_goods_id  ORDER BY [Finished Good] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.FinishedGood = dr["Finished Good"].ToString();
                        objFinishGoodItem.CustomerPart = dr["Customer Part"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (MaterialId == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_finish_goods_id where [" + MaterialID1 + "] like '" + txtData + "%'  ORDER BY [Finished Good] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.FinishedGood = dr["Finished Good"].ToString();
                        objFinishGoodItem.CustomerPart = dr["Customer Part"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                }
            }


            else if (MaterialId == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_finish_goods_id where [" + MaterialID1 + "] like '%" + txtData + "'  ORDER BY [Finished Good] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.FinishedGood = dr["Finished Good"].ToString();
                        objFinishGoodItem.CustomerPart = dr["Customer Part"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                }
            }


            else if (MaterialId == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_finish_goods_id where [" + MaterialID1 + "] like '%" + txtData + "%'  ORDER BY [Finished Good] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.FinishedGood = dr["Finished Good"].ToString();
                        objFinishGoodItem.CustomerPart = dr["Customer Part"].ToString();
                        objFinishGoodItem.CustomerID = dr["Customer ID"].ToString();
                        objFinishGoodItem.CustomerName = dr["Customer Name"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                }
            }

            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModelStandardClassification2(string StandarClass, string StandarClass2, string txtData, string rowcount)
        {
            int rowcountno = 0;
            if (Convert.ToInt32(rowcount) < 0)
                rowcountno = 0;
            else
                rowcountno = Convert.ToInt32(rowcount);
            List<BO_FilterOption> lstStandard_classification = new List<BO_FilterOption>();
            if (rowcount != "" && txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("SELECT * FROM lkup_standard_classification  ORDER BY [Standard] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Standard = dr["Standard"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstStandard_classification.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (StandarClass == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_standard_classification where [" + StandarClass2 + "] like '" + txtData + "%'  ORDER BY [Standard] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Standard = dr["Standard"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstStandard_classification.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


           else if (StandarClass == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_standard_classification where  [" + StandarClass2 + "] like '%" + txtData + "'  ORDER BY [Standard] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Standard = dr["Standard"].ToString();
                        obj.Description = dr["Description"].ToString();

                        lstStandard_classification.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            else if (StandarClass == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_standard_classification where  [" + StandarClass2 + "] like '%" + txtData + "%'  ORDER BY [Standard] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Standard = dr["Standard"].ToString();
                        obj.Description = dr["Description"].ToString();

                        lstStandard_classification.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            return Json(lstStandard_classification, JsonRequestBehavior.AllowGet);

        }
        public JsonResult ModelSubType2_2(string SubType1FGDV1PU, string SubType1FGDV2PU, string txtData, string rowcount)
        {
            int rowcountno = 0;
            if (Convert.ToInt32(rowcount) < 0)
                rowcountno = 0;
            else
                rowcountno = Convert.ToInt32(rowcount);
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (rowcount != "" && txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("SELECT * FROM lkup_sub_type_2  ORDER BY [Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
           else if (SubType1FGDV1PU == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_sub_type_2 where [" + SubType1FGDV2PU + "] like '" + txtData + "%' ORDER BY [Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


           else if (SubType1FGDV1PU == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_sub_type_2 where  [" + SubType1FGDV2PU + "] like '%" + txtData + "' ORDER BY [Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            else if (SubType1FGDV1PU == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_sub_type_2 where  [" + SubType1FGDV2PU + "] like '%" + txtData + "%' ORDER BY [Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);

        }
        public JsonResult ModelSizeCode2(string MaterialId, string MaterialID1, string txtData, string rowcount)
        {
            int rowcountno = 0;
            if (Convert.ToInt32(rowcount) < 0)
                rowcountno = 0;
            else
                rowcountno = Convert.ToInt32(rowcount);
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (rowcount != "" && txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("SELECT * FROM lkup_material_size_code  ORDER BY [Size Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.SizeCode = dr["Size Code"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (MaterialId == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_material_size_code where [" + MaterialID1 + "] like '" + txtData + "%'  ORDER BY [Size Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.SizeCode = dr["Size Code"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (MaterialId == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select  * from lkup_material_size_code where [" + MaterialID1 + "] like '%" + txtData + "'  ORDER BY [Size Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.SizeCode = dr["Size Code"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (MaterialId == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_material_size_code where [" + MaterialID1 + "] like '%" + txtData + "%'  ORDER BY [Size Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.SizeCode = dr["Size Code"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);


        }
        public JsonResult ModelCustomerPO2(string CustomerPO, string CustomerPO2, string txtData, string rowcount)
        {
            int rowcountno = 0;
            if (Convert.ToInt32(rowcount) < 0)
                rowcountno = 0;
            else
                rowcountno = Convert.ToInt32(rowcount);
            List<BO_FilterOption> lstCustomerPo = new List<BO_FilterOption>();
            if (rowcount != "" && txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("SELECT * FROM lkup_customer_po  ORDER BY [Customer PO] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objlstCustomerPo = new BO_FilterOption();
                        objlstCustomerPo.CustomerPO = dr["Customer PO"].ToString();
                        objlstCustomerPo.BillToName = dr["Bill To Name"].ToString();
                        objlstCustomerPo.BillToNumb = dr["Bill To Numb"].ToString();
                        objlstCustomerPo.Status = dr["Status"].ToString();
                        objlstCustomerPo.JCOEDescription = dr["JC/OE Description"].ToString();
                        lstCustomerPo.Add(objlstCustomerPo);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            else if (CustomerPO == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select  * from [lkup_customer_po] where [" + CustomerPO2 + "] like '" + txtData + "%' ORDER BY [Customer PO] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objlstCustomerPo = new BO_FilterOption();
                        objlstCustomerPo.CustomerPO = dr["Customer PO"].ToString();
                        objlstCustomerPo.BillToName = dr["Bill To Name"].ToString();
                        objlstCustomerPo.BillToNumb = dr["Bill To Numb"].ToString();
                        objlstCustomerPo.Status = dr["Status"].ToString();
                        objlstCustomerPo.JCOEDescription = dr["JC/OE Description"].ToString();
                        lstCustomerPo.Add(objlstCustomerPo);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            else if (CustomerPO == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select  * from [lkup_customer_po] where  [" + CustomerPO2 + "] like '%" + txtData + "' ORDER BY [Customer PO] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objlstCustomerPo = new BO_FilterOption();
                        objlstCustomerPo.CustomerPO = dr["Customer PO"].ToString();
                        objlstCustomerPo.BillToName = dr["Bill To Name"].ToString();
                        objlstCustomerPo.BillToNumb = dr["Bill To Numb"].ToString();
                        objlstCustomerPo.Status = dr["Status"].ToString();
                        objlstCustomerPo.JCOEDescription = dr["JC/OE Description"].ToString();
                        lstCustomerPo.Add(objlstCustomerPo);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            else if (CustomerPO == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select  * from [lkup_customer_po] where  [" + CustomerPO2 + "] like '%" + txtData + "%' ORDER BY [Customer PO] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objlstCustomerPo = new BO_FilterOption();
                        objlstCustomerPo.CustomerPO = dr["Customer PO"].ToString();
                        objlstCustomerPo.BillToName = dr["Bill To Name"].ToString();
                        objlstCustomerPo.BillToNumb = dr["Bill To Numb"].ToString();
                        objlstCustomerPo.Status = dr["Status"].ToString();
                        objlstCustomerPo.JCOEDescription = dr["JC/OE Description"].ToString();
                        lstCustomerPo.Add(objlstCustomerPo);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            return Json(lstCustomerPo, JsonRequestBehavior.AllowGet);

        }
        public JsonResult ModelMaterial7820_2(string MaterialID, string MaterialID1, string txtData, string rowcount)
        {
            int rowcountno = 0;
            if (Convert.ToInt32(rowcount) < 0)
                rowcountno = 0;
            else
                rowcountno = Convert.ToInt32(rowcount);
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
           if (rowcount != "" && txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("SELECT * FROM lkup_master_job  ORDER BY [Customer PO] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.JobID = dr["Master Job ID"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.DateOrdered = dr["Date Ordered"].ToString();
                        objFinishGoodItem.BillTo = dr["Bill To #"].ToString();
                        objFinishGoodItem.BillToName = dr["Bill To Name"].ToString();
                        objFinishGoodItem.CustomerPO = dr["Customer PO"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
           else if (MaterialID == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_master_job where [" + MaterialID1 + "] like '" + txtData + "%' ORDER BY [Customer PO] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.JobID = dr["Master Job ID"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.DateOrdered = dr["Date Ordered"].ToString();
                        objFinishGoodItem.BillTo = dr["Bill To #"].ToString();
                        objFinishGoodItem.BillToName = dr["Bill To Name"].ToString();
                        objFinishGoodItem.CustomerPO = dr["Customer PO"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


           else if (MaterialID == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_master_job where  [" + MaterialID1 + "] like '%" + txtData + "' ORDER BY [Customer PO] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.JobID = dr["Master Job ID"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.DateOrdered = dr["Date Ordered"].ToString();
                        objFinishGoodItem.BillTo = dr["Bill To #"].ToString();
                        objFinishGoodItem.BillToName = dr["Bill To Name"].ToString();
                        objFinishGoodItem.CustomerPO = dr["Customer PO"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            else if (MaterialID == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_master_job where  [" + MaterialID1 + "] like '%" + txtData + "%' ORDER BY [Customer PO] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.JobID = dr["Master Job ID"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        objFinishGoodItem.DateOrdered = dr["Date Ordered"].ToString();
                        objFinishGoodItem.BillTo = dr["Bill To #"].ToString();
                        objFinishGoodItem.BillToName = dr["Bill To Name"].ToString();
                        objFinishGoodItem.CustomerPO = dr["Customer PO"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);

        }
        public JsonResult ModelSubType3_2(string SubType1FGDV1PU, string SubType1FGDV2PU, string txtData, string rowcount)
        {
            int rowcountno = 0;
            if (Convert.ToInt32(rowcount) < 0)
                rowcountno = 0;
            else
                rowcountno = Convert.ToInt32(rowcount);
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (rowcount != "" && txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("SELECT * FROM lkup_sub_type_3  ORDER BY [Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (SubType1FGDV1PU == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_sub_type_3 where [" + SubType1FGDV2PU + "] like '" + txtData + "%' ORDER BY [Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            else if (SubType1FGDV1PU == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_sub_type_3 where  [" + SubType1FGDV2PU + "] like '%" + txtData + "' ORDER BY [Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            else if (SubType1FGDV1PU == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_sub_type_3 where  [" + SubType1FGDV2PU + "] like '%" + txtData + "%' ORDER BY [Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);

        }
        public JsonResult ModelInvoiceIdNum2(string InvoiceIdNum, string InvoiceIdNum2, string txtData, string rowcount)
        {
            int rowcountno = 0;
            if (Convert.ToInt32(rowcount) < 0)
                rowcountno = 0;
            else
                rowcountno = Convert.ToInt32(rowcount);
            List<BO_FilterOption> lstInvoiceIdNum = new List<BO_FilterOption>();
            if (rowcount != "" && txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("SELECT * FROM lkup_invoice_id  ORDER BY [Invoice ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.InvoiceId = dr["Invoice ID"].ToString();
                        obj.InvoiceDate = dr["Invoice Date"].ToString();
                        obj.JobOrderId = dr["Job/Order ID"].ToString();
                        obj.JobOrderDesc = dr["Job/Order Desc"].ToString();
                        obj.BillTo = dr["Bill To #"].ToString();
                        obj.BillToName = dr["Bill To Name"].ToString();
                        obj.CustomerPO = dr["Customer PO"].ToString();
                        lstInvoiceIdNum.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (InvoiceIdNum == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select  * from lkup_invoice_id where [" + InvoiceIdNum2 + "] like '" + txtData + "%' ORDER BY [Invoice ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.InvoiceId = dr["Invoice ID"].ToString();
                        obj.InvoiceDate = dr["Invoice Date"].ToString();
                        obj.JobOrderId = dr["Job/Order ID"].ToString();
                        obj.JobOrderDesc = dr["Job/Order Desc"].ToString();
                        obj.BillTo = dr["Bill To #"].ToString();
                        obj.BillToName = dr["Bill To Name"].ToString();
                        obj.CustomerPO = dr["Customer PO"].ToString();
                        lstInvoiceIdNum.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (InvoiceIdNum == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select * from lkup_invoice_id where  [" + InvoiceIdNum2 + "] like '%" + txtData + "' ORDER BY [Invoice ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.InvoiceId = dr["Invoice ID"].ToString();
                        obj.InvoiceDate = dr["Invoice Date"].ToString();
                        obj.JobOrderId = dr["Job/Order ID"].ToString();
                        obj.JobOrderDesc = dr["Job/Order Desc"].ToString();
                        obj.BillTo = dr["Bill To #"].ToString();
                        obj.BillToName = dr["Bill To Name"].ToString();
                        obj.CustomerPO = dr["Customer PO"].ToString();
                        lstInvoiceIdNum.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (InvoiceIdNum == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select * from lkup_invoice_id where  [" + InvoiceIdNum2 + "] like '%" + txtData + "%' ORDER BY [Invoice ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.InvoiceId = dr["Invoice ID"].ToString();
                        obj.InvoiceDate = dr["Invoice Date"].ToString();
                        obj.JobOrderId = dr["Job/Order ID"].ToString();
                        obj.JobOrderDesc = dr["Job/Order Desc"].ToString();
                        obj.BillTo = dr["Bill To #"].ToString();
                        obj.BillToName = dr["Bill To Name"].ToString();
                        obj.CustomerPO = dr["Customer PO"].ToString();
                        lstInvoiceIdNum.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            return Json(lstInvoiceIdNum, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModelAdjustmentLoc2(string AdjustmentLoc, string AdjustmentLoc2, string txtData, string rowcount)
        {
            int rowcountno = 0;
            if (Convert.ToInt32(rowcount) < 0)
                rowcountno = 0;
            else
                rowcountno = Convert.ToInt32(rowcount);
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (rowcount != "" && txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("SELECT * FROM lkup_location_code  ORDER BY [ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.AdjustmentLocCode = dr["ID"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (AdjustmentLoc == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select * from lkup_location_code where [" + AdjustmentLoc2 + "] like '" + txtData + "%' ORDER BY [ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.AdjustmentLocCode = dr["ID"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (AdjustmentLoc == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select * from lkup_location_code where  [" + AdjustmentLoc2 + "] like '%" + txtData + "' ORDER BY [ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.AdjustmentLocCode = dr["ID"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (AdjustmentLoc == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select * from lkup_location_code where  [" + AdjustmentLoc2 + "] like '%" + txtData + "%' ORDER BY [ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        objFinishGoodItem.AdjustmentLocCode = dr["ID"].ToString();
                        objFinishGoodItem.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(objFinishGoodItem);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModelJobCode2_2(string JobCode2_1PSPU, string JobCode2_2PSPU, string txtData, string rowcount)
        {
            int rowcountno = 0;
            if (Convert.ToInt32(rowcount) < 0)
                rowcountno = 0;
            else
                rowcountno = Convert.ToInt32(rowcount);
            List<BO_FilterOption> lstJobcode = new List<BO_FilterOption>();
            if (rowcount != "" && txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("SELECT * FROM lkup_job_code_2  ORDER BY [Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.ProductionType = dr["Production Type"].ToString();
                        obj.Days = dr["Days"].ToString();
                        lstJobcode.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (JobCode2_1PSPU == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select * from lkup_job_code_2 where [" + JobCode2_2PSPU + "] like '" + txtData + "%' ORDER BY [Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.ProductionType = dr["Production Type"].ToString();
                        obj.Days = dr["Days"].ToString();
                        lstJobcode.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (JobCode2_1PSPU == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select  * from lkup_job_code_2 where  [" + JobCode2_2PSPU + "] like '%" + txtData + "' ORDER BY [Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.ProductionType = dr["Production Type"].ToString();
                        obj.Days = dr["Days"].ToString();
                        lstJobcode.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (JobCode2_1PSPU == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select  * from lkup_job_code_2 where  [" + JobCode2_2PSPU + "] like '%" + txtData + "%' ORDER BY [Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption objFinishGoodItem = new BO_FilterOption();
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.ProductionType = dr["Production Type"].ToString();
                        obj.Days = dr["Days"].ToString();
                        lstJobcode.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            return Json(lstJobcode, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModelGenericJobNum2(string GenricJob_Beg, string GenricJob_end, string txtData, string rowcount)
        {
            int rowcountno = 0;
            if (Convert.ToInt32(rowcount) < 0)
                rowcountno = 0;
            else
                rowcountno = Convert.ToInt32(rowcount);
            List<BO_FilterOption> lstGenericJobNub = new List<BO_FilterOption>();
            if (rowcount != "" && txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("SELECT * FROM lkup_generic_job  ORDER BY [Generic Job ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.GenericJobID = dr["Generic Job ID"].ToString();
                        obj.Description = dr["Description"].ToString();
                        obj.DateOrdered = dr["Date Ordered"].ToString();
                        obj.BillTo = dr["Bill To #"].ToString();
                        obj.CustomerPO = dr["Customer PO"].ToString();
                        lstGenericJobNub.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
           else if (GenricJob_Beg == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_generic_job where [" + GenricJob_end + "] like '" + txtData + "%' ORDER BY [Generic Job ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.GenericJobID = dr["Generic Job ID"].ToString();
                        obj.Description = dr["Description"].ToString();
                        obj.DateOrdered = dr["Date Ordered"].ToString();
                        obj.BillTo = dr["Bill To #"].ToString();
                        obj.CustomerPO = dr["Customer PO"].ToString();
                        lstGenericJobNub.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


           else if (GenricJob_Beg == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_generic_job where  [" + GenricJob_end + "] like '%" + txtData + "' ORDER BY [Generic Job ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.GenericJobID = dr["Generic Job ID"].ToString();
                        obj.Description = dr["Description"].ToString();
                        obj.DateOrdered = dr["Date Ordered"].ToString();
                        obj.BillTo = dr["Bill To #"].ToString();
                        obj.CustomerPO = dr["Customer PO"].ToString();
                        lstGenericJobNub.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            else if (GenricJob_Beg == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_generic_job where  [" + GenricJob_end + "] like '%" + txtData + "%' ORDER BY [Generic Job ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.GenericJobID = dr["Generic Job ID"].ToString();
                        obj.Description = dr["Description"].ToString();
                        obj.DateOrdered = dr["Date Ordered"].ToString();
                        obj.BillTo = dr["Bill To #"].ToString();
                        obj.CustomerPO = dr["Customer PO"].ToString();
                        lstGenericJobNub.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            return Json(lstGenericJobNub, JsonRequestBehavior.AllowGet);

        }
        public JsonResult ModellIndustryCode2SBPP2(string IndustryCode, string IndustryCode2, string txtData, string rowcount)
        {
            int rowcountno = 0;
            if (Convert.ToInt32(rowcount) < 0)
                rowcountno = 0;
            else
                rowcountno = Convert.ToInt32(rowcount);
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (rowcount != "" && txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("SELECT * FROM lkup_industry_code  ORDER BY [Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (IndustryCode == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select  * from lkup_industry_code where [" + IndustryCode2 + "] like '" + txtData + "%' ORDER BY [Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            else if (IndustryCode == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_industry_code where [" + IndustryCode2 + "] like '%" + txtData + "' ORDER BY [Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            else if (IndustryCode == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select  * from lkup_industry_code where [" + IndustryCode2 + "] like '%" + txtData + "%' ORDER BY [Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModelProductCode1SBPP2(string ProductCode1SBPP, string ProductCode1SBPP1, string txtData, string rowcount)
        {
            int rowcountno = 0;
            if (Convert.ToInt32(rowcount) < 0)
                rowcountno = 0;
            else
                rowcountno = Convert.ToInt32(rowcount);
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (rowcount != "" && txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("SELECT * FROM lkup_product_code  ORDER BY [Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (ProductCode1SBPP == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_product_code where [" + ProductCode1SBPP1 + "] like '" + txtData + "%' ORDER BY [Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            else if (ProductCode1SBPP == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select  * from lkup_product_code where [" + ProductCode1SBPP1 + "] like '%" + txtData + "' ORDER BY [Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            else if (ProductCode1SBPP == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select  * from lkup_product_code where [" + ProductCode1SBPP1 + "] like '%" + txtData + "%' ORDER BY [Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModelProductDescription2(string ProductDescription, string ProductDescription1, string txtData, string rowcount)
        {
            int rowcountno = 0;
            if (Convert.ToInt32(rowcount) < 0)
                rowcountno = 0;
            else
                rowcountno = Convert.ToInt32(rowcount);
            List<BO_FilterOption> lstFinishGoodItem = new List<BO_FilterOption>();
            if (rowcount != "" && txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("SELECT * FROM lkup_product_desc  ORDER BY [Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (ProductDescription == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_product_desc where [" + ProductDescription1 + "] like '" + txtData + "%' ORDER BY [Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            else if (ProductDescription == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_product_desc where [" + ProductDescription1 + "] like '%" + txtData + "' ORDER BY [Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }


            else if (ProductDescription == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_product_desc where [" + ProductDescription1 + "] like '%" + txtData + "%' ORDER BY [Code] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Code = dr["Code"].ToString();
                        obj.Description = dr["Description"].ToString();
                        lstFinishGoodItem.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }

            return Json(lstFinishGoodItem, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModelCostCenterMajor2(string CostCenterMajor, string CostCenterMajor1, string txtData, string rowcount)
        {
            int rowcountno = 0;
            if (Convert.ToInt32(rowcount) < 0)
                rowcountno = 0;
            else
                rowcountno = Convert.ToInt32(rowcount);
            List<BO_FilterOption> lstCostCenterMajor = new List<BO_FilterOption>();
            if (rowcount != "" && txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("SELECT * FROM lkup_cc_major  ORDER BY [Cost Center ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.CostCenterID = dr["Cost Center ID"].ToString();
                        obj.CostCenterName = dr["Cost Center Name"].ToString();
                        obj.Class = dr["Class"].ToString();
                        obj.Department = dr["Department"].ToString();
                        lstCostCenterMajor.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
           else if (CostCenterMajor == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_cc_major where [" + CostCenterMajor1 + "] like '" + txtData + "%' ORDER BY [Cost Center ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.CostCenterID = dr["Cost Center ID"].ToString();
                        obj.CostCenterName = dr["Cost Center Name"].ToString();
                        obj.Class = dr["Class"].ToString();
                        obj.Department = dr["Department"].ToString();
                        lstCostCenterMajor.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }
            }


            else if (CostCenterMajor == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_cc_major where [" + CostCenterMajor1 + "] like '%" + txtData + "' ORDER BY [Cost Center ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.CostCenterID = dr["Cost Center ID"].ToString();
                        obj.CostCenterName = dr["Cost Center Name"].ToString();
                        obj.Class = dr["Class"].ToString();
                        obj.Department = dr["Department"].ToString();
                        lstCostCenterMajor.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }
            }


            else if (CostCenterMajor == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_cc_major where [" + CostCenterMajor1 + "] like '%" + txtData + "%' ORDER BY [Cost Center ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY", cn);

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.CostCenterID = dr["Cost Center ID"].ToString();
                        obj.CostCenterName = dr["Cost Center Name"].ToString();
                        obj.Class = dr["Class"].ToString();
                        obj.Department = dr["Department"].ToString();
                        lstCostCenterMajor.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }
            }

            return Json(lstCostCenterMajor, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModelVendor2(string Vendor_ID_Beg, string Vendor_ID_End, string txtData, string rowcount)
        {
            int rowcountno = 0;
            if (Convert.ToInt32(rowcount) < 0)
                rowcountno = 0;
            else
                rowcountno = Convert.ToInt32(rowcount);
            List<BO_FilterOption> lstVendorId = new List<BO_FilterOption>();
            if (rowcount != "" && txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("SELECT * FROM lkup_vendor_id  ORDER BY [Vendor ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.VendorID = dr["Vendor ID"].ToString();
                        obj.VendorName = dr["Vendor Name"].ToString();
                        obj.City = dr["City"].ToString();
                        obj.State = dr["State"].ToString();
                        lstVendorId.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (Vendor_ID_Beg == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select * from lkup_vendor_id where [" + Vendor_ID_End + "] like '" + txtData + "%' ORDER BY [Vendor ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.VendorID = dr["Vendor ID"].ToString();
                        obj.VendorName = dr["Vendor Name"].ToString();
                        obj.City = dr["City"].ToString();
                        obj.State = dr["State"].ToString();
                        lstVendorId.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (Vendor_ID_Beg == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select * from lkup_vendor_id where  [" + Vendor_ID_End + "] like '%" + txtData + "' ORDER BY [Vendor ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.VendorID = dr["Vendor ID"].ToString();
                        obj.VendorName = dr["Vendor Name"].ToString();
                        obj.City = dr["City"].ToString();
                        obj.State = dr["State"].ToString();
                        lstVendorId.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (Vendor_ID_Beg == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("select * from lkup_vendor_id where  [" + Vendor_ID_End + "] like '%" + txtData + "%' ORDER BY [Vendor ID] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.VendorID = dr["Vendor ID"].ToString();
                        obj.VendorName = dr["Vendor Name"].ToString();
                        obj.City = dr["City"].ToString();
                        obj.State = dr["State"].ToString();
                        lstVendorId.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            return Json(lstVendorId, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModelWarehouse2(string Warehouse, string Warehouse1, string txtData, string rowcount)
        {
            int rowcountno = 0;
            if (Convert.ToInt32(rowcount) < 0)
                rowcountno = 0;
            else
                rowcountno = Convert.ToInt32(rowcount);
            List<BO_FilterOption> lstWarehouse = new List<BO_FilterOption>();
            if (rowcount != "" && txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("SELECT * FROM lkup_fg_warehouse  ORDER BY [Warehouse] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Warehouse = dr["Warehouse"].ToString();
                        obj.WarehouseName = dr["Name"].ToString();
                        lstWarehouse.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (Warehouse == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_fg_warehouse where [" + Warehouse1 + "] like '" + txtData + "%' ORDER BY [Warehouse] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Warehouse = dr["Warehouse"].ToString();
                        obj.WarehouseName = dr["Name"].ToString();
                        lstWarehouse.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }
            }


            else if (Warehouse == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select  * from lkup_fg_warehouse where [" + Warehouse1 + "] like '%" + txtData + "' ORDER BY [Warehouse] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Warehouse = dr["Warehouse"].ToString();
                        obj.WarehouseName = dr["Name"].ToString();
                        lstWarehouse.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }
            }


            else if (Warehouse == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_fg_warehouse where [" + Warehouse1 + "] like '%" + txtData + "%' ORDER BY [Warehouse] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Warehouse = dr["Warehouse"].ToString();
                        obj.WarehouseName = dr["Name"].ToString();
                        lstWarehouse.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }
            }

            return Json(lstWarehouse, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModelLocation2(string Location, string Location1, string txtData, string rowcount)
        {
            int rowcountno = 0;
            if (Convert.ToInt32(rowcount) < 0)
                rowcountno = 0;
            else
                rowcountno = Convert.ToInt32(rowcount);
            List<BO_FilterOption> lstLocation = new List<BO_FilterOption>();
            if (rowcount != "" && txtData == "")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("SELECT * FROM lkup_fg_location  ORDER BY [Location] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Location = dr["Location"].ToString();
                        obj.Shelf = dr["Shelf"].ToString();
                        obj.Section = dr["Section"].ToString();
                        obj.Bin = dr["Bin"].ToString();
                        lstLocation.Add(obj);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            else if (Location == "Start With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_fg_location where [" + Location1 + "] like '" + txtData + "%' ORDER BY [Location] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Location = dr["Location"].ToString();
                        obj.Shelf = dr["Shelf"].ToString();
                        obj.Section = dr["Section"].ToString();
                        obj.Bin = dr["Bin"].ToString();
                        lstLocation.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }
            }


            else if (Location == "End With")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select * from lkup_fg_location where [" + Location1 + "] like '%" + txtData + "' ORDER BY [Location] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Location = dr["Location"].ToString();
                        obj.Shelf = dr["Shelf"].ToString();
                        obj.Section = dr["Section"].ToString();
                        obj.Bin = dr["Bin"].ToString();
                        lstLocation.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }
            }


            else if (Location == "Contains This")
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();

                    cmd = new SqlCommand("select  * from lkup_fg_location where [" + Location1 + "] like '%" + txtData + "%' ORDER BY [Location] OFFSET " + rowcountno + " ROWS FETCH NEXT 10 ROWS ONLY ", cn);

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO_FilterOption obj = new BO_FilterOption();
                        obj.Location = dr["Location"].ToString();
                        obj.Shelf = dr["Shelf"].ToString();
                        obj.Section = dr["Section"].ToString();
                        obj.Bin = dr["Bin"].ToString();
                        lstLocation.Add(obj);
                    }
                    dr.Close();
                    cn.Close();

                }
            }

            return Json(lstLocation, JsonRequestBehavior.AllowGet);
        }
    }
}