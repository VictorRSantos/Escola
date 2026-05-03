using Escola.Domain.Entities;
using Escola.Domain.Interfaces;

namespace Escola.Infra.Data.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        public Task<Matricula> AddAsync(Matricula matricula)
        {
            throw new NotImplementedException();
        }

        public Task<Matricula> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Matricula>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Matricula> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Matricula> UpdateAsync(Matricula matricula)
        {
            throw new NotImplementedException();
        }
    }
}
