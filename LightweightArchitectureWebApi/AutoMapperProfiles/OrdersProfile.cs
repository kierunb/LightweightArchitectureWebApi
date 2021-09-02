using AutoMapper;
using LightweightArchitectureWebApi.Commands.GetOrderCommand;
using LightweightArchitectureWebApi.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightweightArchitectureWebApi.AutoMapperProfiles
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            CreateMap<Order, GetOrderCommandResponse>();
        }
    }
}
