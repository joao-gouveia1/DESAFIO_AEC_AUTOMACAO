namespace CapturaCursoRPA.Dominio.Entities
{
    public class Curso
    {
        public int IdCaptura { get; set; }
        public string Titulo { get; set; }
        public string NomeProfessor { get; set; }
        public string CargaHoraria { get; set; }
        public string Descricao { get; set; }

        public Curso() { }

        public Curso(string titulo, string nomeProcessor, string cargaHoraria, string descricao) 
        {
            this.Titulo = titulo;
            this.NomeProfessor = nomeProcessor;
            this.CargaHoraria = cargaHoraria;
            this.Descricao = descricao;
        }

        public string ExibirParametros()
        {
            return $"ID: {this.IdCaptura} - Titulo: {this.Titulo} - Nome Professor: {this.NomeProfessor} - Carga Horária: {this.CargaHoraria} - Descrição: {this.Descricao}";
        }
    }
}