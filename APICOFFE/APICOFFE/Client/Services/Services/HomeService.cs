using APICOFFE.Client.Dtos.BestCoffee;
using APICOFFE.Client.Dtos.DiscoverMenu;
using APICOFFE.Client.Dtos.FeedBack;
using APICOFFE.Client.Dtos.Navbar;
using APICOFFE.Client.Dtos.OurHistory;
using APICOFFE.Client.Dtos.OurProduct;
using APICOFFE.Client.Dtos.PaymentBenefits;
using APICOFFE.Client.Dtos.ShortInfo;
using APICOFFE.Client.Dtos.WelcomeSlider;
using APICOFFE.Client.Services.Concretes;
using APICOFFE.Contracts.File;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Client.Services.Services;

public class HomeService : IHomeService
{
    private readonly DataContext _dataContext;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;
    public HomeService(DataContext dataContext, IMapper mapper, IFileService fileService)
    {
        _dataContext = dataContext;
        _mapper = mapper;
        _fileService = fileService;
    }

    public async Task<List<NavbarListItemDto>> NavbarListAsync()
    {
        var navbars = await _dataContext.Navbars
                                .AsNoTracking()
                                .Include(n => n.Subnavbars)
                                .ToListAsync();

        return _mapper.Map<List<NavbarListItemDto>>(navbars);
    }

    public async Task<List<WelcomeSliderListItemDto>> WelcomeSliderListAsync(string page)
    {
        var welcomeSliders = await _dataContext.WelcomeSliders
            .Where(wc => wc.ForPage == page)
            .AsNoTracking()
            .Take(3)
            .ToListAsync();
        var welcomeSliderDto = _mapper.Map<List<WelcomeSliderListItemDto>>(welcomeSliders);

        welcomeSliderDto.ForEach(fbm => fbm.ImageURL = fbm.ImageURL != null
        ? _fileService.GetFileUrl(fbm.ImageURL, UploadDirectory.WELCOME_SLIDER)
        : null!);
        return welcomeSliderDto;
    }
    public async Task<ShortInfoListItemDto> GetShortInfoAsync()
    {
        var shortInfo = await _dataContext.ShortInfo.AsNoTracking().SingleOrDefaultAsync();

        return _mapper.Map<ShortInfoListItemDto>(shortInfo);
    }
    public async Task<OurHistoryListItemDto> GetOurHistoryAsync()
    {
        var ourHistory = await _dataContext.OurHistory.AsNoTracking().SingleOrDefaultAsync();
        var dto = _mapper.Map<OurHistoryListItemDto>(ourHistory);
        dto.ImageURL = dto.ImageURL != null
            ? _fileService.GetFileUrl(dto.ImageURL, UploadDirectory.OUR_HISTORY)
            : null!;
        return dto;
    }
    public async Task<List<PaymentBenefitsListItemDto>> PaymentBenefitsListAsync()
    {

        var paymentBenifits = await _dataContext.PaymentBenefits.AsNoTracking().ToListAsync();
        var paymentBeniftsModel = _mapper.Map<List<PaymentBenefitsListItemDto>>(paymentBenifits);

        paymentBeniftsModel.ForEach(fbm => fbm.ImageURL = fbm.ImageURL != null
        ? _fileService.GetFileUrl(fbm.ImageURL, UploadDirectory.PAYMENT_BENEFITS)
        : null!);
        return paymentBeniftsModel;
    }

    public async Task<List<BestCoffeeListItemDto>> BestCoffeeListAsync()
    {
        var bestCoffee = await _dataContext.Drinks
           .OrderByDescending(bc => bc.OrderProducts!
           .Where(op => op.Order.Status == Contracts.Order.Status.Completed).Count())
           .Include(d => d.DrinkCategory)
           .Where(dc => dc.DrinkCategory.Name == "coffee")
           .AsNoTracking()
           .Take(5)
           .ToListAsync();


        var bestCoffeeDto = _mapper.Map<List<BestCoffeeListItemDto>>(bestCoffee);
        bestCoffeeDto.ForEach(bcm => bcm.ImageURL = bcm.ImageURL != null
                        ? _fileService.GetFileUrl(bcm.ImageURL, UploadDirectory.DRINK_IMAGE)
                        : null!);

        return bestCoffeeDto;
    }
    public async Task<List<OurProductListItemDto>> OurProductListAsync(int foodCategoryId)
    {

        var product = await _dataContext.Foods
              .Include(f => f.FoodCategory)
              .Include(f => f.FoodImages)
              .Where(f => f.FoodCategory!.Id == foodCategoryId)
              .ToListAsync();

        var productDto = _mapper.Map<List<OurProductListItemDto>>(product);

        productDto.ForEach
                        (fbm => fbm.ImageURL = fbm.ImageURL != null
                        ? _fileService.GetFileUrl(fbm.ImageURL, UploadDirectory.FOOD_IMAGE)
                        : null!);
        return productDto;
    }
    public async Task<List<FeedBackListItemDto>> FeedBacksListAsync()
    {
        var feedBacks =
                       await _dataContext.FeedBacks.Include(f => f.Role)
                                   .Take(5)
                                   .ToListAsync();
        var feedBacksDto = _mapper.Map<List<FeedBackListItemDto>>(feedBacks);

        feedBacks.ForEach
                        (fbm => fbm.ImageNameInFileSystem = fbm.ImageNameInFileSystem != null
                        ? _fileService.GetFileUrl(fbm.ImageNameInFileSystem, UploadDirectory.FEEDBACK)
                        : null!);

        return feedBacksDto;
    }


    public async Task<DiscoverMenuListItemDto> GetDiscoverMenuAsync()
    {
        var discoverMenu = await _dataContext.DiscoverMenu
           .Include(dm => dm.DiscoverMenuImages)
           .AsNoTracking()
           .SingleOrDefaultAsync();

        var discoverMenuDto = _mapper.Map<DiscoverMenuListItemDto>(discoverMenu);
        discoverMenuDto.ImageURLs =
            discoverMenuDto.ImageURLs.Select(url => url = _fileService
            .GetFileUrl(url, UploadDirectory.DISCOVER_MENU_IMAGE)).ToList();


        return discoverMenuDto;
    }
}
