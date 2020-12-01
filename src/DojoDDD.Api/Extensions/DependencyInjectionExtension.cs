using Microsoft.Extensions.DependencyInjection;
using DojoDDD.Business.Interfaces;
using DojoDDD.Business;
using DojoDDD.Repository;
using DojoDDD.Repository.Interfaces;


namespace DojoDDD.Api.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {

            //Dependency Injection
            services.AddScoped<DataStore>();
            services.AddTransient<IClienteRepositorio, ClienteRepositorio>();
            services.AddTransient<IOrdemCompraRepositorio, OrdemCompraRepositorio>();
            services.AddTransient<IOrdemCompraServicoRepositorio, OrdemCompraServicoRepositorio>();
            services.AddTransient<IProdutoRepositorio, ProdutoRepositorio>();


            services.AddScoped<IClienteBusiness, ClienteServico>();
            services.AddScoped<IProdutoBusiness, ProdutoServico>();
            services.AddScoped<IOrdemCompraBusiness, OrdemCompraServico>();

            return services;
        }
    }
}
