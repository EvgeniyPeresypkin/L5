using L5.MyGame;

namespace L5
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                // Вызываем метод Menu один раз и сохраняем выбор пользователя
                int choice = Helper.Menu();

                switch (choice) // Используем переменную для выбора
                {
                    case 1:
                        MathGame.Start();
                        break;
                    case 2:
                        Helper.Info();
                        break;
                    case 3:
                        // Сначала запрашиваем размер массива у пользователя
                        int arraySize = ArrayHandler.MassivSize();

                        // Создание экземпляра с использованием конструктора без параметров
                        ArrayHandler defaultArrayHandler = new ArrayHandler(); // Конструктор без параметров
                        defaultArrayHandler.InitializeArray(); // Инициализация массива (можно использовать какой-то стандартный размер)
                        int[] defaultArrayToSort = defaultArrayHandler.GetArray();

                        // Сортировка выбором
                        double defaultSelectionTime = ArrayHandler.SelectionTime(defaultArrayToSort);
                        int[] defaultSortedArray = ArrayHandler.SelectionSort(defaultArrayToSort);

                        // Сортировка методом Шелла
                        double defaultShellTime = ArrayHandler.ShellTime(defaultSortedArray);

                        // Вывод результатов
                        ArrayHandler.Sorter(defaultSelectionTime, defaultShellTime, defaultSortedArray.Length, defaultArrayToSort, defaultSortedArray);

                        // Создание экземпляра с использованием конструктора с параметрами
                        ArrayHandler customArrayHandler = new ArrayHandler(arraySize); // Конструктор с параметрами
                        customArrayHandler.InitializeArray(); // Инициализация массива
                        int[] customArrayToSort = customArrayHandler.GetArray();

                        // Сортировка выбором
                        double customSelectionTime = ArrayHandler.SelectionTime(customArrayToSort);
                        int[] customSortedArray = ArrayHandler.SelectionSort(customArrayToSort);

                        // Сортировка методом Шелла
                        double customShellTime = ArrayHandler.ShellTime(customSortedArray);

                        // Вывод результатов
                        ArrayHandler.Sorter(customSelectionTime, customShellTime, customSortedArray.Length, customArrayToSort, customSortedArray);
                        break;
                    case 4:
                        TreasureHuntGame treasureHuntGame = new TreasureHuntGame(3, 2);
                        treasureHuntGame.Play();
                        break;
                    case 5:
                        running = !Helper.ExitProgram(); // Выход из цикла в зависимости от выбора пользователя
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Пожалуйста, попробуйте снова."); // Обработка неверного ввода
                        break;
                }
            }
        }
    }
}