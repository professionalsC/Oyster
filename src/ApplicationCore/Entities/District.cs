using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oyster.ApplicationCore.Interfaces;

namespace Oyster.ApplicationCore.Entities;

public class District:BaseEntity, IAggregateRoot
{
    public int ProvinceId { get; set; }
    public Province Province { get; set; }
    public string Name { get; set; }
    public District(string name, int provinceId)
    {
       Name = name;
        ProvinceId = provinceId;
    }
}
