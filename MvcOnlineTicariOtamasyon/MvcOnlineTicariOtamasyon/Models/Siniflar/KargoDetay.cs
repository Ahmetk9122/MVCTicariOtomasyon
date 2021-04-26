using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtamasyon.Models.Siniflar
{
    public class KargoDetay
    {
        [KEY]
        public int KargoDetayid { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string Aciklama { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string takipKodu { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Personel { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Alici { get; set; }
        public DateTime Tarih { get; set; }

    }
}