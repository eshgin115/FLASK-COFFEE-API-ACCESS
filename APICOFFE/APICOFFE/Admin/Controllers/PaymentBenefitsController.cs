using APICOFFE.Admin.Dtos.PaymentBenefits;
using APICOFFE.Admin.Services.Concretes;
using APICOFFE.Contracts.Identity;
using APICOFFE.Services.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APICOFFE.Admin.Controllers;
[ApiController]
[Route("payment-benefits")]

[Authorize(Roles = RoleNames.ADMIN)]

public class PaymentBenefitsController : ControllerBase
{
    private readonly IPaymentBenefitsService _PaymentBenefitsService;

    public PaymentBenefitsController(IPaymentBenefitsService paymentBenefitsService)
    {
        _PaymentBenefitsService = paymentBenefitsService;
    }
    #region List
    [HttpGet("payment-benefits")]
    public async Task<IActionResult> ListAsync()
    {
        return Ok(await _PaymentBenefitsService.ListAsync());
    }
    #endregion

    #region Add
    [HttpPost("payment-benefits")]
    public async Task<IActionResult> AddAsync([FromForm] PaymentBenefitsCreateDto dto)
    {
        return Created(string.Empty, await _PaymentBenefitsService.AddAsync(dto));
    }
    #endregion

    #region Update
    [HttpPut("payment-benefits/{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromForm] PaymentBenefitsUpdateDto dto)
    {
        return Ok(await _PaymentBenefitsService.UpdateAsync(id, dto));
    }
    #endregion

    #region Delete
    [HttpDelete("payment-benefits/{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _PaymentBenefitsService.DeleteAsync(id);

        return NoContent();
    }
    #endregion
}
