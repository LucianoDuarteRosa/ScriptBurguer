using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using WebMvc.Context;
using Microsoft.EntityFrameworkCore;
using WebMvc.Repositories.Interfaces;
using WebMvc.Repositories;
using WebMvc.Models;
using Microsoft.AspNetCore.Identity;
using WebMvc.Services;
using ReflectionIT.Mvc.Paging;
using WebMvc.Areas.Admin.Servicos;

namespace WebMvc
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
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
              .AddEntityFrameworkStores<AppDbContext>()
              .AddDefaultTokenProviders();

            services.Configure<ConfigurationImagens>(Configuration.GetSection("ConfigurationPastaImagens"));

            //Adicionar o serviço de repository para usar o acesso a dados a uma unica classe
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<ILancheRepository, LancheRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
            services.AddScoped<RelatorioVendasService>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin",
                    politica =>
                    {
                        politica.RequireRole("Admin");
                    });
            });

            //Cria um padrao de instancia de classe sempre que precisar
            services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));

            //tempo de vida que o cookie vai ficar no local -> no caso abaixo enquanto durar a aplicação
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //para armazenar dados de cache so site(acima tempo de vida)--precisa inicialição o serviço
            services.AddMemoryCache();
            services.AddSession();
            
            services.AddControllersWithViews();

            services.AddPaging(options =>
            {
                options.ViewName = "Bootstrap4";
                options.PageParameterName = "pageindex";
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ISeedUserRoleInitial seedUserRoleInitial)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            //cria os perfis
            seedUserRoleInitial.SeedRoles();
            //cria os usuários e atribui ao perfil
            seedUserRoleInitial.SeedUsers();

            app.UseAuthentication();
            app.UseAuthorization();
            //para armazenar dados de cache so site(dados do carrinho de compras)-.aqui inicializa o serviço
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                   name: "categoriaFiltro",
                   pattern: "Lanche/{action}/{categoria?}",
                   defaults: new { Controller = "Lanche", action = "List" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
