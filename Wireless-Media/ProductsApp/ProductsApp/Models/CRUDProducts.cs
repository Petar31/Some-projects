using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


namespace ProductsApp.Models
{
    public class CRUDProducts
    {
        public static List<Proizvodi> GetAllProducts()
        {
            using (var ctx = new WirelessMediaDbEntities())
            {
                return ctx.Proizvodis.ToList();

            }
        }

        public static void AddProduct(Proizvodi proizvod)
        {
            using (var ctx = new WirelessMediaDbEntities())
            {
                Proizvodi pro = new Proizvodi()
                {
                    naziv = proizvod.naziv,
                    opis = proizvod.opis,
                    kategorija = proizvod.kategorija,
                    proizvodjac = proizvod.proizvodjac,
                    dobavljac = proizvod.dobavljac,
                    cena = proizvod.cena
                };
                ctx.Proizvodis.Add(pro);
                ctx.SaveChanges();

            }
        }

      public static Proizvodi GetProizvodiById(int id)
        {
            using (var ctx = new WirelessMediaDbEntities())
            {
                Proizvodi proizvod = (from query in ctx.Proizvodis where query.id == id select query).FirstOrDefault();
                return proizvod;

            }
        }


        public static void SaveChanges(Proizvodi proizvodi)
        {
            using (var ctx = new WirelessMediaDbEntities())
            {
                int proizvodId = Convert.ToInt32(proizvodi.id);
                Proizvodi pro = (from query in ctx.Proizvodis where query.id == proizvodId select query).FirstOrDefault();
                pro.naziv = proizvodi.naziv;
                pro.opis = proizvodi.opis;
                pro.kategorija = proizvodi.kategorija;
                pro.proizvodjac = proizvodi.proizvodjac;
                pro.dobavljac = proizvodi.dobavljac;
                pro.cena = proizvodi.cena;

                ctx.SaveChanges();
                

            }
        }

       
       

    }
}