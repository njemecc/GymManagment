using ErrorOr;
using GymManagment.Contracts.Subscriptions;
using GymManagment.Domain.Subscriptions;
using MediatR;

namespace GymManagment.Application.Subscriptions.Commands.CreateSubscription;

public record CreateSubscriptionCommand(SubscriptionType SubscriptionType,Guid AdminId) : IRequest<ErrorOr<Guid>>;


