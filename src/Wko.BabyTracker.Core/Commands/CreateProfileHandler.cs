using Microsoft.JSInterop;
using Wko.BabyTracker.Core.Domain.Entities;

namespace Wko.BabyTracker.Core.Commands;

public class CreateProfileHandler: ICommandHandler<Commands.CreateProfile>
{
    private readonly IJSRuntime _jsRuntime;

    public CreateProfileHandler(IJSRuntime jsRuntime) => _jsRuntime = jsRuntime;

    public async Task HandleAsync(Commands.CreateProfile command)
    {
        var profileToAdd = new Child
        {
            Name = command.Name,
            BirthDate = command.BirthDate
        };
        
        await _jsRuntime.InvokeVoidAsync("childRepository.createChild", profileToAdd);
    }
}
