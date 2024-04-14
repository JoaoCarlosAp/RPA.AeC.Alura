using Microsoft.Extensions.DependencyInjection;
using RPA.AeC.Alura.Dominio.Driver;

namespace RPA.AeC.Alura.Aplicacao
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private int _task;
        private IServiceProvider _serviceProvider;

        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
            _task = Convert.ToInt32(configuration["NumberOfTask"]);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            List<string> listaCurso = new List<string>
            {
                "RPA"
            };

            try
            {
                while (!stoppingToken.IsCancellationRequested && listaCurso.Count > 0)
                {
                    if (listaCurso.Count > 0)
                    {
                        Task[] tasks = new Task[_task];

                        for (int i = 0; i < tasks.Length && listaCurso.Count > 0; i++)
                        {
                            string categoria = listaCurso[0];
                            listaCurso.RemoveAt(0);

                            tasks[i] = Task.Factory.StartNew(() => DoWork(categoria, stoppingToken));
                        }
                        await Task.WhenAll(tasks);
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro durante a execu��o.");
            }

            _logger.LogInformation("Servi�o finalizado: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }

        private void DoWork(string categoria, CancellationToken stoppingToken) 
        {
            using IServiceScope scope = _serviceProvider.CreateScope();

            IChromeDriver _chrome = scope.ServiceProvider.GetRequiredService<IChromeDriver>();

            try
            {
                var driver = _chrome.IniciarChromeDriver();
                if (driver == null);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"ERRO -> {ex.Message}");
            }
            finally
            {
                _chrome.FinalizarChromeDriver();
            }
        }
    }
}