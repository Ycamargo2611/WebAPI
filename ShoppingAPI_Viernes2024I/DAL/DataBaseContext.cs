using Microsoft.EntityFrameworkCore;
using ShoppingAPI_Viernes2024I.DAL.Entities;

namespace ShoppingAPI_Viernes2024I.DAL
{
    public class DataBaseContext:DbContext
    {
        //asi me conecto a la bse de datos, por medio de este constructor
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        //este metodo es propio de entity Framework, me sirve para configurar unos indies de cada campo en la BD
        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();// creo indice del campo name para tabla countries
        }

        #region DbSets

        public DbSet<Country> Countries { get; set; }


        #endregion

    }


}
