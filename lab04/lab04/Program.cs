using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab04_ProductManager
{
    public interface IEntity
    {
        string Id { get; }
    }

    public class Repository<T> where T : IEntity
    {
        private List<T> _items = new List<T>();

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void Remove(string id)
        {
            var item = FindById(id);
            if (item != null)
            {
                _items.Remove(item);
            }
        }

        public T FindById(string id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _items.Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _items;
        }
    }

    public class DuplicateProductException : Exception
    {
        public DuplicateProductException(string message) : base(message) { }
    }

    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string message) : base(message) { }
    }

    public class Product : IEntity
    {
        public string MaSP { get; set; }
        public string Id => MaSP; // Thực thi IEntity.Id

        public string TenSP { get; set; }

        private decimal price;
        public decimal Price
        {
            get => price;
            set
            {
                if (value < 0) throw new ArgumentException("Đơn giá không được âm.");
                price = value;
            }
        }

        private int quantity;
        public int Quantity
        {
            get => quantity;
            set
            {
                if (value < 0) throw new ArgumentException("Số lượng không được âm.");
                quantity = value;
            }
        }

        public Product(string maSP, string tenSP, decimal price, int quantity)
        {
            if (string.IsNullOrWhiteSpace(maSP)) throw new ArgumentException("Mã sản phẩm không được rỗng.");

            MaSP = maSP;
            TenSP = tenSP;
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"Mã SP: {MaSP,-5} | Tên: {TenSP,-15} | Giá: {Price,-10:C} | SL: {Quantity,-5}";
        }
    }

    public class ProductService
    {
        private Repository<Product> _repo = new Repository<Product>();

        public event Action<string> OnProductChanged;

        public void AddProduct(Product p)
        {
            if (_repo.FindById(p.Id) != null)
            {
                throw new DuplicateProductException($"Lỗi: Sản phẩm có mã '{p.Id}' đã tồn tại!");
            }

            _repo.Add(p);
            OnProductChanged?.Invoke($"[SUCCESS] Đã thêm thành công sản phẩm: {p.TenSP}");
        }

        public void RemoveProduct(string id)
        {
            var p = _repo.FindById(id);
            if (p == null)
            {
                throw new ProductNotFoundException($"Lỗi: Không tìm thấy sản phẩm có mã '{id}' để xóa!");
            }

            _repo.Remove(id);
            OnProductChanged?.Invoke($"[SUCCESS] Đã xóa thành công sản phẩm mã: {id}");
        }

        public IEnumerable<Product> GetAll() => _repo.GetAll();

        public Product FindById(string id) => _repo.FindById(id);

        public IEnumerable<Product> SearchByName(string keyword)
        {
            return _repo.Find(p => p.TenSP.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        public IEnumerable<Product> FilterByPriceRange(decimal minPrice, decimal maxPrice)
        {
            Func<Product, bool> condition = p => p.Price >= minPrice && p.Price <= maxPrice;
            return _repo.Find(condition);
        }

        public decimal GetTotalInventoryValue()
        {
            return _repo.GetAll().Sum(p => p.Price * p.Quantity);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            ProductService productService = new ProductService();

            productService.OnProductChanged += ShowNotification;

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("\n===== PRODUCT MANAGER =====");
                Console.WriteLine("1. Thêm sản phẩm");
                Console.WriteLine("2. Xuất danh sách");
                Console.WriteLine("3. Tìm theo mã");
                Console.WriteLine("4. Tìm theo tên");
                Console.WriteLine("5. Lọc theo khoảng giá");
                Console.WriteLine("6. Xóa sản phẩm");
                Console.WriteLine("7. Tính tổng giá trị kho");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            AddProductUI(productService);
                            break;
                        case "2":
                            DisplayProducts(productService.GetAll());
                            break;
                        case "3":
                            SearchByIdUI(productService);
                            break;
                        case "4":
                            SearchByNameUI(productService);
                            break;
                        case "5":
                            FilterByPriceUI(productService);
                            break;
                        case "6":
                            RemoveProductUI(productService);
                            break;
                        case "7":
                            Console.WriteLine($"\n=> Tổng giá trị kho: {productService.GetTotalInventoryValue():C}");
                            break;
                        case "0":
                            isRunning = false;
                            Console.WriteLine("Chương trình kết thúc!");
                            break;
                        default:
                            Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng thử lại!");
                            break;
                    }
                }

                catch (DuplicateProductException ex)
                {
                    Console.WriteLine($"\n[CẢNH BÁO] {ex.Message}");
                }
                catch (ProductNotFoundException ex)
                {
                    Console.WriteLine($"\n[CẢNH BÁO] {ex.Message}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"\n[LỖI DỮ LIỆU] {ex.Message}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("\n[LỖI NHẬP LIỆU] Vui lòng nhập đúng định dạng số cho giá và số lượng!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n[LỖI KHÔNG XÁC ĐỊNH] {ex.Message}");
                }
            }
        }

        static void ShowNotification(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{message}");
            Console.ResetColor();
        }

        static void AddProductUI(ProductService service)
        {
            Console.Write("Nhập mã SP: ");
            string id = Console.ReadLine();
            Console.Write("Nhập tên SP: ");
            string name = Console.ReadLine();
            Console.Write("Nhập giá: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Nhập số lượng: ");
            int quantity = int.Parse(Console.ReadLine());

            Product p = new Product(id, name, price, quantity);
            service.AddProduct(p);
        }

        static void DisplayProducts(IEnumerable<Product> products)
        {
            if (!products.Any())
            {
                Console.WriteLine("\nDanh sách sản phẩm trống!");
                return;
            }

            Console.WriteLine("\n--- DANH SÁCH SẢN PHẨM ---");
            foreach (var p in products)
            {
                Console.WriteLine(p.ToString());
            }
        }

        static void SearchByIdUI(ProductService service)
        {
            Console.Write("Nhập mã SP cần tìm: ");
            string id = Console.ReadLine();
            var p = service.FindById(id);
            if (p != null)
                Console.WriteLine($"\nĐã tìm thấy: {p}");
            else
                Console.WriteLine("\nKhông tìm thấy sản phẩm!");
        }

        static void SearchByNameUI(ProductService service)
        {
            Console.Write("Nhập tên SP cần tìm: ");
            string name = Console.ReadLine();
            var results = service.SearchByName(name);
            DisplayProducts(results);
        }

        static void FilterByPriceUI(ProductService service)
        {
            Console.Write("Nhập giá thấp nhất: ");
            decimal min = decimal.Parse(Console.ReadLine());
            Console.Write("Nhập giá cao nhất: ");
            decimal max = decimal.Parse(Console.ReadLine());

            var results = service.FilterByPriceRange(min, max);
            DisplayProducts(results);
        }

        static void RemoveProductUI(ProductService service)
        {
            Console.Write("Nhập mã SP cần xóa: ");
            string id = Console.ReadLine();
            service.RemoveProduct(id);
        }
    }
}