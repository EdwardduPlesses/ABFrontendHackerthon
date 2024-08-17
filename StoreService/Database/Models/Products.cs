using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace StoreService.Database.Models;

public class Products
{
    [Key] public int Id { get; set; }

    [MaxLength(20)] public string Name { get; set; } = "";

    [MaxLength(255)] public string Description { get; set; } = "";

    [MaxLength(int.MaxValue)] public Images? PrimaryImage { get; set; }

    public List<Images> Images { get; set; } = [];

    public List<ProductTags> ProductTags { get; set; } = [];

    public decimal Price { get; set; }

    public static async void Seed(StoreDb db)
    {
        await db.Products.AddRangeAsync([
            new Products
            {
                Name = "Philips Toaster Viva Collection - 950W",
                Description =
                    "2 Extra Wide Slots, 7 Browning Levels, Built-in Bun Warmer, Auto-Shut, Cancel Button, Defrost Function, Metal/Black - HD2637/91",
                Price = 747.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://m.media-amazon.com/images/I/41F0QVlaViL._AC_.jpg"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://m.media-amazon.com/images/I/41Do539zQCL._AC_.jpg"
                    },
                    new Images
                    {
                        Base64 = "https://m.media-amazon.com/images/I/41slNRTbSUL._AC_.jpg"
                    },
                    new Images()
                    {
                        Base64 = "https://m.media-amazon.com/images/I/51PUeeomc5L._AC_.jpg"
                    }
                ]
            },
            new Products
            {
                Name = "Mellerware 22300WH Glass Kettle",
                Description =
                    "1.7L, 2200W, Auto Shut Off, Boil Dry Protection, Indicator Light, Water Level Indicator, Cord Storage, White",
                Price = 1200,
                PrimaryImage = new Images
                {
                    Base64 = "https://m.media-amazon.com/images/I/61vlK9mm-KL._AC_SY300_SX300_.jpg"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://m.media-amazon.com/images/I/71Q5pd0o39L._AC_SX679_.jpg"
                    },
                    new Images
                    {
                        Base64 = "https://m.media-amazon.com/images/I/61NwMaSahGL._AC_SX679_.jpg"
                    },
                    new Images
                    {
                        Base64 = "https://m.media-amazon.com/images/I/71ks5obIxuL._AC_SX679_.jpg"
                    }
                ]
            },
            new Products
            {
                Name = "Defy Oven & Hob Box Set - DCB866E",
                Description = "Static Oven, 4 Solid Plates, 81L Oven Capacity, A Energy Rating, Black",
                Price = 3000.00m,
                PrimaryImage = new Images
                {
                    Base64 =
                        "https://www.hirschs.co.za/media/catalog/product/cache/5650c527889287cec4d241f33ee3fa4b/b/o/box_set_dcb866e_1_.jpg"
                }
            },
            new Products
            {
                Name = "Shuttle Art 25 Colors 2 Fl Oz Acrylic Paint Set for Canvas Rocks Wood Ceramic Fabric",
                Description =
                    "Rich Pigments Non-Toxic Paints for Kids Beginners Students Professional Artist, Acrylic Paints for Painting Canvas, Wood, Clay, Fabric, Ceramic & Crafts",
                Price = 470.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://m.media-amazon.com/images/I/711pUUCzWgL._AC_SY300_SX300_.jpg"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://m.media-amazon.com/images/I/71IFl+WZmnL._AC_SX679_.jpg"
                    },
                    new Images
                    {
                        Base64 = "https://m.media-amazon.com/images/I/61c3n7eOlIL._AC_SX679_.jpg"
                    },
                    new Images
                    {
                        Base64 = "https://m.media-amazon.com/images/I/716w4Wq32ZL._AC_SX679_.jpg"
                    },
                    new Images
                    {
                        Base64 = "https://m.media-amazon.com/images/I/81GkF3X0uKL._AC_SX679_.jpg"
                    },
                    new Images
                    {
                        Base64 = "https://m.media-amazon.com/images/I/81s3dnC0J-L._AC_SX679_.jpg"
                    },
                    new Images
                    {
                        Base64 = "https://m.media-amazon.com/images/I/71q8AU9tntL._AC_SX679_.jpg"
                    }
                ]
            },
            new Products
            {
                Name = "Ryobi 18 Volt Handyline Cordless Drill,Multicolour",
                Description =
                    "18 Volt, 10mm Keyless Chuck, 2 Speed Gearbox, 22 Torque Settings, LED Worklight, 1.3Ah Battery & Charger Included",
                Price = 50.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://m.media-amazon.com/images/I/71gmIYv1rAL._AC_SX679_.jpg"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://m.media-amazon.com/images/I/71UjqpFiKjL._AC_SX679_.jpg"
                    },
                    new Images
                    {
                        Base64 = "https://m.media-amazon.com/images/I/71EsER+yBKL._AC_SX679_.jpg"
                    },
                    new Images
                    {
                        Base64 = "https://m.media-amazon.com/images/I/71fCMYbIzOL._AC_SX679_.jpg"
                    },
                    new Images
                    {
                        Base64 = "https://m.media-amazon.com/images/I/51aOsscXGqL._AC_SX679_.jpg"
                    }
                ]
            },
            new Products
            {
                Name = "Einhell 4259825 TC-ID 1000 Electric Impact Drill",
                Description =
                    "Exact depth fixing by means of adjustable depth stop. Low-fatigue work thanks to adjustable continuous operation. User-friendly screwing with integrated pressure coupling. Short, lightweight design with ergonomically shaped softgrip surfaces. Optimal working in dark areas thanks to LED lighting",
                Price = 799.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://m.media-amazon.com/images/I/81wjtktak6L._AC_SX679_.jpg"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/204"
                    },
                    new Images
                    {
                        Base64 = "https://m.media-amazon.com/images/I/71m4YCEdNRL._AC_SX679_.jpg"
                    },
                    new Images
                    {
                        Base64 = "https://m.media-amazon.com/images/I/71VBAm3du2L._AC_SX679_.jpg"
                    },
                    new Images
                    {
                        Base64 = "https://m.media-amazon.com/images/I/71Pqjy6Z9jL._AC_SX679_.jpg"
                    },
                    new Images
                    {
                        Base64 = "https://m.media-amazon.com/images/I/71gduSMB3iL._AC_SX679_.jpg"
                    },
                    new Images
                    {
                        Base64 = "https://m.media-amazon.com/images/I/71moHQ-vJML._AC_SX679_.jpg"
                    }
                ]
            },
            new Products
            {
                Name = "Product 7",
                Description = "This is a product",
                Price = 70.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/204/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/205/500"
                    }
                ]
            },
            new Products
            {
                Name = "Product 8",
                Description = "This is a product",
                Price = 80.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/206/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/207/500"
                    }
                ]
            },
            new Products
            {
                Name = "Product 9",
                Description = "This is a product",
                Price = 90.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/208/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/209/500"
                    }
                ]
            },
            new Products
            {
                Name = "Product 10",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/210/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/211/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 11",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/222/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/223/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 12",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/224/500"
                },
                Images =
                [
                    new Images()
                    {
                        Base64 = "https://picsum.photos/seed/225/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 13",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/226/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/227/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 14",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/228/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/229/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 15",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/230/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/231/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 16",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/232/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/233/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 17",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/234/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/235/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 18",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/236/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/237/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 19",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/238/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/239/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 20",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/240/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/241/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 21",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/242/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/243/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 22",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/244/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/245/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 23",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/246/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/247/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 24",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/248/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/249/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 25",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/250/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/251/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 26",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/252/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/253/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 27",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/254/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/255/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 28",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/256/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/257/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 29",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/258/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/259/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 30",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/260/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/261/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 31",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/262/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/263/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 32",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/264/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/265/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 33",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/266/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/267/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 34",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/268/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/269/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 35",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/270/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/271/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 36",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/272/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/273/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 37",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/274/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/275/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 38",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/276/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/277/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 39",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/278/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/279/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 40",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/280/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/281/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 41",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/282/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/283/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 42",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/284/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/285/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 43",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/286/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/287/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 44",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/288/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/289/500"
                    }
                ]
            },
            new Products()
            {
                Name = "Product 45",
                Description = "This is a product",
                Price = 100.00m,
                PrimaryImage = new Images
                {
                    Base64 = "https://picsum.photos/seed/290/500"
                },
                Images =
                [
                    new Images
                    {
                        Base64 = "https://picsum.photos/seed/291/500"
                    }
                ]
            }
        ]);

        await db.SaveChangesAsync();

        var product = await db.Products.FirstAsync(f => f.Name == "Philips Toaster Viva Collection - 950W");
        await product.FindOrCreateProductTag(db, "Applicances");
        await product.FindOrCreateProductTag(db, "Toasters");

        product = await db.Products.FirstAsync(f => f.Name == "Mellerware 22300WH Glass Kettle");
        await product.FindOrCreateProductTag(db, "Applicances");
        await product.FindOrCreateProductTag(db, "Kettles");

        product = await db.Products.FirstAsync(f => f.Name == "Defy Oven & Hob Box Set - DCB866E");
        await product.FindOrCreateProductTag(db, "Applicances");
        await product.FindOrCreateProductTag(db, "Ovens");

        product = await db.Products.FirstAsync(f =>
            f.Name == "Shuttle Art 25 Colors 2 Fl Oz Acrylic Paint Set for Canvas Rocks Wood Ceramic Fabric");
        await product.FindOrCreateProductTag(db, "DIY");
        await product.FindOrCreateProductTag(db, "Paint");

        product = await db.Products.FirstAsync(f => f.Name == "Ryobi 18 Volt Handyline Cordless Drill,Multicolour");
        await product.FindOrCreateProductTag(db, "DIY");
        await product.FindOrCreateProductTag(db, "Tools");
        await product.FindOrCreateProductTag(db, "Drills");
        await product.FindOrCreateProductTag(db, "Small Power Tools");

        product = await db.Products.FirstAsync(f => f.Name == "Einhell 4259825 TC-ID 1000 Electric Impact Drill");
        await product.FindOrCreateProductTag(db, "DIY");
        await product.FindOrCreateProductTag(db, "Tools");
        await product.FindOrCreateProductTag(db, "Industrial Drills");
        await product.FindOrCreateProductTag(db, "Industrial Power Tools");

        product = await db.Products.FirstAsync(f => f.Name == "Product 7");
        await product.FindOrCreateProductTag(db, "DIY");
        await product.FindOrCreateProductTag(db, "Tools");
        await product.FindOrCreateProductTag(db, "Hand Tools");
        await product.FindOrCreateProductTag(db, "Hammers");

        product = await db.Products.FirstAsync(f => f.Name == "Product 8");
        await product.FindOrCreateProductTag(db, "Garden");
        await product.FindOrCreateProductTag(db, "Tools");
        await product.FindOrCreateProductTag(db, "Lawnmowers");

        product = await db.Products.FirstAsync(f => f.Name == "Product 9");
        await product.FindOrCreateProductTag(db, "Garden");
        await product.FindOrCreateProductTag(db, "Outdoor Cooking");
        await product.FindOrCreateProductTag(db, "Accessories");

        product = await db.Products.FirstAsync(f => f.Name == "Product 10");
        await product.FindOrCreateProductTag(db, "Garden");
        await product.FindOrCreateProductTag(db, "Outdoor Cooking");
        await product.FindOrCreateProductTag(db, "Braais");
        await db.SaveChangesAsync();
    }
}

public static class Extensions
{
    public static async Task FindOrCreateProductTag(this Products product, StoreDb db, string name)
    {
        var tag = await db.Tags.FirstOrDefaultAsync(f => f.Name == name);
        if (tag == null)
        {
            await db.Tags.AddAsync(new Tags
            {
                Name = name
            });
            await db.SaveChangesAsync();
            tag = await db.Tags.FirstAsync(f => f.Name == name);
        }

        var productTag = await db.ProductTags.Where(w => w.Product == product && w.Tag == tag).FirstOrDefaultAsync();
        if (productTag != null) return;

        await db.ProductTags.AddAsync(new ProductTags
        {
            Product = product,
            Tag = tag
        });
        await db.SaveChangesAsync();
        await db.ProductTags.FirstAsync(f => f.Product == product && f.Tag == tag);
    }
}