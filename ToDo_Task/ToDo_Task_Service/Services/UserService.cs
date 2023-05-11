using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ToDo_Task_DataAccess.Entity;
using ToDo_Task_Repository.IConfiguration;
using ToDo_Task_Service.DataTransferObjects.Users;
using ToDo_Task_Service.IContracts;

namespace ToDo_Task_Service.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    public UserService(IMapper mapper, IUnitOfWork unitOfWork, IConfiguration configuration)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _configuration = configuration;
    }
    public Task<bool> Register(UserSaveDto userSaveDto)
    {
        var user = _mapper.Map<User>(userSaveDto);
        return _unitOfWork.UserRepository.Register(user);
    }

    public async Task<string> Login(UserSaveDto userSaveDto)
    {
        var user = _mapper.Map<User>(userSaveDto);
      

       var userdb= await _unitOfWork.UserRepository.Login(user);
        return  CreateToken(userdb);
    }

    public async Task<User> GetById(int userId)
        => await _unitOfWork.UserRepository.GetUserById(userId);

    private string CreateToken(User user)
    {
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];
        var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!);
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha512Signature
        );
        var subject = new ClaimsIdentity(new[]
        {

            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Email, user.UserName),
            new Claim(ClaimTypes.Name, user.Id.ToString()),
            new Claim(ClaimTypes.UserData, user.Id.ToString())
        });
        var expires = DateTime.UtcNow.AddMinutes(10);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = subject,
            Expires = DateTime.UtcNow.AddMinutes(10),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = signingCredentials
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = tokenHandler.WriteToken(token);
        return jwtToken;
    }

    
}