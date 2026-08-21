using System;
using System.Collections.Generic;
using Backend;

namespace Frontend
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var times = new List<Time>
                {
                    new Time(),
                    new Time(14),
                    new Time(9, 34),
                    new Time(19, 45, 56),
                    new Time(23, 3, 45, 678)
                };

                Time timeToAdd = new Time(9, 34);

                foreach (var t in times)
                {
                    Console.WriteLine($"Time: {t}");
                    Console.WriteLine($"\tMilliseconds: {t.ToMilliseconds():N0}");
                    Console.WriteLine($"\tSeconds     : {t.ToSeconds():N0}");
                    Console.WriteLine($"\tMinutes     : {t.ToMinutes():N0}");
                    Console.WriteLine($"\tAdd         : {t.Add(timeToAdd)}");
                    Console.WriteLine($"\tIs Other day: {(t.ToMilliseconds() + timeToAdd.ToMilliseconds() >= 86400000 ? "True" : "False")}");
                    Console.WriteLine();
                }

                // Prueba de error forzada (como la hora 45)
                var errorTime = new Time(45, 0, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

            Console.ReadKey();
        }
    }
}