using ExpectedObjects;
using static CursoOnline.DominioTest.CursoTests;

namespace CursoOnline.DominioTest;

public class CursoTests
{

    /// <summary>
    /// Crit�rios de aceite
    /// 
    /// -- Criar um curso com os seguintes atributos:
    ///     Nome
    ///     Carga Horaria
    ///     Publico Alvo
    ///     Valor do Curso
    /// 
    /// -- As op��es para o p�blico alvo s�o:
    ///     Estudante
    ///     Universit�rio
    ///     Empregado
    ///     Empreendedor
    ///     
    /// -- Todos os atributos s�o obrigat�rios
    ///     

    public enum PublicoAlvo
    {
        Estudante,
        Universit�rio,
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
        //Assert.Contains(publicoAlvo, new[] { "Estudante", "Universit�rio", "Empregado", "Empreendedor" });
        //Assert.True(curso.ValorCurso > 0);

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
        this.Nome = nome;
        this.CargaHoraria = cargaHoraria;
        this.PublicoAlvo = publicoAlvo;
        this.ValorCurso = valorCurso;
    }
}