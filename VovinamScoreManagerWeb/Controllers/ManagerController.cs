using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VovinamScoreManagerWeb.Models;
using VovinamScoreManagerWeb.Services;

namespace VovinamScoreManagerWeb.Controllers
{
    public class ManagerController : Controller
    {

        AccountServices accountServices = new AccountServices();
        ClassAndScoreServices classAndScoreServices = new ClassAndScoreServices();
        StudentServices studentServices = new StudentServices();

        public IActionResult ManagerRank()
        {
            String mess = HttpContext.Request.Query["mess"].ToString();
            if (mess.Equals("-1"))
            {
                ViewBag.mess = "Thao tác thành công";
            }
            else if (mess.Equals("0"))
            {
                ViewBag.mess = "Thao tác thất bại";
            }
            else
            {
                ViewBag.mess = "";
            }
            ViewBag.userName = HttpContext.Session.GetString("accName");
            ViewBag.chucvu = HttpContext.Session.GetString("chucvu");
            ViewBag.accID = HttpContext.Session.GetString("accID");
            ViewBag.ListRank = classAndScoreServices.GetLstRank();
            return View();
        }
        public IActionResult ManagerStudent()
        {
            String mess = HttpContext.Request.Query["mess"].ToString();
            if (mess.Equals("-1"))
            {
                ViewBag.mess = "Thao tác thành công";
            }
            else if (mess.Equals("0"))
            {
                ViewBag.mess = "Thao tác thất bại";
            }
            else
            {
                ViewBag.mess = "";
            }
            ViewBag.userName = HttpContext.Session.GetString("accName");
            ViewBag.chucvu = HttpContext.Session.GetString("chucvu");
            ViewBag.accID = HttpContext.Session.GetString("accID");
            Student s = new Student();
            s.ClassId = 0;
            s.FullName = "";
            ViewBag.ListStudent = studentServices.GetLstStudents(s);
            return View();
        }
        public IActionResult ManagerClass()
        {
            String mess = HttpContext.Request.Query["mess"].ToString();
            if (mess.Equals("-1"))
            {
                ViewBag.mess = "Thao tác thành công";
            }
            else if (mess.Equals("0"))
            {
                ViewBag.mess = "Thao tác thất bại";
            }
            else
            {
                ViewBag.mess = "";
            }
            ViewBag.userName = HttpContext.Session.GetString("accName");
            ViewBag.chucvu = HttpContext.Session.GetString("chucvu");
            ViewBag.accID = HttpContext.Session.GetString("accID");

            Class c = new Class();
            c.Name = "";
            c.AccountId = 0;
            ViewBag.ListClass = classAndScoreServices.GetLstClasss(c);

            ViewBag.ListAccount = accountServices.GetLstAccount(0);

            return View();
        }
        public IActionResult SettingClass()
        {
            String mess = HttpContext.Request.Query["mess"].ToString();
            if (mess.Equals("-1"))
            {
                ViewBag.mess = "Thao tác thành công";
            }
            else if (mess.Equals("0"))
            {
                ViewBag.mess = "Thao tác thất bại";
            }
            else
            {
                ViewBag.mess = "";
            }
            ViewBag.userName = HttpContext.Session.GetString("accName");
            ViewBag.chucvu = HttpContext.Session.GetString("chucvu");
            ViewBag.accID = HttpContext.Session.GetString("accID");

            Student c = new Student();
            c.FullName = "";
            c.ClassId = 0;
            List<Student> lst = studentServices.GetLstStudents(c);
            ViewBag.lstStudent = lst;


            Models.Class c1 = new Models.Class();
            c1.Name = "";
            ViewBag.lstClass = classAndScoreServices.GetLstClasss(c1);


            try
            {
                int classId = 0;
                classId = int.Parse(HttpContext.Request.Form["classId"]);
                lst = lst.Where(x => x.ClassId == classId).ToList();
                ViewBag.lstStudent2 = lst;

                ViewBag.selectClass = classId;
                
                HttpContext.Session.SetString("classId", classId.ToString());
            }
            catch
            {
                ViewBag.lstStudent2 = new List<Student>();
            }






            return View();
        }


        [HttpPost]
        public ActionResult Setstudent()
        {
            try
            {
                int classId = int.Parse(HttpContext.Session.GetString("classId"));


                int studentId = int.Parse(HttpContext.Request.Form["studentId"]);
                if (studentServices.SetUpStudentClass(classId, studentId))
                {
                    return RedirectToAction("SettingClass", "Manager", new { mess = -1 });
                }
                else
                {
                    return RedirectToAction("SettingClass", "Manager", new { mess = 0 });
                }
            }
            catch
            {

            }

            return RedirectToAction("ManagerClass", "Manager", new { mess = 0 });
        }

