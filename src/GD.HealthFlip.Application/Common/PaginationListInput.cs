using GD.HealthFlip.Domain.SeedWork.SearchableRepository;

namespace GD.HealthFlip.Application.Common;
public abstract class PaginationListInput
{
    public int Page { get; set; }
    public int PerPage { get; set; }
    public string Search { get; set; }
    public string Sort { get; set; }
    public SearchOrder Direction { get; set; }
    public PaginationListInput(
        int page,
        int perPage,
        string search,
        string sort,
        SearchOrder direction)
    {
        Page = page;
        PerPage = perPage;
        Search = search;
        Sort = sort;
        Direction = direction;
    }

    public SearchInput ToSearchInput()
        => new(Page, PerPage, Search, Sort, Direction);
}
