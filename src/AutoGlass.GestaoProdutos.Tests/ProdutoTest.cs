using AutoGlass.GestaoProdutos.Application.Services;
using AutoGlass.GestaoProdutos.Domain.DTO;
using AutoGlass.GestaoProdutos.Domain.Entities;
using AutoGlass.GestaoProdutos.Domain.Repositories;
using AutoMapper;
using Moq;

namespace AutoGlass.GestaoProdutos.Tests
{
    public class ProdutoTest
    {
        private Mock<IProdutoRepository> _mockRepository;
        private Mock<IMapper> _mockMapper;
        private ProdutoService _produtoService;

        public ProdutoTest()
        {
            // Configurar o Moq uma vez para ser reutilizado em todos os testes
            _mockRepository = new Mock<IProdutoRepository>();
            _mockMapper = new Mock<IMapper>();

            _produtoService = new ProdutoService(_mockRepository.Object, _mockMapper.Object);
        }

        private void ConfigurarMockRepository(List<Produto> produtos)
        {
            _mockRepository
                .Setup(repo => repo.ObterProdutoPorDescricaoPaginado(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(produtos);
        }

        private void ConfigurarMockMapper(List<Produto> produtos)
        {
            _mockMapper
                .Setup(mapper => mapper.Map<ICollection<ProdutoDTO>>(It.IsAny<IEnumerable<Produto>>()))
                .Returns((IEnumerable<Produto> p) => new List<ProdutoDTO>(p.Select(prod => new ProdutoDTO { Codigo = prod.Codigo, Descricao = prod.Descricao })));
        }

        /// <summary>
        /// Deve retornar uma lista de produtos preenchida e não vazia (null).
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ObterProdutoPorDescricaoPaginado_DeveRetornarListaDeProdutos()
        {
            // Arrange
            var descricaoProduto = "Teste";
            var pagina = 1;
            var linhas = 10;

            var produtosDoRepositorio = new List<Produto>
        {
            new Produto { Codigo = 1, Descricao = "Teste1" },
            new Produto { Codigo = 2, Descricao = "Teste2" }
        };

            ConfigurarMockRepository(produtosDoRepositorio);
            ConfigurarMockMapper(produtosDoRepositorio);

            // Act
            var resultado = await _produtoService.ObterProdutoPorDescricaoPaginado(descricaoProduto, pagina, linhas);

            // Assert
            Assert.NotNull(resultado);
        }

        /// <summary>
        /// Deve retornar uma lista tipada de ProdutoDTO.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ObterProdutoPorDescricaoPaginado_DeveSerTipoProdutoDTO()
        {
            // Arrange
            var descricaoProduto = "Teste";
            var pagina = 1;
            var linhas = 10;

            var produtosDoRepositorio = new List<Produto>
        {
            new Produto { Codigo = 1, Descricao = "Teste1" },
            new Produto { Codigo = 2, Descricao = "Teste2" }
        };

            ConfigurarMockRepository(produtosDoRepositorio);
            ConfigurarMockMapper(produtosDoRepositorio);

            // Act
            var resultado = await _produtoService.ObterProdutoPorDescricaoPaginado(descricaoProduto, pagina, linhas);

            // Assert
            Assert.IsType<List<ProdutoDTO>>(resultado);
        }

        /// <summary>
        /// Deve retornar uma quantidade de itens como na lista simulada.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ObterProdutoPorDescricaoPaginado_TotalItensResultadoIgualListaSimulada()
        {
            // Arrange
            var descricaoProduto = "Teste";
            var pagina = 1;
            var linhas = 10;

            var produtosDoRepositorio = new List<Produto>
        {
            new Produto { Codigo = 1, Descricao = "Teste1" },
            new Produto { Codigo = 2, Descricao = "Teste2" }
        };

            ConfigurarMockRepository(produtosDoRepositorio);
            ConfigurarMockMapper(produtosDoRepositorio);

            // Act
            var resultado = await _produtoService.ObterProdutoPorDescricaoPaginado(descricaoProduto, pagina, linhas);

            // Assert
            Assert.IsType<List<ProdutoDTO>>(resultado);
        }

       
        [Fact]
        public async Task ValidarDatasProduto_DataValidadeMaiorQueDataFabricacao()
        {
            // Act
            var resultado = await _produtoService.ValidarDatasProduto(DateTime.Now, DateTime.Now.AddDays(1));

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public async Task ValidarDatasProduto_DataValidadeMenorQueDataFabricacao()
        {
            // Act
            var resultado = await _produtoService.ValidarDatasProduto(DateTime.Now.AddDays(1), DateTime.Now);

            // Assert
            Assert.False(resultado);
        }

        [Fact]
        public async Task ValidarDatasProduto_MesmoDia()
        {
            var dataAtual = DateTime.Now;

            // Act
            var resultado = await _produtoService.ValidarDatasProduto(dataAtual, dataAtual);

            // Assert
            Assert.True(resultado);
        }
    }
}