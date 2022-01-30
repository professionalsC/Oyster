﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Oyster.ApplicationCore.Entities;
using Microsoft.Extensions.Logging;

namespace Oyster.Infrastructure.Data;

public class CatalogContextSeed
{
    public static async Task SeedAsync(CatalogContext catalogContext,
        ILoggerFactory loggerFactory, int retry = 0)
    {
        var retryForAvailability = retry;
        try
        {
            if (catalogContext.Database.IsSqlServer())
            {
                catalogContext.Database.Migrate();
            }

            if (!await catalogContext.CatalogBrands.AnyAsync())
            {
                await catalogContext.CatalogBrands.AddRangeAsync(
                    GetPreconfiguredCatalogBrands());

                await catalogContext.SaveChangesAsync();
            }

            if (!await catalogContext.CatalogTypes.AnyAsync())
            {
                await catalogContext.CatalogTypes.AddRangeAsync(
                    GetPreconfiguredCatalogTypes());

                await catalogContext.SaveChangesAsync();
            }
            if (!await catalogContext.CatalogGenderTypes.AnyAsync())
            {
                await catalogContext.CatalogGenderTypes.AddRangeAsync(
                    GetPreconfiguredCatalogGenderTypes());

                await catalogContext.SaveChangesAsync();
            }

            if (!await catalogContext.CatalogItems.AnyAsync())
            {
                await catalogContext.CatalogItems.AddRangeAsync(
                    GetPreconfiguredItems());

                await catalogContext.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            if (retryForAvailability >= 10) throw;

            retryForAvailability++;
            var log = loggerFactory.CreateLogger<CatalogContextSeed>();
            log.LogError(ex.Message);
            await SeedAsync(catalogContext, loggerFactory, retryForAvailability);
            throw;
        }
    }

    static IEnumerable<CatalogBrand> GetPreconfiguredCatalogBrands()
    {
        return new List<CatalogBrand>
            {
                new("Adidash","http://catalogbaseurltobereplaced/images/products/1.png"),
                new("Anta","http://catalogbaseurltobereplaced/images/products/1.png"),
                new("American Eagle","http://catalogbaseurltobereplaced/images/products/1.png"),
                new("Burberry","http://catalogbaseurltobereplaced/images/products/1.png"),
                new("Calvin Clan","http://catalogbaseurltobereplaced/images/products/1.png"),
                new("Gucci","http://catalogbaseurltobereplaced/images/products/1.png"),
                new("Dior","http://catalogbaseurltobereplaced/images/products/1.png"),
                new("Luis Vuitton","http://catalogbaseurltobereplaced/images/products/1.png"),
                new("Prada","http://catalogbaseurltobereplaced/images/products/1.png"),
                new("Tommy Hilfiger","http://catalogbaseurltobereplaced/images/products/1.png"),
                new("Zara","http://catalogbaseurltobereplaced/images/products/1.png")
            };
    }
    static IEnumerable<CatalogGenderType> GetPreconfiguredCatalogGenderTypes()
    {
        return new List<CatalogGenderType>
            {
                new("Male"),
                new("Female"),
                new("Child")
        };
    }

    static IEnumerable<CatalogType> GetPreconfiguredCatalogTypes()
    {
        return new List<CatalogType>
            {
                new("New Arrival","http://catalogbaseurltobereplaced/images/products/1.png"),
                new("Clothing","http://catalogbaseurltobereplaced/images/products/1.png"),
                new("Shoes","http://catalogbaseurltobereplaced/images/products/1.png"),
                new("Accessories","http://catalogbaseurltobereplaced/images/products/1.png"),
                new("Maternity","http://catalogbaseurltobereplaced/images/products/1.png"),
                new("Sale","http://catalogbaseurltobereplaced/images/products/1.png"),
                new("Sports","http://catalogbaseurltobereplaced/images/products/1.png"),
                new("All Clothings","http://catalogbaseurltobereplaced/images/products/1.png"),
                new("Coat & Jackets","http://catalogbaseurltobereplaced/images/products/1.png"),
                new("Jeans","http://catalogbaseurltobereplaced/images/products/1.png"),
                new("Polo Shirts","http://catalogbaseurltobereplaced/images/products/1.png"),
                new("Shorts","http://catalogbaseurltobereplaced/images/products/1.png")

            };
    }

    static IEnumerable<CatalogItem> GetPreconfiguredItems()
    {
        return new List<CatalogItem>
            {
                new(2,2,2, "Addida Slim work", "Addida Slim work", 9000.00M,  "http://catalogbaseurltobereplaced/images/products/1.png"),
                new(1,2,2, "Addida Slim work", "Addida Slim work", 9000.00M, "http://catalogbaseurltobereplaced/images/products/2.png"),
                new(2,2,5, "Addida Slim work", "Prism White T-Shirt", 9000.00M,  "http://catalogbaseurltobereplaced/images/products/3.png"),
                new(2,2,2, "Addida Slim work", "Addida Slim work", 9000.00M, "http://catalogbaseurltobereplaced/images/products/4.png"),
                new(3,2,5, "Addida Slim work", "Addida Slim work", 9000.00M, "http://catalogbaseurltobereplaced/images/products/5.png"),
                new(2,2,2, "Addida Slim work", "Addida Slim work", 9000.00M, "http://catalogbaseurltobereplaced/images/products/6.png"),
                new(2,2,5, "Addida Slim work", "Addida Slim work",  9000.00M, "http://catalogbaseurltobereplaced/images/products/7.png"),
                new(2,2,5, "Addida Slim work", "Addida Slim work", 9000.00M, "http://catalogbaseurltobereplaced/images/products/8.png"),
                new(1,2,5, "Addida Slim work", "Addida Slim work", 9000.00M, "http://catalogbaseurltobereplaced/images/products/9.png"),
                new(3,2,2, "Addida Slim work", "Addida Slim work", 9000.00M, "http://catalogbaseurltobereplaced/images/products/10.png"),
                new(3,2,2, "Addida Slim work", "Addida Slim work", 9000.00M, "http://catalogbaseurltobereplaced/images/products/11.png"),
                new(2,2,5, "Addida Slim work", "Addida Slim work", 9000.00M, "http://catalogbaseurltobereplaced/images/products/12.png")
            };
    }
}
