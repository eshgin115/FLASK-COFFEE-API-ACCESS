using APICOFFE.Admin.Dtos.PaymentBenefits;
using APICOFFE.Admin.Services.Concretes;
using APICOFFE.Contracts.File;
using APICOFFE.Database.Models;
using APICOFFE.Exceptions;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Admin.Services.Services;

public class PaymentBenefitsService : IPaymentBenefitsService
{
    private readonly DataContext _dataContext;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;
    public PaymentBenefitsService(DataContext dataContext, IFileService fileService, IMapper mapper)
    {
        _dataContext = dataContext;
        _fileService = fileService;
        _mapper = mapper;
    }
    public async Task<List<PaymentBenefitsListItemDto>> ListAsync()
    {

        var paymentBenifits = await _dataContext.PaymentBenefits.AsNoTracking().ToListAsync();
        var paymentBeniftsModel = _mapper.Map<List<PaymentBenefitsListItemDto>>(paymentBenifits);


        paymentBeniftsModel.ForEach(fbm => fbm.ImageURL = fbm.ImageURL != null
        ? _fileService.GetFileUrl(fbm.ImageURL, UploadDirectory.PAYMENT_BENEFITS)
        : null!);
        return paymentBeniftsModel;
    }
    public async Task<PaymentBenefitsListItemDto> AddAsync(PaymentBenefitsCreateDto dto)
    {
        if (_dataContext.PaymentBenefits.Any(p => p.Order == dto.Order))
            throw new ExistException("Order Allready exist");

        var paymentBenefits = _mapper.Map<PaymentBenefits>(dto);
        paymentBenefits.ImageNameInFileSystem = await _fileService
            .UploadAsync(dto!.Image!, UploadDirectory.PAYMENT_BENEFITS);

        await _dataContext.PaymentBenefits.AddAsync(paymentBenefits);

        await _dataContext.SaveChangesAsync();

        return _mapper.Map<PaymentBenefitsListItemDto>(paymentBenefits);
    }
    public async Task<PaymentBenefitsListItemDto> UpdateAsync(int id, PaymentBenefitsUpdateDto dto)
    {
        var paymentBenefits = await _dataContext.PaymentBenefits.FirstOrDefaultAsync(b => b.Id == id)
             ?? throw new NotFoundException("PaymentBenefits", id);

        if (_dataContext.PaymentBenefits.Any(p => p.Order == dto.Order) && !(dto.Order == paymentBenefits.Order))
            throw new ExistException("Order Allready using");

        string imageFileNameInSystem = null!;
        if (dto.Image is not null)
        {
            await _fileService.DeleteAsync(paymentBenefits.ImageNameInFileSystem, UploadDirectory.PAYMENT_BENEFITS);
            imageFileNameInSystem = await _fileService.UploadAsync(dto.Image!, UploadDirectory.PAYMENT_BENEFITS);
        }

        _mapper.Map(dto, paymentBenefits);

        paymentBenefits.ImageNameInFileSystem = imageFileNameInSystem ?? paymentBenefits.ImageNameInFileSystem;

        await _dataContext.SaveChangesAsync();

        return _mapper.Map<PaymentBenefitsListItemDto>(paymentBenefits);
    }
    public async Task DeleteAsync(int id)
    {
        var paymentBenefits = await _dataContext.PaymentBenefits.FirstOrDefaultAsync(b => b.Id == id)
                                          ?? throw new NotFoundException("PaymentBenefits", id);

        await _fileService.DeleteAsync(paymentBenefits.ImageNameInFileSystem, UploadDirectory.PAYMENT_BENEFITS);

        _dataContext.PaymentBenefits.Remove(paymentBenefits);

        await _dataContext.SaveChangesAsync();
    }
}
