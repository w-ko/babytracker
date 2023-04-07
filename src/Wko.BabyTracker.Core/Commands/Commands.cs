namespace Wko.BabyTracker.Core.Commands;

public static class Commands
{
    public record CreateProfile(string Name, DateTimeOffset? BirthDate): ICommand;
}
