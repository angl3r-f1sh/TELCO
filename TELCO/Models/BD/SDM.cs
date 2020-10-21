namespace TELCO.Models.BD
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SDM : DbContext
    {
        public SDM()
            : base("name=SDM")
        {
        }

        public virtual DbSet<GENEROS> GENEROS { get; set; }
        public virtual DbSet<PLATAFORMAS> PLATAFORMAS { get; set; }
        public virtual DbSet<VIDEOJUEGOS> VIDEOJUEGOS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GENEROS>()
                .Property(e => e.txt_genero)
                .IsUnicode(false);

            modelBuilder.Entity<GENEROS>()
                .HasMany(e => e.VIDEOJUEGOS)
                .WithRequired(e => e.GENEROS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PLATAFORMAS>()
                .Property(e => e.txt_plataforma)
                .IsUnicode(false);

            modelBuilder.Entity<PLATAFORMAS>()
                .HasMany(e => e.VIDEOJUEGOS)
                .WithRequired(e => e.PLATAFORMAS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VIDEOJUEGOS>()
                .Property(e => e.txt_nombre)
                .IsUnicode(false);

            modelBuilder.Entity<VIDEOJUEGOS>()
                .Property(e => e.txt_descripcion)
                .IsUnicode(false);
        }
    }
}
