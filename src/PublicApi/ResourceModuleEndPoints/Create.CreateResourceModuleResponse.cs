using System;

namespace Oyster.PublicApi.ResourceModuleEndPoints;

public class CreateResourceModuleResponse:BaseResponse
{
    public CreateResourceModuleResponse(Guid correlationId) : base(correlationId)
    {
    }

    public CreateResourceModuleResponse()
    {
    }

    public ResourceModuleDto ResourceModule { get; set; }
}
