//using FLASK_COFFEE_API.Services.Concretes;
//using FLASK_COFFEE_API.Services.Services;

using APICOFFE.Services.Concretes;
using APICOFFE.Services.Services;

namespace APICOFFE.Infrastructure.Configurations
{
    public static class RegisterCustomServicesConfigurations
    {
        public static void RegisterCustomServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IDiscoverMenuService, DiscoverMenuService>();
            services.AddScoped<INavbarService, NavbarService>();
            services.AddScoped<ISubnavbarService, SubnavbarService>();
            services.AddScoped<IShortInfoService, ShortInfoService>();
            services.AddScoped<IWelcomeSliderService, WelcomeSliderService>();
            services.AddScoped<IPaymentBenefitsService, PaymentBenefitsService>();
            services.AddScoped<IOurHistoryService, OurHistoryService>();

            //services.AddScoped<IEmailService, SMTPService>();
            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IBasketService, BasketService>();
            //services.AddSingleton<IFileService, FileService>();
            //services.AddScoped<INotificationService, NotificationService>();
            //services.AddScoped<IFoodService, FoodService>();
            //services.AddScoped<IDrinkService, DrinkService>();
            //services.AddScoped<IOrderService, OrderService>();
            //services.AddScoped<IUserActivationService, UserActivationService>();
            //services.AddScoped<IsAuthenticated>();
        }
    }
}
