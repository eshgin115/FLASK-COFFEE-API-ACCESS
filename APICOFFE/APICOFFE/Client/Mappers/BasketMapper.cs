using APICOFFE.Client.Dtos.Basket;
using APICOFFE.Database.Models;
using AutoMapper;

namespace APICOFFE.Client.Mappers;

public class BasketMapper : Profile
{
    public BasketMapper()
    {
        CreateMap<(Food food, Basket basket, ModalDto dto), BasketProduct>()
                         .ForMember(d => d.Basket,
                         o => o.MapFrom(s => s.basket!))
                         .ForMember(d => d.Food,
                         o => o.MapFrom(s => s.food!))
                         .ForMember(d => d.FoodId,
                         o => o.MapFrom(s => s.food.Id!))
                         .ForMember(d => d.BasketId,
                         o => o.MapFrom(s => s.basket.Id!))
                          .ForMember(d => d.Price,
                         o => o.MapFrom(s => s.food.Price!))
                           .ForMember(d => d.SizeId,
                         o => o.MapFrom(s => s.dto.SizeId != null ? s.dto.SizeId : s.food.FoodSizes!.First().SizeId))
                           .ForMember(d => d.QuantityFood,
                         o => o.MapFrom(s => s.dto.QuantityFood != null ? s.dto.QuantityFood : 1));


        CreateMap<(Drink drink, Basket basket, ModalDto dto), BasketProduct>()
                        .ForMember(d => d.Basket,
                        o => o.MapFrom(s => s.basket!))
                        .ForMember(d => d.Drink,
                        o => o.MapFrom(s => s.drink!))
                        .ForMember(d => d.DrinkId,
                        o => o.MapFrom(s => s.drink.Id!))
                        .ForMember(d => d.BasketId,
                        o => o.MapFrom(s => s.basket.Id!))
                         .ForMember(d => d.Price,
                        o => o.MapFrom(s => s.drink.Price!))
                          .ForMember(d => d.SizeId,
                        o => o.MapFrom(s => s.dto.SizeId != null ? s.dto.SizeId : s.drink.DrinkSizes!.First().SizeId))
                          .ForMember(d => d.QuantityDrink,
                        o => o.MapFrom(s => s.dto.QuantityDrink != null ? s.dto.QuantityDrink : 1));




        CreateMap<(List<BasketProduct> foods, List<BasketProduct> drinks, decimal SubTotal), BasketListItemDto>()
                           .ForMember(d => d.FoodListItemDtos, o => o.MapFrom(s => s.foods))
                           .ForMember(d => d.SubTotal, o => o.MapFrom(s => s.SubTotal))
                           .ForMember(d => d.DrinkListItemDtos, o => o.MapFrom(s => s.drinks));

        CreateMap<BasketProduct, BasketListItemDto.FoodListItemDto>()
                    .ForMember(d => d.SizeId, o => o.MapFrom(s => s.SizeId))
                    .ForMember(d => d.Price, o => o.MapFrom(s => s.Food.Price))
                    .ForMember(d => d.Title, o => o.MapFrom(s => s.Food.Title))
                    .ForMember(d => d.Content, o => o.MapFrom(s => s.Food.Content))
                    .ForMember(d => d.Quantity, o => o.MapFrom(s => s.QuantityFood))
                    .ForMember(d => d.ImageUrl, o => o.MapFrom(s => s.Food.FoodImages.FirstOrDefault() != null
                    ? s.Food.FoodImages.FirstOrDefault().ImageNameInFileSystem : null))
                    .ForMember(d => d.Total, o => o.MapFrom(s => s.QuantityFood * s.Food.Price))
                    .ForMember(d => d.Sizes, o => o.MapFrom(s => s.Food.FoodSizes))
                    .ForMember(d => d.Id, o => o.MapFrom(s => s.FoodId));
        
        
        CreateMap<BasketProduct, BasketListItemDto.DrinkListItemDto>()
                    .ForMember(d => d.Id, o => o.MapFrom(s => s.DrinkId))
                    .ForMember(d => d.SizeId, o => o.MapFrom(s => s.SizeId))
                    .ForMember(d => d.Price, o => o.MapFrom(s => s.Drink.Price))
                    .ForMember(d => d.Title, o => o.MapFrom(s => s.Drink.Title))
                    .ForMember(d => d.Content, o => o.MapFrom(s => s.Drink.Content))
                    .ForMember(d => d.Sizes, o => o.MapFrom(s => s.Drink.DrinkSizes))
                    .ForMember(d => d.Quantity, o => o.MapFrom(s => s.QuantityDrink))
                    .ForMember(d => d.ImageUrl, o => o.MapFrom(s => s.Drink.ImageNameInFileSystem))
                    .ForMember(d => d.Total, o => o.MapFrom(s => s.QuantityDrink * s.Drink.Price))
                    .ForMember(d => d.Id, o => o.MapFrom(s => s.DrinkId));

        CreateMap<DrinkSize, BasketListItemDto.ItemDto>()
                  .ForMember(d => d.Id, o => o.MapFrom(s => s.Size.Id))
                  .ForMember(d => d.Name, o => o.MapFrom(s => s.Size.Name));

        CreateMap<FoodSize, BasketListItemDto.ItemDto>()
                    .ForMember(d => d.Id, o => o.MapFrom(s => s.Size.Id))
                    .ForMember(d => d.Name, o => o.MapFrom(s => s.Size.Name));

    }
}
