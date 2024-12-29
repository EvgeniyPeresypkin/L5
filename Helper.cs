using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5
{
    public static class Helper
    {
        public static double InputDouble(string inputText, string errorText)
        {
            double value = 0;
            bool isValidInput = false;

            while (!isValidInput)
            {
                Console.Write($"{inputText} ");
                string userInput = Console.ReadLine();
                isValidInput = double.TryParse(userInput, out value) && value != 0; // Проверка на 0
                if (!isValidInput)
                {
                    Console.WriteLine($"{errorText}");
                }
            }
            return value;
        }
        public static void Info()
        {
            Console.WriteLine("Вы выбрали пункт 2 ");
            Console.WriteLine("Пересыпкин Евгений Дмитриевич, группа 6101");
        }
        public static int Menu()
        {
            int choice; // Переменная для хранения выбора пользователя
            while (true) // Бесконечный цикл, пока не будет введен корректный ввод
            {
                Console.WriteLine("Меню");
                Console.WriteLine("1. Отгадайте число");
                Console.WriteLine("2. Об авторе");
                Console.WriteLine("3. Сортировка Массива");
                Console.WriteLine("4. Игра поиск сокровищ");
                Console.WriteLine("5. Выход");
                Console.WriteLine("Введите ваш вариант меню:");

                // Попробуем получить ввод от пользователя
                string input = Console.ReadLine();

                // Проверяем, является ли ввод целым числом
                if (int.TryParse(input, out choice))
                {
                    // Проверяем, находится ли выбор в допустимом диапазоне
                    if (choice >= 1 && choice <= 5)
                    {
                        return choice; // Возвращаем корректный выбор
                    }
                    else
                    {
                        Console.WriteLine("Пожалуйста, введите число от 1 до 5.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
                }
            }
        }
        public static double DoubleParse()
        {
            double x = 0;
            bool inputCorrect = false;
            while (!inputCorrect)
            {
                string strA = Console.ReadLine();
                inputCorrect = double.TryParse(strA, out x);
                if (!inputCorrect)
                {
                    Console.WriteLine("Ошибка ввода");
                }
            }
            return x;
        }
         public static int IntParse()
        {
            int x = 0;
            bool inputCorrect = false;
            while (!inputCorrect)
            {
                string strA = Console.ReadLine();
                inputCorrect = int.TryParse(strA, out x);
                if (!inputCorrect)
                {
                    Console.WriteLine("Ошибка ввода");
                }
            }
            return x;
        }
        public static bool ExitProgram()
        {
            Console.WriteLine("Вы выбрали пункт 5 ");
            bool running3 = true;
            bool running = true;
            do
            {
                Console.WriteLine("Вы действительно хотите выйти? ");
                string a1 = Console.ReadLine();

                if (a1 == "д")
                {
                    Console.WriteLine("Вы вышли");
                    running = false;
                    running3 = false;
                }
                else if (a1 == "н")
                {
                    Console.WriteLine("Вы решили остаться");
                    running = true;
                    running3 = false;
                }
                else
                {
                    Console.WriteLine("Ошибка ввода");
                    running3 = true;
                }

            }
            while (running3);
            return running;
        }
    }
    
}