using Aplicacion.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Persistencia
{
    public partial class Contexto:DbContext
    {
        public virtual DbSet<Image> Images { get; set; }
        public Contexto() { }
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ImageConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => base.OnConfiguring(optionsBuilder);

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
