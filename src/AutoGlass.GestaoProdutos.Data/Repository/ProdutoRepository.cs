using AutoGlass.GestaoProdutos.Core.Data;
using AutoGlass.GestaoProdutos.Data.Context;
using AutoGlass.GestaoProdutos.Domain.Entities;
using AutoGlass.GestaoProdutos.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutoGlass.GestaoProdutos.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ProdutoDbContext context) : base(context) { }

        private ProdutoDbContext GetDbContext() { return ((ProdutoDbContext)Db); }

        public async Task<Produto> ObterProdutoPorCodigo(int codigoProduto)
        {
            return await GetDbContext().Produtos
             .Where(wh => wh.Situacao && wh.Codigo == codigoProduto).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<ICollection<Produto>> ObterProdutoPorDescricaoPaginado(string descricaoProduto, int pagina, int linhas)
        {
            return await GetDbContext().Produtos
                .Where(wh => wh.Situacao && wh.Descricao.Contains(descricaoProduto))
                                .Skip((pagina - 1) * linhas).Take(linhas).AsNoTracking().ToListAsync();
        }
    }
}
