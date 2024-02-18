
using GymManagment.Application.Subscriptions.Commands.CreateSubscription;
using GymManagment.Contracts.Subscriptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymManagment.Api.Controllers;

[ApiController]
[Route("[controller]")]

public class SubscriptionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SubscriptionsController( IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost]
    public async  Task<IActionResult> CreateSubscription(CreateSubscriptionRequest request)
    {

        var command = new CreateSubscriptionCommand(request.SubscriptionType.ToString(),request.AdminId);
        
        var createSubscriptionResult = await _mediator.Send(command);

      return  createSubscriptionResult.MatchFirst(
            guid => Ok(new SubscriptionResponse(guid, request.SubscriptionType)),
            error => Problem());
        

    }
}