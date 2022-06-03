using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Create_Users_DataGrid.Models;

namespace Create_Users_DataGrid.Controllers
{
    public class CreateViewController : Controller
    {

        // GET: CreateView
        public ActionResult Index(string option, string search, string sort, decimal? reqid)
        {
            using (Model1 dBmodel = new Model1())
            {

                //if the sort parameter is null or empty then we are initializing the value as descending name  
                ViewBag.SortByName = string.IsNullOrEmpty(sort) ? "descending name" : "";
                //if the sort value is gender then we are initializing the value as descending gender  
                ViewBag.SortByGender = sort == "Gender" ? "descending gender" : "Gender";
                // x.National_ID.Equals(long.Parse(search))
                //here we are converting the db.Students to AsQueryable so that we can invoke all the extension methods on variable records.  
                var records = dBmodel.User_Image.AsQueryable();


                if (option == "Name")
                {
                    records = records.Where(x => x.UserName == search || search == null);
                }


                else
                {
                    records = records.Where(x => x.UserName.StartsWith(search) || search == null);
                }

                switch (sort)
                {

                    case "descending name":
                        records = records.OrderByDescending(x => x.UserName);
                        break;

                    case "descending Id":
                        records = records.OrderByDescending(x => x.ID);
                        break;

                    case "ID":
                        records = records.OrderBy(x => x.ID);
                        break;

                    default:
                        records = records.OrderBy(x => x.UserName);
                        break;

                }
                return View(records.ToList());
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User_Image UI)
        {
            string FullSaveDirectory = Server.MapPath("../Image/");
            CommonFunction.AutoSave(UI, FullSaveDirectory);
            ModelState.Clear();
            return Redirect("Create");
        }

        public ActionResult dumbfoo()
        {
            //sorting
            Model1 Mod = new Model1();
            //Descending
            IEnumerable<User_Image> UI = Mod.User_Image.OrderByDescending(User_Image => User_Image.NationalID);  //(ee => ee.UserName == "Baher")  OrderBy(User_Image => User_Image.NationalID)
            //Ascending
            UI = Mod.User_Image.OrderBy(User_Image => User_Image.NationalID);
            //Search
            UI = Mod.User_Image.Where(ee => ee.UserName == "Baher");
            return View(UI); 
        }

    }
}