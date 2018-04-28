using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class UserInfoController : Controller
    {
        //
        // GET: /UserInfo/
        DbContext my = new MyContext();
        public ActionResult Index()
        {
        
            var list = from a in my.Set<UserInfo>()
                       select a;
            ViewBag.t = "蜀云泉真帅啊";
            ViewBag.list = list;
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(UserInfo userInfo)
        {
            my.Set<UserInfo>().Add(userInfo);
            int result = my.SaveChanges();
            if (result>0)
            {
                return Redirect(@Url.Action("Index", "UserInfo"));
            }
            else
            {
                return Redirect(@Url.Action("Add"));
            }

        }


    }
}
