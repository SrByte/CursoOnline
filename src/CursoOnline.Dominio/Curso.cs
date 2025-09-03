namespace CursoOnline.Dominio;

public enum PublicoAlvo
{
    Estudante,
    Universitário,
    Empregado,
    Empreendedor
}
public class Curso
{
    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public int CargaHoraria { get; private set; }
    public PublicoAlvo PublicoAlvo { get; private set; }
    public decimal ValorCurso { get; private set; }

    public Curso(string nome, string descricao, int cargaHoraria, PublicoAlvo publicoAlvo, decimal valorCurso)
    {
        if (string.IsNullOrEmpty(nome))
            throw new ArgumentException("Nome do curso é obrigatório");
        if (cargaHoraria < 1)
            throw new ArgumentException("Carga horária deve ser maior que zero");

        Nome = nome;
        Descricao = descricao;
        CargaHoraria = cargaHoraria;
        PublicoAlvo = publicoAlvo;
        ValorCurso = valorCurso;
    }
}