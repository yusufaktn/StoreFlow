using StoreFlow.Context;
using StoreFlow.Entity;
using StoreFlow.Entity.Enum;
using Microsoft.EntityFrameworkCore;

namespace StoreFlow.Data
{
    public class DbSeeder
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<MyContext>();

            // 1. Kategorileri Seed Et
            if (!await context.Categories.AnyAsync())
            {
                var categories = new List<Category>
                {
                    new Category { CategoryName = "Elektronik" },
                    new Category { CategoryName = "Moda & Giyim" },
                    new Category { CategoryName = "Ev & Yaşam" },
                    new Category { CategoryName = "Spor & Outdoor" },
                    new Category { CategoryName = "Kitap & Hobi" },
                    new Category { CategoryName = "Kozmetik & Kişisel Bakım" },
                    new Category { CategoryName = "Anne & Bebek" },
                    new Category { CategoryName = "Otomotiv" },
                    new Category { CategoryName = "Yiyecek & İçecek" },
                    new Category { CategoryName = "Ofis & Kırtasiye" }
                };

                await context.Categories.AddRangeAsync(categories);
                await context.SaveChangesAsync();
            }

            // 2. Müşterileri Seed Et
            if (!await context.Customers.AnyAsync())
            {
                var customers = new List<Customer>
                {
                    new Customer { FirstName = "Yusuf", LastName = "Aktan", City = "Bursa", Balance = 15000 },
                    new Customer { FirstName = "Ahmet", LastName = "Yılmaz", City = "İstanbul", Balance = 2500 },
                    new Customer { FirstName = "Ayşe", LastName = "Demir", City = "Ankara", Balance = 3200 },
                    new Customer { FirstName = "Mehmet", LastName = "Kaya", City = "İzmir", Balance = 4100 },
                    new Customer { FirstName = "Fatma", LastName = "Çelik", City = "Antalya", Balance = 1800 },
                    new Customer { FirstName = "Ali", LastName = "Öztürk", City = "Adana", Balance = 2900 },
                    new Customer { FirstName = "Zeynep", LastName = "Arslan", City = "Gaziantep", Balance = 3500 },
                    new Customer { FirstName = "Mustafa", LastName = "Şahin", City = "Konya", Balance = 2100 },
                    new Customer { FirstName = "Elif", LastName = "Aydın", City = "Kayseri", Balance = 4500 },
                    new Customer { FirstName = "Burak", LastName = "Koç", City = "Mersin", Balance = 1950 },
                    new Customer { FirstName = "Selin", LastName = "Erdoğan", City = "Eskişehir", Balance = 3100 },
                    new Customer { FirstName = "Emre", LastName = "Polat", City = "Diyarbakır", Balance = 2750 },
                    new Customer { FirstName = "Deniz", LastName = "Güneş", City = "Samsun", Balance = 3300 },
                    new Customer { FirstName = "Ceren", LastName = "Kaplan", City = "Trabzon", Balance = 2600 },
                    new Customer { FirstName = "Onur", LastName = "Aksoy", City = "Malatya", Balance = 1700 },
                    new Customer { FirstName = "Gizem", LastName = "Yıldız", City = "Erzurum", Balance = 2200 },
                    new Customer { FirstName = "Serkan", LastName = "Özdemir", City = "Van", Balance = 1500 },
                    new Customer { FirstName = "Pınar", LastName = "Aslan", City = "Balıkesir", Balance = 3800 },
                    new Customer { FirstName = "Tolga", LastName = "Simsek", City = "Manisa", Balance = 2400 },
                    new Customer { FirstName = "Esra", LastName = "Kurt", City = "Tekirdağ", Balance = 2950 }
                };

                await context.Customers.AddRangeAsync(customers);
                await context.SaveChangesAsync();
            }

