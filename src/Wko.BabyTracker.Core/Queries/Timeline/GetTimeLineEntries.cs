using Wko.BabyTracker.Core.Dtos.Timeline;
using Wko.BabyTracker.Core.Shared.Enums;

namespace Wko.BabyTracker.Core.Queries.Timeline;

public record GetTimeLineEntries(Guid ChildId): PagedQuery<PagedResult<TimelineEntryDto>>;

public class GetTimeLineEntriesHandler : IQueryHandler<GetTimeLineEntries, PagedResult<TimelineEntryDto>>
{
    public async Task<PagedResult<TimelineEntryDto>> HandleAsync(GetTimeLineEntries query)
    {
        var results = new List<TimelineEntryDto>
        {
            new TimelineEntryDto
            {
                Id = Guid.NewGuid(),
                ChildId = query.ChildId,
                Body = "Hello World",
                Type = TimelineEntryType.Feeding,
                StartDate = DateTimeOffset.Now.AddMinutes(-20),
                EndDate = DateTimeOffset.Now
            }
        };
        
        return new PagedResult<TimelineEntryDto>(results, query.CurrentPage, query.PageSize, results.Count, results.Count);
    }
}
