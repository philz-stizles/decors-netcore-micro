using MediatR;

namespace OrderService.Application.Handlers.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand: IRequest
    {
        public int Id { get; set; }
    }
}
