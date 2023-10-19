using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace My_Core_4Table.Models
{
    public class Personeller
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("ADI SOYADI")]
        public string ADSOYAD { get; set; } = ""; //Adı Soyadı

        [DisplayName("YAŞ")]
        public int YAS { get; set; }

        [DisplayName("CİNSİYETİ")]
        public string CINSIYET { get; set; } = "";

        [DisplayName("ÇALIŞMA SÜRESİ")]
        public int TOPLAMCALISMA { get; set; }
    }
}
