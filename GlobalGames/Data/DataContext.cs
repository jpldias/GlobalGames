
using GlobalGames.Data.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GlobalGames.Data
{
    public class DataContext : DbContext
    {

        public DbSet<Contactos> Contactos { get; set; }

        public DbSet<Inscricoes> Inscricoes { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
