using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FaktureApp.Models.Fakture
{
    [Table("Stavka")]
    public class Stavka
    {
       
        public int RedniBroj { get; set; }

        [Required(ErrorMessage = "Unesite kolicinu")]
        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "Kolicina mora biti veca od 0")]
        public double Kolicina { get; set; }


        public string BrojDokumenta { get; set; }

        [Required(ErrorMessage = "Unesite cenu")]
        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "Cena mora biti veca od 0")]
        public double Cena { get; set; }

        public double Ukupno { get; set; }

        [ForeignKey("BrojDokumenta")]
        public Faktura Faktura { get; set; }
    }
}
