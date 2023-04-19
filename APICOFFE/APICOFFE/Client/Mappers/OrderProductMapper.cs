using APICOFFE.Client.Dtos.Basket;
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


        CreateMap<(Order order, PlaceOrderDto.FoodListItemDto food, decimal foodPrice), OrderProduct>()
                      .ForMember(d => d.FoodId, o => o.MapFrom(s => s.food.Id!))
                      .ForMember(d => d.Order, o => o.MapFrom(s => s.order!))
                      .ForMember(d => d.OrderId, o => o.MapFrom(s => s.order.Id!))
                      .ForMember(d => d.QuantityFood, o => o.MapFrom(s => s.food.Quantity!))
                      .ForMember(d => d.Price, o => o.MapFrom(s => s.foodPrice!))
                      .ForMember(d => d.SizeId, o => o.MapFrom(s => s.food.SizId!));



        CreateMap<(Order order, PlaceOrderDto.DrinkListItemDto drink, decimal drinkPrice), OrderProduct>()
                      .ForMember(d => d.DrinkId, o => o.MapFrom(s => s.drink.Id!))
                      .ForMember(d => d.Order, o => o.MapFrom(s => s.order!))
                      .ForMember(d => d.OrderId, o => o.MapFrom(s => s.order.Id!))
                      .ForMember(d => d.Price, o => o.MapFrom(s => s.drinkPrice!))
                      .ForMember(d => d.QuantityDrink, o => o.MapFrom(s => s.drink.Quantity!))
                      .ForMember(d => d.SizeId, o => o.MapFrom(s => s.drink.SizeId!));
    }
}
