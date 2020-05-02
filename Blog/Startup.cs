using Blog.Models.Blog.Autor;
using Blog.Models.Blog.Categoria;
using Blog.Models.Blog.Etiqueta;
using Blog.Models.Blog.Postagem;
using Blog.Models.ControleDeAcesso;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Blog
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

            // Adicionar o serviço do mecanismo de controle de acesso
            services.AddIdentity<Usuario, Papel>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 6;

            }).AddEntityFrameworkStores<DatabaseContext>();

            // Adicionar o serviço do banco de dados
            services.AddDbContext<DatabaseContext>();

            // Adicionar os serviços de ORM das entidades do domínio, AddTransient instancia novo obj a cada chamada
            services.AddTransient<CategoriaOrmService>();
            services.AddTransient<PostagemOrmService>();
            services.AddTransient<AutorOrmService>();
            services.AddTransient<EtiquetaOrmService>();

            // Adicionar os serviços que possibilitam o funcionamento dos controllers e das views
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();



            //Configuração de rotas
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                /*
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                */

                // Rotas da Área Comum
                endpoints.MapControllerRoute(
                    name: "comum",
                    pattern: "/",
                    defaults: new { controller = "Home", action = "Index" }
                );

                // Rotas da Área Administrativa
                endpoints.MapControllerRoute(
                    name: "admin.categorias",
                    pattern: "admin/categorias/{action}/{id?}",
                    defaults: new { controller = "AdminCategorias", action = "Listar" }
                );

                /*
                endpoints.MapControllerRoute(
                    name: "admin.autores",
                    pattern: "admin/autores/{action}/{id?}",
                    defaults: new { controller = "AdminAutores", action = "Listar"}
                );
                */
            });


        }
    }
}