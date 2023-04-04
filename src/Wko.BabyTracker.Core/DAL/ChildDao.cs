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
    
    public async Task<Child> GetById(Guid id)
    {
        return await _jsRuntime.InvokeAsync<Child>("getChild", id);
    }
    
    public async Task<Child> Create(Child child)
    {
        return await _jsRuntime.InvokeAsync<Child>("createChild", child);
    }
    
    public async Task<Child> Update(Child child)
    {
        return await _jsRuntime.InvokeAsync<Child>("updateChild", child.Id, child);
    }
    
    public async Task Delete(Guid id)
    {
        await _jsRuntime.InvokeVoidAsync("deleteChild", id);
    }
    
}
