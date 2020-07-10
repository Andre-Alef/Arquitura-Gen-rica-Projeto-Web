using ArquiteturaTeste.Domain.Models;
using ArquiteturaTeste.Infrastructure.Data.Map;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaTeste.Infrastructure.Data
{
   public class ContextChamadosTeste1:DbContext
    {
        public ContextChamadosTeste1():base("TesteChamados")
        {
                
        }
        public DbSet <NovoChamado> chamados { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new MapaChamados());
            base.OnModelCreating(modelBuilder);
        }
    }
}
