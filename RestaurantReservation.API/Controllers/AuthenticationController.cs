using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace RestaurantReservation.API.Controllers;

/// <summary>
/// Authentication controller
/// </summary>
[Route("authentication")]
[ApiController]
public class AuthenticationController  : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AuthenticationController(IConfiguration configuration)
    {
        _configuration = configuration ?? 
                         throw new ArgumentNullException(nameof(configuration));
    }

    public class AuthenticationRequestBody
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
    
    private class UserInfoUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UserInfoUser(
            int userId, 
            string userName, 
            string firstName, 
            string lastName)
        {
            UserId = userId;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
        }

    }
    
    [HttpPost("authenticate")]
    public ActionResult<string> GenerateToken(
        AuthenticationRequestBody authenticationRequestBody) 
    {
        var user = ValidateUserCredentials(
            authenticationRequestBody.UserName ?? "",
            authenticationRequestBody.Password ?? "");

        if (user == null)
        {
            return Unauthorized();
        }

        var securityKey = new SymmetricSecurityKey(
            Convert.FromBase64String(_configuration["Authentication:SecretForkey"]));
        var signingCredentials = new SigningCredentials(
            securityKey, SecurityAlgorithms.HmacSha256);
 
        var claimsForToken = new List<Claim>();
        claimsForToken.Add(new Claim("sub", user.UserId.ToString()));
        claimsForToken.Add(new Claim("given_name", user.FirstName));
        claimsForToken.Add(new Claim("family_name", user.LastName));
 
        var jwtSecurityToken = new JwtSecurityToken(
            _configuration["Authentication:Issuer"],
            _configuration["Authentication:Audience"],
            claimsForToken,
            DateTime.UtcNow,
            DateTime.UtcNow.AddHours(1),
            signingCredentials);

        var tokenToReturn = new JwtSecurityTokenHandler()
            .WriteToken(jwtSecurityToken);

        return Ok(tokenToReturn);
    }

    private UserInfoUser? ValidateUserCredentials(string userName, string password)
    {
        //this is a dummy validation for test only
        return userName.Equals("loor") ? new UserInfoUser(1, "Loor Sawalhi", "Loor", "Sawalhi") : null;
    }
}