        public IActionResult ManagerScore()
        {
            String mess = HttpContext.Request.Query["mess"].ToString();
            if (mess.Equals("-1"))
            {
                ViewBag.mess = "Thao tác thành công";
            }
            else if (mess.Equals("0"))
            {
                ViewBag.mess = "Thao tác thất bại";
            }
            else
            {
                ViewBag.mess = "";
            }
            ViewBag.userName = HttpContext.Session.GetString("accName");
            ViewBag.chucvu = HttpContext.Session.GetString("chucvu");
            ViewBag.accID = HttpContext.Session.GetString("accID");


            Class c = new Class();
            c.Name = "";
            c.AccountId = int.Parse(HttpContext.Session.GetString("accID"));
            ViewBag.ListClass = classAndScoreServices.GetLstClasss(c);
            try
            {
                int classId = int.Parse(HttpContext.Request.Form["cboClass"]);
                Score s = new Score();
                s.Student = new Student();
                s.Student.ClassId = classId;
                s.Student.FullName = "";
                ViewBag.ListStudent = classAndScoreServices.GetLstScore(s);
                ViewBag.select = classId;
            }
            catch
            {


                Score s = new Score();
                s.Student = new Student();
                s.Student.ClassId = 0;

                ViewBag.ListStudent = new List<Score>();
            }

            return View();
        }
        public IActionResult ViewRank()
        {
            String mess = HttpContext.Request.Query["mess"].ToString();
            if (mess.Equals("-1"))
            {
                ViewBag.mess = "Thao tác thành công";
            }
            else if (mess.Equals("0"))
            {
                ViewBag.mess = "Thao tác thất bại";
            }
            else
            {
                ViewBag.mess = "";
            }
            ViewBag.userName = HttpContext.Session.GetString("accName");
            ViewBag.chucvu = HttpContext.Session.GetString("chucvu");
            ViewBag.accID = HttpContext.Session.GetString("accID");


            Class c = new Class();
            c.Name = "";
            c.AccountId = int.Parse(HttpContext.Session.GetString("accID"));
            ViewBag.ListClass = classAndScoreServices.GetLstClasss(c);
            try
            {
                int classId = int.Parse(HttpContext.Request.Form["cboClass"]);
                Score s = new Score();
                s.Student = new Student();
                s.Student.ClassId = classId;
                s.Student.FullName = "";
                ViewBag.ListStudent = classAndScoreServices.GetLstScore(s);
                ViewBag.select = classId;
            }
            catch
            {


                Score s = new Score();
                s.Student = new Student();
                s.Student.ClassId = 0;

                ViewBag.ListStudent = new List<Score>();
            }

            return View();
        }

        [HttpPost]
        public ActionResult ModifyScore()
        {
            Score cate = classAndScoreServices.GetScoreById(int.Parse(HttpContext.Request.Form["hidID"]));
            cate.Score1 = int.Parse(HttpContext.Request.Form["nmScore"]);


            List<int> lstDelete = new List<int>();
            lstDelete.Add(cate.Id);
            if (classAndScoreServices.ModifyScore(cate))
            {
                List<Rank> lstRank = classAndScoreServices.GetLstRank();
                int rankId = lstRank.Where(x => x.LimitScore <= cate.Score1 && cate.Score1 <= x.MaxScore).Select(x => x.Id).FirstOrDefault();

                StudentServices ser = new StudentServices();
                ser.UpDateRankStudent(rankId, (int)cate.StudentId);

                return RedirectToAction("ManagerScore", "Manager", new { mess = -1 });
            }
            else
            {
                return RedirectToAction("ManagerScore", "Manager", new { mess = 0 });
            }

        }




        /////////////////////
        // Manager Class
        [HttpPost]
        public ActionResult InsertClass()
        {
            Models.Class cate = new Models.Class();

            cate.Name = HttpContext.Request.Form["txtName"];
            cate.Description = HttpContext.Request.Form["txtDescription"];
            cate.Code = HttpContext.Request.Form["txtCode"];
            cate.AccountId = int.Parse(HttpContext.Request.Form["cboAccount"]);
            if (classAndScoreServices.InsertClass(cate))
            {
                return RedirectToAction("ManagerClass", "Manager", new { mess = -1 });
            }
            else
            {
                return RedirectToAction("ManagerClass", "Manager", new { mess = 0 });
            }
        }

