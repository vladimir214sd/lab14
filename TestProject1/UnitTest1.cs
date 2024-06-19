using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using EmojiLibrary;
using System.Linq;
using la12;

namespace la12Tests
{
    [TestClass]
    public class Lab14_1Tests
    {
        private Stack<Dictionary<int, Emoji>> CreateSampleCollection()
        {
            var chat = new Stack<Dictionary<int, Emoji>>();
            for (int i = 0; i < 5; i++)
            {
                var message = new Dictionary<int, Emoji>();
                for (int j = 0; j < 3; j++)
                {
                    var emoji = new Emoji { Name = $"Emoji{j}{i}", Tag = $"Tag{i}" };
                    message.Add(j, emoji);
                }
                chat.Push(message);
            }
            return chat;
        }

        [TestInitialize]
        public void Initialize()
        {
            lab14_1.chat = CreateSampleCollection();
        }

        [TestMethod]
        public void TestCreateCollection()
        {
            lab14_1.CreateCollection();
            Assert.IsNotNull(lab14_1.chat);
            Assert.AreEqual(5, lab14_1.chat.Count);
        }

        [TestMethod]
        public void TestPrintCollection()
        {
            // Redirect console output to capture it
            var consoleOutput = new System.IO.StringWriter();
            System.Console.SetOut(consoleOutput);

            lab14_1.PrintCollection();
            var output = consoleOutput.ToString();

            Assert.IsTrue(output.Contains("Сообщение"));
            Assert.IsTrue(output.Contains("Ключ"));
            Assert.IsTrue(output.Contains("Эмодзи"));
        }

        [TestMethod]
        public void TestExecuteWhereQuery()
        {
            // Redirect console output to capture it
            var consoleOutput = new System.IO.StringWriter();
            System.Console.SetOut(consoleOutput);

            lab14_1.ExecuteWhereQuery();
            var output = consoleOutput.ToString();

            Assert.IsTrue(output.Contains("Выборка данных (Where)"));
        }

        [TestMethod]
        public void TestExecuteUnionQuery()
        {
            // Redirect console output to capture it
            var consoleOutput = new System.IO.StringWriter();
            System.Console.SetOut(consoleOutput);

            lab14_1.ExecuteUnionQuery();
            var output = consoleOutput.ToString();

            Assert.IsTrue(output.Contains("Объединение множеств (Union)"));
        }

        [TestMethod]
        public void TestExecuteExceptQuery()
        {
            // Redirect console output to capture it
            var consoleOutput = new System.IO.StringWriter();
            System.Console.SetOut(consoleOutput);

            lab14_1.ExecuteExceptQuery();
            var output = consoleOutput.ToString();

            Assert.IsTrue(output.Contains("Исключение множества (Except)"));
        }

        [TestMethod]
        public void TestExecuteIntersectQuery()
        {
            // Redirect console output to capture it
            var consoleOutput = new System.IO.StringWriter();
            System.Console.SetOut(consoleOutput);

            lab14_1.ExecuteIntersectQuery();
            var output = consoleOutput.ToString();

            Assert.IsTrue(output.Contains("Пересечение множеств (Intersect)"));
        }

        [TestMethod]
        public void TestExecuteMaxQuery()
        {
            // Redirect console output to capture it
            var consoleOutput = new System.IO.StringWriter();
            System.Console.SetOut(consoleOutput);

            lab14_1.ExecuteMaxQuery();
            var output = consoleOutput.ToString();

            Assert.IsTrue(output.Contains("Нахождение максимального значения (Max)"));
        }

        [TestMethod]
        public void TestExecuteGroupByQuery()
        {
            // Redirect console output to capture it
            var consoleOutput = new System.IO.StringWriter();
            System.Console.SetOut(consoleOutput);

            lab14_1.ExecuteGroupByQuery();
            var output = consoleOutput.ToString();

            Assert.IsTrue(output.Contains("Группировка данных (Group by)"));
        }

