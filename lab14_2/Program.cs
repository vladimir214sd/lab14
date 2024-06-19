using System;
using System.Linq;
using EmojiLibrary;

namespace la12
{
    public class lab14_2
    {
        static void Main(string[] args)
        {
            MyCollection<Emoji> collection = new MyCollection<Emoji>(); // Создаем коллекцию типа Emoji

            int answer = 0;
            while (answer != 9)
            {
                PrintMenu();
                try
                {
                    answer = IO.InputValidNumber(1, 9, "Введите пункт меню: "); // Считываем ответ пользователя
                    switch (answer)
                    {
                        case 1:
                            int size = IO.InputValidNumber(1, 1000, "Введите длину коллекции: ");
                            CreateCollection(ref collection, size);
                            break;
                        case 2:
                            PrintCollection(collection);
                            break;
                        case 3:
                            WhereQuery(collection);
                            break;
                        case 4:
                            CountQuery(collection);
                            break;
                        case 5:
                            SumQuery(collection);
                            break;
                        case 6:
                            GroupByQuery(collection);
                            break;
                        case 9:
                            Console.WriteLine("Выход из программы.");
                            break;
                        default:
                            Console.WriteLine("Неверный пункт меню. Пожалуйста, выберите существующий пункт.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void PrintMenu()
        {
            Console.WriteLine("\nРабота с коллекцией Emoji\n" +
                "\n1. Создание коллекции" +
                "\n2. Вывод коллекции" +
                "\n3. Выборка данных (Where)" +
                "\n4. Получение счетчика (Count)" +
                "\n5. Агрегирование данных (Sum)" +
                "\n6. Группировка данных (Group by)" +
                "\n9. Выход\n");
        }

        public static void CreateCollection(ref MyCollection<Emoji> collection, int size)
        {
            collection = new MyCollection<Emoji>(size); // Создание коллекции указанного размера
            Console.WriteLine("Коллекция успешно создана");
        }

        public static void PrintCollection(MyCollection<Emoji> collection)
        {
            if (collection.Count == 0)
            {
                Console.WriteLine("\nКоллекция пуста\n");
            }
            else
            {
                collection.PrintList(); // Вывод коллекции на экран
            }
        }

        public static void WhereQuery(MyCollection<Emoji> collection)
        {
            // a) Выборка данных (Where) с использованием LINQ
            var whereQueryLinq = from item in collection
                                 where item.Name.StartsWith("У")
                                 select item;
            Console.WriteLine("\nРезультат выборки данных (Where) с использованием LINQ:");
            foreach (var item in whereQueryLinq)
            {
                Console.WriteLine(item);
            }

            // b) Выборка данных (Where) с использованием методов расширения
            var whereQueryMethod = collection
                .Where(item => item.Name.StartsWith("У"));
            Console.WriteLine("\nРезультат выборки данных (Where) с использованием методов расширения:");
            foreach (var item in whereQueryMethod)
            {
                Console.WriteLine(item);
            }
        }

        public static void CountQuery(MyCollection<Emoji> collection)
        {
            // a) Получение счетчика (Count) с использованием LINQ
            int countQueryLinq = (from item in collection
                                  select item).Count();
            Console.WriteLine($"\nКоличество элементов в коллекции с использованием LINQ: {countQueryLinq}");

            // b) Получение счетчика (Count) с использованием методов расширения
            int countQueryMethod = collection.Count();
            Console.WriteLine($"\nКоличество элементов в коллекции с использованием методов расширения: {countQueryMethod}");
        }

        public static void SumQuery(MyCollection<Emoji> collection)
        {
            // a) Агрегирование данных (Sum) с использованием LINQ
            var sumQueryLinq = (from item in collection
                                select item.Name.Length).Sum();
            Console.WriteLine($"\nСумма длин имен элементов в коллекции с использованием LINQ: {sumQueryLinq}");

            // b) Агрегирование данных (Sum) с использованием методов расширения
            var sumQueryMethod = collection
                .Sum(item => item.Name.Length);
            Console.WriteLine($"\nСумма длин имен элементов в коллекции с использованием методов расширения: {sumQueryMethod}");
        }

        public static void GroupByQuery(MyCollection<Emoji> collection)
        {
            // a) Группировка данных (Group by) с использованием LINQ
            var groupByQueryLinq = from item in collection
                                   group item by item.Tag into g
                                   select new { Tag = g.Key, Count = g.Count() };
            Console.WriteLine("\nРезультат группировки данных (Group by) с использованием LINQ:");
            foreach (var group in groupByQueryLinq)
            {
                Console.WriteLine($"Тэг: {group.Tag}, Количество: {group.Count}");
            }

            // b) Группировка данных (Group by) с использованием методов расширения
            var groupByQueryMethod = collection
                .GroupBy(item => item.Tag)
                .Select(g => new { Tag = g.Key, Count = g.Count() });
            Console.WriteLine("\nРезультат группировки данных (Group by) с использованием методов расширения:");
            foreach (var group in groupByQueryMethod)
            {
                Console.WriteLine($"Тэг: {group.Tag}, Количество: {group.Count}");
            }
        }
    }
}
