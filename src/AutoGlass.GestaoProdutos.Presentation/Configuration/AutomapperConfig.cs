using AutoGlass.GestaoProdutos.Domain.DTO;
using AutoGlass.GestaoProdutos.Domain.Entities;
using AutoMapper;

namespace AutoGlass.GestaoProdutos.Presentation.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<ProdutoDTO, Produto>().ReverseMap();
        }
    }
}