using System;
using System.Text.RegularExpressions;


namespace Задание_11
{

    class Задача835
    {
        static void Main()
        {
            Console.WriteLine(
                "\n\tДанная программа решает следующую задачу:\n"
                + "\n\tМожно обобщить способ шифровки, изложенный в предыдущей задаче—сдвиг\n"
                + "\n\tпроизводится не на одну букву, а на п букв, где п—данное натуральное число\n"
                + "\n\t(можно представлять себе, что буквы выписаны по кругу, как цифры на циферблате).\n"
                + "\n\tВыполнить задания а), б) предыдущей задачи, используя это обобщение.");
            Console.WriteLine("\n\tПожалуйста, введите текст на русском языке");
            char[] input = Console.ReadLine().ToCharArray();
            Console.WriteLine("\n\tВвод количества сдвигов для букв");
            int shift = InputInt(0, int.MaxValue);
            Regex rusReg = new Regex(@"[а-яА-я]{1}");
            if (shift >= 32)
            {
                shift = shift % 32;
            }

            Console.WriteLine("\n\tШифрование");
            for (int index = 0; index < input.Length; index++)
            {
                if (rusReg.IsMatch(input[index].ToString()))
                {
                    int code = input[index] + shift;
                    if (input[index] <= 1071 && code > 1071 || input[index] <= 1103 && code > 1103) // Проверка на выход за пределы
                    {
                        code -= 32;
                    }

                    input[index] = (char)code;
                }
            }

            Console.WriteLine("\n\tСтрока имеет вид:\n");
            Console.Write("\t");
            foreach (char symbol in input)
            {
                Console.Write(symbol);
            }

            Console.WriteLine();
            Console.WriteLine("\n\tДешифровка");
            for (int index = 0; index < input.Length; index++)
            {
                if (rusReg.IsMatch(input[index].ToString()))
                {
                    int code = input[index] - shift;
                    if (input[index] <= 1071 && code < 1040 || input[index] <= 1103 && code < 1072)
                    {
                        code += 32;
                    }

                    input[index] = (char)code;
                }
            }

            Console.WriteLine("\n\tСтрока имеет вид:\n");
            Console.Write("\t");
            foreach (char symbol in input)
            {
                Console.Write(symbol);
            }

            Console.WriteLine();
            Console.WriteLine("\n\tДля завершения работы нажмите на любую клавишу . . .");
            Console.ReadKey();
        }

        public static int InputInt(int min, int max)
        {
            int num;

            while (!int.TryParse(Console.ReadLine(), out num) || num < min || num > max)
            {
                if (num < min || num > max)
                {
                    Console.WriteLine($"Введите целое число от {min} до {max}");
                    continue;
                }
                Console.WriteLine("Введите целое число");
            }

            return num;
        }
    }
}
