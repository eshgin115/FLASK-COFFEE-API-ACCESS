using APICOFFE.Admin.Dtos.Navbar;
using APICOFFE.Database.Models;
using APICOFFE.Exceptions;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Services.Services
{
    public class NavbarService : INavbarService
    {
        private readonly DataContext _dataContext;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        public NavbarService
            (DataContext dataContext,
            IFileService fileService,
            IMapper mapper)
        {
            _dataContext = dataContext;
            _fileService = fileService;
            _mapper = mapper;
        }
        public async Task<List<NavbarListItemDto>> ListAsync()
        {
            var navbars = await _dataContext.Navbars.AsNoTracking().ToListAsync();
            return _mapper.Map<List<NavbarListItemDto>>(navbars);
        }

        public async Task<NavbarListItemDto> AddAsync(NavbarCreateDto dto)
        {
            if (_dataContext.Navbars.Any(n => n.Order == dto.Order))
                throw new ExistException("order allready used");

            var navbar = _mapper.Map<Navbar>(dto);

            await _dataContext.Navbars.AddAsync(_mapper.Map<Navbar>(dto));

            await _dataContext.SaveChangesAsync();

            return _mapper.Map<NavbarListItemDto>(navbar);
        }

        public Task<NavbarListItemDto> UpdateAsync(int id, NavbarUpdateDto dto)
        {
            throw new NotImplementedException();
        }
        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}
