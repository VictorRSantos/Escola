using Escola.Domain.Entities;
using Escola.Domain.Interfaces;

namespace Escola.Infra.Data.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        public Task<Curso> AddAsync(Curso curso)
        {
            throw new NotImplementedException();
        }

        public Task<Curso> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Curso>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Curso> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Curso> UpdateAsync(Curso curso)
        {
            throw new NotImplementedException();
        }
    }
}
