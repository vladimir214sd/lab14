using System;
namespace EmojiLibrary
{
    public interface IO
    {
        public static int InputValidNumber(int a, int b, string prompt)  // проверка на целое число
        {
            int element;
            bool isConvert;

            do
            {
                Console.Write(prompt);
                isConvert = int.TryParse(Console.ReadLine(), out element) && element >= a && element <= b;

                if (!isConvert)
                    Console.Write($"Ошибка при вводе! Введите значение от {a} до {b}: ");
            } while (!isConvert);
            return element;
        }
    }
}

