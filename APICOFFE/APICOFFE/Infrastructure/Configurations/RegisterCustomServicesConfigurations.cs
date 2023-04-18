
using APICOFFE.Admin.Services.Concretes;
using APICOFFE.Admin.Services.Services;
using APICOFFE.Services.Concretes;
using APICOFFE.Services.Services;

namespace APICOFFE.Infrastructure.Configurations
{
    public static class RegisterCustomServicesConfigurations
    {
        public static void RegisterCustomServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSingleton<IFileService, FileService>();
            services.AddScoped<IFeedbackSevice, FeedbackService>();
            services.AddScoped<IDiscoverMenuService, DiscoverMenuService>();
            services.AddScoped<INavbarService, NavbarService>();
            services.AddScoped<ISubnavbarService, SubnavbarService>();
            services.AddScoped<IShortInfoService, ShortInfoService>();
            services.AddScoped<IWelcomeSliderService, WelcomeSliderService>();
            services.AddScoped<IPaymentBenefitsService, PaymentBenefitsService>();
            services.AddScoped<IOurHistoryService, OurHistoryService>();
            services.AddScoped<ISizeService, SizeService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IEmailService, SMTPService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserActivationService, UserActivationService>();
            services.AddScoped<IDrinkCategoryService, DrinkCategoryService>();
            services.AddScoped<IDrinkService, DrinkService>();
            services.AddScoped<IFoodCategoryService, FoodCategoryService>();
            services.AddScoped<IBasketService, BasketService>();
            //services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IFoodService, FoodService>();
            services.AddScoped<IOrderService, OrderService>();
            //services.AddScoped<IsAuthenticated>();
        }
    }
}
