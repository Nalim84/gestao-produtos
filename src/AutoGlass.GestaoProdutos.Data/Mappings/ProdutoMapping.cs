using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutoModel = AutoGlass.GestaoProdutos.Domain.Entities;

namespace AutoGlass.GestaoProdutos.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<ProdutoModel.Produto>
    {
        public void Configure(EntityTypeBuilder<ProdutoModel.Produto> builder)
        {

            builder.ToTable("Produtos");

            builder.HasKey(p => p.Codigo);

            builder.Property(p => p.Descricao)
                .IsRequired().HasColumnType("varchar(300)");

            builder.Property(p => p.Situacao)
               .IsRequired().HasColumnType("bit");

            builder.Property(p => p.DataFabricacao)
                .HasColumnType("datetime");

            builder.Property(p => p.DataValidade)
                .HasColumnType("datetime");

            builder.Property(p => p.CodigoFornecedor)
                .HasColumnType("int");

            builder.Property(p => p.DescricaoFornecedor)
                .IsRequired().HasColumnType("varchar(300)");

            builder.Property(p => p.CNPJ)
                .IsRequired().HasColumnType("varchar(14)");
        }
    }
}
