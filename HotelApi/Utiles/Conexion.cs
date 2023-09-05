using HotelApi.Modelos;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Utiles
{
    public class Conexion : DbContext
    {
        public Conexion(DbContextOptions<Conexion> options) : base(options)
        {

        }

        public DbSet<TblHotel> tblHotel { get; set; }
        public DbSet<ConsultaHotelCiudad> consultaHotelCiudades { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblHotel>()
                .HasKey(h => h.IdHotel);
            modelBuilder.Entity<ConsultaHotelCiudad>()
                .HasKey(h => h.IdHotel);
        }


    }
}
