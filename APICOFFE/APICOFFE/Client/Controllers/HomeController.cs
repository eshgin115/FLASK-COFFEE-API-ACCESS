using APICOFFE.Client.Services.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICOFFE.Client.Controllers;

[Route("home")]
[ApiController]
public class HomeController : ControllerBase
{
    private readonly IHomeService _homeService;
    public HomeController(IHomeService homeService)
    {
        _homeService = homeService;
    }
    [HttpGet("navbars")]
    public async Task<IActionResult> NavbarListAsync()
    {
        return Ok(await _homeService.NavbarListAsync());
    }

    [HttpGet("welcome-sliders")]
    public async Task<IActionResult> WelcomeSliderListAsync(string page)
    {
        return Ok(await _homeService.WelcomeSliderListAsync(page));
    }
    [HttpGet("short-info")]
    public async Task<IActionResult> GetShortInfoAsync()
    {
        return Ok(await _homeService.GetShortInfoAsync());
    }
    [HttpGet("our-history")]
    public async Task<IActionResult> GetOurHistoryAsync()
    {
        return Ok(await _homeService.GetOurHistoryAsync());
    }
    [HttpGet("payment-benefits")]
    public async Task<IActionResult> PaymentBenefitsListAsync()
    {
        return Ok(await _homeService.PaymentBenefitsListAsync());
    }
    [HttpGet("best-coffee")]
    public async Task<IActionResult> BestCoffeeListAsync()
    {
        return Ok(await _homeService.BestCoffeeListAsync());
    }
    [HttpGet("our-products")]
    public async Task<IActionResult> OurProductListAsync(int foodCategoryId)
    {
        return Ok(await _homeService.OurProductListAsync(foodCategoryId));
    }
    [HttpGet("feedbacks")]
    public async Task<IActionResult> FeedBacksListAsync()
    {
        return Ok(await _homeService.FeedBacksListAsync());
    }

    [HttpGet("discover-menu")]
    public async Task<IActionResult> GetDiscoverMenuAsync()
    {
        return Ok(await _homeService.GetDiscoverMenuAsync());
    }
}
