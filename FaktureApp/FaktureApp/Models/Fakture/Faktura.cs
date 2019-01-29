using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FaktureApp.Models.Fakture
{
    [Table("Faktura")]
    public class Faktura
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string BrojDokumenta { get; set; }

        [Required(ErrorMessage = "Unesite broj fakture")]
        [StringLength(20)]
        public string BrojFakture { get; set; }

        [Required(ErrorMessage ="Unesite datum dokumenta")]
        [MyDate(ErrorMessage ="Pogresan opseg datuma")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime DatumDokumenta { get; set; }

        public double Ukupno { get; set; }
    }
}