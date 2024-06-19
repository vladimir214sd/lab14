using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using EmojiLibrary;
using la12;

namespace la12Tests
{
    [TestClass]
    public class Lab14_2Tests
    {
        private MyCollection<Emoji> CreateSampleCollection(int size)
        {
            var collection = new MyCollection<Emoji>(size);
            for (int i = 0; i < size; i++)
            {
                collection.Add(new Emoji { Name = $"Emoji{i}", Tag = $"Tag{i % 3}" });
            }
            return collection;
        }

        [TestMethod]
        public void TestCreateCollection()
        {
            var collection = new MyCollection<Emoji>();
            lab14_2.CreateCollection(ref collection, 5);
            Assert.IsNotNull(collection);
            Assert.AreEqual(5, collection.Count);
        }

        [TestMethod]
        public void TestPrintCollection()
        {
            var collection = CreateSampleCollection(5);
            // Redirect console output to capture it
            var consoleOutput = new System.IO.StringWriter();
            System.Console.SetOut(consoleOutput);

            lab14_2.PrintCollection(collection);
            var output = consoleOutput.ToString();

            Assert.IsTrue(output.Contains("Emoji"));
        }

        [TestMethod]
        public void TestWhereQuery()
        {
            var collection = CreateSampleCollection(5);
            // Redirect console output to capture it
            var consoleOutput = new System.IO.StringWriter();
            System.Console.SetOut(consoleOutput);

            lab14_2.WhereQuery(collection);
            var output = consoleOutput.ToString();

            Assert.IsTrue(output.Contains("Результат выборки данных (Where)"));
        }

        [TestMethod]
        public void TestCountQuery()
        {
            var collection = CreateSampleCollection(5);
            // Redirect console output to capture it
            var consoleOutput = new System.IO.StringWriter();
            System.Console.SetOut(consoleOutput);

            lab14_2.CountQuery(collection);
            var output = consoleOutput.ToString();

            Assert.IsTrue(output.Contains("Количество элементов в коллекции"));
        }

        [TestMethod]
        public void TestSumQuery()
        {
            var collection = CreateSampleCollection(5);
            // Redirect console output to capture it
            var consoleOutput = new System.IO.StringWriter();
            System.Console.SetOut(consoleOutput);

            lab14_2.SumQuery(collection);
            var output = consoleOutput.ToString();

            Assert.IsTrue(output.Contains("Сумма длин имен элементов в коллекции"));
        }

        [TestMethod]
        public void TestGroupByQuery()
        {
            var collection = CreateSampleCollection(5);
            // Redirect console output to capture it
            var consoleOutput = new System.IO.StringWriter();
            System.Console.SetOut(consoleOutput);

            lab14_2.GroupByQuery(collection);
            var output = consoleOutput.ToString();

            Assert.IsTrue(output.Contains("Результат группировки данных (Group by)"));
        }
    }
}
