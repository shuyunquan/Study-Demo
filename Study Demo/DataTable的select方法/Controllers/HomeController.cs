using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace DataTable的select方法.Controllers
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


        public JsonResult GetTypeGradeList(int? id)
        {

            DAL.SqlHelper sqlHelper = new SqlHelper();

            string sql = "select * from EQ_TypeGrade";
            StringBuilder jsonstr = new StringBuilder();
            DataTable dt = sqlHelper.SqlConnectionInformation(sql);
            jsonstr.Append("{");
            foreach (DataRow row in dt.Select(id > 0 ? ("ParentID=" + id.ToString()) : ("ParentID is null OR ParentID=0"), "LevelOrder"))
            {
                jsonstr.Append("'" + row["EQTypeName"].ToString() + "':{id:" + row["EQTypeID"].ToString() + ",text:'" + row["EQTypeName"].ToString() + "',");
                if (dt.Select("ParentID=" + row["EQTypeID"].ToString()).Length > 0)
                {
                    jsonstr.Append("type:'folder',additionalParameters: { id:" + row["EQTypeID"].ToString() + ",children: true}");
                }
                else
                {
                    jsonstr.Append("type:'item'");
                }
                jsonstr.Append("},");
            }
            return Json(jsonstr.ToString().Trim(',') + "}", JsonRequestBehavior.AllowGet);


        }




    }
}