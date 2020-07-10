using ArquiteturaTeste.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace ArquiteturaTeste.Infrastructure.Data.Map
{
    public class MapaChamados:EntityTypeConfiguration<NovoChamado>
    {
        public MapaChamados()
        {
            ToTable("Chamados");
            HasKey(x => x.Id);
            Property(x => x.Assunto).IsRequired().HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Categoria).IsRequired().HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Email).IsRequired().HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.MaisInformacoes).IsRequired().HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Status).IsRequired().HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.DataDeCadastro).IsRequired().HasColumnType("date");

        }
    }
}
