using RPA.AeC.Alura.Aplicacao;
using RPA.AeC.Alura.Dominio.Curso.Crawler;
using RPA.AeC.Alura.Dominio.Curso.Driver;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddScoped<IChromeDriver, ChromeDriver>();
        services.AddScoped<ICursoCrawler, CursoCrawler>();
        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();
