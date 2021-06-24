using System.Linq;
using System.Threading.Tasks;
using controlvac.Models;
using Microsoft.EntityFrameworkCore;

namespace controlvac.Data
{
    public class Repository : IRepository //Implementando os metodos do Repositório 
    {
        public DataContext _context { get; }
        public Repository(DataContext context)
        {
            //Definindo o contexto via injeção de dependencia
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        //Buscas referentes a vacina
        public async Task<Vacina[]> GetVacinasAsync()
        {
            IQueryable<Vacina> query = _context.Vacinas;
            query = query
                         .OrderBy(v => v.Id);
            return await query.ToArrayAsync();
        }
        public async Task<Vacina> GetVacinaByIdAsync(int id)
        {
            IQueryable<Vacina> query = _context.Vacinas;
            query = query.OrderBy(v => v.Id)
                         .Where(v => v.Id == id);
            return await query.FirstOrDefaultAsync();

        }
        //Buscas referentes a Pacientes
        public async Task<Paciente[]> GetPacientesAsync()
        {
            IQueryable<Paciente> query = _context.Pacientes;
            IQueryable<Vacinacao> query2 = _context.Vacinacoes;
            query = query.AsNoTracking()
                         .OrderBy(v => v.Id);
            //.Union(query2, p => p.Id, v => v.PacienteId, (p, v) => new { p, v });
            return await query.ToArrayAsync();
        }

        public async Task<Paciente> GetPacienteByIdAsync(int id)
        {
            IQueryable<Paciente> query = _context.Pacientes;
            query = query.AsNoTracking()
                         .OrderBy(p => p.Id)
                         .Where(p => p.Id == id);
                         //Falta juntar as vacinações
            return await query.FirstOrDefaultAsync();
        }
        //Buscas referentes a Vacinacao
        public async Task<Vacinacao[]> GetVacinacaoAsync()
        {
            IQueryable<Vacinacao> query = _context.Vacinacoes;
            query = query.Include(p => p.Paciente)
                         .AsNoTracking()
                         .Include(v => v.Vacina)
                         .AsNoTracking()
                         .OrderBy(v => v.Id);
            return await query.ToArrayAsync();
        }
        public async Task<Vacinacao> GetVacinacaoByIdAsync(int id)
        {
            IQueryable<Vacinacao> query = _context.Vacinacoes;
            query = query.Include(v => v.Paciente);
            
            query = query.AsNoTracking()
                         .OrderBy(p => p.Id)
                         .Where(p => p.Id == id);
            return await query.FirstOrDefaultAsync();
        }
    }
}