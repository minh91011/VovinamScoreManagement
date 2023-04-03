using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Mvc;
using VovinamScoreManagerWeb.Models;
using VovinamScoreManagerWeb.Services;

namespace VovinamScoreManagerWeb.Controllers
{
    public class AccountController : Controller
    {
        AccountServices accountServives = new AccountServices();
        ClassAndScoreServices classAndScoreServices = new ClassAndScoreServices();
        StudentServices studentServices = new StudentServices();




        [HttpPost]
        public ActionResult LoginAccess()
        {
            String Username = "";
            Username = HttpContext.Request.Form["username"];
            String Pass = "";
            Pass = HttpContext.Request.Form["pass"];
            Account account = new Account();

            account = accountServives.Login(Username, Pass);
            if (account != null)
            {
                HttpContext.Session.SetString("accID", account.Id.ToString());
                HttpContext.Session.SetString("accName", account.FullName.ToString());
                HttpContext.Session.SetString("chucvu", account.AccRule.ToString());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Home", new { mess = 1 });
            }
        }

        public IActionResult Login()
        {
            String mess = HttpContext.Request.Query["mess"].ToString();
            if (mess.Equals("1"))
            {
                ViewBag.mess = "Thông tin tài khoản không tồn tại , kiểm tra lại thông tin đăng nhập";
            }
            else if (mess.Equals("2"))
            {
                ViewBag.mess = "Vui lòng đăng nhập trước khi thêm giỏ hàng";
            }
            else
            {
                ViewBag.mess = "";
            }

            return View();
        }


    }
}
