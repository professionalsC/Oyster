using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Oyster.ApplicationCore.Interfaces;
using Oyster.Infrastructure.Identity;
using Swashbuckle.AspNetCore.Annotations;

namespace Oyster.PublicApi.AuthEndpoints;

public class Register: BaseAsyncEndpoint
    .WithRequest<SignUpRequest>
    .WithResponse<AuthenticateResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ITokenClaimsService _tokenClaimsService;

    public Register(UserManager<ApplicationUser> userManager, ITokenClaimsService tokenClaimsService)
    {
        _userManager=userManager;
        _tokenClaimsService=tokenClaimsService;
    }
    [HttpPost("api/register")]
    [SwaggerOperation(
       Summary = "Register a user",
       Description = "Register a user",
       OperationId = "auth.register",
       Tags = new[] { "AuthEndpoints" })
   ]
    public override async Task<ActionResult<AuthenticateResponse>> HandleAsync(SignUpRequest request, CancellationToken cancellationToken = default)
    {
        var response = new AuthenticateResponse(request.CorrelationId());
        var adminUser = new ApplicationUser { UserName = request.Username, Email = request.Email };
        var result = await _userManager.CreateAsync(adminUser, request.Password);
        adminUser = await _userManager.FindByNameAsync(request.Username);
        await _userManager.AddToRoleAsync(adminUser, request.Role);
        response.Result = result.Succeeded;
        response.Username = request.Username;
        if (result.Succeeded)
        {
            response.Token = await _tokenClaimsService.GetTokenAsync(request.Username);
        }
        return response;
    }
}
