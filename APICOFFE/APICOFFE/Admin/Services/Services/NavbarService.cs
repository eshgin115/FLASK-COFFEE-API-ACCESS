using APICOFFE.Admin.Dtos.Navbar;
using APICOFFE.Admin.Services.Concretes;
using APICOFFE.Database.Models;
using APICOFFE.Exceptions;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Admin.Services.Services
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

            await _dataContext.Navbars.AddAsync(navbar);

            await _dataContext.SaveChangesAsync();


            return _mapper.Map<NavbarListItemDto>(navbar);
        }

        public async Task<NavbarListItemDto> UpdateAsync(int id, NavbarUpdateDto dto)
        {
            var navbar = await _dataContext.Navbars.FirstOrDefaultAsync(n => n.Id == id)
                ?? throw new NotFoundException("Navbar", id);



            if (!_dataContext.Navbars.Any(n => n.Id == id) && !(dto.Order == navbar.Order))
                throw new ExistException("This order used another navbar");

            _mapper.Map(dto, navbar);


            await _dataContext.SaveChangesAsync();

            return _mapper.Map<NavbarListItemDto>(navbar);
        }
        public async Task DeleteAsync(int id)
        {
            var navbar = await _dataContext.Navbars.FirstOrDefaultAsync(n => n.Id == id)
                ?? throw new NotFoundException("Navbar", id);

            _dataContext.Navbars.Remove(navbar);

            await _dataContext.SaveChangesAsync();
        }

    }
}
