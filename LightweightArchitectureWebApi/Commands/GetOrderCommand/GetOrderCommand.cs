using AutoMapper;
using FluentValidation;
using LightweightArchitectureWebApi.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// https://timdows.com/projects/use-mediatr-with-fluentvalidation-in-the-asp-net-core-pipeline/

namespace LightweightArchitectureWebApi.Commands.GetOrderCommand
{
    public class GetOrderCommand : IRequest<GetOrderCommandResponse>
    {
        public int OrderId { get; set; }
    }

    public class GetOrderValidator : AbstractValidator<GetOrderCommand>
    {
        public GetOrderValidator()
        {
            RuleFor(x => x.OrderId).NotEmpty().GreaterThan(0);
        }
    }


    public class GetOrderCommandResponse
    {
        public int OrderId { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public short Status { get; set; }
    }

    public class GetOrderCommandHandler : IRequestHandler<GetOrderCommand, GetOrderCommandResponse>
    {
        private readonly ILogger<GetOrderCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public GetOrderCommandHandler(
            ILogger<GetOrderCommandHandler> logger,
            IMapper mapper,
            IOrderRepository orderRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _orderRepository = orderRepository;
        }
        
        public async Task<GetOrderCommandResponse> Handle(GetOrderCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var response = await _orderRepository.GetById(request.OrderId);

            return _mapper.Map<GetOrderCommandResponse>(response);
        }
    }
}
