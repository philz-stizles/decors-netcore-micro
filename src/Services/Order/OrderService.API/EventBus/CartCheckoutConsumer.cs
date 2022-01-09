using AutoMapper;
using Decors.EventBus.Events;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using OrderService.Application.Handlers.Orders.Commands;
using System;
using System.Threading.Tasks;

namespace OrderService.API.EventBus
{
    public class CartCheckoutConsumer : IConsumer<CartCheckoutEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<CartCheckoutConsumer> _logger;

        public CartCheckoutConsumer(IMediator mediator, IMapper mapper, ILogger<CartCheckoutConsumer> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Consume(ConsumeContext<CartCheckoutEvent> context)
        {
            var command = _mapper.Map<CheckoutOrderCommand>(context.Message);
            var result = await _mediator.Send(command);

            _logger.LogInformation("CartCheckoutEvent consumed successfully. Created Order Id : {newOrderId}", result);
        }
    }
}
