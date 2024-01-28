using AutoGlass.GestaoProdutos.Core.Data;
using AutoGlass.GestaoProdutos.Domain.Entities;

namespace AutoGlass.GestaoProdutos.Domain.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<Produto> ObterProdutoPorCodigo(int codigoProduto);
        Task<ICollection<Produto>> ObterProdutoPorDescricaoPaginado(string descricaoProduto, int pagina, int linhas);
    }
}
