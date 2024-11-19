using CafeOrderManagementSystem.Application.StaticServices;
using CafeOrderManagementSystem.Domain.Entities;
using CafeOrderManagementSystem.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace CafeOrderManagementSystem.Web.Middlewares
{
    public static class ExtensionsMiddleware
    {
        public static void CreateSeedData(WebApplication app)
        {
            using (var scoped = app.Services.CreateScope())
            {


                var context = scoped.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                #region Varsayılan Kullanıcı Olusturma
                if (!context.Users.Any())
                {
                    var user = new User
                    {
                        UserName = "admin",
                        Email = "admin@admin.com",
                        FirstName = "Rıdvan",
                        LastName = "Coşkun",
                        Password = HashService.Encrypt("123")
                    };
                    context.Users.Add(user);
                    context.SaveChanges();
                }
                #endregion

                #region Varsayılan Kategori Oluşturma
                if (!context.Categories.Any())
                {
                    var categories = new List<Category>
                        {
                            new Category { Name = "Sıcak İçecekler" },
                            new Category { Name = "Soğuk İçecekler" },
                            new Category { Name = "Kahvaltı Ürünleri" },
                            new Category { Name = "Tatlılar" },
                            new Category { Name = "Atıştırmalıklar" },
                            new Category { Name = "Ana Yemekler" },
                            new Category { Name = "Sandviçler" },
                            new Category { Name = "Salatalar" },
                            new Category { Name = "Smoothie ve Detoks İçecekleri" },
                            new Category { Name = "Çocuk Menüsü" }
                        };

                    context.Categories.AddRange(categories);
                    context.SaveChanges();
                }
                #endregion

                #region Varsayılan Menü Oluşturma
                if (!context.Menus.Any())
                {
                    var menus = new List<Menu>
                        {
                            new Menu { Name = "Geleneksel Kahvaltı Menüsü" },
                            new Menu { Name = "Serpme Kahvaltı Menüsü" },
                            new Menu { Name = "Fit Kahvaltı Menüsü" },
                            new Menu { Name = "Vegan Kahvaltı Menüsü" },
                            new Menu { Name = "Türk Kahvesi Keyfi Menüsü" },
                            new Menu { Name = "Latte ve Tatlı Menüsü" },
                            new Menu { Name = "Çay Saati Menüsü" },
                            new Menu { Name = "Soğuk Kahve ve Sandviç Menüsü" },
                            new Menu { Name = "Tatlı Krizi Menüsü" },
                            new Menu { Name = "Burger ve Kızartma Menüsü" },
                            new Menu { Name = "Pizza Ziyafeti Menüsü" },
                            new Menu { Name = "Pasta ve Çikolata Menüsü" },
                            new Menu { Name = "Salata ve Smoothie Menüsü" },
                            new Menu { Name = "Detoks İçecek Menüsü" },
                            new Menu { Name = "Akşam Yemeği Menüsü" },
                            new Menu { Name = "Kebap ve Mezeler Menüsü" },
                            new Menu { Name = "Deniz Ürünleri Menüsü" },
                            new Menu { Name = "Çocuklar için Mini Menü" },
                            new Menu { Name = "Makarna ve Soslar Menüsü" },
                            new Menu { Name = "Dünya Mutfağı Menüsü" }
                        };

                    context.Menus.AddRange(menus);
                    context.SaveChanges();
                }

                #endregion

                #region Varsayılan Masa Oluşturma
                if (!context.Tables.Any())
                {
                    var tables = new List<Table>
                        {
                            new Table { TableNumber = "Masa 1" },
                            new Table { TableNumber = "Masa 2" },
                            new Table { TableNumber = "Masa 3" },
                            new Table { TableNumber = "Masa 4" },
                            new Table { TableNumber = "Masa 5" },
                            new Table { TableNumber = "Masa 6" },
                            new Table { TableNumber = "Masa 7" },
                            new Table { TableNumber = "Masa 8" },
                            new Table { TableNumber = "Masa 9" },
                            new Table { TableNumber = "Masa 10" },
                            new Table { TableNumber = "Masa 11" },
                            new Table { TableNumber = "Masa 12" },
                            new Table { TableNumber = "Masa 13" },
                            new Table { TableNumber = "Masa 14" },
                            new Table { TableNumber = "Masa 15" },
                            new Table { TableNumber = "Masa 16" },
                            new Table { TableNumber = "Masa 17" },
                            new Table { TableNumber = "Masa 18" },
                            new Table { TableNumber = "Masa 19" },
                            new Table { TableNumber = "Masa 20" },
                            new Table { TableNumber = "Bahçe 1" },
                            new Table { TableNumber = "Bahçe 2" },
                            new Table { TableNumber = "Teras 1" },
                            new Table { TableNumber = "Teras 2" },
                            new Table { TableNumber = "VIP Masa 1" }
                        };

                    context.Tables.AddRange(tables);
                    context.SaveChanges();
                }

                #endregion

                #region Varsayılan Ürün Oluşturma
                if (!context.Products.Any())
                {
                  var products = new List<Product>
                  {
                   new Product { Name = "Espresso", Description = "Yoğun kahve çekirdeği aroması.", Price = 15.50m, CategoryId = 1 },
                   new Product { Name = "Americano", Description = "Espresso üzerine sıcak su eklenmiş klasik kahve.", Price = 18.00m, CategoryId = 1 },
                   new Product { Name = "Latte", Description = "Espresso ve buharda ısıtılmış süt ile hazırlanmış.", Price = 22.00m, CategoryId = 1 },
                   new Product { Name = "Cappuccino", Description = "Espresso, süt ve süt köpüğünün mükemmel birleşimi.", Price = 20.00m, CategoryId = 1 },
                   new Product { Name = "Türk Kahvesi", Description = "Klasik Türk kahvesi fincanında servis edilir.", Price = 12.00m, CategoryId = 1 },

                   new Product { Name = "Ice Latte", Description = "Espresso ve soğuk süt ile hazırlanır.", Price = 24.00m, CategoryId = 2 },
                   new Product { Name = "Cold Brew", Description = "Soğuk demleme yöntemiyle hazırlanan kahve.", Price = 25.00m, CategoryId = 2 },
                   new Product { Name = "Limonata", Description = "Taze sıkılmış limonlarla hazırlanan ev yapımı.", Price = 10.00m, CategoryId = 2 },
                   new Product { Name = "Ice Americano", Description = "Espresso ve soğuk su ile hazırlanır.", Price = 20.00m, CategoryId = 2 },
                   new Product { Name = "Mojito", Description = "Taze nane ve limon ile hazırlanan serinletici içecek.", Price = 30.00m, CategoryId = 2 },


                   new Product { Name = "Serpme Kahvaltı", Description = "Çeşitli peynirler, zeytinler ve sıcak böreklerle tam kahvaltı.", Price = 75.00m, CategoryId = 3 },
                   new Product { Name = "Menemen", Description = "Yumurta, biber ve domatesle hazırlanan geleneksel lezzet.", Price = 25.00m, CategoryId = 3 },
                   new Product { Name = "Omlet", Description = "Peynirli, sebzeli veya sade omlet.", Price = 20.00m, CategoryId = 3 },
                   new Product { Name = "Simit Tabağı", Description = "Sıcak simit, peynir ve zeytin ile.", Price = 15.00m, CategoryId = 3 },
                   new Product { Name = "Pankek", Description = "Çikolata sosu ve meyveyle süslenmiş pankek.", Price = 25.00m, CategoryId = 3 },

                   new Product { Name = "Cheesecake", Description = "Taze peynir kreması ile hazırlanmış cheesecake.", Price = 35.00m, CategoryId = 4 },
                   new Product { Name = "Tiramisu", Description = "Mascarpone peynirli ve kahveli klasik tatlı.", Price = 40.00m, CategoryId = 4 },
                   new Product { Name = "Profiterol", Description = "Çikolata sosu ile kaplanmış mini tatlı topları.", Price = 25.00m, CategoryId = 4 },
                   new Product { Name = "Brownie", Description = "Yoğun çikolatalı kek.", Price = 20.00m, CategoryId = 4 },
                   new Product { Name = "Magnolia", Description = "Taze meyve ve bisküvilerle hazırlanmış tatlı.", Price = 30.00m, CategoryId = 4 },


                   new Product { Name = "Patates Kızartması", Description = "Kızarmış altın sarısı patates dilimleri.", Price = 15.00m, CategoryId = 5 },
                   new Product { Name = "Mozzarella Çubukları", Description = "Kızarmış mozzarella peynir çubukları.", Price = 28.00m, CategoryId = 5 },
                   new Product { Name = "Sigara Böreği", Description = "Peynirle doldurulmuş ve kızartılmış ince börekler.", Price = 18.00m, CategoryId = 5 },
                   new Product { Name = "Karışık Çerez Tabağı", Description = "Fındık, badem ve kuru meyve karışımı.", Price = 35.00m, CategoryId = 5 },
                   new Product { Name = "Çıtır Tavuk Kanatları", Description = "Baharatlarla marine edilmiş çıtır tavuk kanatları.", Price = 45.00m, CategoryId = 5 },

                     new Product { Name = "Izgara Tavuk", Description = "Baharatlarla marine edilmiş, yumuşak ve lezzetli ızgara tavuk göğsü.", Price = 50.00m, CategoryId = 6 },
                    new Product { Name = "Etli Güveç", Description = "Dana eti, sebzeler ve özel baharatlarla fırında pişirilmiş geleneksel lezzet.", Price = 65.00m, CategoryId = 6 },
                    new Product { Name = "Sebzeli Makarna", Description = "Taze sebzelerle zenginleştirilmiş, kremalı soslu makarna.", Price = 45.00m, CategoryId = 6 },
                    new Product { Name = "Adana Kebap", Description = "Izgarada pişirilmiş baharatlı kıyma kebabı, pilav ve salata ile servis edilir.", Price = 70.00m, CategoryId = 6 },
                    new Product { Name = "Izgara Somon", Description = "Limon ve zeytinyağı sosuyla marine edilmiş, ızgarada pişirilmiş somon fileto.", Price = 80.00m, CategoryId = 6 },



                   new Product { Name = "Tavuklu Sandviç", Description = "Izgara tavuk, marul ve domates ile hazırlanan sandviç.", Price = 30.00m, CategoryId = 7 },
                   new Product { Name = "Club Sandviç", Description = "Yumurta, tavuk, peynir ve sebzelerle kat kat lezzet.", Price = 40.00m, CategoryId = 7 },
                   new Product { Name = "Ton Balıklı Sandviç", Description = "Taze ton balığı ve sebzelerle hafif lezzet.", Price = 35.00m, CategoryId = 7 },
                   new Product { Name = "Izgara Sebzeli Sandviç", Description = "Izgara sebzeler ve zeytin ezmesi ile.", Price = 30.00m, CategoryId = 7 },
                   new Product { Name = "Kaşarlı Tost", Description = "Sade ve klasik kaşarlı tost.", Price = 15.00m, CategoryId = 7 },

                   new Product { Name = "Sezar Salatası", Description = "Izgara tavuk ve parmesan peyniri ile klasik lezzet.", Price = 40.00m, CategoryId = 8 },
                   new Product { Name = "Ton Balıklı Salata", Description = "Taze sebzeler ve ton balığıyla hazırlanmış.", Price = 35.00m, CategoryId = 8 },
                   new Product { Name = "Yunan Salatası", Description = "Feta peyniri ve zeytinyağı ile zenginleştirilmiş.", Price = 30.00m, CategoryId = 8 },
                   new Product { Name = "Izgara Sebze Salatası", Description = "Izgara sebzelerle hafif ve lezzetli.", Price = 30.00m, CategoryId = 8 },
                   new Product { Name = "Avokadolu Salata", Description = "Taze avokado dilimleriyle özel salata.", Price = 45.00m, CategoryId = 8 },

                   new Product { Name = "Çilekli Smoothie", Description = "Taze çilek, yoğurt ve sütle hazırlanır.", Price = 30.00m, CategoryId = 9 },
                   new Product { Name = "Yeşil Detoks", Description = "Ispanak, elma ve zencefil karışımı.", Price = 35.00m, CategoryId = 9 },
                   new Product { Name = "Muzlu Smoothie", Description = "Muz ve sütle enerji veren lezzet.", Price = 30.00m, CategoryId = 9 },
                   new Product { Name = "Karpuzlu Smoothie", Description = "Taze karpuz ve nane ile yaz ferahlığı.", Price = 30.00m, CategoryId = 9 },
                   new Product { Name = "Zencefilli Detoks", Description = "Zencefil, limon ve bal ile özel karışım.", Price = 35.00m, CategoryId = 9 }
                  };

                    context.Products.AddRange(products);
                    context.SaveChanges();
                }

                #endregion

                #region Varsayılan Menü-Ürün Oluşturma

                if (!context.MenuProducts.Any())
                {
                    var menuProducts = new List<MenuProduct>
                    {
                        new MenuProduct { MenuId = 1, ProductId = 1 }, 
                        new MenuProduct { MenuId = 1, ProductId = 11 },
                        new MenuProduct { MenuId = 1, ProductId = 12 },
                        new MenuProduct { MenuId = 1, ProductId = 13 },
                    
                        new MenuProduct { MenuId = 2, ProductId = 3 }, 
                        new MenuProduct { MenuId = 2, ProductId = 14 },
                        new MenuProduct { MenuId = 2, ProductId = 15 },
                        new MenuProduct { MenuId = 2, ProductId = 2 }, 
                    
                        new MenuProduct { MenuId = 3, ProductId = 41 },
                        new MenuProduct { MenuId = 3, ProductId = 13 },
                        new MenuProduct { MenuId = 3, ProductId = 14 },
                        new MenuProduct { MenuId = 3, ProductId = 39 },
                    
                        new MenuProduct { MenuId = 4, ProductId = 42 },
                        new MenuProduct { MenuId = 4, ProductId = 39 },
                        new MenuProduct { MenuId = 4, ProductId = 40 },
                    
                        new MenuProduct { MenuId = 5, ProductId = 5 }, 
                        new MenuProduct { MenuId = 5, ProductId = 17 },
                        new MenuProduct { MenuId = 5, ProductId = 20 },
                    
                        new MenuProduct { MenuId = 6, ProductId = 3 },  
                        new MenuProduct { MenuId = 6, ProductId = 16 }, 
                        new MenuProduct { MenuId = 6, ProductId = 19 }, 
                    
                        new MenuProduct { MenuId = 7, ProductId = 8 }, 
                        new MenuProduct { MenuId = 7, ProductId = 18 },
                        new MenuProduct { MenuId = 7, ProductId = 20 },
                    
                        new MenuProduct { MenuId = 8, ProductId = 7 }, 
                        new MenuProduct { MenuId = 8, ProductId = 31 },
                        new MenuProduct { MenuId = 8, ProductId = 32 },
                    
                        new MenuProduct { MenuId = 9, ProductId = 16 }, 
                        new MenuProduct { MenuId = 9, ProductId = 18 }, 
                        new MenuProduct { MenuId = 9, ProductId = 19 }, 
                    
                        new MenuProduct { MenuId = 10, ProductId = 21 },
                        new MenuProduct { MenuId = 10, ProductId = 25 },
                        new MenuProduct { MenuId = 10, ProductId = 26 },
                    
                        new MenuProduct { MenuId = 11, ProductId = 27 }, 
                        new MenuProduct { MenuId = 11, ProductId = 28 }, 
                        new MenuProduct { MenuId = 11, ProductId = 29 }, 
                    
                        new MenuProduct { MenuId = 12, ProductId = 16 }, 
                        new MenuProduct { MenuId = 12, ProductId = 18 }, 
                        new MenuProduct { MenuId = 12, ProductId = 20 }, 
                    
                        new MenuProduct { MenuId = 13, ProductId = 36 }, 
                        new MenuProduct { MenuId = 13, ProductId = 40 }, 
                        new MenuProduct { MenuId = 13, ProductId = 41 }, 
                    
                        new MenuProduct { MenuId = 14, ProductId = 42 }, 
                        new MenuProduct { MenuId = 14, ProductId = 43 }, 
                        new MenuProduct { MenuId = 14, ProductId = 44 }, 
                    
                        new MenuProduct { MenuId = 15, ProductId = 26 }, 
                        new MenuProduct { MenuId = 15, ProductId = 27 }, 
                        new MenuProduct { MenuId = 15, ProductId = 30 }, 
                    
                        new MenuProduct { MenuId = 16, ProductId = 29 }, 
                        new MenuProduct { MenuId = 16, ProductId = 27 }, 
                        new MenuProduct { MenuId = 16, ProductId = 26 }, 
                    
                        new MenuProduct { MenuId = 17, ProductId = 30 }, 
                        new MenuProduct { MenuId = 17, ProductId = 39 }, 
                        new MenuProduct { MenuId = 17, ProductId = 37 }, 
                    };


                    context.MenuProducts.AddRange(menuProducts);
                    context.SaveChanges();
                }
                #endregion
            }
        }
    }
}
