// See https://aka.ms/new-console-template for more information

using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Linq;

namespace massiv1
{

    public static class StringExtensions
    {
        public static string toUpperFirst(this string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return s;
            }

            return char.ToUpper(s[0]) + s.Substring(1).ToLower();
        }
    }


    class Person
    {
        public string name = "Undefined", patronymic = "Undefined", surname = "Undefined", cit = "Undefined", num = "Undefined";
        public DateTime dob = DateTime.MinValue;
        

    }

    

    class Program
    {
        static void Main(string[] args)
        {
            Person data = new Person();

            string answer = "";
            const string yes = "yes";
            do
            {
                Console.WriteLine("Имя: ");
                while (string.IsNullOrEmpty(data.name = Console.ReadLine()))
                {
                    Console.WriteLine("Введите еще раз корректное значение");
                }
                Console.WriteLine("Фамилию: ");
                while (string.IsNullOrEmpty(data.surname = Console.ReadLine()))
                {
                    Console.WriteLine("Введите еще раз корректное значение");
                }
                Console.WriteLine("Отчество: ");
                while (string.IsNullOrEmpty(data.patronymic = Console.ReadLine()))
                {
                    Console.WriteLine("Введите еще раз корректное значение");
                }

                var notValid = true;
                do
                {
                    Console.WriteLine("Введите дату рождения в формате дд.ММ.гггг (день.месяц.год):");
                    var str = Console.ReadLine();
                    if (DateTime.TryParse(str, out data.dob) && data.dob.Year > 1900)
                        notValid = false;
                }
                while (notValid);
                Console.WriteLine("Город: ");
                while (string.IsNullOrEmpty(data.cit = Console.ReadLine()))
                {
                    Console.WriteLine("Введите еще раз корректное значение");
                }
                Console.WriteLine("Телефон: напишите начиная с +7");
                while (!(data.num = Console.ReadLine()).StartsWith("+7"))
                {
                    Console.WriteLine("Введите еще раз корректное значение");
                }




                Console.WriteLine($"ФИО: {data.name.toUpperFirst()} {data.surname.toUpperFirst()} {data.patronymic.toUpperFirst()} | Дата: {data.dob.ToShortDateString()} | Город: {data.cit.toUpperFirst()} | Телефон: {data.num}");
                File.AppendAllText("C:\\Users\\maxho\\OneDrive\\Рабочий стол\\C#\\tekst.txt", ($"{data.name.toUpperFirst()} {data.surname.toUpperFirst()} {data.patronymic.toUpperFirst()} ,{data.dob.ToShortDateString()},{data.cit},{data.num}\r\n"));

                Console.WriteLine("Желаете ввести данные снова(Yes/No) ");
                answer = Console.ReadLine();
            } while (answer.Equals(yes, StringComparison.OrdinalIgnoreCase));

            var lines = File.ReadAllLines("C:\\Users\\maxho\\OneDrive\\Рабочий стол\\C#\\tekst.txt");
            var list = new List<Person>();
            foreach (var line in lines)
            {
                var strs = line.Split(",");
                var person = new Person
                {
                    name = strs[0],
                    dob = DateTime.Parse(strs[1]),
                    cit = strs[2],
                    num = strs[3]
                };
                list.Add(person);
                Console.WriteLine($"{person.name},{person.dob.ToShortDateString()},{person.cit},{person.num}");

                //var listt = list.OrderBy(x => x.name).ToList();
                //Console.WriteLine(listt);  - не получется вывести в сортировке по алфавиту
            }
            Console.WriteLine($"Колличество человек {list.Count}");
        }
    }
}
