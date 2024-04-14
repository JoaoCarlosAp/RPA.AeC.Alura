using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RPA.AeC.Alura.Infraestrutura.Curso.Modelos;

namespace RPA.AeC.Alura.Infraestrutura.Curso.Repositorio
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CursoModelo> curso { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=cursos.db");
        }
    }
}