            // 3. Ürünleri Seed Et
            if (!await context.Products.AnyAsync())
            {
                var allCategories = await context.Categories.ToListAsync();
                var catDict = allCategories.ToDictionary(c => c.CategoryName, c => c.CategoryId);

                var products = new List<Product>
                {
                    // --- Elektronik ---
                    new Product { CategoryId = catDict["Elektronik"], ProductName = "Anker Soundcore R50 Kulaklık", ProductStock = 20, ProductPrice = 800 },
                    new Product { CategoryId = catDict["Elektronik"], ProductName = "Logitech MX Master Mouse", ProductStock = 10, ProductPrice = 1200 },
                    new Product { CategoryId = catDict["Elektronik"], ProductName = "Apple AirTag 4'lü Paket", ProductStock = 15, ProductPrice = 1350 },
                    new Product { CategoryId = catDict["Elektronik"], ProductName = "Samsung T7 Portable SSD 1TB", ProductStock = 8, ProductPrice = 2500 },
                    new Product { CategoryId = catDict["Elektronik"], ProductName = "Xiaomi Redmi Buds 4 Pro", ProductStock = 25, ProductPrice = 950 },

                    // --- Moda & Giyim ---
                    new Product { CategoryId = catDict["Moda & Giyim"], ProductName = "Nike Air Force 1 Sneaker", ProductStock = 12, ProductPrice = 3200 },
                    new Product { CategoryId = catDict["Moda & Giyim"], ProductName = "Levi's 501 Original Jeans", ProductStock = 30, ProductPrice = 1800 },
                    new Product { CategoryId = catDict["Moda & Giyim"], ProductName = "Ray-Ban Aviator Güneş Gözlüğü", ProductStock = 5, ProductPrice = 4500 },
                    new Product { CategoryId = catDict["Moda & Giyim"], ProductName = "Lacoste Polo Yaka Tişört", ProductStock = 40, ProductPrice = 1100 },
                    new Product { CategoryId = catDict["Moda & Giyim"], ProductName = "Converse Chuck Taylor All Star", ProductStock = 18, ProductPrice = 1600 },

                    // --- Ev & Yaşam ---
                    new Product { CategoryId = catDict["Ev & Yaşam"], ProductName = "Philips Airfryer XXL", ProductStock = 7, ProductPrice = 5500 },
                    new Product { CategoryId = catDict["Ev & Yaşam"], ProductName = "Karaca Bio Granit Tencere Seti", ProductStock = 15, ProductPrice = 2200 },
                    new Product { CategoryId = catDict["Ev & Yaşam"], ProductName = "IKEA Markaryd Battaniye", ProductStock = 50, ProductPrice = 450 },
                    new Product { CategoryId = catDict["Ev & Yaşam"], ProductName = "Fakir Kaave Türk Kahve Makinesi", ProductStock = 20, ProductPrice = 1300 },
                    new Product { CategoryId = catDict["Ev & Yaşam"], ProductName = "Paşabahçe Cam Bardak Takımı 6'lı", ProductStock = 60, ProductPrice = 350 },

                    // --- Spor & Outdoor ---
                    new Product { CategoryId = catDict["Spor & Outdoor"], ProductName = "Adidas Yoga Matı", ProductStock = 25, ProductPrice = 600 },
                    new Product { CategoryId = catDict["Spor & Outdoor"], ProductName = "Decathlon Kamp Çadırı 2 Kişilik", ProductStock = 10, ProductPrice = 2800 },
                    new Product { CategoryId = catDict["Spor & Outdoor"], ProductName = "Speedo Mayo Erkek", ProductStock = 30, ProductPrice = 450 },
                    new Product { CategoryId = catDict["Spor & Outdoor"], ProductName = "Wilson Basketbol Topu", ProductStock = 15, ProductPrice = 750 },
                    new Product { CategoryId = catDict["Spor & Outdoor"], ProductName = "Garmin Forerunner 55 Saat", ProductStock = 8, ProductPrice = 6200 },

                    // --- Kitap & Hobi ---
                    new Product { CategoryId = catDict["Kitap & Hobi"], ProductName = "Simyeci - Paulo Coelho", ProductStock = 100, ProductPrice = 120 },
                    new Product { CategoryId = catDict["Kitap & Hobi"], ProductName = "Leggenda Star Wars Millennium Falcon", ProductStock = 5, ProductPrice = 3500 },
                    new Product { CategoryId = catDict["Kitap & Hobi"], ProductName = "Faber-Castell Renkli Kalem 48'li", ProductStock = 40, ProductPrice = 250 },
                    new Product { CategoryId = catDict["Kitap & Hobi"], ProductName = "Harry Potter Komple Set", ProductStock = 20, ProductPrice = 850 },
                    new Product { CategoryId = catDict["Kitap & Hobi"], ProductName = "Monopoly Klasik Oyun", ProductStock = 35, ProductPrice = 550 },

                    // --- Kozmetik & Kişisel Bakım ---
                    new Product { CategoryId = catDict["Kozmetik & Kişisel Bakım"], ProductName = "Nivea Güneş Kremi SPF50", ProductStock = 50, ProductPrice = 180 },
                    new Product { CategoryId = catDict["Kozmetik & Kişisel Bakım"], ProductName = "Oral-B Elektrikli Diş Fırçası", ProductStock = 15, ProductPrice = 1400 },
                    new Product { CategoryId = catDict["Kozmetik & Kişisel Bakım"], ProductName = "L'Oreal Paris Revitalift Serum", ProductStock = 25, ProductPrice = 320 },
                    new Product { CategoryId = catDict["Kozmetik & Kişisel Bakım"], ProductName = "Dove Şampuan 400ml", ProductStock = 60, ProductPrice = 90 },
                    new Product { CategoryId = catDict["Kozmetik & Kişisel Bakım"], ProductName = "Maybelline Fit Me Fondöten", ProductStock = 30, ProductPrice = 210 },

                    // --- Anne & Bebek ---
                    new Product { CategoryId = catDict["Anne & Bebek"], ProductName = "Philips Avent Biberon Seti", ProductStock = 20, ProductPrice = 450 },
                    new Product { CategoryId = catDict["Anne & Bebek"], ProductName = "Sleepy Bebek Bezi 4 Numara", ProductStock = 100, ProductPrice = 220 },
                    new Product { CategoryId = catDict["Anne & Bebek"], ProductName = "Chicco Bebek Arabası", ProductStock = 5, ProductPrice = 7500 },
                    new Product { CategoryId = catDict["Anne & Bebek"], ProductName = "Sebi Bebek Oyun Halısı", ProductStock = 15, ProductPrice = 600 },
                    new Product { CategoryId = catDict["Anne & Bebek"], ProductName = "Johnson's Bebek Şampuanı", ProductStock = 40, ProductPrice = 85 },

                    // --- Otomotiv ---
                    new Product { CategoryId = catDict["Otomotiv"], ProductName = "Michelin Lastik 205/55 R16", ProductStock = 16, ProductPrice = 2100 },
                    new Product { CategoryId = catDict["Otomotiv"], ProductName = "Castrol Magnatec 5W-30 Motor Yağı", ProductStock = 30, ProductPrice = 450 },
                    new Product { CategoryId = catDict["Otomotiv"], ProductName = "Osram Far Ampülü H7", ProductStock = 50, ProductPrice = 120 },
                    new Product { CategoryId = catDict["Otomotiv"], ProductName = "AutoPro Paspas Takımı", ProductStock = 25, ProductPrice = 350 },
                    new Product { CategoryId = catDict["Otomotiv"], ProductName = "Baseus Araç Telefon Tutucu", ProductStock = 40, ProductPrice = 250 },

                    // --- Yiyecek & İçecek ---
                    new Product { CategoryId = catDict["Yiyecek & İçecek"], ProductName = "Nescafe Classic 200gr", ProductStock = 50, ProductPrice = 110 },
                    new Product { CategoryId = catDict["Yiyecek & İçecek"], ProductName = "Ülker Çokokrem 750gr", ProductStock = 40, ProductPrice = 95 },
                    new Product { CategoryId = catDict["Yiyecek & İçecek"], ProductName = "Erikli Su 12'li Paket", ProductStock = 100, ProductPrice = 60 },
                    new Product { CategoryId = catDict["Yiyecek & İçecek"], ProductName = "Torku Bal Kaymaklı Kraker", ProductStock = 60, ProductPrice = 15 },
                    new Product { CategoryId = catDict["Yiyecek & İçecek"], ProductName = "Lav Az Yağlı Zeytinyağı 1L", ProductStock = 30, ProductPrice = 280 },

                    // --- Ofis & Kırtasiye ---
                    new Product { CategoryId = catDict["Ofis & Kırtasiye"], ProductName = "A4 Fotokopi Kağıdı 500'lü", ProductStock = 200, ProductPrice = 140 },
                    new Product { CategoryId = catDict["Ofis & Kırtasiye"], ProductName = "Staedtler Kurşun Kalem 12'li", ProductStock = 50, ProductPrice = 60 },
                    new Product { CategoryId = catDict["Ofis & Kırtasiye"], ProductName = "Dosya Düzenleyici Zarflı", ProductStock = 100, ProductPrice = 10 },
                    new Product { CategoryId = catDict["Ofis & Kırtasiye"], ProductName = "HP Printer Kartuşu Siyah", ProductStock = 20, ProductPrice = 350 },
                    new Product { CategoryId = catDict["Ofis & Kırtasiye"], ProductName = "Post-it Not Kağıdı Renkli", ProductStock = 80, ProductPrice = 45 }
                };

                await context.Products.AddRangeAsync(products);
                await context.SaveChangesAsync();
            }

