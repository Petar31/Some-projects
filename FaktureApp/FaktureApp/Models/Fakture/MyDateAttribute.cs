using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FaktureApp.Models.Fakture
{
    public class MyDateAttribute : ValidationAttribute
    {


        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }
          
            bool x = DateTime.TryParse(value.ToString(), out DateTime res);
            if (x)
            {
                if (res > DateTime.Now.AddYears(-100) && res <= DateTime.Now)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            


        }
    }
}
