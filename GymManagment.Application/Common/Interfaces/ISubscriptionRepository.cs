using GymManagment.Domain.Subscriptions;

namespace GymManagment.Application.Common.Interfaces;

public interface ISubscriptionRepository
{
  Task AddSubscriptionAsync(Subscription subscriptions);
}