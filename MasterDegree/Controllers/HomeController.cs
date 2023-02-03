using MasterDegree.UserDefined;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterDegree.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        public ActionResult Run(string UserName, string Password, string list)
        {



            if (UserName == "Admin" && Password == "7nJ4oq7@f*Dg")
            {
                switch (list)
                {
                    case "API":
                        return RedirectToAction("Index", "Help");

                    case "DatabaseBakup":

                        String ConStr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                        SqlConnectionStringBuilder Builder = new SqlConnectionStringBuilder(ConStr);

                        String DatabaseName = Builder.InitialCatalog;
                        String ServerDB = Builder.DataSource;
                        String PasswordDB = Builder.Password;
                        String UserNameDB = Builder.UserID;

                        DatabaseBackup.GenerateBackup(ServerDB, UserNameDB, PasswordDB, DatabaseName);
                        return Redirect($"~/{Paths.DatabaseBackupFilePath}");

                    case "GetLogFile":
                        return Redirect($"~/{Paths.logFilePath}");

                    default:
                        return View("~/Views/Shared/Error.cshtml");

                }


            }

            return View("~/Views/Shared/Error.cshtml");

        }



    }
}
