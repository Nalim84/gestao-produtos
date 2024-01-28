using System.ComponentModel.DataAnnotations;

namespace AutoGlass.GestaoProdutos.Domain.DTO
{
    public class ProdutoDTO 
    {
        [Key]
        public int Codigo { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 5)]
        public string Descricao { get; set; }
        public bool Situacao { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int? CodigoFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string CNPJ { get; set; }
    }
}
