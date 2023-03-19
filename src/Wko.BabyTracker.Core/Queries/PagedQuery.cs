namespace Wko.BabyTracker.Core.Queries;

public record PagedQuery<T> : IQuery<T>
{
    private const int DefaultPage = 1;
    private const int DefaultPageSize = 25;

    public int CurrentPage { get; set; } = DefaultPage;
    public int PageSize { get; set; } = DefaultPageSize;
}

public record PagedResult<T>(int CurrentPage, int ItemsPerPage, int TotalPages, long TotalCount)
{
    public IReadOnlyList<T> Data { get; } = new List<T>();

    public PagedResult(
        IReadOnlyList<T> data,
        int currentPage,
        int itemsPerPage,
        int totalPages,
        long totalCount
    ) : this(currentPage, itemsPerPage, totalPages, totalCount)
    {
        Data = data;
    }
}
