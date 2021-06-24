using System.Threading.Tasks;
using controlvac.Models;

namespace controlvac.Data
{
    public interface IRepository
    {
        //Criação de Repositório com metodos comuns a todas as controllers
        //Construção com Generics para pode ser utilizado por qualquer entidade
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAllAsync();

        //Buscas referentes a vacina
        Task<Vacina[]> GetVacinasAsync();
        Task<Vacina> GetVacinaByIdAsync(int id);

        //Buscas referentes a Pacientes
        Task<Paciente[]> GetPacientesAsync();
        Task<Paciente> GetPacienteByIdAsync(int id);

        //Buscas referentes a Vacinacao
        Task<Vacinacao[]> GetVacinacaoAsync();
        Task<Vacinacao> GetVacinacaoByIdAsync(int id);
    }
}