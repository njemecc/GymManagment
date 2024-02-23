
using GymManagment.Application.Subscriptions.Commands.CreateSubscription;
using GymManagment.Application.Subscriptions.Queries;
using GymManagment.Contracts.Subscriptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymManagment.Api.Controllers;

[ApiController]
[Route("[controller]")]

public class SubscriptionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SubscriptionsController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost]
    public async Task<IActionResult> CreateSubscription(CreateSubscriptionRequest request)
    {

        var command = new CreateSubscriptionCommand(request.SubscriptionType, request.AdminId);

        var createSubscriptionResult = await _mediator.Send(command);

        return createSubscriptionResult.MatchFirst(
            subscriptionId => Ok(new SubscriptionResponse(subscriptionId, request.SubscriptionType)),
            error => Problem());


    }


    [HttpGet("{subscriptionId:guid}")]
    public async Task<IActionResult> GetSubscription(Guid subscriptionId)
    {

        var query = new GetSubscriptionQuery(subscriptionId);

        var getSubscriptionsResult = await _mediator.Send(query);
        
        return getSubscriptionsResult.MatchFirst(
            subscription => Ok(new SubscriptionResponse(
                subscription.Id,subscription.SubscriptionType)),
            error => Problem());

    }

}