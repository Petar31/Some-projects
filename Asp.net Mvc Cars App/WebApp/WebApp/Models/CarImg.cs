using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class CarImg
    {
        public Car Car { get; set; }
        public List<Image> Images { get; set; }
    }
}