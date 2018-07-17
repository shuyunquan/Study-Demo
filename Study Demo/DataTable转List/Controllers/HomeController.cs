using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataTable转List.Models;

namespace DataTable转List.Controllers
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

        public JsonResult ReturnJson()
        {
            string sql = "select AccountNumber,Name from [dbo].[SysUser]";

            DAL.SqlHelper sqlHelper = new DAL.SqlHelper();

            DataTable dataTable = sqlHelper.SqlConnectionInformation(sql);

            var list = (
                from d in dataTable.AsEnumerable()
                where d.Field<string>("Name")=="许嵩"
                select new User
                {
                    Number = d.Field<string>("AccountNumber"),
                    Name = d.Field<string>("Name")
                }
                ).ToList();

            return Json(list,JsonRequestBehavior.AllowGet);
        }


    }
}