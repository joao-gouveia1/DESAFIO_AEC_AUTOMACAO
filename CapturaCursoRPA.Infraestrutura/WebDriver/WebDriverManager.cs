using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CapturaCursoRPA.AplicacaoRPA.Interfaces;
using OpenQA.Selenium.Support.UI;

namespace CapturaCursoRPA.Infraestrutura.Services
{
    public class WebDriverManager : IBrowserDriver
    {
        private readonly IWebDriver _webDriver;

        public WebDriverManager() 
        {
            try
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--start-maximized");

                _webDriver = new ChromeDriver(options);
            }
            catch (Exception e)
            {
                throw new Exception($"Falha ao abrir navegador Chrome", e);
            }
        }

        public void EncerrarWebDriver()
        {
            _webDriver?.Quit();
        }

        public void AcessarUrl(string url)
        {
            try
            {
                _webDriver.Navigate().GoToUrl(url);
            }
            catch (Exception e)
            {
                throw new Exception($"Falha ao acessar a URL {url}", e);
            }
        }

        public string CapturarTextoPorId(string id)
        {
            return CapturarTexto(id, "id");
        }

        public string CapturarTextoPorXPath(string xpath)
        {
            return CapturarTexto(xpath, "xpath");
        }

        public string CapturarTextoPorCSS(string css)
        {
            return CapturarTexto(css, "css");
        }

        private string CapturarTexto(string seletor, string tipoSeletor)
        {
            IWebElement elemento = EncontrarElemento(seletor, tipoSeletor);
            return elemento.Text;
        }

        public void ClicarElementoPorId(string id)
        {
            ClicarElemento(id, "id");
        }

        public void ClicarElementoPorXPath(string xpath)
        {
            ClicarElemento(xpath, "xpath");
        }

        public void ClicarElementoPorCSS(string css)
        {
            ClicarElemento(css, "css");
        }

        private void ClicarElemento(string seletor, string tipoSeletor)
        {
            IWebElement elemento = EncontrarElemento(seletor, tipoSeletor);
            elemento.Click();
        }

        public void EnviarTextoPorId(string id, string textoDigitar)
        {
            EnviarTexto(id, "id", textoDigitar);
        }

        public void EnviarTextoPorCSS(string css, string textoDigitar)
        {
            EnviarTexto(css, "css", textoDigitar);
        }

        public void EnviarTextoPorXPath(string xpath, string textoDigitar)
        {
            EnviarTexto(xpath, "xpath", textoDigitar);
        }

        private void EnviarTexto(string seletor, string tipoSeletor, string textoDigitar)
        {
            IWebElement elemento = EncontrarElemento(seletor, tipoSeletor);
            elemento.Clear();
            elemento.SendKeys(textoDigitar);
        }

        private IWebElement EncontrarElemento(string seletor, string tipoSeletor)
        {
            IWebElement elemento = null;
            
            try
            {
                By by = null;
                WebDriverWait aguardar = new(_webDriver, TimeSpan.FromSeconds(15));

                switch (tipoSeletor.ToLower())
                {
                    case "id":
                        by = By.Id(seletor);
                        break;
                    case "xpath":
                        by = By.XPath(seletor);
                        break;
                    case "css":
                        by = By.CssSelector(seletor);
                        break;
                    default:
                        break;
                }

                aguardar.Until(e => e.FindElement(by)); // Aguardar no máximo 15 segundos para o elemento ficar acessível
                elemento = _webDriver.FindElement(by);  // Capturar elemento
            }
            catch (Exception e)
            {
                throw new Exception($"Elemento com seletor '{seletor}' não encontrado.", e);
            }

            return elemento;
        }

        public void EnviarSubmitPorId(string id)
        {
            EnviarSubmit(id, "id");
        }

        public void EnviarSubmitPorCSS(string css)
        {
            EnviarSubmit(css, "css");
        }

        public void EnviarSubmitPorXPath(string xpath)
        {
            EnviarSubmit(xpath, "xpath");
        }

        private void EnviarSubmit(string seletor, string tipoSeletor)
        {
            IWebElement elemento = EncontrarElemento(seletor, tipoSeletor);
            elemento.Submit();
        }

        public bool VerificarElementoExistePorId(string id)
        {
            return VerificarElementoExiste(id, "id");
        }

        public bool VerificarElementoExistePorCSS(string css)
        {
            return VerificarElementoExiste(css, "css");
        }

        public bool VerificarElementoExistePorXPath(string xpath)
        {
            return VerificarElementoExiste(xpath, "xpath");
        }

        private bool VerificarElementoExiste(string seletor, string tipoSeletor)
        {
            try
            {
                By by = null;
                WebDriverWait aguardar = new(_webDriver, TimeSpan.FromSeconds(5));

                switch (tipoSeletor.ToLower())
                {
                    case "id":
                        by = By.Id(seletor);
                        break;
                    case "xpath":
                        by = By.XPath(seletor);
                        break;
                    case "css":
                        by = By.CssSelector(seletor);
                        break;
                    default:
                        break;
                }

                aguardar.Until(e => e.FindElement(by));

                return true;
            }
            catch (Exception)
            {
                return false;
            }            
        }
    }
}
