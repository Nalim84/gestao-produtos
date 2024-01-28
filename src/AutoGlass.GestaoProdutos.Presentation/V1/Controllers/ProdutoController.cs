using AutoGlass.GestaoProdutos.Domain.DTO;
using AutoGlass.GestaoProdutos.Domain.Services;
using AutoGlass.GestaoProdutos.Interfaces;
using AutoGlass.GestaoProdutos.Presentation.Controllers;
using AutoGlass.GestaoProdutos.Presentation.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoGlass.GestaoProdutos.Presentation.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/produtos")]
    public class ProdutoController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService, IMapper mapper,
            INotificador notificador,
            IUser user) : base(notificador, user) { _produtoService = produtoService; _mapper = mapper; }

        [AllowAnonymous]
        [HttpGet("/{codigoProduto:int}")]
        public async Task<ActionResult<ProdutoDTO>> ObterProdutoPorCodigo(int codigoProduto)
        {
            if (codigoProduto <= 0)
            {
                NotificarErro("O código do produto é inválido!");
                return CustomResponse();
            }

            var produto = await _produtoService.ObterProdutoPorCodigo(codigoProduto);

            if (produto == null) return NotFound("O produto não foi encontrado.");

            return produto;
        }

        [AllowAnonymous]
        [HttpGet("/{descricaoProduto}/{pagina:int}/{linhas:int}")]
        public async Task<ActionResult<ICollection<ProdutoDTO>>> ObterProdutoPorDescricaoPaginado(string descricaoProduto, int pagina, int linhas)
        {
            if (linhas <= 0 || pagina <= 0)
            {
                NotificarErro("O número de linhas e páginas devem ser maior que zero.");
                return CustomResponse();
            }

            var produtos = await _produtoService.ObterProdutoPorDescricaoPaginado(descricaoProduto, pagina, linhas);

            if (produtos == null || produtos.Count == 0) return NotFound();

            return produtos.ToList();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<ProdutoDTO>> Inserir(ProdutoDTO produto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (!await _produtoService.ValidarDatasProduto(produto.DataFabricacao, produto.DataValidade))
            {
                NotificarErro("A data de fabricação que não poderá ser maior ou igual a data de validade.");
                return CustomResponse();
            }

            await _produtoService.Inserir(produto);

            return CustomResponse(produto);
        }

        [AllowAnonymous]
        [HttpPut]
        public async Task<ActionResult<ProdutoDTO>> Editar(ProdutoDTO produto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (!await _produtoService.ValidarDatasProduto(produto.DataFabricacao, produto.DataValidade))
            {
                NotificarErro("A data de fabricação que não poderá ser maior ou igual a data de validade.");
                return CustomResponse();
            }

            await _produtoService.Editar(produto);

            return CustomResponse(produto);
        }

        [AllowAnonymous]
        [HttpDelete]
        public async Task<ActionResult<ProdutoDTO>> Excluir(int codigoProduto)
        {
            if (codigoProduto <= 0)
            {
                NotificarErro("O código do produto é inválido!");
                return CustomResponse();
            }
            var produto = await _produtoService.ObterProdutoPorCodigo(codigoProduto);

            if (produto == null) return NotFound($"Produto com o código {codigoProduto} não foi encontrado.");

            await _produtoService.Excluir(codigoProduto);

            return CustomResponse($"Produto com o código {codigoProduto} foi excluido.");
        }
    }
}



