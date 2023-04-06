using Microsoft.AspNetCore.Components;
using Wko.BabyTracker.Core.Services;

namespace Wko.BabyTracker.Features.Shared;

abstract class EventfulComponentBase: ComponentBase
{
    [Inject] protected IDispatcher Dispatcher { get; set; } = default!;
    
}
