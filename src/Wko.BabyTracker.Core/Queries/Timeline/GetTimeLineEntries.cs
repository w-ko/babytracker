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
            new()
            {
                Id = Guid.NewGuid(),
                ChildId = query.ChildId,
                Body = "Hello World",
                Type = TimelineEntryType.Feeding,
                StartDate = DateTimeOffset.Now.AddMinutes(-20),
                EndDate = DateTimeOffset.Now
            },
            new()
            {
                Id = Guid.NewGuid(),
                ChildId = query.ChildId,
                Body = "Hello World",
                Type = TimelineEntryType.Sleep,
                StartDate = DateTimeOffset.Now.AddMinutes(-21),
                EndDate = DateTimeOffset.Now
            },
            new()
            {
                Id = Guid.NewGuid(),
                ChildId = query.ChildId,
                Body = "Hello World",
                Type = TimelineEntryType.Nappy,
                StartDate = DateTimeOffset.Now.AddMinutes(-22),
                EndDate = DateTimeOffset.Now
            },
            new()
            {
                Id = Guid.NewGuid(),
                ChildId = query.ChildId,
                Body = "Hello World",
                Type = TimelineEntryType.Measure,
                StartDate = DateTimeOffset.Now.AddMinutes(-23),
                EndDate = DateTimeOffset.Now
            },
            
            new()
            {
                Id = Guid.NewGuid(),
                ChildId = query.ChildId,
                Body = "Hello World",
                Type = TimelineEntryType.Measure,
                StartDate = DateTimeOffset.Now.AddMinutes(-23),
                EndDate = DateTimeOffset.Now,
                Measure = new MeasureEntryDto {Type = MeasureType.Height}
            }, 
            new()
            {
                Id = Guid.NewGuid(),
                ChildId = query.ChildId,
                Body = "Hello World",
                Type = TimelineEntryType.Milestone,
                StartDate = DateTimeOffset.Now.AddMinutes(-24),
                EndDate = DateTimeOffset.Now
            }
        };
        
        return new PagedResult<TimelineEntryDto>(results, query.CurrentPage, query.PageSize, results.Count, results.Count);
    }
}
