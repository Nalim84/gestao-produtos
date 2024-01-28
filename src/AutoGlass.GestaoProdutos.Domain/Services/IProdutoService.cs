using AutoGlass.GestaoProdutos.Domain.DTO;
using AutoGlass.GestaoProdutos.Domain.Entities;

namespace AutoGlass.GestaoProdutos.Domain.Services
{
    public interface IProdutoService : IDisposable
    {
        Task<ProdutoDTO> ObterProdutoPorCodigo(int codigoProduto);
        Task<ICollection<ProdutoDTO>> ObterProdutoPorDescricaoPaginado(string descricaoProduto, int pagina, int linhas);
        Task<ProdutoDTO> Inserir(DTO.ProdutoDTO produto);
        Task<ProdutoDTO> Editar(DTO.ProdutoDTO produto);
        Task<ProdutoDTO> Excluir(int codigoProduto);
        Task<bool> ValidarDatasProduto(DateTime dataFabricacao, DateTime dataValidade);
    }
}
