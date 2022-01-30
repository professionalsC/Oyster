using System;
using Ardalis.GuardClauses;
using Oyster.ApplicationCore.Interfaces;

namespace Oyster.ApplicationCore.Entities;

public class CatalogBrand : BaseEntity, IAggregateRoot
{
    public string Brand { get; private set; }
    public string PictureUri { get; set; }
    public CatalogBrand(string brand, string pictureUri)
    {
        Brand = brand;
        PictureUri = pictureUri;

    }
    public void UpdatePictureUri(string pictureName)
    {
        if (string.IsNullOrEmpty(pictureName))
        {
            PictureUri = string.Empty;
            return;
        }
        PictureUri = $"images\\products\\{pictureName}?{new DateTime().Ticks}";
    }    

    public void UpdateBrand(string brand)
    {
        Guard.Against.NullOrEmpty(brand, nameof(brand));
        Brand = Brand;
    }
}
