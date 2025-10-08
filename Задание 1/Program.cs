using System;

namespace Задание_1
{

        public interface IFigure
        {
            double CalculateArea();
            double CalculatePerimeter();
        }

        public class Circle : IFigure
        {
            public double Radius { get; }
            public Circle(double r) => Radius = r > 0 ? r : throw new ArgumentException("Радиус должен быть > 0");
            public double CalculateArea() => Math.PI * Radius * Radius;
            public double CalculatePerimeter() => 2 * Math.PI * Radius;
        }

        public class Rectangle : IFigure
        {
            public double Width { get; }
            public double Height { get; }
            public Rectangle(double w, double h)
            {
                if (w <= 0 || h <= 0) throw new ArgumentException("Стороны должны быть > 0");
                Width = w; Height = h;
            }
            public double CalculateArea() => Width * Height;
            public double CalculatePerimeter() => 2 * (Width + Height);
        }

        public class Triangle : IFigure
        {
            public double SideA { get; }
            public double SideB { get; }
            public double SideC { get; }
            public Triangle(double a, double b, double c)
            {
                if (a <= 0 || b <= 0 || c <= 0 || !(a + b > c && a + c > b && b + c > a))
                    throw new ArgumentException("Некорректные стороны треугольника");
                SideA = a; SideB = b; SideC = c;
            }
            public double CalculatePerimeter() => SideA + SideB + SideC;
            public double CalculateArea()
            {
                double p = CalculatePerimeter() / 2;
                return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
            }
        }

        class Program
        {
            static void Main()
            {
                IFigure[] figures = { new Circle(5), new Rectangle(3, 4), new Triangle(3, 4, 5) };
                foreach (var f in figures)
                    Console.WriteLine($"{f.GetType().Name}: Площадь = {f.CalculateArea():F2}, Периметр = {f.CalculatePerimeter():F2}");

                Console.Write("\nНажмите любую клавишу для завершения...");
                Console.ReadKey();
            }
        }
}