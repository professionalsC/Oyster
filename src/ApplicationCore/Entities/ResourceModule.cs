using System;
using Oyster.ApplicationCore.Interfaces;

namespace Oyster.ApplicationCore.Entities;
public class ResourceModule:BaseEntity, IAggregateRoot
{
    public string Name { get; set; }
    public string Icon { get; set; }
    public string Aliase { get; set; }


    public ResourceModule(string name,string icon,string aliase)
    {
        Name = name;
        Icon = icon;    
        Aliase = aliase;

    }

    public void UpdateIconUri(string icon)
    {
        throw new NotImplementedException();
    }

    public void UpdateResourceModule(string name, string icon, string aliase)
    {
        throw new NotImplementedException();
    }
}
