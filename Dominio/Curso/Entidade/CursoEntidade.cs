using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPA.AeC.Alura.Dominio.Curso.Entidade
{
    public class CursoEntidade
    {
        private string _titulo;
        private string _professor;
        private string _cargaHoraria;
        private string _descricao;

        public CursoEntidade(string titulo, string professor, string cargaHoraria, string descricao)
        {
            _titulo = titulo;
            _professor = professor;
            _cargaHoraria = cargaHoraria;
            _descricao = descricao;
            Validar();
        }

        public string Titulo
        {
            get { return _titulo; }
        }
        public string Professor
        {
            get { return _professor; }
        }
        public string CargaHoraria
        {
            get { return _cargaHoraria; }
        }
        public string Descricao
        {
            get { return _descricao; }
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Titulo))
                throw new InvalidOperationException("Título nulo.");

            if (string.IsNullOrEmpty(Descricao))
                throw new InvalidOperationException("Descriçao nula.");

            if (string.IsNullOrEmpty(CargaHoraria))
                throw new InvalidOperationException("Carga Horária nula.");

            if (string.IsNullOrEmpty(Professor))
                throw new InvalidOperationException("Professor não nulo.");
        }
    }
}
