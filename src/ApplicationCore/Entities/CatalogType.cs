using System;
using Ardalis.GuardClauses;
using Oyster.ApplicationCore.Interfaces;

namespace Oyster.ApplicationCore.Entities;

public class CatalogType : BaseEntity, IAggregateRoot
{
    public string Type { get; private set; }
    public string PictureUri { get; private set; }

    public CatalogType(string type, string pictureUri)
    {
        Type = type;
        PictureUri = pictureUri;
    }
    public void UpdateType(string type)
    {
        Guard.Against.NullOrEmpty(type, nameof(type));
        Type = type;
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
}
