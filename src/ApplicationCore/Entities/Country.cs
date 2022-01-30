using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oyster.ApplicationCore.Interfaces;

namespace Oyster.ApplicationCore.Entities;

public class Country:BaseEntity, IAggregateRoot
{
    public string Name { get; set; }
    public string Code { get; set; }
    public Country(string name, string code)
    {
        Name = name;
        Code = code;
    }
}