        [HttpPost]
        public ActionResult ModifyClass()
        {
            Models.Class cate = classAndScoreServices.GetClassById(int.Parse(HttpContext.Request.Form["hidID"]));
            cate.Name = HttpContext.Request.Form["txtName"];
            cate.Description = HttpContext.Request.Form["txtDescription"];
            cate.AccountId = int.Parse(HttpContext.Request.Form["cboAccount"]);

            if (HttpContext.Request.Form["btn"] == "2")
            {
                if (classAndScoreServices.ModifyClass(cate))
                {
                    return RedirectToAction("ManagerClass", "Manager", new { mess = -1 });
                }
                else
                {
                    return RedirectToAction("ManagerClass", "Manager", new { mess = 0 });
                }
            }
            else
            {
                List<int> lstDelete = new List<int>();
                lstDelete.Add(cate.Id);
                if (classAndScoreServices.DeleteClass(lstDelete))
                {
                    return RedirectToAction("ManagerClass", "Manager", new { mess = -1 });
                }
                else
                {
                    return RedirectToAction("ManagerClass", "Manager", new { mess = 0 });
                }
            }



        }



        /////////////////////
        // Manager Rank
        [HttpPost]
        public ActionResult InsertRank()
        {
            Rank cate = new Rank();

            cate.Name = HttpContext.Request.Form["txtName"];
            cate.LimitScore = int.Parse(HttpContext.Request.Form["nmLimit"]);
            cate.MaxScore = int.Parse(HttpContext.Request.Form["nmMax"]);
            cate.Image = HttpContext.Request.Form["txtImage"];
            if (classAndScoreServices.InsertRank(cate))
            {
                return RedirectToAction("ManagerRank", "Manager", new { mess = -1 });
            }
            else
            {
                return RedirectToAction("ManagerRank", "Manager", new { mess = 0 });
            }
        }

        [HttpPost]
        public ActionResult ModifyRank()
        {
            Rank cate = classAndScoreServices.GetRankById(int.Parse(HttpContext.Request.Form["hidID"]));
            cate.Name = HttpContext.Request.Form["txtName"];
            cate.LimitScore = int.Parse(HttpContext.Request.Form["nmLimit"]);
            cate.MaxScore = int.Parse(HttpContext.Request.Form["nmMax"]);
            cate.Image = HttpContext.Request.Form["txtImage"];




            if (HttpContext.Request.Form["btn"] == "2")
            {
                if (classAndScoreServices.ModifyRank(cate))
                {
                    return RedirectToAction("ManagerRank", "Manager", new { mess = -1 });
                }
                else
                {
                    return RedirectToAction("ManagerRank", "Manager", new { mess = 0 });
                }
            }
            else
            {
                List<int> lstDelete = new List<int>();
                lstDelete.Add(cate.Id);
                if (classAndScoreServices.DeleteRank(lstDelete))
                {
                    return RedirectToAction("ManagerRank", "Manager", new { mess = -1 });
                }
                else
                {
                    return RedirectToAction("ManagerRank", "Manager", new { mess = 0 });
                }
            }

        }



        /////////////////////
        // Manager Student
        [HttpPost]
        public ActionResult InsertStudent()
        {
            Student cate = new Student();

            cate.FullName = HttpContext.Request.Form["txtName"];
            cate.Code = HttpContext.Request.Form["txtCode"];
            cate.Address = HttpContext.Request.Form["txtAddress"];
            cate.Phone = HttpContext.Request.Form["txtPhone"];


            if (studentServices.InsertStudent(cate))
            {
                return RedirectToAction("ManagerStudent", "Manager", new { mess = -1 });
            }
            else
            {
                return RedirectToAction("ManagerStudent", "Manager", new { mess = 0 });
            }
        }

        [HttpPost]
        public ActionResult ModifyStudent()
        {
            Student cate = studentServices.GetStudentById(int.Parse(HttpContext.Request.Form["hidID"]));
            cate.FullName = HttpContext.Request.Form["txtName"];
            cate.Code = HttpContext.Request.Form["txtCode"];
            cate.Address = HttpContext.Request.Form["txtAddress"];
            cate.Phone = HttpContext.Request.Form["txtPhone"];

            if (HttpContext.Request.Form["btn"] == "2")
            {
                if (studentServices.ModifyStudent(cate))
                {
                    return RedirectToAction("ManagerStudent", "Manager", new { mess = -1 });
                }
                else
                {
                    return RedirectToAction("ManagerStudent", "Manager", new { mess = 0 });
                }
            }
            else
            {
                List<int> lstDelete = new List<int>();
                lstDelete.Add(cate.Id);
                if (studentServices.CheckDeleteStudent(int.Parse(HttpContext.Request.Form["hidID"])))
                {
                    if (studentServices.DeleteStudent(lstDelete))
                    {
                        return RedirectToAction("ManagerStudent", "Manager", new { mess = -1 });
                    }
                    else
                    {
                        return RedirectToAction("ManagerStudent", "Manager", new { mess = 0 });
                    }
                }
                else
                {
                    return RedirectToAction("ManagerStudent", "Manager", new { mess = 1 });
                }
            }

        }
    }
}
