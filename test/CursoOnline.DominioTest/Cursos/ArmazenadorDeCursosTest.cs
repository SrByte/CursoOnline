using Bogus;
using CursoOnline.Dominio;
using CursoOnline.Dominio.Cursos;
using CursoOnline.Dominio.PublicosAlvo;
using CursoOnline.DominioTest._Builder;
using CursoOnline.DominioTest._Utils;
using Moq;

namespace CursoOnline.DominioTest.Cursos
{
    public class ArmazenadorDeCursosTest
    {
        private CursoDto _cursoDto;
        private Mock<ICursoRepositorio> _cursoRepositorioMock;
        private ArmazenadorDeCurso _armazenadorDeCurso;

        public ArmazenadorDeCursosTest()
        {
            var fake=new Faker();

            _cursoDto = new CursoDto
            {
                Nome = fake.Random.Words(),
                Descricao = fake.Lorem.Paragraphs(),
                CargaHoraria = fake.Random.Int(1,120),
                PublicoAlvo = "Estudante",
                ValorCurso = fake.Random.Decimal(1,1000)
            };
            
            _cursoRepositorioMock = new Mock<ICursoRepositorio>();

            _armazenadorDeCurso = new ArmazenadorDeCurso(_cursoRepositorioMock.Object);

        }

        [Fact]
        public void DeveArmazenarCurso()
        {
            _armazenadorDeCurso.Armazenar(_cursoDto);


            //cursoRepositorioMock.Verify(r => r.Adicionar(It.IsAny<Curso>()),Times.AtLeastOnce);
            _cursoRepositorioMock.Verify(r => r.Adicionar(It.Is<Curso>(c => c.Nome == _cursoDto.Nome)));
        }
        [Fact]
        public void NaoDeveInformarPublicoAlvoInvalido()
        {
            var publicoAlvoInvalido = "Médico";
            _cursoDto.PublicoAlvo = publicoAlvoInvalido;

           Assert.Throws<ArgumentException>(() => _armazenadorDeCurso.Armazenar(_cursoDto))
                .ComMensagem("Público alvo inválido");
        }
        [Fact]
        public void NaoDeveArmazenarCursoComMesmoNomeDeOutroJaSalvo()
        {
            var cursoJaSalvo = CursoBuilder.Novo().ComNome(_cursoDto.Nome).Build();
            _cursoRepositorioMock.Setup(r => r.ObterPorNome(_cursoDto.Nome)).Returns(cursoJaSalvo);


            Assert.Throws<ArgumentException>(() => _armazenadorDeCurso.Armazenar(_cursoDto))
                .ComMensagem($"Já existe um curso com o nome {_cursoDto.Nome} cadastrado");

        }
    }
        public class ArmazenadorDeCurso
        {
            private readonly ICursoRepositorio _cursoRepositorio;
            public ArmazenadorDeCurso(ICursoRepositorio @object)
            {
                _cursoRepositorio = @object;
            }

            public void Armazenar(CursoDto cursoDto)
            {

                var cursoJaSalvo = _cursoRepositorio.ObterPorNome(cursoDto.Nome);
                if (cursoJaSalvo != null)
                    throw new ArgumentException($"Já existe um curso com o nome {cursoDto.Nome} cadastrado");

                Enum.TryParse(typeof(PublicoAlvo),cursoDto.PublicoAlvo, out var publicoAlvo);

                if (publicoAlvo == null)
                    throw new ArgumentException("Público alvo inválido");

                var curso = new Curso(
                    cursoDto.Nome,
                    cursoDto.Descricao,
                    cursoDto.CargaHoraria,
                    (PublicoAlvo)publicoAlvo,
                    cursoDto.ValorCurso
                );
                _cursoRepositorio.Adicionar(curso);
            }
        }
    public interface ICursoRepositorio
    {
        void Adicionar(Curso curso);
        Curso ObterPorNome(string nome);
    }
}
