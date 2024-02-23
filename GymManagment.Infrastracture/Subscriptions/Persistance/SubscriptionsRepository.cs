using GymManagment.Application.Common.Interfaces;
using GymManagment.Domain.Subscriptions;

namespace GymManagment.Infrastracture.Subscriptions.Persistance;

public class SubscriptionsRepository : ISubscriptionRepository
{
    private readonly static List<Subscription> _subscriptions = new();
    
    
    
    
    public Task AddSubscriptionAsync(Subscription subscription)
    {
        _subscriptions.Add(subscription);

        return Task.CompletedTask;
    }



    public  Task<Subscription?> GetByIdAsync(Guid subscriptionId)
    {
        var subscription = _subscriptions.FirstOrDefault(s => s.Id == subscriptionId);

        return Task.FromResult(subscription);

    }
}