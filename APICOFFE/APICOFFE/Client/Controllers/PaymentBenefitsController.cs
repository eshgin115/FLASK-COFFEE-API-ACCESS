using APICOFFE.Client.Dtos.PaymentBenefits;
using APICOFFE.Contracts.File;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Client.Controllers;

[ApiController]
[Route("payment-benefits")]
public class PaymentBenefitsController : ControllerBase
{
    private readonly DataContext _dataContext;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;

    public PaymentBenefitsController
        (DataContext dataContext, 
        IFileService fileService,
        IMapper mapper)
    {
        _dataContext = dataContext;
        _fileService = fileService;
        _mapper = mapper;
    }

    [HttpGet("payment-benefits")]
    public async Task<IActionResult> ListAsync()
    {
        var paymentBenefits =
            await _dataContext.PaymentBenefits
                                   .OrderBy(p => p.Order)
                                   .Take(3)
                                   .ToListAsync();
        var paymentBenefitsDto = _mapper.Map<List<PaymentBenefitsListItemDto>>(paymentBenefits);

        paymentBenefitsDto.ForEach
                        (fbm => fbm.ImageURL = fbm.ImageURL != null
                        ? _fileService.GetFileUrl(fbm.ImageURL, UploadDirectory.PAYMENT_BENEFITS)
                        : null!);
        return Ok(paymentBenefitsDto);

    }
}
