using OpenQA.Selenium;
using RPA.AeC.Alura.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPA.AeC.Alura.Dominio.Crawler
{
    public interface ICursoCrawler
    {
        public List<CursoEntidade> ConsultarCursos(IWebDriver driver, string cursoPesquisado);
    }
}
