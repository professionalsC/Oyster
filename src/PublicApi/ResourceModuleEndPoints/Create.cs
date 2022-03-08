using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oyster.ApplicationCore.Constants;
using Oyster.ApplicationCore.Entities;
using Oyster.ApplicationCore.Exceptions;
using Oyster.ApplicationCore.Interfaces;
using Oyster.ApplicationCore.Specifications;
using Swashbuckle.AspNetCore.Annotations;

namespace Oyster.PublicApi.ResourceModuleEndPoints;

[Authorize(Roles = Constants.Roles.ADMINISTRATORS, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

public class Create : BaseAsyncEndpoint
    .WithRequest<CreateResourceModuleRequest>
    .WithResponse<CreateResourceModuleResponse>
{
    private readonly IRepository<ResourceModule> _itemRepository;
    private readonly IUriComposer _uriComposer;

    public Create(IRepository<ResourceModule> itemRepository,
        IUriComposer uriComposer)
    {
        _itemRepository = itemRepository;
        _uriComposer = uriComposer;
    }

    [HttpPost("api/resourcemodule")]
    [SwaggerOperation(
        Summary = "Creates a new ResourceModule",
        Description = "Creates a new ResourceModule",
        OperationId = "resourcemodule.create",
        Tags = new[] { "ModuleEndPoints" })
    ]
    public override async Task<ActionResult<CreateResourceModuleResponse>> HandleAsync(CreateResourceModuleRequest request, CancellationToken cancellationToken = default)
    {
        var response = new CreateResourceModuleResponse(request.CorrelationId());

        var resourceModuleNameSpecification = new ResourceModuleNameSpecification(request.Name);
        var existingResourceModule = await _itemRepository.CountAsync(resourceModuleNameSpecification, cancellationToken);
        if (existingResourceModule > 0)
        {
            throw new DuplicateException($"A resourcemodule with name {request.Name} already exists");
        }

        var newItem = new ResourceModule(request.Name, request.Icon, request.Aliase);
        newItem = await _itemRepository.AddAsync(newItem, cancellationToken);

        if (newItem.Id != 0)
        {

            newItem.UpdateIconUri(request.Icon);
            await _itemRepository.UpdateAsync(newItem, cancellationToken);
        }

        var dto = new ResourceModuleDto
        {
            Id = newItem.Id,
            Name = newItem.Name,
            Icon = _uriComposer.ComposePicUri(newItem.Icon),
            Aliase = newItem.Aliase,
        };
        response.ResourceModule = dto;
        return response;
    }
}
