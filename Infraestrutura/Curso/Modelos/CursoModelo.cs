using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPA.AeC.Alura.Infraestrutura.Curso.Modelos
{
    public class CursoModelo
    {
        [Key]
        public int Id               { get; set; }
        public string Titulo        { get; set; } = string.Empty;
        public string Descricao     { get; set; } = string.Empty;
        public string Professor     { get; set; } = string.Empty;
        public string CargaHoraria  { get; set; } = string.Empty;
        public string Categoria     { get; set; } = string.Empty;
        public DateTime DataConslta { get; set; } = DateTime.Now;
    }
}
