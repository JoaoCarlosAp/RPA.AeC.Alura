using RPA.AeC.Alura.Dominio.Curso.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPA.AeC.Alura.Infraestrutura.Curso.Repositorio
{
    public interface ICursoRepositorio<TEntity>
    {
        void InserirCurso(List<CursoEntidade> listaCursos, string categoria);
    }
}
