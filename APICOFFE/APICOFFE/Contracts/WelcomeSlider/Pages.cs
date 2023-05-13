namespace APICOFFE.Contracts.WelcomeSlider;

public class Pages
{
    public const string HOME = "Home";
    public const string MENU = "Menu";
    public const string CART = "Cart";
    public const string SERVICES = "services";

    public static List<string> GetAll()
    {
        return new List<string>()
            {
                HOME,
                MENU,
                CART,
                SERVICES,
            };
    }
}