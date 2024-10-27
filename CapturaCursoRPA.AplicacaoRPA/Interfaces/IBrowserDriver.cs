namespace CapturaCursoRPA.AplicacaoRPA.Interfaces
{
    public interface IBrowserDriver
    {
        void AcessarUrl(string url);
        void ClicarElementoPorId(string id);
        void ClicarElementoPorCSS(string css);
        void ClicarElementoPorXPath(string xpath);
        void EnviarTextoPorId(string id, string textoDigitar);
        void EnviarTextoPorCSS(string css, string textoDigitar);
        void EnviarTextoPorXPath(string xpath, string textoDigitar);
        string CapturarTextoPorId(string id);
        string CapturarTextoPorCSS(string css);
        string CapturarTextoPorXPath(string xpath);
        void EnviarSubmitPorId(string id);
        void EnviarSubmitPorCSS(string css);
        void EnviarSubmitPorXPath(string xpath);
        bool VerificarElementoExistePorId(string id);
        bool VerificarElementoExistePorCSS(string css);
        bool VerificarElementoExistePorXPath(string xpath);
        void EncerrarWebDriver();        
    }
}
