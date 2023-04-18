using APICOFFE.Contracts.Order;
using APICOFFE.Database.Models;
using AutoMapper;

namespace APICOFFE.Client.Mappers;

public class OrderProductMapper : Profile
{
    public OrderProductMapper()
    {
        CreateMap<(decimal subTotal, string Id, User user), Order>()
                        .ForMember(d => d.UserId, o => o.MapFrom(s => s.user.Id!))
                        .ForMember(d => d.Id, o => o.MapFrom(s => s.Id!))
                        .ForMember(d => d.User, o => o.MapFrom(s => s.user!))
                        .ForMember(d => d.Status, o => o.MapFrom(s => Status.Created!))
                        .ForMember(d => d.UserId, o => o.MapFrom(s => s.user.Id!))
                        .ForMember(d => d.SumTotalPrice, o => o.MapFrom(s => s.subTotal!));
    }
}
