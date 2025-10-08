using System;
using System.Collections.Generic;

namespace Задание_2
{
    public interface IProduct
    {
        decimal GetPrice();
        int GetStock();
        string GetInfo();
    }

    public class Food : IProduct
    {
        public string Name { get; }
        public decimal Price { get; }
        public int Stock { get; private set; }
        public DateTime ExpiryDate { get; }

        public Food(string name, decimal price, int stock, DateTime expiry)
        {
            if (price < 0 || stock < 0) throw new ArgumentException("Цена и запас не могут быть отрицательными");
            Name = name; Price = price; Stock = stock; ExpiryDate = expiry;
        }

        public decimal GetPrice() => Price;
        public int GetStock() => Stock;
        public string GetInfo() => $"{Name} (Еда) - {Price:C}, Остаток: {Stock}, Годен до: {ExpiryDate:dd.MM.yyyy}";

        public void Sell(int quantity)
        {
            if (quantity > Stock) throw new InvalidOperationException("Недостаточно товара на складе");
            Stock -= quantity;
        }
    }

    public class Electronics : IProduct
    {
        public string Name { get; }
        public decimal Price { get; }
        public int Stock { get; private set; }
        public string Brand { get; }

        public Electronics(string name, decimal price, int stock, string brand)
        {
            if (price < 0 || stock < 0) throw new ArgumentException("Цена и запас не могут быть отрицательными");
            Name = name; Price = price; Stock = stock; Brand = brand;
        }

        public decimal GetPrice() => Price;
        public int GetStock() => Stock;
        public string GetInfo() => $"{Name} (Электроника) - {Price:C}, Остаток: {Stock}, Бренд: {Brand}";

        public void Sell(int quantity)
        {
            if (quantity > Stock) throw new InvalidOperationException("Недостаточно товара на складе");
            Stock -= quantity;
        }
    }

    public class Clothing : IProduct
    {
        public string Name { get; }
        public decimal Price { get; }
        public int Stock { get; private set; }
        public string Size { get; }

        public Clothing(string name, decimal price, int stock, string size)
        {
            if (price < 0 || stock < 0) throw new ArgumentException("Цена и запас не могут быть отрицательными");
            Name = name; Price = price; Stock = stock; Size = size;
        }

        public decimal GetPrice() => Price;
        public int GetStock() => Stock;
        public string GetInfo() => $"{Name} (Одежда) - {Price:C}, Остаток: {Stock}, Размер: {Size}";

        public void Sell(int quantity)
        {
            if (quantity > Stock) throw new InvalidOperationException("Недостаточно товара на складе");
            Stock -= quantity;
        }
    }

    class Program
    {
        static void Main()
        {
            List<IProduct> products = new List<IProduct>
        {
            new Food("Молоко", 80.50m, 25, new DateTime(2024, 12, 15)),
            new Electronics("Смартфон", 25000m, 10, "Samsung"),
            new Clothing("Футболка", 1200m, 50, "L")
        };

            Console.WriteLine("=== УЧЁТ ПРОДУКТОВ В МАГАЗИНЕ ===\n");
            foreach (var product in products)
            {
                Console.WriteLine(product.GetInfo());
                Console.WriteLine($"Стоимость всех единиц: {product.GetPrice() * product.GetStock():C}\n");
            }

            // Демонстрация продажи
            var milk = (Food)products[0];
            milk.Sell(5);
            Console.WriteLine($"После продажи 5 единиц молока: Остаток = {milk.GetStock()}");

            Console.Write("\nНажмите любую клавишу для завершения...");
            Console.ReadKey();
        }
    }
}