            // 4. Siparişleri ve Sipariş Detaylarını Seed Et
            if (!await context.Orders.AnyAsync())
            {
                // Verileri çek
                var customers = await context.Customers.ToListAsync();
                var products = await context.Products.ToListAsync();

                // Hızlı erişim için Dictionary oluştur
                var custDict = customers.ToDictionary(c => c.FirstName, c => c);
                var prodDict = products.ToDictionary(p => p.ProductName, p => p);

                // Yardımcı fonksiyon: Ürün fiyatını almak için
                decimal GetPrice(string name) => prodDict[name].ProductPrice;
                int GetProdId(string name) => prodDict[name].ProductId;
                int GetCustId(string name) => custDict[name].CustomerId;

                var orders = new List<Order>();

                // --- SİPARİŞ 1: Yusuf Aktan (Elektronik Alışverişi) ---
                var order1Details = new List<OrderDetail>
                {
                    new OrderDetail { ProductId = GetProdId("Anker Soundcore R50 Kulaklık"), Unit_Price = (int)GetPrice("Anker Soundcore R50 Kulaklık"), Unit_Product_Count = 1 },
                    new OrderDetail { ProductId = GetProdId("Samsung T7 Portable SSD 1TB"), Unit_Price = (int)GetPrice("Samsung T7 Portable SSD 1TB"), Unit_Product_Count = 1 }
                };
                // Toplam Hesaplama
                decimal total1 = order1Details.Sum(d => d.Unit_Price * d.Unit_Product_Count);

                orders.Add(new Order
                {
                    CustomerId = GetCustId("Yusuf"),
                    TotalPrice = total1,
                    Total_Product_Count = order1Details.Sum(x => x.Unit_Product_Count),
                    OrderDetails = order1Details
                });

                // --- SİPARİŞ 2: Ahmet Yılmaz (Giyim) ---
                var order2Details = new List<OrderDetail>
                {
                    new OrderDetail { ProductId = GetProdId("Nike Air Force 1 Sneaker"), Unit_Price = (int)GetPrice("Nike Air Force 1 Sneaker"), Unit_Product_Count = 1 },
                    new OrderDetail { ProductId = GetProdId("Levi's 501 Original Jeans"), Unit_Price = (int)GetPrice("Levi's 501 Original Jeans"), Unit_Product_Count = 2 }
                };
                decimal total2 = order2Details.Sum(d => d.Unit_Price * d.Unit_Product_Count);

                orders.Add(new Order
                {
                    CustomerId = GetCustId("Ahmet"),
                    TotalPrice = total2,
                    Total_Product_Count = order2Details.Sum(x => x.Unit_Product_Count),
                    OrderDetails = order2Details
                });

                // --- SİPARİŞ 3: Ayşe Demir (Ev & Yaşam) ---
                var order3Details = new List<OrderDetail>
                {
                    new OrderDetail { ProductId = GetProdId("Philips Airfryer XXL"), Unit_Price = (int)GetPrice("Philips Airfryer XXL"), Unit_Product_Count = 1 },
                    new OrderDetail { ProductId = GetProdId("Paşabahçe Cam Bardak Takımı 6'lı"), Unit_Price = (int)GetPrice("Paşabahçe Cam Bardak Takımı 6'lı"), Unit_Product_Count = 2 }
                };
                decimal total3 = order3Details.Sum(d => d.Unit_Price * d.Unit_Product_Count);

                orders.Add(new Order
                {
                    CustomerId = GetCustId("Ayşe"),
                    TotalPrice = total3,
                    Total_Product_Count = order3Details.Sum(x => x.Unit_Product_Count),
                    OrderDetails = order3Details
                });

                // --- SİPARİŞ 4: Mehmet Kaya (Spor) ---
                var order4Details = new List<OrderDetail>
                {
                    new OrderDetail { ProductId = GetProdId("Garmin Forerunner 55 Saat"), Unit_Price = (int)GetPrice("Garmin Forerunner 55 Saat"), Unit_Product_Count = 1 },
                    new OrderDetail { ProductId = GetProdId("Adidas Yoga Matı"), Unit_Price = (int)GetPrice("Adidas Yoga Matı"), Unit_Product_Count = 1 }
                };
                decimal total4 = order4Details.Sum(d => d.Unit_Price * d.Unit_Product_Count);

                orders.Add(new Order
                {
                    CustomerId = GetCustId("Mehmet"),
                    TotalPrice = total4,
                    Total_Product_Count = order4Details.Sum(x => x.Unit_Product_Count),
                    OrderDetails = order4Details
                });

                // --- SİPARİŞ 5: Fatma Çelik (Kozmetik & Kitap) ---
                var order5Details = new List<OrderDetail>
                {
                    new OrderDetail { ProductId = GetProdId("L'Oreal Paris Revitalift Serum"), Unit_Price = (int)GetPrice("L'Oreal Paris Revitalift Serum"), Unit_Product_Count = 3 },
                    new OrderDetail { ProductId = GetProdId("Simyeci - Paulo Coelho"), Unit_Price = (int)GetPrice("Simyeci - Paulo Coelho"), Unit_Product_Count = 1 }
                };
                decimal total5 = order5Details.Sum(d => d.Unit_Price * d.Unit_Product_Count);

                orders.Add(new Order
                {
                    CustomerId = GetCustId("Fatma"),
                    TotalPrice = total5,
                    Total_Product_Count = order5Details.Sum(x => x.Unit_Product_Count),
                    OrderDetails = order5Details
                });

                // Tüm siparişleri ve detaylarını tek seferde kaydet
                await context.Orders.AddRangeAsync(orders);
                await context.SaveChangesAsync();
            }
            if (!await context.Activities.AnyAsync())
            {
                var activities = new List<Activity>
                {
                    new Activity
                    {
                        Title = "Sipariş Alındı",
                        Description = "Müşteri siparişi oluşturdu ve ödeme onaylandı.",
                        ActivityTime = new TimeOnly(09, 30)
                    },
                    new Activity
                    {
                        Title = "Paketleme Aşamasında",
                        Description = "Ürünler depoda toplanıp paketlendi.",
                        ActivityTime = new TimeOnly(11, 15)
                    },
                    new Activity
                    {
                        Title = "Kargoya Verildi",
                        Description = "Sipariş Yurtiçi Kargo firmasına teslim edildi. Takip No: 123456789.",
                        ActivityTime = new TimeOnly(14, 45)
                    },
                    new Activity
                    {
                        Title = "Dağıtım Merkezinde",
                        Description = "Paket İstanbul dağıtım merkezine ulaştı.",
                        ActivityTime = new TimeOnly(08, 20)
                    },
                    new Activity
                    {
                        Title = "Teslim Edildi",
                        Description = "Paket müşteriye başarıyla teslim edildi.",
                        ActivityTime = new TimeOnly(16, 10)
                    }
                };

                await context.Activities.AddRangeAsync(activities);
                await context.SaveChangesAsync();
            }

