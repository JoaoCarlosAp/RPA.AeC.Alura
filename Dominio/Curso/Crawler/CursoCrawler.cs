using OpenQA.Selenium;
using RPA.AeC.Alura.Dominio.Curso.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RPA.AeC.Alura.Dominio.Curso.Crawler
{
    public class CursoCrawler : ICursoCrawler
    {
        private string _url;
        private ILogger<CursoCrawler> _logger;

        public CursoCrawler(ILogger<CursoCrawler> logger, IConfiguration configuration)
        {
            _logger = logger;
            _url = configuration["Url"]?.ToString();
        }

        public List<CursoEntidade> ConsultarCursos(IWebDriver driver, string cursoPesquisado)
        {
            try
            {
                List<CursoEntidade> cursos = new List<CursoEntidade>();

                driver.Navigate().GoToUrl($"{_url}/busca?query={cursoPesquisado}");

                var resultado = driver.FindElement(By.XPath("//*[@id=\"busca-resultados\"]"));

                if (!resultado.ToString().Contains("Elemento não encontrado"))
                {
                    var paginas = driver.FindElements(By.XPath("//*[@id=\"busca\"]/nav/nav/a"));
                    foreach (var pagina in paginas)
                    {
                        try
                        {
                            string id = pagina?.Text;
                            if (!pagina.GetAttribute("class").Contains("selecionado"))
                            {
                                var pageIndex = driver.FindElement(By.XPath($"//*[@href=\"/busca?pagina={id}&query={cursoPesquisado}\"]"));
                                pageIndex.Click();
                            }

                            var cursosEncontrados = driver.FindElements(By.XPath("//*[@id=\"busca-resultados\"]/ul/li"));
                            PegarInformacoesCurso(ref cursos, cursosEncontrados, driver);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, $"ERRO: {ex.Message}");
                        }
                    }
                }

                return cursos;
            }
            catch (Exception ex)
            {
                throw new Exception($"{MethodBase.GetCurrentMethod()?.Name} -> {ex.Message}");
            }
        }

        private void PegarInformacoesCurso(ref List<CursoEntidade> cursos, IReadOnlyCollection<IWebElement> cursosEncontrados, IWebDriver driver)
        {
            foreach (var selecionado in cursosEncontrados)
            {
                try
                {
                    string titulo = selecionado.FindElement(By.ClassName("busca-resultado-nome")).Text;
                    string descricao = selecionado.FindElement(By.ClassName("busca-resultado-descricao")).Text;
                    string url = selecionado.FindElement(By.TagName("a")).GetAttribute("href");

                    if (!string.IsNullOrEmpty(url))
                    {
                        driver.SwitchTo().NewWindow(WindowType.Tab);
                        driver.Navigate().GoToUrl(url);

                        string professor = PegarElemento(driver, By.ClassName("instructor-title--name"));
                        string cargaHoraria = PegarElemento(driver, By.ClassName("courseInfo-card-wrapper-infos"));
                        var curso = new CursoEntidade(titulo, descricao, professor, cargaHoraria);

                        if (driver.WindowHandles.Count > 0)
                        {
                            driver.Close();
                            Thread.Sleep(TimeSpan.FromMilliseconds(300));

                            driver.SwitchTo().Window(driver.WindowHandles.First());
                            Thread.Sleep(TimeSpan.FromMilliseconds(300));
                        }

                        cursos.Add(curso);

                        Thread.Sleep(TimeSpan.FromSeconds(3));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"{ex.Message}");
                }
            }
        }

        private string PegarElemento(IWebDriver driver, By selector)
        {
            try
            {
                IWebElement element = driver.FindElement(selector);
                return element.Text ?? "N/A";
            }
            catch (NoSuchElementException)
            {
                return "N/A";
            }
        }
    }
}
