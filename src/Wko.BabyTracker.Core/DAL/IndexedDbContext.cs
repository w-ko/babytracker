using Microsoft.JSInterop;

namespace Wko.BabyTracker.Core.DAL;

public class IndexedDbContext
{
    private readonly IJSRuntime _jsRuntime;

    public IndexedDbContext(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }
    
    private async ValueTask InitDb()
    {
        await _jsRuntime.InvokeVoidAsync("initDb");
    }
}
