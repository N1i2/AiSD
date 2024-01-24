using System;
using System.Collections.Generic;
using System.Diagnostics;
//var 1 = 10 , 2 = 15, 3 = 15
namespace laba8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool end = false;
            int kace = 0;

            List<Belonging> list = new List<Belonging>();

            for (int i = 0; !end;)
            {
                Console.Clear();
                int size;
                int price;

                try
                {
                    if (i == 0)
                    {
                        Console.Write("Введите размер рюкзака(от 1 до 99):\t");
                        if (!int.TryParse(Console.ReadLine(), out size))
                            throw new Exception("Это не число");

                        if (size < 0 || size > 500)
                            size = 50;

                        kace = size;

                        i++;
                    }
                    else
                    {
                        Console.WriteLine("Заполнение тавара №{0}\n[Что бы прекратить заполнение ввелите в поле размер чифру '0']", Belonging.Count + 1);

                        Console.Write("Введите размер товара:\t");
                        if (!int.TryParse(Console.ReadLine(), out size))
                            throw new Exception("Это не число");
                        if (size > kace)
                            throw new Exception("Нет так нельзя");

                        if (size == 0)
                        {
                            end = true;
                            break;
                        }

                        Console.Write("Введите стоимость товара:\t");
                        if (!int.TryParse(Console.ReadLine(), out price))
                            throw new Exception("Это не число");

                        list.Add(new Belonging(size, price));
                    }

                    Console.WriteLine("Все хорошо");
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
            }

            try
            {
                if (list.Count == 0)
                {
                    Console.WriteLine("Введите вариант из файла(1 - 3)");
                    if(!int.TryParse(Console.ReadLine(), out int var)||var<1||var>3)
                        Debug.Assert(false);

                    list = Help.Deser(var);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            foreach (var item in list)
            {
                Console.WriteLine("\nname: {0}", item.Name);
                Console.WriteLine("size: {0}", item.Size);
                Console.WriteLine("price: {0}", item.Price);
                Console.WriteLine();
            }

            int result = 0;

            try
            {
                result = Belonging.RekursSchet(list.ToArray(), kace, list.Count - 1);
                Belonging.ShowPath(list.ToArray(), kace);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(result);
        }
    }
}