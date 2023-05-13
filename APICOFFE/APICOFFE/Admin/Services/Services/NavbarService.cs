using APICOFFE.Admin.Dtos.Navbar;
using APICOFFE.Admin.Services.Concretes;
using APICOFFE.Contracts.ModelName;
using APICOFFE.Database.Models;
using APICOFFE.Exceptions;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace APICOFFE.Admin.Services.Services;

public class NavbarService : INavbarService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    public NavbarService
        (DataContext dataContext,
        IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }
    public IEnumerable<string> GetUrlsForGetMethods()
    {
        var controllerTypes = Assembly.GetExecutingAssembly().GetTypes().Where(type => typeof(ControllerBase).IsAssignableFrom(type));
        var urls = new List<string>();

        foreach (var controllerType in controllerTypes)
        {
            var methods = controllerType.GetMethods().Where(m => m.CustomAttributes.Any(attr => attr.AttributeType == typeof(HttpGetAttribute)));

            foreach (var method in methods)
            {
                var url = $"/{controllerType.Name.Replace("Controller", "")}/{method.Name}";

                urls.Add(url);
            }
        }

        return urls;
    }
    public async Task<List<NavbarListItemDto>> ListAsync()
    {
        var navbars = await _dataContext.Navbars.AsNoTracking().ToListAsync();
        return _mapper.Map<List<NavbarListItemDto>>(navbars);
    }

    public async Task<NavbarListItemDto> AddAsync(NavbarCreateDto dto)
    {
        if (_dataContext.Navbars.Any(n => n.Order == dto.Order))
            throw new ValidationException("order allready used");

        var navbar = _mapper.Map<Navbar>(dto);

        await _dataContext.Navbars.AddAsync(navbar);

        await _dataContext.SaveChangesAsync();


        return _mapper.Map<NavbarListItemDto>(navbar);
    }

    public async Task<NavbarListItemDto> UpdateAsync(int id, NavbarUpdateDto dto)
    {
        var navbar = await _dataContext.Navbars.FirstOrDefaultAsync(n => n.Id == id)
            ?? throw new NotFoundException(DomainModelNames.NAVBAR, id);



        if (!_dataContext.Navbars.Any(n => n.Id == id) && !(dto.Order == navbar.Order))
            throw new ValidationException("This order used another navbar");

        _mapper.Map(dto, navbar);


        await _dataContext.SaveChangesAsync();

        return _mapper.Map<NavbarListItemDto>(navbar);
    }
    public async Task DeleteAsync(int id)
    {
        var navbar = await _dataContext.Navbars.FirstOrDefaultAsync(n => n.Id == id)
            ?? throw new NotFoundException(DomainModelNames.NAVBAR, id);

        _dataContext.Navbars.Remove(navbar);

        await _dataContext.SaveChangesAsync();
    }

}
