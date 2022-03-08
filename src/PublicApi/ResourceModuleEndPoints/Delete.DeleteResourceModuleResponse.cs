using System;

namespace Oyster.PublicApi.ResourceModuleEndPoints;

public class DeleteResourceModuleResponse:BaseResponse
{
    public DeleteResourceModuleResponse(Guid correlationId) : base(correlationId)
    {
    }

    public DeleteResourceModuleResponse()
    {
    }

    public string Status { get; set; } = "Deleted";
}
