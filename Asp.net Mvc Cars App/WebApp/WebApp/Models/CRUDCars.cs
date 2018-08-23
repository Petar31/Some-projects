using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;


namespace WebApp.Models
{
    public class CRUDCars
    {
        
       public static List<CarImg> GetAllCars()
        {

            try
            {
                using (var ctx = new carShopEntities())
                {
                    List<CarImg> carImgs = new List<CarImg>();


                    foreach (var item in ctx.Cars)
                    {
                        CarImg carImg = new CarImg
                        {
                            Car = item
                        };

                        List<Image> images = (from query in ctx.Images where query.CarId == item.CarId select query).ToList();
                        carImg.Images = images;
                        carImgs.Add(carImg);

                    }
                    return carImgs;
                }
            }
            catch (Exception)
            {

                return null;
            }
         
        }

        public static CarImg GetCarById(int id)
        {
            try
            {
                using (var ctx = new carShopEntities())
                {
                    CarImg carImgs = new CarImg();
                    Car carItem = (from query in ctx.Cars where query.CarId == id select query).First();
                    carImgs.Car = carItem;
                    List<Image> images = (from query in ctx.Images where query.CarId == id select query).ToList();
                    carImgs.Images = images;


                    return carImgs;

                }
            }
            catch (Exception)
            {

                return null;
            }
            
        }

        public static bool AddCar(Car car, IEnumerable<HttpPostedFileBase> fileUpload)
        {


            try
            {
                using (var ctx = new carShopEntities())
                {

                    ctx.Cars.Add(car);
                    ctx.SaveChanges();

                    foreach (var item in fileUpload)
                    {
                        Image image = new Image()
                        {
                            ProductImage = item.FileName,
                            CarId = car.CarId

                        };

                        var fileName = Path.GetFileName(item.FileName);
                        var filePath = Path.Combine(HttpContext.Current.Server.MapPath("~/images"), fileName);
                        item.SaveAs(filePath);



                        ctx.Images.Add(image);
                        ctx.SaveChanges();
                    }


                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
         

        }


        public static List<Image> RemoveCar(int id)
        {
            try
            {
                using (var ctx = new carShopEntities())
                {
                    Car query = (from que in ctx.Cars where que.CarId == id select que).FirstOrDefault();
                    ctx.Cars.Remove(query);
                    List<Image> images = (from que in ctx.Images where que.CarId == id select que).ToList();

                    foreach (Image item in images)
                    {
                        ctx.Images.Remove(item);


                    }
                    ctx.SaveChanges();
                    return images;
                }
            }
            catch (Exception)
            {

                return null;
            }
          
        }




    }
}