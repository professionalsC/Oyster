using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oyster.ApplicationCore.Interfaces;

namespace Oyster.ApplicationCore.Entities;

public class CatalogGenderType : BaseEntity, IAggregateRoot
{
    public string GenderType { get; private set; }
    public CatalogGenderType(string genderType)
    {
        GenderType = genderType;
    }
}