            // 6. TodoItem Seed Et
            if (!await context.TodoItems.AnyAsync())
            {
                var todos = new List<TodoItem>
                {
                    new TodoItem { Title = "Alisa ile toplantı", IsCompleted = false },
                    new TodoItem { Title = "John'u ara", IsCompleted = true },
                    new TodoItem { Title = "Fatura oluştur", IsCompleted = false },
                    new TodoItem { Title = "Hesap cetvellerini yazdır", IsCompleted = false },
                    new TodoItem { Title = "Sunum için hazırlık yap", IsCompleted = true },
                    new TodoItem { Title = "Çocukları okuldan al", IsCompleted = false }
                };

                await context.TodoItems.AddRangeAsync(todos);
                await context.SaveChangesAsync();
            }

            // 7. Project Seed Et
            if (!await context.Projects.AnyAsync())
            {
                var projects = new List<Project>
                {
                    new Project { ProjectName = "StoreFlow Backend", AssignedPerson = "Yusuf Aktan", Priority = ProjectPriority.High },
                    new Project { ProjectName = "Mobil Uygulama", AssignedPerson = "Ahmet Yılmaz", Priority = ProjectPriority.Medium },
                    new Project { ProjectName = "Admin Paneli", AssignedPerson = "Ayşe Demir", Priority = ProjectPriority.Low },
                    new Project { ProjectName = "Ödeme Entegrasyonu", AssignedPerson = "Mehmet Kaya", Priority = ProjectPriority.High },
                    new Project { ProjectName = "Raporlama Modülü", AssignedPerson = "Fatma Çelik", Priority = ProjectPriority.Medium }
                };

                await context.Projects.AddRangeAsync(projects);
                await context.SaveChangesAsync();
            }

