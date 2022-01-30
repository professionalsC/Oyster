using System;
using Oyster.ApplicationCore.Interfaces;

namespace Oyster.ApplicationCore.Entities;

public class DeliveryBoy:BaseEntity, IAggregateRoot
{
    public string Name { get; set; }
    public string NickName { get; set; }
    public int GenderId { get; set; }
    public Gender Gender { get; set; }
    public DateTime Dob { get; set; }
    public string ContactNumber1 { get; set; }
    public string ContactNumber2 { get; set; }
    public string Email { get; set; }
    public int CountryId { get; set; }
    public int ProvinceId { get; set; }
    public int DistrictId { get; set; }
    public string AddressLine1 { get; set; }
}
