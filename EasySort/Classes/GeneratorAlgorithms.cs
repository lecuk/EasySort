using System;
using System.Threading;
using Troschuetz.Random.Generators;

namespace EasySort.Classes
{
    internal delegate void GeneratorAlgorithmFunction(SortingArray array);

    internal static class GeneratorAlgorithms
    {
        public delegate void OnUpdate(SortingArray array);
        public static event OnUpdate Updated;

        public static void GenerateRandomPositioned(SortingArray array)
        {
            GenerateSorted(array);
            Shuffle(array);
        }

        public static void GenerateSorted(SortingArray array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array.Modify(i, i + 1);
                Updated(array);
            }
        }

        public static void GenerateReversed(SortingArray array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array.Modify(i, array.Length - i);
                Updated(array);
            }
        }

        public static void GenerateRandom(SortingArray array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                StandardGenerator rand = new StandardGenerator();
                int val = rand.Next(1, array.Length + 1);
                array.Modify(i, val);
                Updated(array);
            }
        }

        public static void GenerateSortedAndShuffleNPercent(SortingArray array, int chance)
        {
            GenerateSorted(array);
            for (int i = 0; i < array.Length; i++)
            {
                StandardGenerator rand = new StandardGenerator();
                int randNum = rand.Next(101);
                if (randNum <= chance)
                {
                    int pos = rand.Next(array.Length);
                    array.Swap(i, pos);
                    Updated(array);
                }
            }
        }

        public static void GenerateSortedAndShuffle10Percent(SortingArray array)
        {
            GenerateSortedAndShuffleNPercent(array, 10);
        }

        public static void GenerateSortedAndShuffle33Percent(SortingArray array)
        {
            GenerateSortedAndShuffleNPercent(array, 33);
        }

        public static void Generate8Blocked(SortingArray array)
        {
            double d = array.Length / 8.0;
            double val = d;
            for (int i = 0; i < array.Length; i++)
            {
                if (i >= val)
                {
                    val += d;
                }
                array.Modify(i, (int)val);
                Updated(array);
            }
            Shuffle(array);
        }

        public static void GenerateCubic(SortingArray array)
        {
            double a = array.Length / 2;
            double n = 1 / (a * a);

            for (int x = 0; x < array.Length; x++)
            {
                double t = x - a;
                int y = Math.Min(array.Length, (int)(n * (t * t * t) + a) + 1);
                array.Modify(x, y);
                Updated(array);
            }
            Shuffle(array);
        }
        
        public static void GenerateRandomDescending(SortingArray array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                StandardGenerator rand = new StandardGenerator();
                int value = rand.Next(array.Length - i) + 1;
                array.Modify(i, value);
                Updated(array);
            }
        }

        public static void GenerateRandomAscending(SortingArray array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                StandardGenerator rand = new StandardGenerator();
                int value = rand.Next(i, array.Length) + 1;
                array.Modify(i, value);
                Updated(array);
            }
        }

        public static void Shuffle(SortingArray array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                StandardGenerator rand = new StandardGenerator();
                int pos = rand.Next(0, array.Length);
                array.Swap(i, pos);
                Updated(array);
            }
        }
    }

    struct GeneratorInfo
    {
        public readonly string name;
        public readonly string description;

        public GeneratorInfo(string name, string description)
        {
            this.name = name;
            this.description = description;
        }
    }
    
    static class GeneratorCollection
    {
        public static readonly GeneratorAlgorithm[] All = new GeneratorAlgorithm[]
        { RandomPosition, Sorted, Reversed, Random, Shuffle10, Shuffle33, Block8, Cubic, RandomDescending, RandomAscending
        };

        public static GeneratorAlgorithm Default
        {
            get
            {
                return RandomPosition;
            }
        }

        public static GeneratorAlgorithm RandomPosition
        {
            get
            {
                string name = "Random position";
                string description = "Creates a sorted array, then randomizes position of each part.";
                GeneratorInfo info = new GeneratorInfo(name, description);
                return new GeneratorAlgorithm(info, GeneratorAlgorithms.GenerateRandomPositioned);
            }
        }

        public static GeneratorAlgorithm Sorted
        {
            get
            {
                string name = "Sorted";
                string description = "Creates a already sorted array.";
                GeneratorInfo info = new GeneratorInfo(name, description);
                return new GeneratorAlgorithm(info, GeneratorAlgorithms.GenerateSorted);
            }
        }

        public static GeneratorAlgorithm Reversed
        {
            get
            {
                string name = "Reversed";
                string description = "Creates a reversed array.";
                GeneratorInfo info = new GeneratorInfo(name, description);
                return new GeneratorAlgorithm(info, GeneratorAlgorithms.GenerateReversed);
            }
        }

        public static GeneratorAlgorithm Random
        {
            get
            {
                string name = "Random";
                string description = "Creates a array with random elements (each value is less than array length).";
                GeneratorInfo info = new GeneratorInfo(name, description);
                return new GeneratorAlgorithm(info, GeneratorAlgorithms.GenerateRandom);
            }
        }

        public static GeneratorAlgorithm Shuffle10
        {
            get
            {
                string name = "10% shuffled";
                string description = "Creates a array with random elements (each value is less than array length).";
                GeneratorInfo info = new GeneratorInfo(name, description);
                return new GeneratorAlgorithm(info, GeneratorAlgorithms.GenerateSortedAndShuffle10Percent);
            }
        }

        public static GeneratorAlgorithm Shuffle33
        {
            get
            {
                string name = "1/3 shuffled";
                string description = "Creates a array with random elements (each value is less than array length).";
                GeneratorInfo info = new GeneratorInfo(name, description);
                return new GeneratorAlgorithm(info, GeneratorAlgorithms.GenerateSortedAndShuffle33Percent);
            }
        }

        public static GeneratorAlgorithm Block8
        {
            get
            {
                string name = "8-blocked";
                string description = "Creates a array with random elements (each value is less than array length).";
                GeneratorInfo info = new GeneratorInfo(name, description);
                return new GeneratorAlgorithm(info, GeneratorAlgorithms.Generate8Blocked);
            }
        }
        
        public static GeneratorAlgorithm Cubic
        {
            get
            {
                string name = "Cubic";
                string description = "Creates a array with random elements (each value is less than array length).";
                GeneratorInfo info = new GeneratorInfo(name, description);
                return new GeneratorAlgorithm(info, GeneratorAlgorithms.GenerateCubic);
            }
        }

        public static GeneratorAlgorithm RandomDescending
        {
            get
            {
                string name = "Random descending";
                string description = "Creates a array with random elements (each value is less than array length).";
                GeneratorInfo info = new GeneratorInfo(name, description);
                return new GeneratorAlgorithm(info, GeneratorAlgorithms.GenerateRandomDescending);
            }
        }

        public static GeneratorAlgorithm RandomAscending
        {
            get
            {
                string name = "Random ascending";
                string description = "Creates a array with random elements (each value is less than array length).";
                GeneratorInfo info = new GeneratorInfo(name, description);
                return new GeneratorAlgorithm(info, GeneratorAlgorithms.GenerateRandomAscending);
            }
        }
    }
}
