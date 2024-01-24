using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba8
{
    [Serializable]
    class Belonging
    {
        static Belonging()
        {
            Count = 0;
        }
        public Belonging(int size, int price)
        {
            Name = "Вещь №" + (Count + 1);
            GetPrice(price);
            Size = size;
            Number = ++Count;
        }

        public string Name { get; private set; }

        public int Price { get; private set; }
        public int Number { get; private set; }
        private int size;

        static public int Count { get; private set; }

        public int Size
        {
            get => size;
            set
            {
                if (value < 1)
                    value = 5;

                size = value;
            }
        }
        private void GetPrice(int price)
        {
            if (price < 1)
                price = 5;

            Price = price;
        }

        static public int RekursSchet(Belonging[] elem, int freeSize, int item)
        {
            if (item < 0 || freeSize == 0)
                return 0;

            if (elem[item].size > freeSize)
                return RekursSchet(elem, freeSize, item - 1);

            return Math.Max(elem[item].Price + RekursSchet(elem, freeSize - elem[item].size, item - 1),
                 RekursSchet(elem, freeSize, item - 1));
        }
        static public void ShowPath(Belonging[] elem, int freeSize)
        {
            int[,] tabl = new int[elem.Length + 1, freeSize + 1];
            bool[] need = new bool[elem.Length];

            for (int i = 1; i <= elem.Length; i++)
                for (int j = 0; j <= freeSize; j++)
                {
                    if (elem[i - 1].size > j)
                    {
                        if (tabl[i - 1, j] != 0)
                            tabl[i, j] = tabl[i - 1, j];

                        continue;
                    }

                    int first = tabl[i - 1, j];
                    int second = elem[i - 1].Price + tabl[i - 1, j - elem[i - 1].size];

                    tabl[i, j] = (first > second) ?
                        first :
                        second;
                }

            for (int i = 0; i <= elem.Length; i++)
            {
                for (int j = 0; j <= freeSize; j++)
                    Console.Write($"{tabl[i, j]}\t");

                Console.WriteLine('\n');
            }

            for (int i = elem.Length; i > 0; i--)
            {
                if (tabl[i, freeSize] <= 1)
                    break;

                if (tabl[i, freeSize] - elem[i - 1].Price == tabl[i - 1, freeSize - elem[i - 1].Size])
                {
                    freeSize -= elem[i - 1].Size;
                    need[i - 1] = true;
                }
            }

            for (int i = 0; i < need.Length; i++)
                if (need[i])
                    Console.WriteLine("Берем предмет №" + (i + 1));
        }
    }
}

//var 1 = 1, 3
//var 2 = 1, 4, 5
//var 3 = 2, 3, 4, 5