using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Filters;

namespace WebApp.Controllers
{
    [Localization]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            try
            {
                return View("Index");
            }
            catch (Exception)
            {

                return View("Error");
            }
            


        }

        public ActionResult Show(int id)
        {
            if (CRUDCars.GetCarById(id) != null)
            {
                ViewData.Model = CRUDCars.GetCarById(id);
                return View("Show");
            }
            else
            {
                return View("Error");
            }
           
           
        }

        public ActionResult AddCarPage()
        {
            return View("AddCar");
        }

        public ActionResult AddCar(Car car, IEnumerable<HttpPostedFileBase> fileUpload)
        {
            if (car.EngineVolume < 0)
            {
                ModelState.AddModelError("EngineVolume", "Engine volume must be greather then 0");
            }
            if (car.EnginePower < 0)
            {
                ModelState.AddModelError("EnginePower", "Engine power must be greather then 0");
            }
            if (car.Price < 0)
            {
                ModelState.AddModelError("Price", "Price must be greather then 0");

            }

            if (ModelState.IsValid)
            {
                if (CRUDCars.AddCar(car, fileUpload))
                {
                   
                    ViewBag.NewCar = car.Make + " " + car.Model;
                    return View("Index");
                }
                else
                {
                    return View("Error");
                }
               
            }
            else
            {
                return View("AddCar");
            }
          
        }

        [Authorize]
        public ActionResult RemoveCar(int id)
        {
            List<Image> images = CRUDCars.RemoveCar(id);
            if (images != null)
            {
                foreach (Image item in images)
                {
                    string path = Path.Combine(Server.MapPath("~/images"), item.ProductImage);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }


                }

                return View("Index");
            }
            else
            {
                return View("Error");
            }

            
        }


        public ActionResult AboutUs()
        {
            return View("AboutUs");
        }

        [Authorize]
        public ActionResult Contact()
        {

            return View();
        }

        public ActionResult Error()
        {
            return View("Error");
        }


        public ActionResult SetCulture(string culture, string sourceUrl)
        {
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
            {
                cookie.Value = culture;
            }
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return Redirect(sourceUrl);

        }
    }
}