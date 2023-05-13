using APICOFFE.Client.Services.Concretes;
using APICOFFE.Contracts.WelcomeSlider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICOFFE.Client.Controllers;

[Route("service")]
[ApiController]
public class ServiceController : ControllerBase
{
    private readonly IHomeService _homeService;
    private readonly IServiceService _serviceService;
    public ServiceController
        (IHomeService homeService,
        IServiceService serviceService)
    {
        _homeService = homeService;
        _serviceService = serviceService;
    }
    [HttpGet("welcome-sliders")]
    public async Task<IActionResult> WelcomeSliderListAsync()
    {
        return Ok(await _homeService.WelcomeSliderListAsync(Pages.SERVICES));
    }
    [HttpGet("payment-benefits")]
    public async Task<IActionResult> PaymentBenefitsListAsync()
    {
        return Ok(await _serviceService.PaymentBenefitsListAsync());
    }
}
