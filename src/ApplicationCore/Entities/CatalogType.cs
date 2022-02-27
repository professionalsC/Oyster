using System;
using Ardalis.GuardClauses;
using Oyster.ApplicationCore.Interfaces;

namespace Oyster.ApplicationCore.Entities;

public class CatalogType : BaseEntity, IAggregateRoot
{
    public string Type { get; private set; }
    public string PictureUri { get; private set; }
    public string BannerPictureUri { get; private set; }
    public string Description { get; set; }
    public int? ParentCatalogTypeId { get; set; }
    public CatalogType ParentCatalogType { get; set; }
    public bool Status { get; set; }

    public CatalogType(string type, string pictureUri, string bannerPictureUri, string description, int? parentCatalogTypeId,bool status)
    {
        Type = type;
        PictureUri = pictureUri;
        BannerPictureUri = bannerPictureUri;
        Description = description;
        ParentCatalogTypeId = parentCatalogTypeId;
        Status = status;
    }
    public void UpdateType(string type, string description, int? parentCatalogTypeId, bool status)
    {
        Guard.Against.NullOrEmpty(type, nameof(type));
        Type = type;
        Description = description;
        ParentCatalogTypeId= parentCatalogTypeId;
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
}
