using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5
{
    public static class MathGame
    {
        public static void Start()
        {
            double a = Helper.InputDouble("Введите значение a:", "Неправильный ввод a!");
            double b = Helper.InputDouble("Введите значение b:", "Неправильный ввод b!");

            if (b > 0)
            {
                double result = CalculateFunction(a, b);
                PlayGame(result);
            }
            else
            {
                Console.WriteLine("Такое значение b не правильно");
            }
        }

        private static void PlayGame(double correctAnswer)
        {
            int attempts = 0;
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine($"Правильный результат: {correctAnswer}");
                Console.WriteLine("Введите вашу догадку: ");
                double userGuess = 0;
                string userInput = Console.ReadLine();

                bool isValidInput = double.TryParse(userInput, out userGuess);
                if (isValidInput && Math.Abs(correctAnswer - userGuess) < 0.01) // Сравнение с учетом погрешности
                {
                    Console.WriteLine("Вы угадали, поздравляю !!!");
                    isRunning = false;
                }
                else
                {
                    attempts++;
                    Console.WriteLine($"Вы не угадали. У вас осталось {3 - attempts} попыток.");

                    if (attempts == 3)
                    {
                        Console.WriteLine($"Вы проиграли :( Правильным числом было {correctAnswer}");
                        isRunning = false;
                    }
                }
            }
        }

        

        public static double CalculateFunction(double a, double b)
        {
            // Конвертация в радианы
            double radians = a * (Math.PI / 180); // преобразование градусов в радианы
            double result1 = Math.Sqrt(b + Math.Sin(radians)); // sin(a) должен быть в радианах
            double result2 = Math.Pow(Math.Cos(radians), 3); // cos(a) должен быть в радианах
            double result3 = Math.Log(result1 / result2, b);
            return Math.Round(result3, 2); // Округление до 2 знаков после запятой
        }
    }
}