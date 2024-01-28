using AutoGlass.GestaoProdutos.Application.Services;
using AutoGlass.GestaoProdutos.Core.Notificacoes;
using AutoGlass.GestaoProdutos.Data.Context;
using AutoGlass.GestaoProdutos.Data.Repository;
using AutoGlass.GestaoProdutos.Domain.Repositories;
using AutoGlass.GestaoProdutos.Domain.Services;
using AutoGlass.GestaoProdutos.Interfaces;
using AutoGlass.GestaoProdutos.Presentation.Extensions;
using AutoGlass.GestaoProdutos.Presentation.Interface;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AutoGlass.GestaoProdutos.Presentation.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ProdutoDbContext>();
            services.AddScoped<INotificador, Notificador>();

            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
