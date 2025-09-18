using CursoOnline.Dominio;
using CursoOnline.Dominio.Cursos;
using CursoOnline.Dominio.PublicosAlvo;
using CursoOnline.DominioTest.Cursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CursoOnline.DominioTest.Cursos.CursoTests;

namespace CursoOnline.DominioTest._Builder;

internal class CursoBuilder
{
    private string _nome = "Curso de Testes";
    private string _descricao = "Descrição do curso de testes";
    private int _cargaHoraria = 40;
    private PublicoAlvo _publicoAlvo = PublicoAlvo.Estudante;
    private decimal _valorCurso = 199.99m;

    public static CursoBuilder Novo()
    {
        return new CursoBuilder();
    }
    public CursoBuilder ComNome(string nome)
    {
        _nome = nome;
        return this;
    }
    public CursoBuilder ComNomeVazio()
    {
        _nome = string.Empty;
        return this;
    }
    public CursoBuilder ComDescricao(string descricao)
    {
        _descricao = descricao;
        return this;
    }
    public CursoBuilder ComCargaHoraria(int cargaHoraria)
    {
        _cargaHoraria = cargaHoraria;
        return this;
    }
    public CursoBuilder ComPublicoAlvo(PublicoAlvo publicoAlvo)
    {
        _publicoAlvo = publicoAlvo;
        return this;
    }
    public CursoBuilder ComValorCurso(decimal valorCurso)
    {
        _valorCurso = valorCurso;
        return this;
    }

    public Curso Build()
    {
        return new Curso(_nome, _descricao, _cargaHoraria, _publicoAlvo, _valorCurso);
    }

}
