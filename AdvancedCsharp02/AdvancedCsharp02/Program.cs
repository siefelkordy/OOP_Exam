using System.Data.Common;
using System.Reflection.Metadata.Ecma335;

namespace AdvancedCsharp02
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; } // "Electronics", "Clothing", "Food", "Books"
        public double Price { get; set; }
        public int Stock { get; set; }

        public List<Product> SearchProducts(List<Product> catalog,Func<Product,bool> filtercondition)
        {
            List<Product> ResultList = new List<Product>();
            foreach(Product P in catalog)
            {
                if (filtercondition(P))
                    ResultList.Add(P);
            }
            return ResultList;
        }
        public void PrintReport(List<Product> catalog,Action<Product> action)
        {
            foreach(Product P in catalog)
            {
                action(P);
            }
        }
        public List<string> TransformProducts(List<Product> catalog,Func<Product,string> transformFunc)
        {
            List<string> result = new List<string>();

            foreach (Product P in catalog)
            {
                result.Add(transformFunc(P));
            }
            return result;
        }
        public List<Product> FilterProducts(List<Product> catalog , Predicate<Product> predicate)
        {
            List<Product> result = new List<Product>();
            foreach (Product p in catalog)
            {
                if (predicate(p))
                    result.Add(p);
            }
            return result;
        }
    }
   
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> catalog = new()
        {
        new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200, Stock = 10 },
        new Product { Id = 2, Name = "Phone", Category = "Electronics", Price = 800, Stock = 25 },
        new Product { Id = 3, Name = "T-Shirt", Category = "Clothing", Price = 30, Stock = 100 },
        new Product { Id = 4, Name = "Jeans", Category = "Clothing", Price = 60, Stock = 50 },
        new Product { Id = 5, Name = "Chocolate", Category = "Food", Price = 5, Stock = 200 },
        new Product { Id = 6, Name = "Coffee Beans", Category = "Food", Price = 15, Stock = 80 },
        new Product { Id = 7, Name = "C# Book", Category = "Books", Price = 45, Stock = 30 },
        new Product { Id = 8, Name = "Novel", Category = "Books", Price = 20, Stock = 60 },
        new Product { Id = 9, Name = "Headphones", Category = "Electronics", Price = 150, Stock = 40 },
        new Product { Id = 10, Name = "Jacket", Category = "Clothing", Price = 120, Stock = 15 }
        };

            Product product = new Product();
            List<Product> electronics = product.SearchProducts(catalog, p => p.Category == "Electronics");
            List<Product> expensiveProducts = product.SearchProducts(catalog, p => p.Price > 50);
            List<Product> availableProducts = product.SearchProducts(catalog, p => p.Stock > 0);
            List<Product> cheapProducts = product.SearchProducts(catalog, p => p.Price < 100);
            Console.WriteLine("-----Electronics-----");
            foreach(Product p in electronics)
            {
                Console.WriteLine($"\n{p.Name}-${p.Price}-(Stock: {p.Stock})\n");
            }
            Console.WriteLine("-----Expensive Products-----");
            foreach (Product p in expensiveProducts)
            {
                Console.WriteLine($"\n{p.Name}-${p.Price}-(Stock: {p.Stock})\n");
            }
            Console.WriteLine("-----In Stock-----");
            foreach (Product p in availableProducts)
            {
                Console.WriteLine($"\n{p.Name}-${p.Price}-(Stock: {p.Stock})\n");
            }
            Console.WriteLine("-----Clothing Under $100-----");
            foreach (Product p in cheapProducts)
            {
                Console.WriteLine($"\n{p.Name}-${p.Price}-(Stock: {p.Stock})\n");
            }
            Action<Product> ShortReport = p => Console.WriteLine($"{p.Name} - ${p.Price}");
            Action<Product> DetailedReport = p => Console.WriteLine($"[{p.Category}]{p.Name} | Price:{p.Price} | Stock: {p.Stock}");
            product.PrintReport(catalog, ShortReport);
            product.PrintReport(catalog, DetailedReport);
            Func<Product,string> transfunc = p => ($"{p.Name} (${p.Price})");
            Func<Product, string> transfunc2 = p => (p.Price > 100) ? ($"{p.Name}Expensive!") : ($"{p.Name}Affordable");
            List<string> transformedList1 = product.TransformProducts(catalog, transfunc);
            List<string> transformedList2 = product.TransformProducts(catalog, transfunc2);
            foreach(string item in transformedList1)
            {
                Console.WriteLine(item);
            }
            foreach (string item in transformedList2)
            {
                Console.WriteLine(item);
            }

            Predicate<Product> predicate = p => p.Stock < 20;
            List<Product> filteredList = product.FilterProducts(catalog, predicate);
            foreach(Product p in filteredList)
            {
                Console.WriteLine($"[LOW STOCK] {p.Name} : only {p.Stock} left!");
            }
        }
    }
}
