using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.Script.Serialization;
using ProductsApp.Models;

namespace ProductsApp.Controllers
{
    public class JSONController : Controller
    {
        // GET: JSON
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

        public List<Proizvodi> proizvodiList()
        {
            string file = Server.MapPath("/Content/json1.json");
            string json = System.IO.File.ReadAllText(file);
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Proizvodi> personList = js.Deserialize<List<Proizvodi>>(json);
            return personList;
        }

        public ActionResult JsonResult()
        {
            try
            {
                List<Proizvodi> personList = proizvodiList();
                return View(personList);
            }
            catch (Exception)
            {

                return View("Error");
            }
            
        }

        public ActionResult AddJsonData()
        {
            return View();
        }

        public ActionResult CreateJson(Proizvodi proizvodi)
        {

            try
            {
                List<Proizvodi> personList = proizvodiList();
                int id = (from query in personList select query.id).LastOrDefault();
                int id1 = id + 1;

                Proizvodi proizvodi1 = new Proizvodi()
                {
                    id = id1,
                    naziv = proizvodi.naziv,
                    opis = proizvodi.opis,
                    kategorija = proizvodi.kategorija,
                    proizvodjac = proizvodi.proizvodjac,
                    dobavljac = proizvodi.dobavljac,
                    cena = proizvodi.cena
                };
                personList.Add(proizvodi1);

                string jsonInput = new JavaScriptSerializer().Serialize(personList);
                string file1 = Server.MapPath("/Content/json1.json");
                System.IO.File.WriteAllText(file1, jsonInput);
                return RedirectToAction("JsonResult");
            }
            catch (Exception)
            {

                return View("Error");
            }

           
        }


        public ActionResult Edit(int id)
        {

            
            List<Proizvodi> personList = proizvodiList();

            Proizvodi proizvodi = (from query in personList where query.id == id select query).FirstOrDefault();

           
            return View(proizvodi);
        }
       

        public ActionResult SaveChanges(Proizvodi proizvodi)
        {
            try
            {
                List<Proizvodi> lista = proizvodiList();

                Proizvodi proizvod = (from query in lista where query.id == proizvodi.id select query).First();

                lista.Remove(proizvod);
                lista.Add(proizvodi);

                List<Proizvodi> sortedList = lista.OrderBy(x => x.id).ToList();
                string jsonInput = new JavaScriptSerializer().Serialize(sortedList);
                string file1 = Server.MapPath("/Content/json1.json");
                System.IO.File.WriteAllText(file1, jsonInput);
                return RedirectToAction("JsonResult");
            }
            catch (Exception)
            {

                return View("Error");
            }
            

        }
    }

    
}