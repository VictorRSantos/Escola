using Escola.Domain.Entities;
using Escola.Domain.Interfaces;

namespace Escola.Infra.Data.Repositories
{
    public class TurmaRepository : ITurmaRepository
    {
        public Task<Turma> AddAsync(Turma turma)
        {
            throw new NotImplementedException();
        }

        public Task<Turma> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Turma>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Turma> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Turma> UpdateAsync(Turma turma)
        {
            throw new NotImplementedException();
        }
    }
}