            // 8. Tedarikçileri Seed Et
            if (!await context.Suppliers.AnyAsync())
            {
                var suppliers = new List<Supplier>
                {
                    new Supplier { CompanyName = "TechDist A.Ş.", ContactPerson = "Hakan Çetin", Email = "hakan@techdist.com", Phone = "0212 555 01 01", Address = "İstanbul, Bağcılar" },
                    new Supplier { CompanyName = "ModaToptan Ltd.", ContactPerson = "Selin Arslan", Email = "selin@modatoptan.com", Phone = "0232 444 02 02", Address = "İzmir, Konak" },
                    new Supplier { CompanyName = "EvDepo A.Ş.", ContactPerson = "Murat Demir", Email = "murat@evdepo.com", Phone = "0312 333 03 03", Address = "Ankara, Sincan" },
                    new Supplier { CompanyName = "SporLine Ltd.", ContactPerson = "Gamze Kaya", Email = "gamze@sporline.com", Phone = "0322 222 04 04", Address = "Adana, Çukurova" },
                    new Supplier { CompanyName = "KitapMerkezi A.Ş.", ContactPerson = "Tuncay Yıldız", Email = "tuncay@kitapmerkezi.com", Phone = "0224 111 05 05", Address = "Bursa, Osmangazi" }
                };

                await context.Suppliers.AddRangeAsync(suppliers);
                await context.SaveChangesAsync();
            }

