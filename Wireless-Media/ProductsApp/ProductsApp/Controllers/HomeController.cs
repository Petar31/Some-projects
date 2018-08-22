using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductsApp.Models;


namespace ProductsApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        public ActionResult Error()
        {
            return View();
        }
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {

                return View("Error");
            }
            
        }

       

        public ActionResult AddProductPage()
        {
            return View("AddProduct");
        }

        public ActionResult AddProduct(Proizvodi proizvodi)
        {
            try
            {
                CRUDProducts.AddProduct(proizvodi);
                return View("Index");
            }
            catch (Exception)
            {

                return View("Error");
            }
                
            
            

        }

        public ActionResult Edit(int id)
        {
            ViewData["id"] = id;
            return View("Edit");
        }

        public ActionResult Update(Proizvodi proizvodi)
        {
            try
            {
                CRUDProducts.SaveChanges(proizvodi);
                return View("Index");
            }
            catch (Exception)
            {
                return View("Error");

            }
            
        }


        
    }
}