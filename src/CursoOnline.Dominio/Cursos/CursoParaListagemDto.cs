namespace CursoOnline.Dominio.Cursos
{
    public class CursoParaListagemDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal CargaHoraria { get; set; }
        public string PublicoAlvo { get; set; }
        public decimal Valor { get; set; }
    }
}