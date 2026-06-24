namespace Escola.Domain.Pagination
{
    public class PagedList<T> : List<T>
    {
        public PagedList(IEnumerable<T> items, int pageNumber, int pageSize, int count)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }
}
