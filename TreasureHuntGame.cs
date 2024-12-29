using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace L5
{
    /// <summary>
    /// Класс для реализации игры "Поиск сокровищ".
    /// </summary>
    public  class TreasureHuntGame
    {
        private const int BoardSize = 10; // Размер игрового поля
        private const char TreasureSymbol = 'С'; // Символ сокровища
        private const char TrapSymbol = 'Л'; // Символ ловушки
        private const char EmptySymbol = 'П'; // Символ пустой клетки

        private char[,] board; // Игровое поле
        private int treasuresToFind; // Количество сокровищ для поиска
        private int treasuresFound; // Количество найденных сокровищ
        private int trapsCount; // Количество ловушек
        private bool gameOver; // Флаг завершения игры

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="treasuresToFind">Количество сокровищ для поиска.</param>
        /// <param name="trapsCount">Количество ловушек на поле.</param>
        public  TreasureHuntGame(int treasuresToFind, int trapsCount)
        {
            this.treasuresToFind = treasuresToFind;
            this.trapsCount = trapsCount;
            this.treasuresFound = 0; // Изначально сокровища не найдены
            this.gameOver = false; // Игра не окончена
            board = new char[BoardSize, BoardSize];
            InitializeGame();
        }

        /// <summary>
        /// Инициализирует игровое поле.
        /// </summary>
        private void InitializeGame()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    board[i, j] = EmptySymbol;
                }
            }
            PlaceItems(TreasureSymbol, treasuresToFind);
            PlaceItems(TrapSymbol, trapsCount); // Размещаем ловушки
        }

        /// <summary>
        /// Размещает элементы на игровом поле.
        /// </summary>
        /// <param name="item">Элемент для размещения.</param>
        /// <param name="count">Количество элементов.</param>
        private void PlaceItems(char item, int count)
        {
            Random rand = new Random();
            int placedCount = 0;

            while (placedCount < count)
            {
                int x = rand.Next(BoardSize);
                int y = rand.Next(BoardSize);
                if (board[x, y] == EmptySymbol)
                {
                    board[x, y] = item;
                    placedCount++;
                }
            }
        }

        /// <summary>
        /// Запускает игру.
        /// </summary>
        public void Play()
        {
            while (!gameOver)
            {
                Console.Clear();
                PrintBoard();
                Console.WriteLine($"Найдено сокровищ: {treasuresFound}/{treasuresToFind}");

                string input = GetUserInput(); // Получаем ввод пользователя

                if (input.ToLower() == "exit") // Проверяем команду выхода
                {
                    gameOver = true; // Завершение игры
                }
                else
                {
                    ProcessInput(input); // Обрабатываем ввод пользователя
                }

                // Проверяем условие победы
                if (treasuresFound == treasuresToFind)
                {
                    Console.Clear();
                    PrintBoard();
                    Console.WriteLine("Поздравляем! Вы нашли все сокровища!");
                    gameOver = true; // Завершение игры
                }
            }

            Console.WriteLine("Спасибо за игру!");
        }

        /// <summary>
        /// Обрабатывает ввод пользователя.
        /// </summary>
        /// <param name="input">Ввод пользователя.</param>
        private void ProcessInput(string input)
        {
            bool validInput = false; // Флаг для проверки корректности ввода
            int row = -1, col = -1;

            // Проверка ввода
            if (input.Length == 2)
            {
                col = input[0] - 'A'; // Преобразует букву в индекс столбца (A=0)

                // Проверяем, является ли второй символ цифрой и преобразуем его в индекс строки
                if (char.IsDigit(input[1]) && int.TryParse(input[1].ToString(), out int rowInput))
                {
                    row = rowInput; // Преобразует 0-9 в 0-9
                    // Проверяем, что столбец и строка находятся в допустимых пределах
                    if (col >= 0 && col < BoardSize && row >= 0 && row < BoardSize)
                    {
                        validInput = true; // Устанавливаем флаг в true
                    }
                }
            }

            if (validInput)
            {
                char cell = board[row, col];
                if (cell == TreasureSymbol)
                {
                    Console.WriteLine("Вы нашли сокровище!");
                    treasuresFound++;
                    board[row, col] = EmptySymbol; // Удаляем найденное сокровище
                }
                else if (cell == TrapSymbol)
                {
                    Console.WriteLine("Вы попали в ловушку! Игра окончена!");
                    gameOver = true; // Завершение игры
                }
                else
                {
                    Console.WriteLine("Эта клетка пустая. Продолжайте искать!");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод! Пожалуйста, введите координаты в формате A0.");
            }

            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
            Console.ReadKey();
        }

        /// <summary>
        /// Выводит игровое поле на экран.
        /// </summary>
        private void PrintBoard()
        {
            Console.WriteLine("  A B C D E F G H I J");
            for (int i = 0; i < BoardSize; i++)
            {
                Console.Write(i + " "); // Выводим номер строки, начиная с 0
                for (int j = 0; j < BoardSize; j++)
                {
                    Console.Write(board[i, j] + " "); // Выводим содержимое ячейки
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Получает ввод пользователя.
        /// </summary>
        /// <returns>Строку ввода от пользователя.</returns>
        private string GetUserInput()
        {
            string input = string.Empty; // Переменная для хранения ввода
            bool validInputReceived = false; // Флаг для проверки корректности ввода

            while (!validInputReceived) // Цикл продолжается, пока не получен корректный ввод
            {
                Console.Write("Введите координаты (например, A0) или 'exit' для выхода: ");
                input = Console.ReadLine();

                if (input.Length == 2 || input.ToLower() == "exit") // Проверяем, что ввод корректный
                {
                    validInputReceived = true; // Устанавливаем флаг, если ввод корректный
                }
                else
                {
                    Console.WriteLine("Некорректный ввод! Пожалуйста, введите координаты в формате A0.");
                }
            }

            return input; // Возвращаем корректный ввод
        }
    }
}


