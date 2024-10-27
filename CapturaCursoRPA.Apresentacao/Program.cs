using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using CapturaCursoRPA.Infraestrutura.Data;
using CapturaCursoRPA.Dominio.Repositories;
using CapturaCursoRPA.Infraestrutura.Repositories;
using CapturaCursoRPA.AplicacaoRPA.Interfaces;
using CapturaCursoRPA.Infraestrutura.Services;
using CapturaCursoRPA.AplicacaoRPA.Services;
using CapturaCursoRPA.Dominio.Entities;
using System;

namespace CapturaCursoRPA.Apresentacao
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var services = new ServiceCollection();

            //// Configura o DbContext com SQLite
            //services.AddDbContext<RPADbContext>(options => options.UseSqlite("Data Source=automacao.db"));

            //// Registra os repositórios e serviços para injeção de dependência
            //services.AddScoped<ICursoRepository, CursoRepository>();
            //services.AddScoped<IBrowserDriver, WebDriverManager>();
            //services.AddScoped<CapturaCursoService>();
            //services.AddScoped<CursoService>();
            //services.AddScoped<Curso>();

            //// Se o argumento "migrar" não estiver presente, executa a automação
            //if (args.Length == 0 || args[0] != "migrar")
            //{
            //    // Cria o provider de serviço
            //    var serviceProvider = services.BuildServiceProvider();

            //    // Usa o serviço
            //    var cursoService = serviceProvider.GetService<CapturaCursoService>();
            //    cursoService.CapturarCurso();
            //}



            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddDbContext<RPADbContext>(options =>
                        options.UseSqlite("Data Source=automacao.db"));

                    services.AddScoped<ICursoRepository, CursoRepository>();
                    services.AddScoped<IBrowserDriver, WebDriverManager>();
                    services.AddScoped<CapturaCursoService>();
                    services.AddScoped<CursoService>();
                    services.AddScoped<Curso>();
                })
                .Build();

            // Se o argumento "migrar" não estiver presente, executa a automação
            if (args.Length == 0 || args[0] != "migrar")
            {
                // Resolvendo o serviço e executando a captura de informações
                var capturaService = host.Services.GetRequiredService<CapturaCursoService>();
                capturaService.CapturarCurso();
            }



            //var optionsBuilder = new DbContextOptionsBuilder<RPADbContext>();
            //optionsBuilder.UseSqlite("Data Source=CapturaCursoRPA.db");

            //using (var context = new RPADbContext(optionsBuilder.Options))
            //{
            //    context.Database.Migrate();
            //}

            //var serviceProvider = new ServiceCollection()
            //    .AddDbContext<RPADbContext>(options => options.UseSqlite("Data Source=CapturaCursoRPA.db"))
            //    .BuildServiceProvider();

            //using (var context = serviceProvider.GetRequiredService<RPADbContext>())
            //{
            //    context.Database.Migrate();
            //}
        }
    }
}