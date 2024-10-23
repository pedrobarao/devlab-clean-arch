namespace Lab.Core.Commons.Communication;

public static class PagedResultHandler
{
    public static PagedResult<TOutput> MapItems<TInput, TOutput>(PagedResult<TInput> pagedResult,
        Func<TInput, TOutput> converter) where TInput : class where TOutput : class
    {
        var convertedItems = pagedResult.Items.Select(converter);

        return new PagedResult<TOutput>(
            convertedItems,
            pagedResult.TotalItems,
            pagedResult.PageIndex,
            pagedResult.PageSize,
            pagedResult.Filter
        );
    }
}

public class PagedResult<T> where T : class
{
    public PagedResult(IEnumerable<T>? items, int totalItems, int pageIndex, int pageSize, string? filter)
    {
        TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
        if (TotalPages < 0) TotalPages = 0;
        Items = items ?? [];
        TotalItems = totalItems;
        PageIndex = pageIndex;
        PageSize = pageSize;
        Filter = filter;
    }

    public IEnumerable<T> Items { get; set; }
    public int TotalItems { get; private set; }
    public int TotalPages { get; private set; }
    public int PageIndex { get; private set; }
    public int PageSize { get; private set; }
    public string? Filter { get; private set; }
}