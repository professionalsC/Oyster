using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oyster.ApplicationCore.Interfaces;

namespace Oyster.ApplicationCore.Entities;
public class BannerAdvertisement : BaseEntity, IAggregateRoot
{
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public bool Status { get; set; }
    public BannerAdvertisement(string title, string imageUrl, bool status)
    {
        Title = title;
        ImageUrl = imageUrl;
        Status = status;
            
    }

    public void UpdateImageUri(string imageUrl)
    {
        if (string.IsNullOrEmpty(imageUrl))
        {
            ImageUrl = string.Empty;
            return;
        }
        ImageUrl = $"images\\products\\{imageUrl}?{new DateTime().Ticks}";
    }
}
