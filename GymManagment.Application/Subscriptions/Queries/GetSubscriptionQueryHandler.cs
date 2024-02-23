using System.ComponentModel;
using ErrorOr;
using GymManagment.Application.Common.Interfaces;
using GymManagment.Domain.Subscriptions;

namespace GymManagment.Application.Subscriptions.Queries;


public class GetSubscriptionQueryHandler
{

    private readonly ISubscriptionRepository _subscriptionRepository;
    
    public GetSubscriptionQueryHandler(ISubscriptionRepository subscriptionRepository)
    {
        _subscriptionRepository = subscriptionRepository;
    }


    public async Task<ErrorOr<Subscription>> Handle(GetSubscriptionQuery query, CancellationToken cancellationToken)
    {
        var subscription = await _subscriptionRepository.GetByIdAsync(query.SubscriptionId);

        return subscription is null
            ? Error.NotFound(description: "Subscription not found")
            : subscription;
    }
    
}