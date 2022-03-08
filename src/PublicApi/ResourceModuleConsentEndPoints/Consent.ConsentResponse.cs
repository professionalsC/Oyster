using System;
using System.Collections.Generic;
using Oyster.ApplicationCore.Entities;

namespace Oyster.PublicApi.ResourceModuleConsentEndPoints;

public class ConsentResponse:BaseResponse
{
    public ConsentResponse(Guid correlationId) : base(correlationId)
    {
    }

    public string Role { get; set; }
    public List<ResourceModuleConsentDto> ResourceModuleConsentDtos { get; set; }

}
