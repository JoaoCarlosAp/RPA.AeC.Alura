using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPA.AeC.Alura.Dominio.Curso.Driver
{
    public interface IChromeDriver
    {
        public IWebDriver IniciarChromeDriver();
        public void FinalizarChromeDriver();
        public void LimparProcessosChrome();
    }
}
