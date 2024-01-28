using AutoGlass.GestaoProdutos.Domain.DTO;
using AutoGlass.GestaoProdutos.Domain.Entities;
using AutoGlass.GestaoProdutos.Domain.Repositories;
using AutoGlass.GestaoProdutos.Domain.Services;
using AutoMapper;

namespace AutoGlass.GestaoProdutos.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<ProdutoDTO> ObterProdutoPorCodigo(int codigoProduto)
        {
            var produto =
                _mapper.Map<ProdutoDTO>(await _produtoRepository.ObterProdutoPorCodigo(codigoProduto));

            return produto;
        }

        public async Task<ICollection<ProdutoDTO>> ObterProdutoPorDescricaoPaginado(string descricaoProduto, int pagina, int linhas)
        {
            var produtos =
                _mapper.Map<ICollection<ProdutoDTO>>(await _produtoRepository.ObterProdutoPorDescricaoPaginado(descricaoProduto, pagina, linhas));

            return produtos.ToList();
        }

        public async Task<ProdutoDTO> Inserir(ProdutoDTO produto)
        {
            var entity = _mapper.Map<Produto>(produto);

            await _produtoRepository.Adicionar(_mapper.Map<Produto>(entity));
            produto.Codigo = entity.Codigo;

            return produto;
        }

        public async Task<ProdutoDTO> Editar(ProdutoDTO produto)
        {
            await _produtoRepository.Atualizar(_mapper.Map<Produto>(produto));

            return produto;
        }

        public async Task<ProdutoDTO> Excluir(int codigoProduto)
        {
            var produto = await _produtoRepository.ObterProdutoPorCodigo(codigoProduto);
            produto.Situacao = false;

            await _produtoRepository.Atualizar(_mapper.Map<Produto>(produto));

            return _mapper.Map<ProdutoDTO>(produto);;
        }

        public async Task<bool> ValidarDatasProduto(DateTime dataFabricacao, DateTime dataValidade)
        {
            return (dataFabricacao <= dataValidade);
        }

        public void Dispose()
        {
            _produtoRepository.Dispose();
        }
    }
}
