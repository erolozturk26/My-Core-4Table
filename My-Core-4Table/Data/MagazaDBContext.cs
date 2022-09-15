using Microsoft.EntityFrameworkCore; //Ekledik
using My_Core_4Table.Models;

namespace My_Core_4Table.Data
{
    public class MagazaDBContext : DbContext //Sql server ile bağlantılı olan alan(DbContext)Dataların tutulacağı yer.
    {
        public MagazaDBContext(DbContextOptions<MagazaDBContext> options) : base(options) //Sql Oluşturma
        {

        }
        public virtual DbSet<Subeler> Subelers { get; set; }
        public virtual DbSet<Personeller> Personellers { get; set; }
        public virtual DbSet<Toptancilar> Toptancilars { get; set; }
        public virtual DbSet<Urunler> Urunlers { get; set; }

    }
}
