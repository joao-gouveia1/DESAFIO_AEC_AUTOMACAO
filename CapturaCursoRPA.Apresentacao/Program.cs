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

namespace CapturaCursoRPA.Apresentacao
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Cria host para acessar o banco de dados e realizar as injeções de dependências
            var host = CreateHostBuilder(args).Build();

            // Se o argumento "migrar" não estiver presente, executa a automação.
            // Para não executar tudo em tempo de design das migrações
            if (args.Length == 0 || args[0] != "migrar")
            {
                // Resolvendo o serviço e executando a captura de informações
                var capturaService = host.Services.GetRequiredService<CapturaCursoService>();                
                capturaService.CapturarCurso();
                // Mostrar no console as capturas
                capturaService.MostrarTodosCursos();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    // Verifica e cria o diretório se necessário
                    var databasePath = Path.Combine(Directory.GetCurrentDirectory(), "BancoDeDados");
                    if (!Directory.Exists(databasePath))
                    {
                        Directory.CreateDirectory(databasePath);
                    }
                    databasePath = Path.Combine(databasePath, "automacao.db");

                    services.AddDbContext<RPADbContext>(options =>
                        options.UseSqlite($"Data Source={databasePath}"));

                    services.AddScoped<ICursoRepository, CursoRepository>();
                    services.AddScoped<IBrowserDriver, WebDriverManager>();
                    services.AddScoped<CapturaCursoService>();
                    services.AddScoped<CursoService>();
                    services.AddScoped<Curso>();
                });
    }
}