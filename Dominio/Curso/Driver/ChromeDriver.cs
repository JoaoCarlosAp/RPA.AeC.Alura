using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace RPA.AeC.Alura.Dominio.Curso.Driver
{
    public class ChromeDriver : IChromeDriver
    {
        private IWebDriver _driver;

        public ChromeDriver() 
        {
        }

        public IWebDriver IniciarChromeDriver()
        {
            try
            {
                ChromeOptions options = new()
                {
                    PageLoadStrategy = PageLoadStrategy.Normal
                };

                options.AddArgument("no-sandbox");
                options.AddArgument("--profile-directory=Default");
                options.AddArgument("--disable-web-security");
                options.AddArgument("--disable-gpu");
                options.AddArgument("--start-maximized");
                options.AddExcludedArgument("enable-logging");
                options.Proxy = new Proxy { Kind = ProxyKind.System };

                _driver = new OpenQA.Selenium.Chrome.ChromeDriver(options);
                _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);

                return _driver;
            }
            catch (Exception ex)
            {
                throw new Exception($"{MethodBase.GetCurrentMethod()?.Name} -> {ex.Message}");
            }
        }

        public void FinalizarChromeDriver()
        {
            try
            {
                _driver?.Dispose();
            }
            catch
            {

            }
        }

        public void LimparProcessosChrome()
        {
            try
            {
                var listDrivers = Process.GetProcessesByName("chromedriver");

                foreach (var driver in listDrivers)
                {
                    driver.Kill(true);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{MethodBase.GetCurrentMethod()?.Name} -> {ex.Message}");
            }
        }
    }
}
