using System;
using System.Collections.Generic;
using System.Linq;

namespace Задание_3
{
    public interface IStudent
    {
        double GetAverageGrade();
        string GetCourseInfo();
    }

    public class FirstYearStudent : IStudent
    {
        public string Name { get; }
        private List<int> _grades;

        public FirstYearStudent(string name, List<int> grades)
        {
            Name = name;
            _grades = grades;
            new List<int>();
        }

        public double GetAverageGrade() => _grades.Count > 0 ? _grades.Average() : 0;
        public string GetCourseInfo() => $"{Name} - 1 курс";

        public void AddGrade(int grade) => _grades.Add(grade);
    }

    public class MasterStudent : IStudent
    {
        public string Name { get; }
        public string ResearchTopic { get; }
        private List<int> _grades;

        public MasterStudent(string name, string researchTopic, List<int> grades)
        {
            Name = name;
            ResearchTopic = researchTopic;
            _grades = grades;  
            new List<int>();
        }

        public double GetAverageGrade() => _grades.Count > 0 ? _grades.Average() : 0;
        public string GetCourseInfo() => $"{Name} - Магистратура, Тема: {ResearchTopic}";

        public void AddGrade(int grade) => _grades.Add(grade);
    }

    public class PhDStudent : IStudent
    {
        public string Name { get; }
        public string DissertationTopic { get; }
        private List<int> _grades;

        public PhDStudent(string name, string dissertationTopic, List<int> grades)
        {
            Name = name;
            DissertationTopic = dissertationTopic;
            _grades = grades;
            new List<int>();
        }

        public double GetAverageGrade() => _grades.Count > 0 ? _grades.Average() : 0;
        public string GetCourseInfo() => $"{Name} - Аспирантура: {DissertationTopic}";

        public void AddGrade(int grade) => _grades.Add(grade);
    }

    class Program
    {
        static void Main()
        {
            List<IStudent> students = new List<IStudent>
        {
            new FirstYearStudent("Иван Петров", new List<int> {4, 5, 3, 5}),
            new MasterStudent("Анна Сидорова", "ИИ в образовании", new List<int> {5, 5, 4}),
            new PhDStudent("Артём Коваленко", "Радио физика", new List<int> {5, 5, 5, 4})
        };

            Console.WriteLine("=== СИСТЕМА УЧЁТА СТУДЕНТОВ ===\n");

            foreach (var student in students)
            {
                Console.WriteLine(student.GetCourseInfo());
                Console.WriteLine($"Средний балл: {student.GetAverageGrade():F2}\n");
            }

            // Добавляем новые оценки
            var firstYear = (FirstYearStudent)students[0];
            firstYear.AddGrade(5);
            Console.WriteLine($"После добавления оценки: {firstYear.GetCourseInfo()}");
            Console.WriteLine($"Новый средний балл: {firstYear.GetAverageGrade():F2}");

            Console.Write("\nНажмите любую клавишу для завершения...");
            Console.ReadKey();
        }
    }
}