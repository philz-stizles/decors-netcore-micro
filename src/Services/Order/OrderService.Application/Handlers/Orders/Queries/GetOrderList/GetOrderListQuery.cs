using CatalogService.Application.Models.Dtos;
using MediatR;
using System;
using System.Collections.Generic;

namespace OrderService.Application.Handlers.Orders.Queries
{
    public class GetOrderListQuery: IRequest<List<OrderDto>>
    {
        public string UserName { get; set; }

        public GetOrderListQuery(string userName)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
        }
    }
}
