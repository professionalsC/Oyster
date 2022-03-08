using System;
using System.Collections.Generic;

namespace Oyster.PublicApi.ResourceModuleEndPoints;

public class ListResourceModuleResponse : BaseResponse
{
    public ListResourceModuleResponse(Guid correlationId) : base(correlationId)
    {
    }

    public ListResourceModuleResponse()
    {
    }

    public List<ResourceModuleDto> ResourceModules { get; set; } = new List<ResourceModuleDto>();
    public int PageCount { get; set; }
}
