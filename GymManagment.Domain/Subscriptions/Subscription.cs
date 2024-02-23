using GymManagment.Contracts.Subscriptions;

namespace GymManagment.Domain.Subscriptions;

public class Subscription
{
    public Guid Id { get; set; } 
    
    public SubscriptionType  SubscriptionType { get; set; }
}