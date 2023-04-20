using APICOFFE.Client.Dtos.BestCoffee;
using APICOFFE.Client.Dtos.DiscoverMenu;
using APICOFFE.Client.Dtos.FeedBack;
using APICOFFE.Client.Dtos.Navbar;
using APICOFFE.Client.Dtos.OurHistory;
using APICOFFE.Client.Dtos.OurProduct;
using APICOFFE.Client.Dtos.PaymentBenefits;
using APICOFFE.Client.Dtos.ShortInfo;
using APICOFFE.Client.Dtos.WelcomeSlider;

namespace APICOFFE.Client.Services.Concretes;

public interface IHomeService
{
    Task<List<NavbarListItemDto>> NavbarListAsync();
    Task<List<WelcomeSliderListItemDto>> WelcomeSliderListAsync(string page);
    Task<ShortInfoListItemDto> GetShortInfoAsync();
    Task<OurHistoryListItemDto> GetOurHistoryAsync();
    Task<List<PaymentBenefitsListItemDto>> PaymentBenefitsListAsync();
    Task<List<BestCoffeeListItemDto>> BestCoffeeListAsync();
    Task<List<OurProductListItemDto>> OurProductListAsync(int foodCategoryId);
    Task<List<FeedBackListItemDto>> FeedBacksListAsync();
    Task<DiscoverMenuListItemDto> GetDiscoverMenuAsync();
}
