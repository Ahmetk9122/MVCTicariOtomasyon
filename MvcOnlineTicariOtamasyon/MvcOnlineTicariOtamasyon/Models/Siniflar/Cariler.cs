using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtamasyon.Models.Siniflar
{
    public class Cariler
    {
        [Key]
        public int Cariid { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="En Fazla 30 Karakter Yazabilirsiniz.")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string CariAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage ="Bu alanı boş geçemezsiniz.")]
        public string CariSoyad { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string CariSehir { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
         [Required(ErrorMessage ="Bu alanı boş geçemezsiniz.")]
        public string CariMail { get; set; }

        public bool Durum { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
        // public string CariUnvan { get; set; }
    }
}