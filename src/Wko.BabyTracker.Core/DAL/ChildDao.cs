using Microsoft.JSInterop;
using Wko.BabyTracker.Core.Domain.Entities;

namespace Wko.BabyTracker.Core.DAL;

public class ChildDao
{
    private readonly IJSRuntime _jsRuntime;

    public ChildDao(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }
    
    public async Task<Child> GetById(int id)
    {
        return await _jsRuntime.InvokeAsync<Child>("babyTracker.getChild", id);
    }
    
    public async Task<Child> Create(Child child)
    {
        return await _jsRuntime.InvokeAsync<Child>("babyTracker.createChild", child);
    }
    
    public async Task<Child> Update(Child child)
    {
        return await _jsRuntime.InvokeAsync<Child>("babyTracker.updateChild", child.Id, child);
    }
    
    public async Task Delete(int id)
    {
        await _jsRuntime.InvokeVoidAsync("babyTracker.deleteChild", id);
    }
    
}
