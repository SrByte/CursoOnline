using Bogus;
using CursoOnline.Dominio;
using CursoOnline.Dominio.Cursos;
using CursoOnline.Dominio.PublicosAlvo;
using CursoOnline.DominioTest._Builder;
using CursoOnline.DominioTest._Utils;
using ExpectedObjects;
using Xunit.Abstractions;

namespace CursoOnline.DominioTest.Cursos;

public class CursoTests : IDisposable
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly string _nome;
    private string _descricao;
    private int _cargaHoraria;
    private readonly PublicoAlvo _publicoAlvo;
    private decimal _valorCurso;

    public CursoTests(ITestOutputHelper testOutputHelper)
    {
        _nome= "Curso de Testes";
        _descricao = "Descri��o do curso de testes";
        _cargaHoraria = 40;
        _publicoAlvo = PublicoAlvo.Estudante;
        _valorCurso = 199.99m;
        
        _testOutputHelper = testOutputHelper;
        _testOutputHelper.WriteLine("Construtor de CursoTests");
        var faker = new Faker();
        _testOutputHelper.WriteLine($"{faker.Company.CompanyName()}");

    }
    public void Dispose()
    {
        _testOutputHelper.WriteLine("Dispose sendo executado");

    }
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

 

    [Fact]
    public void DeveCriarCurso()
    {
        // Arrange
        var cursoEsperado = new
        {
            Nome = _nome,
            Descricao = _descricao,
            CargaHoraria = _cargaHoraria,
            PublicoAlvo = _publicoAlvo,
            ValorCurso = 199.99m
        };

        // Act
        var curso = new Curso(cursoEsperado.Nome, cursoEsperado.Descricao, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.ValorCurso);

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
    [Fact]
    public void NaoDeveCriarCursoComNomeVazio()
    {
        
        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
       CursoBuilder.Novo().ComNomeVazio().Build())
            .ComMensagem("Nome do curso � obrigat�rio");
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(-100)]
    public void NaoDeveCriarCursoTerUmaCargaMenorQueHum(int cargaHorariaInvalida)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
        CursoBuilder.Novo().ComCargaHoraria(cargaHorariaInvalida).Build())
            .ComMensagem("Carga hor�ria deve ser maior que zero");
    }
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void NaoDeveCursoTerNomeInvalido(string nomeInvalido)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
         CursoBuilder.Novo().ComNome(nomeInvalido).Build());
    }


}

