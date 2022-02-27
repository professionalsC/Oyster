using System;
using Ardalis.GuardClauses;
using Oyster.ApplicationCore.Interfaces;

namespace Oyster.ApplicationCore.Entities;

public class CatalogBrand : BaseEntity, IAggregateRoot
{
    public string Brand { get; private set; }
    public string PictureUri { get; private set; }
    public string BannerPictureUri { get; private set; }
    public bool Status { get; private set; }

    public CatalogBrand(string brand, 
        string pictureUri, 
        string bannerPictureUri, 
        bool status)
    {
        Brand = brand;
        PictureUri = pictureUri;
        BannerPictureUri = bannerPictureUri;
        Status = status;

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
    public void UpdateBannerPictureUri(string bannerPictureName)
    {
        if (string.IsNullOrEmpty(bannerPictureName))
        {
            BannerPictureUri = string.Empty;
            return;
        }
        BannerPictureUri = $"images\\products\\{bannerPictureName}?{new DateTime().Ticks}";
    }

    public void UpdateBrand(string brand,bool status)
    {
        Guard.Against.NullOrEmpty(brand, nameof(brand));
        Brand = Brand;
        Status = status;
    }
}
