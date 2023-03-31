//using AutoMapper;
//using FLASK_COFFEE_API.Areas.Client.Dtos.Auth;
//using FLASK_COFFEE_API.Contracts.Identity;
//using FLASK_COFFEE_API.Database;
//using FLASK_COFFEE_API.Database.Models;
//using FLASK_COFFEE_API.Exceptions;
//using FLASK_COFFEE_API.Services.Concretes;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace FLASK_COFFEE_API.Services.Services;

//public class UserService : IUserService
//{

//    private readonly DataContext _dataContext;
//    private readonly IHttpContextAccessor _httpContextAccessor;
//    private readonly IUserActivationService _userActivationService;
//    public readonly IMapper _mapper;
//    private User _currentUser;
//    private readonly IConfiguration _configuration;

//    public UserService(DataContext dataContext,
//        IHttpContextAccessor httpContextAccessor,
//        IUserActivationService userActivationService,
//        IConfiguration configuration,
//        IMapper mapper)
//    {
//        _dataContext = dataContext;
//        _httpContextAccessor = httpContextAccessor;
//        _userActivationService = userActivationService;
//        _configuration = configuration;
//        _mapper = mapper;
//    }

//    public bool IsAuthenticated
//    {
//        get => _httpContextAccessor.HttpContext!.User.Identity!.IsAuthenticated;
//    }

//    public User CurrentUser
//    {
//        get
//        {
//            if (_currentUser is not null)
//            {
//                return _currentUser;
//            }

//            var idClaim = _httpContextAccessor.HttpContext!.User.Claims.FirstOrDefault(C => C.Type == CustomClaimNames.ID);
//            if (idClaim is null)
//                throw new IdentityCookieException("Identity cookie not found");

//            _currentUser = _dataContext.Users
//                .Include(u => u.Basket)
//                .ThenInclude(ub => ub.BasketProducts)
//                .First(u => u.Id == int.Parse(idClaim.Value));

//            return _currentUser;
//        }
//    }

//    public async Task<bool> CheckEmailConfirmedAsync(string? email)
//    {
//        ArgumentNullException.ThrowIfNull(email);
//        return await _dataContext.Users.AnyAsync(u => u.Email == email && u.IsEmailConfirmed);
//    }


//    //public string GetCurrentUserFullName()
//    //{
//    //    return $"{CurrentUser.FirstName} {CurrentUser.LastName}";
//    //}

//    public async Task<bool> CheckPasswordAsync(string? email, string? password)
//    {
//        ArgumentNullException.ThrowIfNull(email);
//        ArgumentNullException.ThrowIfNull(password);


//        var user = await _dataContext.Users.SingleOrDefaultAsync(u => u.Email == email);

//        if (user is null) return false;

//        return BCrypt.Net.BCrypt.Verify(password, user!.Password);

//    }
//    public async Task<string> SignInAsync(int id, string? role = null)
//    {
//        var claims = new List<Claim>
//        {
//                new Claim(CustomClaimNames.ID, id.ToString())
//        };

//        if (role is not null) claims.Add(new Claim(ClaimTypes.Role, role));


//        var issuer = _configuration["JwtOptinos:Issuer"];
//        var audience = _configuration["JwtOptinos:Audience"];
//        var key = _configuration["JwtOptinos:Key"];
//        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
//        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
//        var expireDate = DateTime.Now.AddMinutes(double.Parse(_configuration["JwtOptinos:ExperationMinute"]));



//        var tokenConfigurations = new JwtSecurityToken(
//            issuer,
//            audience,
//            claims,
//            expires: expireDate,
//            signingCredentials: credentials
//            );

//        return new JwtSecurityTokenHandler().WriteToken(tokenConfigurations); ;
//    }

//    public async Task<string> SignInAsync(string? email, string? password, string? role = null)
//    {
//        ArgumentNullException.ThrowIfNull(email);
//        ArgumentNullException.ThrowIfNull(password);
//        var user = await _dataContext.Users.Include(u => u.Role).FirstAsync(u => u.Email == email);


//        if (BCrypt.Net.BCrypt.Verify(password, user!.Password))
//        {
//            if (user.Role != null && user.Role.Name == RoleNames.ADMIN)
//            {
//                return await SignInAsync(user.Id, user.Role.Name);
//            }
//            else
//            {

//                return await SignInAsync(user.Id, role);
//            }
//        }
//        return null;
//    }

//    public async Task SignOutAsync()
//    {
//        await _httpContextAccessor.HttpContext!.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//    }

//    public async Task CreateAsync(RegisterDto model)
//    {
//        ArgumentNullException.ThrowIfNull(model);
//        var user = _mapper.Map<User>(model);
//        await _dataContext.Users.AddAsync(user);
//        await _dataContext.Baskets.AddAsync(_mapper.Map<Basket>(user));
//        await _userActivationService.SendActivationUrlAsync(user);
//        await _dataContext.SaveChangesAsync();
//    }

//    public string GetCurrentUserFullName()
//    {
//        throw new NotImplementedException();
//    }
//}