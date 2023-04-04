using Wko.BabyTracker.Core.Commands;
using Wko.BabyTracker.Core.DAL;
using Wko.BabyTracker.Core.Queries;
using Wko.BabyTracker.Core.Services;

namespace Wko.BabyTracker.Extensions;

public static class ServiceExtensions
{
    public static void AddAppServices(this IServiceCollection services)
    {
        services.AddSingleton<IDispatcher, Dispatcher>();
        services.AddTransient<TimelineDao>();
        services.AddTransient<ChildDao>();
        services.AddHandlers(typeof(IQueryHandler<,>));
        services.AddHandlers(typeof(ICommandHandler<>));
    }

    private static void AddHandlers(this IServiceCollection services, Type typeToAdd)
    {
        var assembly = typeToAdd.Assembly;
        var mappings = 
            from type in assembly.GetTypes()
            where !type.IsAbstract
            where !type.IsGenericType
            from i in type.GetInterfaces()
            where i.IsGenericType
            where i.GetGenericTypeDefinition() == typeToAdd
            select new { service = i, type };

        foreach (var mapping in mappings)
        {
            services.AddTransient(mapping.service, mapping.type);
        }
    }
}
