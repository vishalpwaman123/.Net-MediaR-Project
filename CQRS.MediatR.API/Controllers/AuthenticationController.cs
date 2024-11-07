using AutoMapper;
using CQRS.Mediator.Model;
using CQRS.Mediator.ServiceLayer;
using CQRS.MediatR.API.Data.Command;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CQRS.MediatR.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public AuthenticationController(IMediator mediator, IMapper mapper, IConfiguration configuration)
        {
            _mediator = mediator;
            _mapper = mapper;
            _configuration = configuration;
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            try
            {
                var response = await _mediator.Send(new RegisterEmployeeQuery(request.EmailID, request.Password));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(new BasicResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                });
            }

        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(RegisterRequest request)
        {
            LoginResponse response = new LoginResponse();
            try
            {
                response = await _mediator.Send(new LoginEmployeeQuery(request.EmailID, request.Password));
                if (response.IsSuccess)
                {
                    var authClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, request.EmailID),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };
                    response.Token = GetToken(authClaims);
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        private string GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token).ToString();
        }

    }
}
