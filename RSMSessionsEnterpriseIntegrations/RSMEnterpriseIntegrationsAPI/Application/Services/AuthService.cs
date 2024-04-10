namespace RSMEnterpriseIntegrationsAPI.Application.Services
{
  using AutoMapper;
  using FluentValidation;
  using Microsoft.IdentityModel.Tokens;
  using RSMEnterpriseIntegrationsAPI.Application.DTOs;
  using RSMEnterpriseIntegrationsAPI.Application.Exceptions;
  using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
  using RSMEnterpriseIntegrationsAPI.Domain.Models;
  using System.IdentityModel.Tokens.Jwt;
  using System.Security.Claims;
  using System.Text;
  using System.Threading.Tasks;

  public class AuthService : IAuthService
  {
    private readonly IAuthRepository _authRepository;
    private readonly IValidator<RegisterDto> _registerValidator;
    private readonly IValidator<LoginDto> _loginValidator;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public AuthService(IAuthRepository repository, IValidator<RegisterDto> registerValidator, IValidator<LoginDto> loginValidator, IConfiguration configuration, IMapper mapper, IPasswordHasher passwordHasher)
    {
      _authRepository = repository;
      _registerValidator = registerValidator;
      _loginValidator = loginValidator;
      _mapper = mapper;
      _configuration = configuration;
      _passwordHasher = passwordHasher;
    }

    public async Task<AuthResponseDto> Register(RegisterDto userDto)
    {
      var validationResult = _registerValidator.Validate(userDto);

      if (!validationResult.IsValid)
      {
        throw new BadRequestException("User info is not valid. " + string.Join(" ", validationResult.Errors.Select(error => error.ErrorMessage)));
      }

      // Verificar si el correo electrónico ya está registrado
      if (await IsEmailRegistered(userDto.Email))
      {
        throw new BadRequestException("Email is already registered.");
      }

      var user = _mapper.Map<User>(userDto);

      // Encripta la contraseña antes de guardarla en la base de datos
      user.Password = _passwordHasher.HashPassword(user.Password);


      await _authRepository.Register(user);

      // Genera el token JWT
      var token = GenerateToken(user);

      // Devuelve el token JWT
      return new AuthResponseDto
      {
        Token = token
      };
    }

    public async Task<AuthResponseDto> Login(LoginDto loginDto)
    {

      var validationResult = _loginValidator.Validate(loginDto);

      Console.WriteLine(string.Join(" ", validationResult.Errors.Select(error => error.ErrorMessage)));

      if (!validationResult.IsValid)
      {
        throw new BadRequestException("Login info is not valid. " + string.Join(" ", validationResult.Errors.Select(error => error.ErrorMessage)));
      }

      // Buscar el usuario por su email
      var user = await _authRepository.GetUserByEmail(loginDto.Email);

      if (user == null)
      {
        throw new UnauthorizedException("Invalid email or password.");
      }

      // Verificar si la contraseña proporcionada coincide con la contraseña almacenada en la base de datos
      if (!_passwordHasher.VerifyPassword(loginDto.Password, user.Password))
      {
        throw new UnauthorizedException("Invalid email or password.");
      }

      var token = GenerateToken(user);

      return new AuthResponseDto()
      {
        Token = token
      };

    }

    private string GenerateToken(User user)
    {
      // Crear los claims del usuario (pueden incluir roles u otras informaciones)
      var claims = new[]
      {
                new Claim("name", user.Name),
                new Claim("email", user.Email),
                new Claim("role", user.Role)
            };

      // Generar la clave secreta utilizada para firmar el token
      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

      // Crear las credenciales de firma usando el algoritmo HmacSha256
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(
        claims: claims,
        expires: DateTime.Now.AddHours(1),
        signingCredentials: creds
      );

      // Devolver el token JWT generado
      return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private async Task<bool> IsEmailRegistered(string email)
    {
      var existingUser = await _authRepository.GetUserByEmail(email);
      return existingUser != null;
    }
  }

}
