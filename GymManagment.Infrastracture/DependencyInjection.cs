using GymManagment.Application.Common.Interfaces;
using GymManagment.Infrastracture;
using GymManagment.Infrastracture.Subscriptions.Persistance;
using Microsoft.Extensions.DependencyInjection;

namespace GymManagment.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastracture(this IServiceCollection services)
    {

        services.AddScoped<ISubscriptionRepository, SubscriptionsRepository>();
        return services;
    }

  
}