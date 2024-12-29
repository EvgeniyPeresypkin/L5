using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5
{
    using System;
    using System.Diagnostics;

    namespace MyGame
    {
        /// <summary>
        /// Класс для работы с массивами.
        /// </summary>
        public class ArrayHandler
        {
            private int size;
            private int[] array;
            private int[] copy;

            /// <summary>
            /// Конструктор по умолчанию, задающий размер массива равным 10.
            /// </summary>
            public ArrayHandler()
            {
                size = 10;
                array = new int[size];
                
            }

            /// <summary>
            /// Конструктор с параметрами.
            /// </summary>
            /// <param name="size">Размер массива.</param>
            public ArrayHandler(int size)
            {
                this.size = size;
                array = new int[size];
                
            }
            public int[] CopyArray1
            {
                get { return copy; }
                set { copy = value; }
            }

            /// <summary>
            /// Инициализирует массив случайными значениями.
            /// </summary>
            public void InitializeArray()
            {
                Random rnd = new Random();
                for (int i = 0; i < size; i++)
                {
                    array[i] = rnd.Next(10);
                }
            }

            /// <summary>
            /// Получает массив.
            /// </summary>
            /// <returns>Массив целых чисел.</returns>
            public int[] GetArray()
            {
                return array;
            }

            /// <summary>
            /// Сортирует массив методом выбора.
            /// </summary>
             public void SelectionSort()
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    int minIndex = i;
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[j] < array[minIndex])
                        {
                            minIndex = j;
                        }
                    }
                    int temp = array[minIndex];
                    array[minIndex] = array[i];
                    array[i] = temp;
                }
            }
            public static void PrintArray(int[] array)
            {
                if (array.Length <= 10)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        Console.Write(array[i] + " ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Массивы не могут быть выведены на экран, так как длина массива больше 10");
                }
            }
            public static int MassivSize()
            {
                int x;
                bool i = true;
                while (i)
                {
                    Console.WriteLine("Введите длину массива");
                    x = Helper.IntParse();
                    if (x > 0)
                    {
                        return x;
                    }
                    else
                    {
                        Console.WriteLine("Размер массива должен быть больше нуля");
                    }
                }
                return 0;
            }
            public static int[] MassivInicialization(int a)
            {
                int[] array = new int[a];
                Random rnd = new Random();
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = rnd.Next(10);
                }
                return array;
            }
            public static int[] CopyArray(int[] arr)
            {
                int[] copy = new int[arr.Length]; // Создаем новый массив для копирования
                for (int i = 0; i < arr.Length; i++)
                {
                    copy[i] = arr[i]; // Копируем элементы из arr в copy
                }
                return copy; // Возвращаем скопированный массив
            }
            public static int[] SelectionSort(int[] array1)
            {
                for (int i = 0; i < array1.Length - 1; i++)
                {
                    int minIndex = i;
                    for (int j = i + 1; j < array1.Length; j++)
                    {
                        if (array1[j] < array1[minIndex])
                        {
                            minIndex = j;
                        }
                    }
                    // Меняем местами
                    int temp = array1[minIndex];
                    array1[minIndex] = array1[i];
                    array1[i] = temp;
                }
                return array1; // Возвращаем отсортированный массив
            }
            public static int[] ShellSort(int[] array2)
            {
                int j;
                int step = array2.Length / 2;
                while (step > 0)
                {
                    for (int i = 0; i < (array2.Length - step); i++)
                    {
                        j = i;
                        while ((j >= 0) && (array2[j] > array2[j + step]))
                        {
                            int tmp = array2[j];
                            array2[j] = array2[j + step];
                            array2[j + step] = tmp;
                            j -= step;
                        }
                    }
                    step = step / 2;
                }
                return array2; // Возвращаем отсортированный массив
            }
            public static double SelectionTime(int[] array1)
            {
                Stopwatch a = new Stopwatch();
                a.Start();
                SelectionSort(array1);
                a.Stop();
                return a.Elapsed.TotalMilliseconds;
            }
            public static double ShellTime(int[] array2)
            {
                Stopwatch a = new Stopwatch();
                a.Start();
                ShellSort(array2);
                a.Stop();
                return a.Elapsed.TotalMilliseconds;
            }
            public static void Sorter(double TimeSelection, double TimeShell, int q, int[] RandArray, int[] NewMassiv)
            {
                if (q <= 10)
                {
                    Console.Write("Массив после сортировки выбором: ");
                    PrintArray(RandArray);
                    Console.WriteLine("Время выполнения сортировки выбором: " + TimeSelection);
                    Console.Write("Массив после сортировки Шелла: ");
                    PrintArray(NewMassiv);
                    Console.WriteLine("Время выполнения сортировки методом Шелла: " + TimeShell);
                    if (TimeSelection > TimeShell)
                    {
                        Console.WriteLine("Сортировка Шелла оказалась быстрее");
                    }
                    else if (TimeSelection < TimeShell)
                    {
                        Console.WriteLine("Сортировка выбором оказалась быстрее");
                    }
                    else
                    {
                        Console.WriteLine("Время выполнения сортировок одинаковое");
                    }
                }
                else
                {
                    Console.WriteLine("Вывести массив не получится, размер массива больше 10");
                    PrintArray(RandArray);
                    Console.WriteLine("Время выполнения сортировки выбором: " + TimeSelection);
                    PrintArray(NewMassiv);
                    Console.WriteLine("Время выполнения сортировки методом Шелла: " + TimeShell);
                }
            }
        }

  

        

    }
}
