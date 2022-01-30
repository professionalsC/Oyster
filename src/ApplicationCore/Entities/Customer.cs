using System;
using Oyster.ApplicationCore.Interfaces;

namespace Oyster.ApplicationCore.Entities;

public class Customer:BaseEntity, IAggregateRoot
{
    public string MobileNumber { get; set; }
    public string FName { get; set; }
    public string MName { get; set; }
    public string LName { get; set; }
    public int GenderId { get; set; }
    public Gender Gender { get; set; }
    public DateTime Dob { get; set; }
    public string ProfilePicture { get; set; }
    public int CountryId { get; set; }
    public Country Country { get; set; }
    public int ProvinceId { get; set; }
    public Province Province { get; set; }
    public int DistrictId { get; set; }
    public District District { get; set; }
    public string City { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }

    public Customer(string mobileNumber,
        string fName,
        string mName,
        string lName,
        int genderId,
        DateTime dob,
        string profilePicture,
        int countryId,
        int proviceId,
        int districtId,
        string city,
        string addressLine1,
        string addressLine2)
    {
        MobileNumber = mobileNumber;
        FName = fName;
        MName = mName;
        LName = lName;
        GenderId = genderId;
        Dob = dob;
        ProfilePicture = profilePicture;
        CountryId = countryId;
        ProvinceId = proviceId;
        DistrictId = districtId;
        City = city;
        AddressLine1 = addressLine1;
        AddressLine2 = addressLine2;
    }
}
