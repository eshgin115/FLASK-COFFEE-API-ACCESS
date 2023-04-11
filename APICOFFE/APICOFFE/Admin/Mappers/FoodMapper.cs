using APICOFFE.Admin.Dtos.Food;
using APICOFFE.Database.Models;
using AutoMapper;

namespace APICOFFE.Admin.Mappers
{
    public class FoodMapper : Profile
    {
        public FoodMapper()
        {

            CreateMap<Food, FoodListItemDto>()
                 .ForMember(d => d.FoodTags, opt => opt.MapFrom(src => src.FoodTags))
                 .ForMember(d => d.ImageURL, opt => opt.MapFrom(src => src.FoodImages!
                 .Take(1).FirstOrDefault()!.ImageNameInFileSystem))
                 .ForMember(d => d.FoodSizes, opt => opt.MapFrom(src => src.FoodSizes))
                 .ForMember(d => d.CategoryName, opt => opt.MapFrom(src => src.FoodCategory.Name));
            CreateMap<FoodTag, FoodListItemDto.ItemDto>()
                        .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Tag.Name))
                        .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Tag.Id));
            CreateMap<FoodSize, FoodListItemDto.ItemDto>()
                        .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Size.Name))
                        .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Size.Id)); ;
         
            CreateMap<FoodCreateDto, Food>()
                .ForMember(d => d.FoodCategoryId, opt => opt.MapFrom(src => src.CategoryId));
            CreateMap<(int model, Food food), FoodSize>()
                 .ForMember(d => d.SizeId, opt => opt.MapFrom(src => src.model))
                 .ForMember(d => d.Food, opt => opt.MapFrom(src => src.food));
            CreateMap<(int model, Food food), FoodTag>()
                .ForMember(d => d.TagId, opt => opt.MapFrom(src => src.model))
                .ForMember(d => d.Food, opt => opt.MapFrom(src => src.food));



            CreateMap<(IFormFile FoodImage, Food food, bool Ismain, string imageNameInSystem), FoodImage>()
             .ForMember(d => d.IsMain, opt => opt.MapFrom(src => src.Ismain))
              .ForMember(d => d.ImageName, opt => opt.MapFrom(src => src.FoodImage.FileName))
              .ForMember(d => d.ImageNameInFileSystem, opt => opt.MapFrom(src => src.imageNameInSystem))
             .ForMember(d => d.Food, opt => opt.MapFrom(src => src.food));



           
            //CreateMap<FoodSize, int>()
            //     .ForMember(d => d, opt => opt.MapFrom(src => src.SizeId));

            //CreateMap<FoodTag, int>()
            //  .ForMember(d => d.GetType(), opt => opt.MapFrom(src => src.TagId));
            CreateMap<FoodSize, int>();
            CreateMap<FoodSize, int>();
            CreateMap<FoodTag, int>();
            CreateMap<FoodUpdateDto, Food>()
              .ForMember(d => d.FoodCategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(d => d.Id, opt => opt.Ignore());


        }
    }
}
