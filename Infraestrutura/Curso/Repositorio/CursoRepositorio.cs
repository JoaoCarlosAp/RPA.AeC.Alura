using RPA.AeC.Alura.Dominio.Curso.Entidade;
using RPA.AeC.Alura.Infraestrutura.Curso.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPA.AeC.Alura.Infraestrutura.Curso.Repositorio
{
    public class CursoRepositorio<TEntity> : ICursoRepositorio<TEntity> where TEntity : class
    {
        public void InserirCurso(List<CursoEntidade> listaCursos, string categoria)
        {
            using (var context = new ApplicationDbContext())
            {
                foreach (var curso in listaCursos)
                {
                    var novoCurso = new CursoModelo
                    {
                        Titulo          = curso.Titulo,
                        Descricao       = curso.Descricao,
                        Professor       = curso.Professor,
                        CargaHoraria    = curso.CargaHoraria,
                        Categoria       = categoria
                    };

                    context.curso.Add(novoCurso);
                    context.SaveChanges();
                }
            }
        }
    }
}
