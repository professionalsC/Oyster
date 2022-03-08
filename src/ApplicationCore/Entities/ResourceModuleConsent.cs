using System;
using Oyster.ApplicationCore.Interfaces;

namespace Oyster.ApplicationCore.Entities;
public class ResourceModuleConsent : BaseEntity, IAggregateRoot
{
    public string Role { get; set; }
    public int ResourceModuleId { get; set; }
    public ResourceModule ResourceModule { get; set; }
    public bool IsViewConsent { get; set; }
    public bool IsUpdateConsent { get; set; }
    public bool IsDeleteConsent { get; set; }
    public ResourceModuleConsent(string role, int resourceModuleId, bool isViewConsent, bool isUpdateConsent, bool isDeleteConsent)
    {
        Role = role;
        ResourceModuleId = resourceModuleId;
        IsViewConsent = isViewConsent;
        IsUpdateConsent = isUpdateConsent;
        IsDeleteConsent = isDeleteConsent;
    }

   
}
