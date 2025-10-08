using System;
using System.Collections.Generic;

namespace Задание_5
{

    public interface IDrawing
    {
        void DrawLine(int x1, int y1, int x2, int y2);
        void DrawCircle(int x, int y, int radius);
        void DrawRectangle(int x, int y, int width, int height);
        void DisplayCanvas();
        void ClearCanvas();
    }

    public class Canvas : IDrawing
    {
        private List<string> _shapes = new List<string>();

        public void DrawLine(int x1, int y1, int x2, int y2)
        {
            _shapes.Add($"Линия: ({x1},{y1}) - ({x2},{y2})");
            Console.WriteLine($"Нарисована линия из ({x1},{y1}) в ({x2},{y2})");
        }

        public void DrawCircle(int x, int y, int radius)
        {
            _shapes.Add($"Круг: центр ({x},{y}), радиус {radius}");
            Console.WriteLine($"Нарисован круг в точке ({x},{y}) с радиусом {radius}");
        }

        public void DrawRectangle(int x, int y, int width, int height)
        {
            _shapes.Add($"Прямоугольник: ({x},{y}), размер {width}x{height}");
            Console.WriteLine($"Нарисован прямоугольник в ({x},{y}) размером {width}x{height}");
        }

        public void DisplayCanvas()
        {
            Console.WriteLine("\n=== СОДЕРЖИМОЕ ХОЛСТА ===");
            if (_shapes.Count == 0)
            {
                Console.WriteLine("Холст пуст");
                return;
            }

            foreach (var shape in _shapes)
            {
                Console.WriteLine($" - {shape}");
            }
            Console.WriteLine($"Всего фигур: {_shapes.Count}");
        }

        public void ClearCanvas()
        {
            _shapes.Clear();
            Console.WriteLine("Холст очищен");
        }
    }

    public class AdvancedCanvas : IDrawing
    {
        private List<string> _shapes = new List<string>();
        public string Color { get; set; } = "Черный";

        public void DrawLine(int x1, int y1, int x2, int y2)
        {
            _shapes.Add($"Линия {Color}: ({x1},{y1}) - ({x2},{y2})");
            Console.WriteLine($"Нарисована {Color.ToLower()} линия из ({x1},{y1}) в ({x2},{y2})");
        }

        public void DrawCircle(int x, int y, int radius)
        {
            _shapes.Add($"Круг {Color}: центр ({x},{y}), радиус {radius}");
            Console.WriteLine($"Нарисован {Color.ToLower()} круг в точке ({x},{y}) с радиусом {radius}");
        }

        public void DrawRectangle(int x, int y, int width, int height)
        {
            _shapes.Add($"Прямоугольник {Color}: ({x},{y}), размер {width}x{height}");
            Console.WriteLine($"Нарисован {Color.ToLower()} прямоугольник в ({x},{y}) размером {width}x{height}");
        }

        public void DisplayCanvas()
        {
            Console.WriteLine("\n=== РАСШИРЕННЫЙ ХОЛСТ ===");
            if (_shapes.Count == 0)
            {
                Console.WriteLine("Холст пуст");
                return;
            }

            foreach (var shape in _shapes)
            {
                Console.WriteLine($" - {shape}");
            }
        }

        public void ClearCanvas()
        {
            _shapes.Clear();
            Console.WriteLine("Расширенный холст очищен");
        }

        public void ChangeColor(string newColor)
        {
            Color = newColor;
            Console.WriteLine($"Цвет рисования изменен на {newColor}");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== ПРИЛОЖЕНИЕ ДЛЯ РИСОВАНИЯ ===\n");

            // Простой холст
            IDrawing canvas = new Canvas();
            canvas.DrawLine(0, 0, 10, 10);
            canvas.DrawCircle(5, 5, 3);
            canvas.DrawRectangle(2, 2, 6, 4);
            canvas.DisplayCanvas();

            Console.WriteLine("\n" + new string('-', 40) + "\n");

            // Расширенный холст с цветами
            AdvancedCanvas advancedCanvas = new AdvancedCanvas();
            advancedCanvas.DrawLine(0, 0, 8, 8);
            advancedCanvas.ChangeColor("Красный");
            advancedCanvas.DrawCircle(4, 4, 2);
            advancedCanvas.ChangeColor("Синий");
            advancedCanvas.DrawRectangle(1, 1, 5, 3);
            advancedCanvas.DisplayCanvas();

            Console.WriteLine("\n=== ОЧИСТКА ХОЛСТА ===");
            canvas.ClearCanvas();
            canvas.DisplayCanvas();

            Console.Write("\nНажмите любую клавишу для завершения...");
            Console.ReadKey();
        }
    }
}
