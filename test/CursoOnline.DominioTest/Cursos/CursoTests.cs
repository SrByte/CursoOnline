using CursoOnline.DominioTest._Utils;
using ExpectedObjects;
using static CursoOnline.DominioTest.Cursos.CursoTests;

namespace CursoOnline.DominioTest.Cursos;

public class CursoTests
{

    /// <summary>
    /// Critérios de aceite
    /// 
    /// -- Criar um curso com os seguintes atributos:
    ///     Nome
    ///     Carga Horaria
    ///     Publico Alvo
    ///     Valor do Curso
    /// 
    /// -- As opções para o público alvo são:
    ///     Estudante
    ///     Universitário
    ///     Empregado
    ///     Empreendedor
    ///     
    /// -- Todos os atributos são obrigatórios
    ///     

    public enum PublicoAlvo
    {
        Estudante,
        Universitário,
        Empregado,
        Empreendedor
    }

    [Fact]
    public void DeveCriarCurso()
    {
        // Arrange
        var cursoEsperado = new
        {
            Nome = "Curso de Testes",
            CargaHoraria = 40,
            PublicoAlvo = PublicoAlvo.Estudante,
            ValorCurso = 199.99m
        };

        // Act
        var curso = new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.ValorCurso);

        // Assert
        cursoEsperado.ToExpectedObject().ShouldMatch(curso);

        //Assert.Equal(nome, curso.Nome);
        //Assert.Equal(cargaHoraria, curso.CargaHoraria);
        //Assert.Equal(publicoAlvo, curso.PublicoAlvo);
        //Assert.Equal(valorCurso, curso.ValorCurso);
        //Assert.NotNull(curso);
        //Assert.NotEmpty(curso.Nome);
        //Assert.True(curso.CargaHoraria > 0);
        //Assert.Contains(publicoAlvo, new[] { "Estudante", "Universitário", "Empregado", "Empreendedor" });
        //Assert.True(curso.ValorCurso > 0);

    }
    [Fact]
    public void NaoDeveCriarCursoComNomeVazio()
    {
        // Arrange
        var cursoEsperado = new
        {
            Nome = "Curso de Testes",
            CargaHoraria = 40,
            PublicoAlvo = PublicoAlvo.Estudante,
            ValorCurso = 199.99m
        };

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
        new Curso(string.Empty, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.ValorCurso))
            .ComMensagem("Nome do curso é obrigatório");
    }
    [Theory]
    [InlineData(0)]
    [InlineData(-100)]
    public void NaoDeveCriarCursoTerUmaCargaMenorQueHum(int cargaHorariaInvalida)
    {
        // Arrange
        var cursoEsperado = new
        {
            Nome = "Curso de Testes",
            CargaHoraria = 10,
            PublicoAlvo = PublicoAlvo.Estudante,
            ValorCurso = 199.99m
        };

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
        new Curso(cursoEsperado.Nome, cargaHorariaInvalida, cursoEsperado.PublicoAlvo, cursoEsperado.ValorCurso))
            .ComMensagem("Carga horária deve ser maior que zero");
    }
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void NaoDeveCursoTerNomeInvalido(string nomeInvalido)
    {
        // Arrange
        var cursoEsperado = new
        {
            Nome = "Curso de Testes",
            CargaHoraria = 40,
            PublicoAlvo = PublicoAlvo.Estudante,
            ValorCurso = 199.99m
        };
        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
         new Curso(nomeInvalido, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.ValorCurso));
    }

}


internal class Curso
{
    public string Nome { get; private set; }
    public int CargaHoraria { get; private set; }
    public PublicoAlvo PublicoAlvo { get; private set; }
    public decimal ValorCurso { get; private set; }

    public Curso(string nome, int cargaHoraria, PublicoAlvo publicoAlvo, decimal valorCurso)
    {
        if (string.IsNullOrEmpty(nome))
            throw new ArgumentException("Nome do curso é obrigatório");
        if (cargaHoraria < 1)
            throw new ArgumentException("Carga horária deve ser maior que zero");

        Nome = nome;
        CargaHoraria = cargaHoraria;
        PublicoAlvo = publicoAlvo;
        ValorCurso = valorCurso;
    }
}