using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using VSPApplication.Models;

namespace VSPApplication.Controllers
{
    public class AccountController : Controller
    {
        public SqlConnection cn;
        public SqlCommand cmd;
        public String connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        // GET: Account
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User_Master propUserMaster)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    using (cn = new SqlConnection(connString))
                    {
                        cn.Open();
                        cmd = new SqlCommand("Sp_CreateUser", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FirstName", propUserMaster.FirstName.ToString());
                        cmd.Parameters.AddWithValue("@LastName", propUserMaster.LastName.ToString());
                        cmd.Parameters.AddWithValue("@EmailID", propUserMaster.Email.ToString());
                        cmd.Parameters.AddWithValue("@Password", propUserMaster.Password.ToString());
                        cmd.Parameters.AddWithValue("@IsActivated", "No");
                        cmd.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.Output;
                        int result = Convert.ToInt32(cmd.Parameters["@ReturnValue"].Value);
                        int res = cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                    Mails mail = new Mails();

                    ModelState.Clear();
                    string ActivationUrl = Url.Action("Login", "Account", new { username = propUserMaster.FirstName, email = propUserMaster.Email }, "http");
                    mail.SendActivationLinkUsingEmail(propUserMaster, ActivationUrl);

                    ViewBag.Message = "You are successfully registered with us, activation link has sent to your mailid! Please activate your account";
                    //return View("Thanks", propUserMaster);
                    return View();
                //}
                //else
                //{
                //    return View();
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpGet]
        public ActionResult Login(string UserName, string email)
        {
            if ((Session["EmailID"] == null || Session["firstName"] == null || Session["UserID"] == null)&& email==null)
            {
                return View("Login");
            }
            if (email != null)
            {
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_ActivatedAccount", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmailID", email);
                    cmd.Parameters.Add("@ResultValues", SqlDbType.Int).Direction = ParameterDirection.Output;                  
                    int res = cmd.ExecuteNonQuery();
                    int result = Convert.ToInt32(cmd.Parameters["@ResultValues"].Value);
                    cn.Close();
                    return View();
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login propLogin)
        {
            try
            {
                bool chkActivated = false;
                bool chk = false;
                if (ModelState.IsValid)
                {
                    string emailId = propLogin.Email.ToString();
                    Session["EmailID"] = emailId;
                    SqlConnection conn = new SqlConnection(connString);
                    conn.Open();
                    SqlCommand cmdFirstName = new SqlCommand("select * from UserMaster where EmailID='" + emailId + "'", conn);
                    SqlDataReader rdr = cmdFirstName.ExecuteReader();
                    int chkExist = 0;
                    while (rdr.Read())
                    {
                        chkExist += 1;
                        Session["firstName"] = rdr["FirstName"].ToString();
                        ViewBag.FirstName = Session["firstName"].ToString();
                    }

                    if (chkExist != 0)
                    {
                        using (cn = new SqlConnection(connString))
                        {
                            //cn.Open();
                            cmd = new SqlCommand("sp_VerifyUserMaster", cn);

                            cmd.CommandType = CommandType.StoredProcedure;

                            DataSet ds = new DataSet();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(ds);
                            DataTable dt = ds.Tables[0];
                            int UserID = 0;
                            for (int i = 0; i <= dt.Rows.Count - 1; i++)
                            {
                                if (dt.Rows[i]["EmailID"].ToString() == propLogin.Email.ToString())
                                {
                                    chkActivated = true;
                                    break;
                                }
                                else
                                {
                                    chkActivated = false;
                                }
                            }
                            if (chkActivated == true)
                            {
                                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                                {
                                    if (dt.Rows[i]["EmailID"].ToString() == propLogin.Email.ToString() && dt.Rows[i]["Password"].ToString() == propLogin.Password.ToString())
                                    {
                                        chk = true;
                                        UserID = Convert.ToInt32(dt.Rows[i]["UserID"]);
                                        Session["UserID"] = UserID;
                                        break;

                                    }
                                    else
                                    {
                                        chk = false;
                                    }
                                }
                                if (chk == true)
                                {
                                    Session["ReportName"] = "Dashboard";
                                    //return RedirectToAction("FilterOption", "Report");
                                    return RedirectToAction("Dashboard", "Account", new { UserID = UserID });
                                }
                                else
                                {
                                    ViewBag.ShowMessage = "Please Check Email ID & Password..";
                                    return View();
                                }
                            }
                            else
                            {
                                ViewBag.ShowMessage = "Your EmailID is Not Activated, Please Activate";
                                return View();
                            }

                        }
                    }
                    else
                    {
                        ViewBag.ShowMessage = "Your EmailID is not Found in My Database Acount";
                        return View();
                    }
                }
                return View();
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }
        public ActionResult CheckExistingEmail(string email)
        {
            using (cn = new SqlConnection(connString))
            {
                bool chk = false;
                cmd = new SqlCommand("sp_VerifyUserMaster", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    if (dt.Rows[i]["EmailID"].ToString() == email)
                    {
                        chk = true;
                        break;
                    }
                    else
                    {
                        chk = false;
                    }
                }
                if (chk == true)
                {
                    return Json(string.Format("{0} already exists", email), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }

        }
        public ActionResult CheckExistingEmailForChagePassword(string PasswordChangEmialId)
        {
            try
            {
                TempData["EmailID"] = PasswordChangEmialId;
                int result = 0;
                using (cn = new SqlConnection(connString))
                {
                    cn.Open();
                    cmd = new SqlCommand("sp_VerifyUserMasterForChagePassword", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmailID", PasswordChangEmialId);
                    cmd.Parameters.Add("@ResultValue", SqlDbType.Int).Direction = ParameterDirection.Output;
                    int res = cmd.ExecuteNonQuery();
                    result = Convert.ToInt32(cmd.Parameters["@ResultValue"].Value);
                    cn.Close();
                    if (result != 1)
                    {
                        return Json(string.Format("{0} not exists", PasswordChangEmialId), JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
        public ActionResult Logout()
        {
           
            Session.Abandon();
            Session.Clear();
            
            return RedirectToAction("Login", "Account");
        }
        public ActionResult Dashboard(int UserID)
        {
            try
            {
                Session["ReportName"] = "Dashboard";
                Session["UserID"] = UserID;
                using (cn = new SqlConnection(connString))
                {
                    //cn.Open();
                    cmd = new SqlCommand("sp_Get_ReportHistory", cn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("UserID", UserID);
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    ViewData.Model = dt.AsEnumerable();
                    return View();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(Login propLogin)
        {
            try
            {
                if (propLogin.Email.ToString()!="")
                {
                    int result = 0;
                    using (cn = new SqlConnection(connString))
                    {
                        cn.Open();
                        cmd = new SqlCommand("sp_ForgotPassword", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmailID", propLogin.Email.ToString());                     
                        cmd.Parameters.Add("@ResultValue", SqlDbType.Int).Direction = ParameterDirection.Output;                     
                        int res = cmd.ExecuteNonQuery();
                        result = Convert.ToInt32(cmd.Parameters["@ResultValue"].Value);                        
                        cn.Close();
                    }
                    if (result != 0)
                    {
                        Mails mail = new Mails();

                        ModelState.Clear();
                        string ActivationUrl = Url.Action("ChangePassword", "Account", new { email = propLogin.Email }, "http");
                        mail.SendForgotPasswordUsingEmail(propLogin, ActivationUrl);

                        ViewBag.ShowMessage = "Password chage link has sent to your mailid! Please click to chage password your account";
                        return View();
                    }
                    else
                    {
                        ViewBag.ShowMessage = "Your EmailID is not Found in My Database Acount";
                        return View();
                    }
                  
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(User_Master prop)
        {
            try
            {
                if (prop.PasswordChangEmialId.ToString() != "")
                {
                    int result = 0;
                    int resultValues = CheckExistingPassword(prop.Password.ToString(),prop.PasswordChangEmialId.ToString());
                    if (resultValues != 1)
                    {
                        using (cn = new SqlConnection(connString))
                        {
                            cn.Open();
                            cmd = new SqlCommand("sp_ChagePassword", cn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@EmailID", prop.PasswordChangEmialId.ToString());
                            cmd.Parameters.AddWithValue("@Password", prop.Password.ToString());
                            cmd.Parameters.Add("@ResultValue", SqlDbType.Int).Direction = ParameterDirection.Output;
                            int res = cmd.ExecuteNonQuery();
                            result = Convert.ToInt32(cmd.Parameters["@ResultValue"].Value);
                            cn.Close();

                        }
                        if (result != 0)
                        {
                            ViewBag.Message = "Password chaged successfully";
                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "The entered password is the existing one in our database, please choose a new password.";
                        return View();
                    }
                }
            }         
        

            catch (Exception ex)
            {
                throw ex;
            }
            
            return View();
        }
        public int CheckExistingPassword(string password,string emailID)
        {
            using (cn = new SqlConnection(connString))
            {
                cn.Open();
                cmd = new SqlCommand("sp_CheckExistingPassword", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmailID", emailID);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.Add("@ResultValue", SqlDbType.Int).Direction = ParameterDirection.Output;
                int res = cmd.ExecuteNonQuery();
                int result = Convert.ToInt32(cmd.Parameters["@ResultValue"].Value);
                cn.Close();
                return result;
            }

        }
       
    }
}