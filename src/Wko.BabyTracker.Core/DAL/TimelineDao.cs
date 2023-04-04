using Microsoft.JSInterop;
using Wko.BabyTracker.Core.Domain.Entities;

namespace Wko.BabyTracker.Core.DAL;

public class TimelineDao
{
    private readonly IJSRuntime _jsRuntime;

    public TimelineDao(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }
    
    public async Task<TimelineEntry> GetById(Guid id)
    {
        return await _jsRuntime.InvokeAsync<TimelineEntry>("getTimelineById", id);
    }
    
    public async Task<TimelineEntry[]> GetByChildId(Guid childId)
    {
        return await _jsRuntime.InvokeAsync<TimelineEntry[]>("getTimelineByChildId", childId);
    }

    public async Task<TimelineEntry> Create(TimelineEntry timelineEntry)
    {
        return await _jsRuntime.InvokeAsync<TimelineEntry>("createTimelineEntry", timelineEntry);
    }
    
    public async Task<TimelineEntry> Update(TimelineEntry timelineEntry)
    {
        return await _jsRuntime.InvokeAsync<TimelineEntry>("updateTimelineEntry", timelineEntry.Id, timelineEntry);
    }
    
    public async Task Delete(Guid id)
    {
        await _jsRuntime.InvokeVoidAsync("deleteTimelineEntry", id);
    }

}
