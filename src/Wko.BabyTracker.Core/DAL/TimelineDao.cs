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
        return await _jsRuntime.InvokeAsync<TimelineEntry>("timelineRepository.getTimelineById", id);
    }
    
    public async Task<TimelineEntry[]> GetByChildId(Guid childId)
    {
        return await _jsRuntime.InvokeAsync<TimelineEntry[]>("timelineRepository.getTimelineByChildId", childId);
    }

    public async Task<TimelineEntry> Create(TimelineEntry timelineEntry)
    {
        return await _jsRuntime.InvokeAsync<TimelineEntry>("timelineRepository.createTimelineEntry", timelineEntry);
    }
    
    public async Task<TimelineEntry> Update(TimelineEntry timelineEntry)
    {
        return await _jsRuntime.InvokeAsync<TimelineEntry>("timelineRepository.updateTimelineEntry", timelineEntry.Id, timelineEntry);
    }
    
    public async Task Delete(Guid id)
    {
        await _jsRuntime.InvokeVoidAsync("timelineRepository.deleteTimelineEntry", id);
    }

}
