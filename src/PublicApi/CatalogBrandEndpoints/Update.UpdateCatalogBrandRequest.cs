﻿using System.ComponentModel.DataAnnotations;

namespace Oyster.PublicApi.CatalogBrandEndpoints;

public class UpdateCatalogBrandRequest : BaseRequest
{   
    public int Id { get; set; }   
    public string Brand { get; set; }
    public string PictureBase64 { get; set; }
    public string PictureUri { get; set; }
    public string PictureName { get; set; }
    public string BannerPictureBase64 { get; set; }
    public string BannerPictureUri { get; set; }
    public string BannerPictureName { get; set; }
    public bool Status { get; set; }

}