            // 9. Giderleri Seed Et
            if (!await context.Expenses.AnyAsync())
            {
                var expenses = new List<Expense>
                {
                    new Expense { Title = "Ocak Kirası", Amount = 15000, ExpenseDate = new DateTime(2026, 1, 1), ExpenseCategory = ExpenseCategory.Rent },
                    new Expense { Title = "Şubat Kirası", Amount = 15000, ExpenseDate = new DateTime(2026, 2, 1), ExpenseCategory = ExpenseCategory.Rent },
                    new Expense { Title = "Mart Kirası", Amount = 15000, ExpenseDate = new DateTime(2026, 3, 1), ExpenseCategory = ExpenseCategory.Rent },
                    new Expense { Title = "Nisan Kirası", Amount = 15000, ExpenseDate = new DateTime(2026, 4, 1), ExpenseCategory = ExpenseCategory.Rent },
                    new Expense { Title = "Personel Maaşları - Ocak", Amount = 45000, ExpenseDate = new DateTime(2026, 1, 31), ExpenseCategory = ExpenseCategory.Salary },
                    new Expense { Title = "Personel Maaşları - Şubat", Amount = 45000, ExpenseDate = new DateTime(2026, 2, 28), ExpenseCategory = ExpenseCategory.Salary },
                    new Expense { Title = "Personel Maaşları - Mart", Amount = 45000, ExpenseDate = new DateTime(2026, 3, 31), ExpenseCategory = ExpenseCategory.Salary },
                    new Expense { Title = "Elektrik Faturası - Ocak", Amount = 3200, ExpenseDate = new DateTime(2026, 1, 15), ExpenseCategory = ExpenseCategory.Utilities },
                    new Expense { Title = "Elektrik Faturası - Şubat", Amount = 2900, ExpenseDate = new DateTime(2026, 2, 15), ExpenseCategory = ExpenseCategory.Utilities },
                    new Expense { Title = "Kargo & Lojistik - Ocak", Amount = 8500, ExpenseDate = new DateTime(2026, 1, 20), ExpenseCategory = ExpenseCategory.Logistics },
                    new Expense { Title = "Kargo & Lojistik - Şubat", Amount = 7800, ExpenseDate = new DateTime(2026, 2, 20), ExpenseCategory = ExpenseCategory.Logistics },
                    new Expense { Title = "Ofis Malzemeleri", Amount = 1200, ExpenseDate = new DateTime(2026, 3, 10), ExpenseCategory = ExpenseCategory.Other },
                };

                await context.Expenses.AddRangeAsync(expenses);
                await context.SaveChangesAsync();
            }

