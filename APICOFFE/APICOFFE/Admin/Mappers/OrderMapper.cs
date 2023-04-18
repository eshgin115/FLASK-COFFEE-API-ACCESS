using APICOFFE.Admin.Dtos.Order;
using APICOFFE.Contracts.Order;
using APICOFFE.Database.Models;
using AutoMapper;

namespace APICOFFE.Admin.Mappers;

public class OrderMapper : Profile
{
    public OrderMapper()
    {
        CreateMap<Order, OrderListItemDto>()
           .ForMember(d => d.OrderDate, o => o.MapFrom(s => s.CreatedAt))
           .ForMember(d => d.TotalPrice, o => o.MapFrom(s => s.SumTotalPrice))
           .ForMember(d => d.CurrentStatus, o => o.MapFrom(s => s.Status.GetShortNameWithStatus()))
           .ForMember(d => d.Identifikator, o => o.MapFrom(s => s.Id));
    }
}
