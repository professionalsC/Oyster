using System;

namespace Oyster.PublicApi.ResourceModuleEndPoints;

public class GetByIdResourceModuleResponse:BaseResponse
{
    public GetByIdResourceModuleResponse(Guid correlationId) : base(correlationId)
    {
    }

    public GetByIdResourceModuleResponse()
    {
    }

    public ResourceModuleDto ResourceModule { get; set; }
}
