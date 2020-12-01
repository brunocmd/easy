using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DojoDDD.Business.Interfaces;
using DojoDDD.Business;
using DojoDDD.Repository;
using DojoDDD.Repository.Interfaces;

namespace DojoDDD.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();

            services.AddScoped<DataStore>();
            services.AddTransient<IClienteRepositorio, ClienteRepositorio>();
            services.AddTransient<IOrdemCompraRepositorio, OrdemCompraRepositorio>();
            services.AddTransient<IOrdemCompraServicoRepositorio, OrdemCompraServicoRepositorio>();
            services.AddTransient<IProdutoRepositorio, ProdutoRepositorio>();


            services.AddScoped<IClienteBusiness, ClienteServico>();
            services.AddScoped<IProdutoBusiness, ProdutoServico>();
            services.AddScoped<IOrdemCompraBusiness, OrdemCompraServico>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
