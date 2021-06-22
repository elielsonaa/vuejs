using controlvac.Models;
using Microsoft.EntityFrameworkCore;

namespace controlvac.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) {}

        //Sentando Models que fará a composição da estrutura de dados criada pelo EntityFramework
        public DbSet<Vacina> Vacinas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Vacinacao> Vacinacoes { get; set; }

    }
}