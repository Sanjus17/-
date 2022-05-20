using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace phonebook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<int, string[]> book = new Dictionary<int, string[]>();
            Console.WriteLine("Вы открыли телефонную книжку!");
            string action;
            int id = 0;
            do
            {
                Console.WriteLine("Выберите действие:\n1 - Создать запись\n2 - Редактировать запись\n3 - Удалить запись\n4 - просмотреть запись\n5 - просмотреть  краткую информацию всех записей\n6 - закрыть телефонную книжку");
                Console.WriteLine();
                action = Console.ReadLine();
                if (action == "1")
                {
                    id++;
                    book.Add(id, Program.MakeNote());
                    Console.WriteLine();
                    Console.WriteLine($"Запись №{id} добавлена!");
                    Console.WriteLine();
                }
                else if (action == "2")
                {
                    Console.Write("Введите номер записи, которую вы хотите изменить: ");
                    int number = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    if (book.ContainsKey(number)) { book[number] = Program.MakeNote(); Console.WriteLine(); Console.WriteLine($"Запись №{number} изменена!"); }
                    else { Console.WriteLine("Записи с таким номером нет в телефонной книжке!"); }
                    Console.WriteLine();
                }
                else if (action == "3")
                {
                    Console.Write("Введите номер записи, которую вы хотите удалить: ");
                    int number = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    if (book.ContainsKey(number)) { book.Remove(number); Console.WriteLine($"Запись №{number} удалена!"); }
                    else { Console.WriteLine("Записи с таким номером нет в телефонной книжке!"); }
                    Console.WriteLine();
                }
                else if (action == "4")
                {
                    Console.Write("Введите номер записи, которую вы хотите просмотреть: ");
                    int number = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    if (book.ContainsKey(number))
                    {
                        Console.WriteLine($"Фамилия: {book[number][0]}\nИмя: {book[number][1]}");
                        if (book[number][2] != "") { Console.WriteLine($"Отчество: {book[number][2]}"); }
                        Console.WriteLine($"Номер телефона: {book[number][3]}\nСтрана: {book[number][4]}");
                        if (book[number][5] != "") { Console.WriteLine($"Дата рождения: {book[number][5]}"); }
                        if (book[number][6] != "") { Console.WriteLine($"Организация: {book[number][6]}"); }
                        if (book[number][7] != "") { Console.WriteLine($"Должность: {book[number][7]}"); }
                        if (book[number][8] != "") { Console.WriteLine($"Прочие заметки: {book[number][8]}"); }
                    }
                    else { Console.WriteLine("Записи с таким номером нет в телефонной книжке!"); }
                    Console.WriteLine();
                }
                else if (action == "5")
                {
                    Console.WriteLine();
                    foreach (var item in book)
                    {
                        Console.WriteLine($"Запись №{item.Key}\nФамилия: {item.Value[0]}\nИмя: {item.Value[1]}\nНомер телефона: {item.Value[3]}");
                        Console.WriteLine();
                    }
                }
                else if (action == "6") { Console.WriteLine(); Console.WriteLine("Вы закрыли телефонную книжку!"); }
                else { Console.WriteLine(); Console.WriteLine("Такого действия нет. Попробуйте снова!"); Console.WriteLine(); }

            } while (action != "6");
        }
        public static string[] MakeNote()
        {
            string[] note = new string[9];

            Console.Write("Фамилия: ");
            note[0] = Console.ReadLine();
            Console.Write("Имя: ");
            note[1] = Console.ReadLine();
            Console.Write("Отчество (нажмите Enter, чтобы пропустить): ");
            note[2] = Console.ReadLine();
            Console.Write("Номер телефона: ");
            note[3] = Console.ReadLine();
            Console.Write("Страна: ");
            note[4] = Console.ReadLine();
            Console.Write("Дата рождения (нажмите Enter, чтобы пропустить): ");
            note[5] = Console.ReadLine();
            Console.Write("Организация (нажмите Enter, чтобы пропустить): ");
            note[6] = Console.ReadLine();
            Console.Write("Должность (нажмите Enter, чтобы пропустить): ");
            note[7] = Console.ReadLine();
            Console.Write("Прочие заметки (нажмите Enter, чтобы пропустить): ");
            note[8] = Console.ReadLine();

            return note;
        }
    }
}