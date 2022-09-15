using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace My_Core_4Table.Models
{
    public class Toptancilar
    {
        [Key]
        public int ID { get; set; }
        [Required]//zorunlu
        [StringLength(20)]//ad soy karakter sayısı 
        [DisplayName("ADI SOYADI")]
        public string ADISOYADI { get; set; } = "";
        
        //---
        [Required]
        [StringLength(10)]
        [DisplayName("KONUM")]
        public string KONUMU { get; set; } = "";

        
        [DisplayName("TELEFON NUMARASI")]
        public string TELEFONNO { get; set; } = "";

        
        [DisplayName("ÇALIŞMA SAYISI")]
        public int TOPLAMCALISMA { get; set; }
        

    }
}
