using APICOFFE.Client.Dtos.BestCoffee;
using APICOFFE.Client.Dtos.DiscoverMenu;
using APICOFFE.Client.Dtos.FeedBack;
using APICOFFE.Client.Dtos.Navbar;
using APICOFFE.Client.Dtos.OurHistory;
using APICOFFE.Client.Dtos.OurProduct;
using APICOFFE.Client.Dtos.PaymentBenefits;
using APICOFFE.Client.Dtos.ShortInfo;
using APICOFFE.Client.Dtos.WelcomeSlider;
using APICOFFE.Database.Models;
using AutoMapper;

namespace APICOFFE.Client.Mappers;

public class HomeMapper : Profile
{
    public HomeMapper()
    {
        CreateMap<ShortInfo, ShortInfoListItemDto>();

        CreateMap<Navbar, NavbarListItemDto>()
           .ForMember(d => d.SubnavbarItems, o => o.MapFrom(s => s.Subnavbars))
           .ForMember(d => d.URL, o => o.MapFrom(s => s.ToURL));

        CreateMap<Subnavbar, NavbarListItemDto.SubnavbarListItemDto>();
        
        CreateMap<WelcomeSlider, WelcomeSliderListItemDto>()
           .ForMember(d => d.ImageURL, o => o.MapFrom(s => s.ImageNameInFileSystem!));
        
        CreateMap<OurHistory, OurHistoryListItemDto>()
            .ForMember(d => d.ImageURL, o => o.MapFrom(s => s.ImageNameInFileSystem));
        
        CreateMap<PaymentBenefits, PaymentBenefitsListItemDto>()
          .ForMember(d => d.ImageURL, o => o.MapFrom(s => s.ImageNameInFileSystem));
       
        CreateMap<Drink, BestCoffeeListItemDto>()
                         .ForMember(d => d.ImageURL, o => o.MapFrom(s => s.ImageNameInFileSystem));

        CreateMap<Food, OurProductListItemDto>()
                         .ForMember(d => d.ImageURL, o => o.MapFrom(s => s.FoodImages.FirstOrDefault().ImageNameInFileSystem));
        CreateMap<Drink, OurProductListItemDto>()
           .ForMember(d => d.ImageURL, o => o.MapFrom(s => s.ImageNameInFileSystem));


        CreateMap<FeedBack, FeedBackListItemDto>()
                          .ForMember(d => d.RoleName, o => o.MapFrom(s => s.Role!.Name))
                          .ForMember(d => d.FullName, o => o.MapFrom(s => s.Name))
                          .ForMember(d => d.ProfilePhotoUrl, o => o.MapFrom(s => s.ImageNameInFileSystem));

        CreateMap<DiscoverMenu, DiscoverMenuListItemDto>()
                         .ForMember(d => d.ImageURLs,
                         o => o.MapFrom(s => s.DiscoverMenuImages!.Select(dm => dm.ImageNameInFileSystem)!));
    }
}
