using AutoGlass.GestaoProdutos.Core.Models;

namespace AutoGlass.GestaoProdutos.Domain.Entities
{
    public class Produto : Entity
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public bool Situacao { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int? CodigoFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string CNPJ { get; set; }
    }
}
