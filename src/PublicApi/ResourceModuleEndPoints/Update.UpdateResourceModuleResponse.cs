using System;

namespace Oyster.PublicApi.ResourceModuleEndPoints;

public class UpdateResourceModuleResponse:BaseResponse
{
    public UpdateResourceModuleResponse(Guid correlationId) : base(correlationId)
    {
    }

    public UpdateResourceModuleResponse()
    {
    }

    public ResourceModuleDto ResourceModule { get; set; }
}
