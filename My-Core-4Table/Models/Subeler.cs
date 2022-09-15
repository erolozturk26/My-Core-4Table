using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace My_Core_4Table.Models
{
    public class Subeler
    {
        [Key]
        public int ID { get; set; }
        [Required]//zorunlu
        [StringLength(20)]//ad soy karakter sayısı
        [DisplayName("ŞUBE ADI")]
        public string ADI { get; set; } = "";

        [Required]
        [StringLength(10)]
        [DisplayName("ŞUBE KONUM")]
        public string KONUM { get; set; } = "";

        [DisplayName("CİRO(YILLIK)")]
        public int YILLIKCIRO { get; set; }

        [DisplayName("ÇALIŞAN SAYISI")]
        public int TOPLAMCALISAN { get; set; }
    }
}
