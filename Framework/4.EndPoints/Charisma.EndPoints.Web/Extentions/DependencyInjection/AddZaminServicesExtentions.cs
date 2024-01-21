using Zamin.Utilities;

namespace Charisma.EndPoints.Web.Extentions.DependencyInjection;
public static class AddZaminServicesExtensions
{
    public static IServiceCollection AddZaminUntilityServices(
        this IServiceCollection services)
    {
        services.AddTransient<ZaminServices>();
        return services;
    }
}