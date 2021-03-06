using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtamasyon.Models.Siniflar
{
    public class Faturalar
    { 
        [Key]
        public int Faturaid { get; set; }

        //[Column(TypeName = "Char")]
        //[StringLength(1)]
        ////public char FaturaSeriNo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string FaturaSıraNo { get; set; }
        //public DateTime Saat { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string VergiDairesi { get; set; }

        //[Column(TypeName = "char")]
        //[StringLength(5)]
        //public string Tarih { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public String TeslimEden { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public String TeslimAlan { get; set; }

        public decimal Toplam { get; set; }

        public DateTime Tarih { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}