using APICOFFE.Client.Dtos.PaymentBenefits;
using APICOFFE.Client.Services.Concretes;
using APICOFFE.Contracts.File;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Client.Services.Services;

public class ServiceService : IServiceService
{
    private readonly DataContext _dataContext;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;
    public ServiceService(DataContext dataContext, IMapper mapper, IFileService fileService)
    {
        _dataContext = dataContext;
        _mapper = mapper;
        _fileService = fileService;
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
}
