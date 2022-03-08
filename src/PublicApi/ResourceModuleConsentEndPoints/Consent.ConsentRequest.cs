using System.Collections.Generic;
using Oyster.ApplicationCore.Entities;

namespace Oyster.PublicApi.ResourceModuleConsentEndPoints;

public class ConsentRequest:BaseRequest
{
    public string Role { get; set; }
    public List<ResourceModuleConsent> ResourceModulePermissions { get; set; }
}
