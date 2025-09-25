using CursoOnline.Dados.Contextos;
using CursoOnline.Dados.Repositorios;
using CursoOnline.Dominio._Base;
using CursoOnline.Dominio.Alunos;
using CursoOnline.Dominio.Cursos;
using CursoOnline.Dominio.Matriculas;
using CursoOnline.Dominio.PublicosAlvo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CursoOnline.Ioc
{
    public static class StartupIoc
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // 🔹 Registrar o DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            // 🔹 Repositórios genéricos e específicos
            services.AddScoped(typeof(IRepositorio<>), typeof(RepositorioBase<>));
            services.AddScoped<ICursoRepositorio, CursoRepositorio>();
            //services.AddScoped<IAlunoRepositorio, AlunoRepositorio>();
            //services.AddScoped<IMatriculaRepositorio, MatriculaRepositorio>();

            // 🔹 Unit of Work
            //services.AddScoped<IUnitOfWork, UnitOfWork>();

            // 🔹 Conversor de Público-Alvo
            services.AddScoped<IConversorDePublicoAlvo, ConversorDePublicoAlvo>();

            //    // 🔹 Armazenadores / Services de aplicação
            services.AddScoped<ArmazenadorDeCurso>();
            //    services.AddScoped<ArmazenadorDeAluno>();
            //    services.AddScoped<CriacaoDaMatricula>();
            //    services.AddScoped<ConclusaoDaMatricula>();
            //    services.AddScoped<CancelamentoDaMatricula>();
        }
    }
}
