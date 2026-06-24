using Escola.Domain.Pagination;
using Microsoft.EntityFrameworkCore;

namespace Escola.Infra.Data.Helpers
{
    public static class PaginationHelper
    {
        public static async Task<PagedList<T>> CreatePagedListAsync<T>(
            IQueryable<T> source,
            int pageNumber,
            int pageSize) where T : class
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedList<T>(items, pageNumber, pageSize, count);
        }
    }
}
