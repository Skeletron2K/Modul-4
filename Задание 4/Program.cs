using System;
using System.Collections.Generic;

namespace Задание_4
{

    public interface IBook
    {
        bool IsAvailable();
        void IssueBook();
        void ReturnBook();
        string GetBookInfo();
    }

    public class PaperBook : IBook
    {
        public string Title { get; }
        public string Author { get; }
        public bool IsIssued { get; private set; }
        public int Pages { get; }

        public PaperBook(string title, string author, int pages)
        {
            Title = title;
            Author = author;
            Pages = pages > 0 ? pages : throw new ArgumentException("Количество страниц должно быть положительным");
        }

        public bool IsAvailable() => !IsIssued;
        public void IssueBook() => IsIssued = true;
        public void ReturnBook() => IsIssued = false;
        public string GetBookInfo() => $"{Title} - {Author} ({Pages} стр.) [Бумажная] - {(IsAvailable() ? "Доступна" : "Выдана")}";
    }

    public class EBook : IBook
    {
        public string Title { get; }
        public string Author { get; }
        public string Format { get; }
        public double FileSize { get; } // в МБ

        public EBook(string title, string author, string format, double fileSize)
        {
            Title = title;
            Author = author;
            Format = format;
            FileSize = fileSize > 0 ? fileSize : throw new ArgumentException("Размер файла должен быть положительным");
        }

        public bool IsAvailable() => true; // Электронные книги всегда доступны
        public void IssueBook() => Console.WriteLine($"Скачана электронная книга: {Title} в формате {Format}");
        public void ReturnBook() => Console.WriteLine("Электронная книга не требует возврата");
        public string GetBookInfo() => $"{Title} - {Author} [{Format}, {FileSize} ] - Всегда доступна";
    }

    public class AudioBook : IBook
    {
        public string Title { get; }
        public string Author { get; }
        public string Narrator { get; }
        public int Duration { get; } // в минутах

        public AudioBook(string title, string author, string narrator, int duration)
        {
            Title = title;
            Author = author;
            Narrator = narrator;
            Duration = duration > 0 ? duration : throw new ArgumentException("Длительность должна быть положительной");
        }

        public bool IsAvailable() => true; // Аудиокниги всегда доступны
        public void IssueBook() => Console.WriteLine($"Доступ предоставлен к аудиокниге: {Title} (читает: {Narrator})");
        public void ReturnBook() { } // Не требует явного возврата
        public string GetBookInfo() => $"{Title} - {Author} (читает: {Narrator}) [{Duration} мин.] - Всегда доступна";
    }

    class Program
    {
        static void Main()
        {
            List<IBook> library = new List<IBook>
        {
            new PaperBook("Преступление и наказание", "Федор Достоевский", 671),
            new EBook("Тайна полтергейста", "Сергей Недоруб", "PDF", 2.5),
            new AudioBook("Мастер и Маргарита", "Михаил Булгаков", "Иван Стебунов", 1420)
        };

            Console.WriteLine("=== БИБЛИОТЕКА КНИГ ===\n");

            // Показываем все книги
            foreach (var book in library)
            {
                Console.WriteLine(book.GetBookInfo());
            }

            // Демонстрация выдачи книг
            Console.WriteLine("\n=== ВЫДАЧА КНИГ ===");
            var paperBook = (PaperBook)library[0];
            if (paperBook.IsAvailable())
            {
                paperBook.IssueBook();
                Console.WriteLine($"После выдачи: {paperBook.GetBookInfo()}");
            }

            library[1].IssueBook(); // Электронная книга
            library[2].IssueBook(); // Аудиокнига

            // Возврат бумажной книги
            Console.WriteLine("\n=== ВОЗВРАТ КНИГИ ===");
            paperBook.ReturnBook();
            Console.WriteLine($"После возврата: {paperBook.GetBookInfo()}");

            Console.Write("\nНажмите любую клавишу для завершения...");
            Console.ReadKey();
        }
    }
}