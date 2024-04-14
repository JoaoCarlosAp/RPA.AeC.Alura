using RPA.AeC.Alura.Aplicacao;
using RPA.AeC.Alura.Dominio.Curso.Crawler;
using RPA.AeC.Alura.Dominio.Curso.Driver;
using RPA.AeC.Alura.Infraestrutura.Curso.Modelos;
using RPA.AeC.Alura.Infraestrutura.Curso.Repositorio;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddScoped<IChromeDriver, ChromeDriver>();
        services.AddScoped<ICursoCrawler, CursoCrawler>();
        services.AddScoped<ICursoRepositorio<CursoModelo>, CursoRepositorio<CursoModelo>>();
        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();
