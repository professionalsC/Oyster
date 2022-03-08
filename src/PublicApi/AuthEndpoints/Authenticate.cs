using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Oyster.ApplicationCore.Interfaces;
using Oyster.Infrastructure.Identity;
using Swashbuckle.AspNetCore.Annotations;

namespace Oyster.PublicApi.AuthEndpoints;

public class Authenticate : BaseAsyncEndpoint
    .WithRequest<AuthenticateRequest>
    .WithResponse<AuthenticateResponse>
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ITokenClaimsService _tokenClaimsService;
    private readonly UserManager<ApplicationUser> _userManager;



    public Authenticate(SignInManager<ApplicationUser> signInManager,ITokenClaimsService tokenClaimsService, UserManager<ApplicationUser> userManager)
    {
        _signInManager = signInManager;
        _tokenClaimsService = tokenClaimsService;
         _userManager=userManager;
    }

    [HttpPost("api/authenticate")]
    [SwaggerOperation(
        Summary = "Authenticates a user",
        Description = "Authenticates a user",
        OperationId = "auth.authenticate",
        Tags = new[] { "AuthEndpoints" })
    ]

    public override async Task<ActionResult<AuthenticateResponse>> HandleAsync(AuthenticateRequest request, CancellationToken cancellationToken)
    {
        var response = new AuthenticateResponse(request.CorrelationId());

        // This doesn't count login failures towards account lockout
        // To enable password failures to trigger account lockout, set lockoutOnFailure: true
        //  var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: true);

        var result = await _signInManager.PasswordSignInAsync(request.Username, request.Password, request.RememberMe, lockoutOnFailure: false);
        response.Result = result.Succeeded;
        response.IsLockedOut = result.IsLockedOut;
        response.IsNotAllowed = result.IsNotAllowed;
        response.RequiresTwoFactor = result.RequiresTwoFactor;
        response.Username = request.Username;
        var user = await _userManager.FindByNameAsync(request.Username);

        var roles = await _userManager.GetRolesAsync(user);


        if (result.Succeeded)
        {
            response.Token = await _tokenClaimsService.GetTokenAsync(request.Username);
            response.Role= roles[0];
        }
        return response;
    } 
    
}