        [TestMethod]
        public void TestExecuteLetQuery()
        {
            // Redirect console output to capture it
            var consoleOutput = new System.IO.StringWriter();
            System.Console.SetOut(consoleOutput);

            lab14_1.ExecuteLetQuery();
            var output = consoleOutput.ToString();

            Assert.IsTrue(output.Contains("Создание нового типа (Let)"));
        }

        [TestMethod]
        public void TestExecuteJoinQuery()
        {
            // Redirect console output to capture it
            var consoleOutput = new System.IO.StringWriter();
            System.Console.SetOut(consoleOutput);

            lab14_1.ExecuteJoinQuery();
            var output = consoleOutput.ToString();

            Assert.IsTrue(output.Contains("Соединение множеств (Join)"));
        }

        [TestMethod]
        public void TestWhereQueryLinq()
        {
            var chat = CreateSampleCollection();
            var result = lab14_1.WhereQueryLinq(chat).ToList();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.All(e => e.Name.StartsWith("Emoji")));
        }

        [TestMethod]
        public void TestWhereQueryMethod()
        {
            var chat = CreateSampleCollection();
            var result = lab14_1.WhereQueryMethod(chat).ToList();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.All(e => e.Name.StartsWith("Emoji")));
        }

        [TestMethod]
        public void TestUnionQueryLinq()
        {
            var chat = CreateSampleCollection();
            var result = lab14_1.UnionQueryLinq(chat).ToList();
            Assert.IsNotNull(result);
            Assert.AreEqual(6, result.Count);
        }

        [TestMethod]
        public void TestUnionQueryMethod()
        {
            var chat = CreateSampleCollection();
            var result = lab14_1.UnionQueryMethod(chat).ToList();
            Assert.IsNotNull(result);
            Assert.AreEqual(6, result.Count);
        }

        [TestMethod]
        public void TestExceptQueryLinq()
        {
            var chat = CreateSampleCollection();
            var result = lab14_1.ExceptQueryLinq(chat).ToList();
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void TestExceptQueryMethod()
        {
            var chat = CreateSampleCollection();
            var result = lab14_1.ExceptQueryMethod(chat).ToList();
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void TestIntersectQueryLinq()
        {
            var chat = CreateSampleCollection();
            var result = lab14_1.IntersectQueryLinq(chat).ToList();
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void TestIntersectQueryMethod()
        {
            var chat = CreateSampleCollection();
            var result = lab14_1.IntersectQueryMethod(chat).ToList();
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void TestMaxQueryLinq()
        {
            var chat = CreateSampleCollection();
            var result = lab14_1.MaxQueryLinq(chat);
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void TestMaxQueryMethod()
        {
            var chat = CreateSampleCollection();
            var result = lab14_1.MaxQueryMethod(chat);
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void TestGroupByQueryLinq()
        {
            var chat = CreateSampleCollection();
            var result = lab14_1.GroupByQueryLinq(chat).ToList();
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count);
        }

        [TestMethod]
        public void TestGroupByQueryMethod()
        {
            var chat = CreateSampleCollection();
            var result = lab14_1.GroupByQueryMethod(chat).ToList();
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count);
        }

        [TestMethod]
        public void TestLetQueryLinq()
        {
            var chat = CreateSampleCollection();
            var result = lab14_1.LetQueryLinq(chat).ToList();
            Assert.IsNotNull(result);
            Assert.AreEqual(15, result.Count);
            Assert.IsTrue(result.All(e => e.Length == 7));
        }

        [TestMethod]
        public void TestLetQueryMethod()
        {
            var chat = CreateSampleCollection();
            var result = lab14_1.LetQueryMethod(chat).ToList();
            Assert.IsNotNull(result);
            Assert.AreEqual(15, result.Count);
            Assert.IsTrue(result.All(e => e.Length == 7));
        }

        [TestMethod]
        public void TestJoinQueryLinq()
        {
            var chat = CreateSampleCollection();
            var result = lab14_1.JoinQueryLinq(chat).ToList();
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void TestJoinQueryMethod()
        {
            var chat = CreateSampleCollection();
            var result = lab14_1.JoinQueryMethod(chat).ToList();
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }
    }
}
