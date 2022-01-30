using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oyster.ApplicationCore.Interfaces;

namespace Oyster.ApplicationCore.Entities;

public class Province:BaseEntity, IAggregateRoot
{
    public int CountryId { get; set; }
    public Country Country { get; set; }
    public string Name { get; set; }
    public Province(string name,int countrId)
    {
        Name = name;
        CountryId = countrId;
    }
}