            // 10. Stok Hareketlerini Seed Et
            if (!await context.StockMovements.AnyAsync())
            {
                var products = await context.Products.ToListAsync();
                var prodDict = products.ToDictionary(p => p.ProductName, p => p.ProductId);

                var movements = new List<StockMovement>
                {
                    // Stok Girişleri
                    new StockMovement { ProductId = prodDict["Anker Soundcore R50 Kulaklık"], Quantity = 30, MovementType = MovementType.In, Description = "Tedarikçiden ilk sipariş", MovementDate = new DateTime(2026, 1, 5) },
                    new StockMovement { ProductId = prodDict["Logitech MX Master Mouse"], Quantity = 20, MovementType = MovementType.In, Description = "Tedarikçiden ilk sipariş", MovementDate = new DateTime(2026, 1, 5) },
                    new StockMovement { ProductId = prodDict["Nike Air Force 1 Sneaker"], Quantity = 25, MovementType = MovementType.In, Description = "Sezon açılış siparişi", MovementDate = new DateTime(2026, 1, 10) },
                    new StockMovement { ProductId = prodDict["Philips Airfryer XXL"], Quantity = 15, MovementType = MovementType.In, Description = "Tedarikçiden ilk sipariş", MovementDate = new DateTime(2026, 1, 12) },
                    new StockMovement { ProductId = prodDict["Samsung T7 Portable SSD 1TB"], Quantity = 10, MovementType = MovementType.In, Description = "Tedarikçiden ilk sipariş", MovementDate = new DateTime(2026, 1, 15) },

                    // Stok Çıkışları (satış)
                    new StockMovement { ProductId = prodDict["Anker Soundcore R50 Kulaklık"], Quantity = 10, MovementType = MovementType.Out, Description = "Satış", MovementDate = new DateTime(2026, 2, 1) },
                    new StockMovement { ProductId = prodDict["Logitech MX Master Mouse"], Quantity = 10, MovementType = MovementType.Out, Description = "Satış", MovementDate = new DateTime(2026, 2, 5) },
                    new StockMovement { ProductId = prodDict["Nike Air Force 1 Sneaker"], Quantity = 13, MovementType = MovementType.Out, Description = "Satış", MovementDate = new DateTime(2026, 2, 10) },
                    new StockMovement { ProductId = prodDict["Samsung T7 Portable SSD 1TB"], Quantity = 2, MovementType = MovementType.Out, Description = "Satış", MovementDate = new DateTime(2026, 2, 15) },
                };

                await context.StockMovements.AddRangeAsync(movements);
                await context.SaveChangesAsync();
            }
        }
    }
}