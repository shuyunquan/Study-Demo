using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var a =ViewBag.Title;
            return View();
        }

        public ActionResult list()
        {
            string json = "{\"total\":2,\"rows\":[{\"id\":\"1\",\"用户名\":\"Vae\",\"time\":\"2017\",\"state\":\"0\"},{\"id\":\"2\",\"用户名\":\"蜀云泉\",\"time\":\"2017\",\"state\":\"很好\"}]}";
            return Content(json);
        }

        public void GetDepartment(int limit, int offset, string departmentname, string statu)
        {
          
          
        }

    }
}
