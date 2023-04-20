using APICOFFE.Client.Services.Concretes;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;

namespace APICOFFE.Client.Services.Services;

public class MenuService : IMenuService
{
    private readonly DataContext _dataContext;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;
    public MenuService
        (DataContext dataContext,
        IMapper mapper,
        IFileService fileService)
    {
        _dataContext = dataContext;
        _mapper = mapper;
        _fileService = fileService;
    }
}