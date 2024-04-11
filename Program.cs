using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Password_Ahalizator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Введите пароль, больше 5 символов:");
                string password = "";
                Console.WriteLine("Введите пароль");
                password = Console.ReadLine();
                
                //Ввод параметров
                Console.WriteLine("Введите скорость перебора паролей в секунду: ");
                int s = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите количество неправильных попыток, при котырых идет пауза:");
                int m = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите продолжительность паузы в сек.:");
                int v = Convert.ToInt32(Console.ReadLine());

                // Анализ и подсчет надежности пароля
                int N = Alphabet.AlphabetLength(password);
                double M = CombinationCount(password.Length, N);

                double total_time = M / s;
                int try_count = (int)M / m;
                if ( M%m == 0)
                {
                    try_count -= 1;

                }
                double time_delay = try_count * v;
                total_time += time_delay;


                int totalSeconds = (int)total_time;

                int years = totalSeconds / (365 * 24 * 60 * 60);
                totalSeconds %= 365 * 24 * 60 * 60;

                int months = totalSeconds / (30 * 24 * 60 * 60);
                totalSeconds %= 30 * 24 * 60 * 60;

                int days = totalSeconds / (24 * 60 * 60);
                totalSeconds %= 24 * 60 * 60;

                int hours = totalSeconds / (60 * 60);
                totalSeconds %= 60 * 60;

                int minutes = totalSeconds / 60;
                totalSeconds %= 60;

                int seconds = totalSeconds;


            // Вывод результата
            Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("Результаты анализа надежности пароля:");
                Console.WriteLine("---------------------------------------------------");
                
                Console.WriteLine($"Мощность алфавита для подбора пароля:  {N}");
                Console.WriteLine($"Мощность пространства паролей: {M}");
                Console.WriteLine($"Время перебора всех возможных комбинаций: {years} лет {months} месяцев {days} дней {hours} часов {minutes} минут {seconds} секунд");
                Console.Read();
        }
        public static double CombinationCount(int L, int N)
        {
            return Math.Pow(N, L);
        }
    }
}
