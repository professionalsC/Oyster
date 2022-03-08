using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Oyster.ApplicationCore.Entities;
using Oyster.ApplicationCore.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Oyster.PublicApi.ResourceModuleConsentEndPoints;

public class Consent : BaseAsyncEndpoint
    .WithRequest<ConsentRequest>
    .WithResponse<ConsentResponse>
{
    private readonly IRepository<ResourceModuleConsent> _itemRepository;
    private readonly IUriComposer _uriComposer;

    public Consent(IRepository<ResourceModuleConsent> itemRepository,
        IUriComposer uriComposer)
    {
        _itemRepository = itemRepository;
        _uriComposer = uriComposer;
    }

    [HttpPost("api/consent")]
    [SwaggerOperation(
        Summary = "Creates a new Consent",
        Description = "Creates a new Consent",
        OperationId = "Module.consent",
        Tags = new[] { "ModuleEndPoints" })
    ]
    public override async Task<ActionResult<ConsentResponse>> HandleAsync(ConsentRequest request, CancellationToken cancellationToken = default)
    {
        var response = new ConsentResponse(request.CorrelationId());

        //var catalogItemNameSpecification = new CatalogItemNameSpecification(request.Name);
        //var existingCataloogItem = await _itemRepository.CountAsync(catalogItemNameSpecification, cancellationToken);
        //if (existingCataloogItem > 0)
        //{
        //    throw new DuplicateException($"A catalogItem with name {request.Name} already exists");
        //}
        var dtos = new List<ResourceModuleConsentDto>();
        request.ResourceModulePermissions.ForEach(async permission =>
        {
            var newItem = new ResourceModuleConsent(permission.Role, permission.ResourceModuleId, permission.IsViewConsent, permission.IsUpdateConsent, permission.IsDeleteConsent);
            await _itemRepository.AddAsync(newItem, cancellationToken);

            var dto = new ResourceModuleConsentDto
            {
                Id = newItem.Id,
                Role= newItem.Role,
                ResourceModuleId = newItem.ResourceModuleId,
                IsViewConsent = newItem.IsViewConsent,
                IsUpdateConsent = newItem.IsUpdateConsent,
                IsDeleteConsent = newItem.IsDeleteConsent
            };
        });

       
        response.ResourceModuleConsentDtos = dtos;
        return response;
    }
}
