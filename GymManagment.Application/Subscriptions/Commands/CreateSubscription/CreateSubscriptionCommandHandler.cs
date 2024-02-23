using ErrorOr;
using GymManagment.Application.Common.Interfaces;
using GymManagment.Domain.Subscriptions;
using MediatR;

namespace GymManagment.Application.Subscriptions.Commands.CreateSubscription;

public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand,ErrorOr<Guid>>
{
    private readonly ISubscriptionRepository _subscriptionRepository;
    private readonly IUnitOfWork _unitOfWork;


    public CreateSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository,IUnitOfWork unitOfWork)
    {
        _subscriptionRepository = subscriptionRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<ErrorOr<Guid>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
    {

        //Create Subcription
        var subscription = new Subscription
        {
            Id = Guid.NewGuid(),
            SubscriptionType = request.SubscriptionType
        };

        //Add it to the database
        _subscriptionRepository.AddSubscriptionAsync(subscription);

        await _unitOfWork.CommitChangesAsync();

        // Return subscription
        return subscription.Id;
    }
}