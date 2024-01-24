namespace laba10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dot = "ABCDEFGHI";
            int size = -1;
            int startPheramon = -1;
            int alf = -1;
            int murCount = -1;
            int beta = -1;
            var pathes = new List<Path>();

            while (true)
            {
                try
                {
                    if (size == -1)
                    {
                        Console.Write("Введите количество городов: ");
                        if (!(int.TryParse(Convert.ToString(Console.ReadKey().KeyChar), out size) && size > 2))
                        {
                            size = -1;
                            throw new Exception("\nТакого количества городов не может быть");
                        }
                        Console.WriteLine();
                    }
                    if (startPheramon == -1)
                    {
                        Console.Write("Введите количство феромонов на путях: ");
                        if (!(int.TryParse(Console.ReadLine(), out startPheramon) && startPheramon >= 0 && startPheramon < 1000))
                        {
                            startPheramon = -1;
                            throw new Exception("Неверное количество ферамонов");
                        }
                    }
                    Console.Write("Введите значение альфа(по стандарту 1): ");
                    if (!(int.TryParse(Convert.ToString(Console.ReadKey().KeyChar), out alf) && alf < 4))
                        alf = 1;
                    Console.WriteLine();
                    Console.Write("Введите значение бета(по стандарту 1): ");
                    if (!(int.TryParse(Convert.ToString(Console.ReadKey().KeyChar), out beta) && beta < 4))
                        beta = 1;
                    Console.WriteLine();
                    Console.Write("Введите количество проходов(по стондарту равно количеству точек): ");
                    if (!(int.TryParse(Convert.ToString(Console.ReadKey().KeyChar), out murCount) && murCount > 2))
                        murCount = size;

                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine();

            string need = "";

            for (int i = 0; i < size; i++)
            {
                need += dot[i];
                for (int j = (i + 1); j < size; j++)
                    pathes.Add(new Path(dot[i], dot[j], startPheramon));
            }
            Path.ShowAllDot(pathes);
            Console.WriteLine();
            string[] help = new string[murCount];
            int[] helpL = new int[murCount];


            for (int i = 0; i < murCount; i++)
            {
                (help[i], helpL[i]) = AntAlgorithm.StrtAlgoritm(pathes, need, alf, beta);
                AntAlgorithm.RecreatPheramon(pathes, help[i], helpL[i]);
            }

            size = helpL.ToList().IndexOf(helpL.Min());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\nСамый лучший найленый путь");
            Console.WriteLine(help[size] + " == " + helpL[size]);
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}