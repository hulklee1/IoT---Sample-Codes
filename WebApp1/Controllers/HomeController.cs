using jsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public static string GetEncrypt(string str)
        {
            MD5 md = new MD5CryptoServiceProvider();
            byte[] bArr = md.ComputeHash(Encoding.Default.GetBytes(str));
            string sRet = "";
            for (int i = 0; i < bArr.Length; i++)
            {
                sRet += $"{bArr[i]:x2}";
            }
            return sRet;
        }

        public ActionResult Login()
        {
            if(Session["uid"] != null)
            {
                    return RedirectToAction("Index");
            }
            ViewBag.Message = "Your login page.";
            string uid = Request.QueryString["UID"];
            string pwd = Request.QueryString["PWD"];
            if(uid != null)
            {
                SQLDB db = new SQLDB(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KOSTA\source\repos\MyDatabase.mdf;Integrated Security=True;Connect Timeout=30");
                if(db.Get($"select password from users where uid='{uid}'").ToString().Trim() == GetEncrypt(pwd))
                {
                    Session["uid"] = uid;
                    Session["account"] = db.Get($"select account from users where uid='{uid}'");
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}