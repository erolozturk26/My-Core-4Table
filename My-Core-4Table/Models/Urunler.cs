using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace My_Core_4Table.Models
{
    public class Urunler
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("ÜRÜN ADI")]
        public string ADI { get; set; } = "";

        [DisplayName("FİYAT")]
        public int FIYAT { get; set; }

        [DisplayName("MARKASI")]
        public string MARKA { get; set; } = "";

        [DisplayName("EK ÖZELLİKLER")]
        public string EKOZELLIKLER { get; set; } = "";
    }
}
