using System.Diagnostics;
using System.Collections;
using System;
using EmojiLibrary;
using System.Collections.Generic;
using System.Linq;

namespace la12
{
    public class lab14_1
    {
        public static Stack<Dictionary<int, Emoji>> chat;

        static void Main(string[] args)
        {
            int answer = 0;
            while (answer != 11)
            {
                PrintMenu();
                try
                {
                    answer = IO.InputValidNumber(1, 11, "Введите пункт меню: ");
                    switch (answer)
                    {
                        case 1:
                            CreateCollection();
                            Console.WriteLine("Коллекция успешно создана и заполнена случайными значениями.");
                            break;
                        case 2:
                            PrintCollection();
                            break;
                        case 3:
                            ExecuteWhereQuery();
                            break;
                        case 4:
                            ExecuteUnionQuery();
                            break;
                        case 5:
                            ExecuteExceptQuery();
                            break;
                        case 6:
                            ExecuteIntersectQuery();
                            break;
                        case 7:
                            ExecuteMaxQuery();
                            break;
                        case 8:
                            ExecuteGroupByQuery();
                            break;
                        case 9:
                            ExecuteLetQuery();
                            break;
                        case 10:
                            ExecuteJoinQuery();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        static void PrintMenu()
        {
            Console.WriteLine("\nМеню управления коллекцией Emoji\n" +
                "\n1. Создание коллекции" +
                "\n2. Вывод коллекции" +
                "\n3. Выполнение запроса на выборку данных (Where)" +
                "\n4. Выполнение запроса объединения множеств (Union)" +
                "\n5. Выполнение запроса исключения множества (Except)" +
                "\n6. Выполнение запроса пересечения множеств (Intersect)" +
                "\n7. Выполнение запроса нахождения максимального значения (Max)" +
                "\n8. Выполнение запроса группировки данных (Group by)" +
                "\n9. Выполнение запроса создания нового типа (Let)" +
                "\n10. Выполнение запроса соединения множеств (Join)" +
                "\n11. Выход\n");
        }


        /// Создание коллекции и заполнение ее случайными значениями.
        public static void CreateCollection()
        {
            chat = new Stack<Dictionary<int, Emoji>>();
            for (int i = 0; i < 5; i++)
            {
                Dictionary<int, Emoji> message = new Dictionary<int, Emoji>();
                for (int j = 0; j < 3; j++)
                {
                    Emoji emoji = new Emoji();
                    emoji.RandomInit();
                    message.Add(j, emoji);
                }
                chat.Push(message);
            }
        }


        /// Вывод всех элементов коллекции.
        public static void PrintCollection()
        {
            if (chat == null || chat.Count == 0)
            {
                Console.WriteLine("Коллекция пуста.");
                return;
            }

            int dictIndex = 0;
            foreach (var dict in chat)
            {
                Console.WriteLine($"Сообщение {dictIndex}:");
                foreach (var kvp in dict)
                {
                    Console.WriteLine($"Ключ: {kvp.Key}, Эмодзи: {kvp.Value}");
                }
                dictIndex++;
            }
        }


        /// Выполнение запроса на выборку данных (Where).
        public static void ExecuteWhereQuery()
        {
            Console.WriteLine("Выборка данных (Where) с использованием LINQ:");
            var whereLinq = WhereQueryLinq(chat);
            foreach (var emoji in whereLinq)
            {
                emoji.Show();
            }

            Console.WriteLine("\nВыборка данных (Where) с использованием методов расширения:");
            var whereMethod = WhereQueryMethod(chat);
            foreach (var emoji in whereMethod)
            {
                emoji.Show();
            }
        }


        /// LINQ-запрос на выборку эмодзи, чьи имена начинаются с буквы "У".
        public static IEnumerable<Emoji> WhereQueryLinq(Stack<Dictionary<int, Emoji>> chat)
        {
            return from m in chat.SelectMany(c => c.Values)
                   where m.Name.StartsWith("У")
                   select m;
        }


        /// Запрос на выборку эмодзи, чьи имена начинаются с буквы "У", с использованием методов расширения.
        public static IEnumerable<Emoji> WhereQueryMethod(Stack<Dictionary<int, Emoji>> chat)
        {
            return chat.SelectMany(c => c.Values).Where(m => m.Name.StartsWith("У"));
        }


        /// Выполнение запроса объединения множеств (Union).
        public static void ExecuteUnionQuery()
        {
            Console.WriteLine("Объединение множеств (Union) с использованием LINQ:");
            var unionLinq = UnionQueryLinq(chat);
            foreach (var emoji in unionLinq)
            {
                emoji.Show();
            }

            Console.WriteLine("\nОбъединение множеств (Union) с использованием методов расширения:");
            var unionMethod = UnionQueryMethod(chat);
            foreach (var emoji in unionMethod)
            {
                emoji.Show();
            }
        }


        /// LINQ-запрос на объединение первого и последнего словарей в коллекции chat.

        public static IEnumerable<Emoji> UnionQueryLinq(Stack<Dictionary<int, Emoji>> chat)
        {
            return (from m in chat.First() select m.Value)
                   .Union(from m in chat.Last() select m.Value);
        }


        /// Запрос на объединение первого и последнего словарей в коллекции chat с использованием методов расширения.

        public static IEnumerable<Emoji> UnionQueryMethod(Stack<Dictionary<int, Emoji>> chat)
        {
            return chat.First().Values.Union(chat.Last().Values);
        }


        /// Выполнение запроса исключения множества (Except).

        public static void ExecuteExceptQuery()
        {
            Console.WriteLine("Исключение множества (Except) с использованием LINQ:");
            var exceptLinq = ExceptQueryLinq(chat);
            foreach (var emoji in exceptLinq)
            {
                emoji.Show();
            }

            Console.WriteLine("\nИсключение множества (Except) с использованием методов расширения:");
            var exceptMethod = ExceptQueryMethod(chat);
            foreach (var emoji in exceptMethod)
            {
                emoji.Show();
            }
        }


        /// LINQ-запрос на исключение эмодзи из первого словаря, которые есть в последнем словаре.
        public static IEnumerable<Emoji> ExceptQueryLinq(Stack<Dictionary<int, Emoji>> chat)
        {
            return (from m in chat.First() select m.Value)
                   .Except(from m in chat.Last() select m.Value);
        }


        /// Запрос на исключение эмодзи из первого словаря, которые есть в последнем словаре, с использованием методов расширения.
        public static IEnumerable<Emoji> ExceptQueryMethod(Stack<Dictionary<int, Emoji>> chat)
        {
            return chat.First().Values.Except(chat.Last().Values);
        }


        /// Выполнение запроса пересечения множеств (Intersect).

        public static void ExecuteIntersectQuery()
        {
            Console.WriteLine("Пересечение множеств (Intersect) с использованием LINQ:");
            var intersectLinq = IntersectQueryLinq(chat);
            foreach (var emoji in intersectLinq)
            {
                emoji.Show();
            }

            Console.WriteLine("\nПересечение множеств (Intersect) с использованием методов расширения:");
            var intersectMethod = IntersectQueryMethod(chat);
            foreach (var emoji in intersectMethod)
            {
                emoji.Show();
            }
        }


        /// LINQ-запрос на пересечение первого и последнего словарей в коллекции chat.

        public static IEnumerable<Emoji> IntersectQueryLinq(Stack<Dictionary<int, Emoji>> chat)
        {
            return (from m in chat.First() select m.Value)
                   .Intersect(from m in chat.Last() select m.Value);
        }


        /// Запрос на пересечение первого и последнего словарей в коллекции chat с использованием методов расширения.

        public static IEnumerable<Emoji> IntersectQueryMethod(Stack<Dictionary<int, Emoji>> chat)
        {
            return chat.First().Values.Intersect(chat.Last().Values);
        }


        /// Выполнение запроса нахождения максимального значения (Max).

        public static void ExecuteMaxQuery()
        {
            Console.WriteLine("Нахождение максимального значения (Max) с использованием LINQ:");
            var maxLinq = MaxQueryLinq(chat);
            Console.WriteLine($"Максимальная длина имени: {maxLinq}");

            Console.WriteLine("\nНахождение максимального значения (Max) с использованием методов расширения:");
            var maxMethod = MaxQueryMethod(chat);
            Console.WriteLine($"Максимальная длина имени: {maxMethod}");
        }


        /// LINQ-запрос на нахождение максимальной длины имени среди всех эмодзи в коллекции chat.

        public static int MaxQueryLinq(Stack<Dictionary<int, Emoji>> chat)
        {
            return (from m in chat.SelectMany(c => c.Values)
                    select m.Name.Length).Max();
        }


        /// Запрос на нахождение максимальной длины имени среди всех эмодзи в коллекции chat с использованием методов расширения.

        public static int MaxQueryMethod(Stack<Dictionary<int, Emoji>> chat)
        {
            return chat.SelectMany(c => c.Values).Max(m => m.Name.Length);
        }


        /// Выполнение запроса группировки данных (Group by).

        public static void ExecuteGroupByQuery()
        {
            Console.WriteLine("Группировка данных (Group by) с использованием LINQ:");
            var groupByLinq = GroupByQueryLinq(chat);
            foreach (var group in groupByLinq)
            {
                Console.WriteLine($"Tag: {group.Key}");
                foreach (var emoji in group)
                {
                    emoji.Show();
                }
            }

            Console.WriteLine("\nГруппировка данных (Group by) с использованием методов расширения:");
            var groupByMethod = GroupByQueryMethod(chat);
            foreach (var group in groupByMethod)
            {
                Console.WriteLine($"Tag: {group.Key}");
                foreach (var emoji in group)
                {
                    emoji.Show();
                }
            }
        }


        /// LINQ-запрос на группировку эмодзи по тегам.

        public static IEnumerable<IGrouping<string, Emoji>> GroupByQueryLinq(Stack<Dictionary<int, Emoji>> chat)
        {
            return from m in chat.SelectMany(c => c.Values)
                   group m by m.Tag;
        }


        /// Запрос на группировку эмодзи по тегам с использованием методов расширения.

        public static IEnumerable<IGrouping<string, Emoji>> GroupByQueryMethod(Stack<Dictionary<int, Emoji>> chat)
        {
            return chat.SelectMany(c => c.Values).GroupBy(m => m.Tag);
        }


        /// Выполнение запроса создания нового типа (Let).

        public static void ExecuteLetQuery()
        {
            Console.WriteLine("Создание нового типа (Let) с использованием LINQ:");
            var letLinq = LetQueryLinq(chat);
            foreach (var item in letLinq)
            {
                Console.WriteLine($"Name: {item.Name}, Length: {item.Length}");
            }

            Console.WriteLine("\nСоздание нового типа (Let) с использованием методов расширения:");
            var letMethod = LetQueryMethod(chat);
            foreach (var item in letMethod)
            {
                Console.WriteLine($"Name: {item.Name}, Length: {item.Length}");
            }
        }


        /// LINQ-запрос на создание нового типа, включающего имя эмодзи и его длину.

        public static IEnumerable<(string Name, int Length)> LetQueryLinq(Stack<Dictionary<int, Emoji>> chat)
        {
            return from m in chat.SelectMany(c => c.Values)
                   let length = m.Name.Length
                   select (Name: m.Name, Length: length);
        }


        /// Запрос на создание нового типа, включающего имя эмодзи и его длину, с использованием методов расширения.

        public static IEnumerable<(string Name, int Length)> LetQueryMethod(Stack<Dictionary<int, Emoji>> chat)
        {
            return chat.SelectMany(c => c.Values)
                       .Select(m => (Name: m.Name, Length: m.Name.Length));
        }


        /// Выполнение запроса соединения множеств (Join).

        public static void ExecuteJoinQuery()
        {
            Console.WriteLine("Соединение множеств (Join) с использованием LINQ:");
            var joinLinq = JoinQueryLinq(chat);
            foreach (var item in joinLinq)
            {
                Console.WriteLine($"Key: {item.Key}, Name1: {item.Name1}, Name2: {item.Name2}");
            }

            Console.WriteLine("\nСоединение множеств (Join) с использованием методов расширения:");
            var joinMethod = JoinQueryMethod(chat);
            foreach (var item in joinMethod)
            {
                Console.WriteLine($"Key: {item.Key}, Name1: {item.Name1}, Name2: {item.Name2}");
            }
        }


        /// LINQ-запрос на соединение первого и последнего словарей по ключу.

        public static IEnumerable<(int Key, string Name1, string Name2)> JoinQueryLinq(Stack<Dictionary<int, Emoji>> chat)
        {
            return from m1 in chat.First()
                   join m2 in chat.Last() on m1.Key equals m2.Key
                   select (Key: m1.Key, Name1: m1.Value.Name, Name2: m2.Value.Name);
        }


        /// Запрос на соединение первого и последнего словарей по ключу с использованием методов расширения.

        public static IEnumerable<(int Key, string Name1, string Name2)> JoinQueryMethod(Stack<Dictionary<int, Emoji>> chat)
        {
            return chat.First()
                       .Join(chat.Last(), m1 => m1.Key, m2 => m2.Key, (m1, m2) => (Key: m1.Key, Name1: m1.Value.Name, Name2: m2.Value.Name));
        }
    }
}
