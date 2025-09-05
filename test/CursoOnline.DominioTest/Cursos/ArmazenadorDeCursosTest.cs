using Bogus;
using CursoOnline.Dominio;
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
                PublicoAlvoId = 1,
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

        public interface ICursoRepositorio
        {
            void Adicionar(Curso curso);
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
              var curso = new Curso(
                    cursoDto.Nome,
                    cursoDto.Descricao,
                    cursoDto.CargaHoraria,
                    PublicoAlvo.Universitário,
                    cursoDto.ValorCurso
                );
                _cursoRepositorio.Adicionar(curso);
            }
        }
    }
}
