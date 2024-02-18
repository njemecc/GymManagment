using ErrorOr;
using MediatR;

namespace GymManagment.Application.Subscriptions.Commands.CreateSubscription;

public record CreateSubscriptionCommand(string SubscriptionType,Guid AdminId) : IRequest<ErrorOr<Guid>>;


