using System.Threading;

namespace EasySort.Classes
{
    internal delegate void SortAlgorithm(SortingArray array);

    internal static class SortAlgorithms
    {
        public delegate void OnUpdate(SortingArray array);
        public static event OnUpdate Updated;

        public static void BubbleSort(SortingArray array)
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array.IsBigger(j, j + 1))
                        array.Swap(j, j + 1);
                    Updated(array);
                }
            }
        }

        public static void InsertionSort(SortingArray array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (array.IsBigger(j - 1, j))
                    {
                        array.Swap(j - 1, j);
                    }
                    else
                    {
                        Updated(array);
                        break;
                    }
                    Updated(array);
                }
            }
        }

        public static void OptimizedBubbleSort(SortingArray array)
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                bool sorted = true;
                for (int j = 0; j < i; j++)
                {
                    if (array.IsBigger(j, j + 1))
                    {
                        array.Swap(j, j + 1);
                        sorted = false;
                    }
                    Updated(array);
                }
                if (sorted)
                    break;
            }
        }

        public static void CocktailSort(SortingArray array)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left < right)
            {
                for (int i = left; i < right; i++)
                {
                    if (array.IsBigger(i, i + 1))
                        array.Swap(i, i + 1);
                    Updated(array);
                }

                for (int i = right; i > left; i--)
                {
                    if (array.IsSmaller(i, i - 1))
                        array.Swap(i, i - 1);
                    Updated(array);
                }

                left++;
                right--;
            }
        }

        public static void OptimizedCocktailSort(SortingArray array)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left < right)
            {
                int nextLeft = right;
                int nextRight = left;

                bool sorted = true;

                for (int i = left; i < right; i++)
                {
                    if (array.IsBigger(i, i + 1))
                    {
                        array.Swap(i, i + 1);
                        sorted = false;
                        nextRight = i;
                    }
                    Updated(array);
                }

                if (sorted)
                    break;

                right = nextRight;

                for (int i = right; i > left; i--)
                {
                    if (array.IsSmaller(i, i - 1))
                    {
                        array.Swap(i, i - 1);
                        sorted = false;
                        nextLeft = i;
                    }
                    Updated(array);
                }

                if (sorted)
                    break;

                left = nextLeft;
            }
        }

        public static void CombSort(SortingArray array)
        {
            int distance = (int)(array.Length / 1.3);

            while (distance > 1)
            {
                for (int i = 0; i < array.Length - distance; i++)
                {
                    if (array.IsBigger(i, i + distance))
                        array.Swap(i, i + distance);
                    Updated(array);
                }
                distance = (int)(distance / 1.3);
            }

            OptimizedBubbleSort(array);
        }

        public static void ShellSort(SortingArray array)
        {
            int distance = array.Length / 2;

            while (distance > 1)
            {
                for (int i = distance; i < array.Length; i++)
                {
                    int j = i;
                    while (j >= 0)
                    {
                        Updated(array);
                        j -= distance;
                        if (array.IsBigger(j, j + distance))
                            array.Swap(j, j + distance);
                        else
                            break;
                    }
                }

                distance = (distance + 1) / 2;
            }

            InsertionSort(array);
        }

        static void QuickSortRecursion(SortingArray array, int left, int right)
        {
            if (left < right)
            {
                int pivot = right;

                int l = left;
                int r = right;

                while (l < r)
                {
                    if (array.IsBigger(l, pivot))
                    {
                        while (l < r && array.IsBiggerOrEqual(r, pivot))
                        {
                            r--;
                            Updated(array);
                        }
                        array.Swap(l, r);
                    }
                    l++;
                    Updated(array);
                }
                if (l > left)
                    QuickSortRecursion(array, left, l - 1);
                if (r < right)
                {
                    array.Swap(r, pivot);
                    QuickSortRecursion(array, r, right);
                }
            }
        }
        public static void QuickSort(SortingArray array)
        {
            QuickSortRecursion(array, 0, array.Length - 1);
        }

        static void MergeSortRecursion(SortingArray array, int[] temp, int left, int right)
        {
            if (left < right)
            {
                int len = right - left + 1;
                int mid = left + len / 2;
                MergeSortRecursion(array, temp, left, mid - 1);
                MergeSortRecursion(array, temp, mid, right);

                int p1 = left;
                int p2 = mid;

                for (int i = 0; i < len; i++)
                {
                    bool first = true;

                    if ((p1 >= mid) | (p2 <= right && array.IsBigger(p1, p2)))
                    {
                        first = false;
                    }

                    if (first)
                    {
                        temp[i] = array.Get(p1);
                        p1++;
                    }
                    else
                    {
                        temp[i] = array.Get(p2);
                        p2++;
                    }
                    Updated(array);
                }

                for (int i = 0; i < len; i++)
                {
                    array.Modify(left + i, temp[i]);
                    Updated(array);
                }
            }
        }
        public static void MergeSort(SortingArray array)
        {
            int[] temp = new int[array.Length];
            MergeSortRecursion(array, temp, 0, array.Length - 1);
        }

        static void MaxHeapify(SortingArray array, int n, int i)
        {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;
            
            if (l < n)
            {
                if (array.IsBigger(l, largest))
                    largest = l;

                Updated(array);
            }
            
            if (r < n)
            {
                if (array.IsBigger(r, largest))
                    largest = r;

                Updated(array);
            }

            if (largest != i)
            {
                array.Swap(i, largest);
                Updated(array);
                MaxHeapify(array, n, largest);
            }
        }
        public static void MaxHeapSort(SortingArray array)
        {
            for (int i = array.Length / 2 - 1; i >= 0; i--)
            {
                MaxHeapify(array, array.Length, i);
            }
            for (int i = array.Length - 1; i >= 0; i--)
            {
                array.Swap(0, i);
                Updated(array);
                MaxHeapify(array, i, 0);
            }
        }

        public static void SelectionSort(SortingArray array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                int biggest = 0;
                for (int j = 0; j <= i; j++)
                {
                    if (array.IsBiggerOrEqual(j, biggest))
                        biggest = j;
                    Updated(array);
                }
                array.Swap(biggest, i);
                Updated(array);
            }
        }

        public static void OddEvenSort(SortingArray array)
        {
            var sorted = false;
            while (!sorted)
            {
                sorted = true;
                for (var i = 1; i < array.Length - 1; i += 2)
                {
                    if (array.IsBigger(i, i + 1))
                    {
                        array.Swap(i, i + 1);
                        sorted = false;
                    }
                    Updated(array);
                }

                for (var i = 0; i < array.Length - 1; i += 2)
                {
                    if (array.IsBigger(i, i + 1))
                    {
                        array.Swap(i, i + 1);
                        sorted = false;
                    }
                    Updated(array);
                }
            }
        }

        static void BitonicSortRecursion(SortingArray array, int index, int length, bool direction)
        {
            if (length > 1)
            {
                int median = (length / 2);

                BitonicSortRecursion(array, index, median, true);
                BitonicSortRecursion(array, index + median, median, false);
                BitonicMerge(array, index, length, direction);
            }
        }
        static void BitonicMerge(SortingArray array, int index, int length, bool direction)
        {
            if (length > 1)
            {
                int median = (length / 2);

                for (int i = index; i < index + median; i++)
                {
                    BitonicCompare(array, i, i + median, direction);
                }
                BitonicMerge(array, index, median, direction);
                BitonicMerge(array, index + median, median, direction);
            }
        }
        static void BitonicCompare(SortingArray array, int source, int destination, bool direction)
        {
            if (direction == array.IsBigger(source, destination)) 
                array.Swap(source, destination);
            Updated(array);
        }
        public static void BitonicSort(SortingArray array)
        {
            BitonicSortRecursion(array, 0, array.Length, true);
            InsertionSort(array);
        }
    }

    struct SortInfo
    {
        public readonly string name;
        public readonly string description;
        public readonly string minTime, maxTime;
        public readonly string sortInfoURL;

        public SortInfo(string name, string description, string minTime, string maxTime, string sortInfoURL)
        {
            this.name = name;
            this.description = description;
            this.minTime = minTime;
            this.maxTime = maxTime;
            this.sortInfoURL = sortInfoURL;
        }
    }
    
    static class SortCollection
    {
        public static readonly SortingAlgorithm[] All = new SortingAlgorithm[]
        { BubbleSort, InsertionSort, OptimizedBubbleSort, CocktailSort, OptimizedCocktailSort, CombSort,
          ShellSort, QuickSort, MergeSort, MaxHeapSort, SelectionSort, OddEvenSort, BitonicSort };

        public static SortingAlgorithm Default
        {
            get
            {
                return BubbleSort;
            }
        }

        public static SortingAlgorithm BubbleSort
        {
            get
            {
                string name = "Bubble sort";
                string description = "Bubble sort, sometimes referred to as sinking sort, is a simple sorting algorithm " +
                "that repeatedly steps through the list to be sorted, compares each pair of adjacent items and swaps them " +
                "if they are in the wrong order.The pass through the list is repeated until no swaps are needed, which indicates that the list is sorted.";
                string minTime = "n^2";
                string maxTime = "n^2";
                string sortInfoUrl = "https://en.wikipedia.org/wiki/Bubble_sort";
                SortInfo info = new SortInfo(name, description, minTime, maxTime, sortInfoUrl);
                return new SortingAlgorithm(info, SortAlgorithms.BubbleSort);
            }
        }

        public static SortingAlgorithm InsertionSort
        {
            get
            {
                string name = "Insertion sort";
                string description = "Insertion sort iterates, consuming one input element each repetition, " +
                "and growing a sorted output list. At each iteration, insertion sort removes one element from the input data, " +
                "finds the location it belongs within the sorted list, and inserts it there. It repeats until no input elements remain.";
                string minTime = "n";
                string maxTime = "n^2";
                string sortInfoUrl = "https://en.wikipedia.org/wiki/Insertion_sort";
                SortInfo info = new SortInfo(name, description, minTime, maxTime, sortInfoUrl);
                return new SortingAlgorithm(info, SortAlgorithms.InsertionSort);
            }
        }

        public static SortingAlgorithm OptimizedBubbleSort
        {
            get
            {
                string name = "Optimized bubble sort";
                string description = "It has same algorithm as bubble sort, but if in current iteration were no swaps, " +
                    "it ends its work (because that means array is already sorted)";
                string minTime = "n";
                string maxTime = "n^2";
                string sortInfoUrl = "https://en.wikipedia.org/wiki/Bubble_sort";
                SortInfo info = new SortInfo(name, description, minTime, maxTime, sortInfoUrl);
                return new SortingAlgorithm(info, SortAlgorithms.OptimizedBubbleSort);
            }
        }

        public static SortingAlgorithm CocktailSort
        {
            get
            {
                string name = "Cocktail sort";
                string description = "Cocktail shaker sort is a slight variation of bubble sort. " +
                "It differs in that instead of repeatedly passing through the list from bottom to top, " +
                "it passes alternately from bottom to top and then from top to bottom. It can achieve " +
                "slightly better performance than a standard bubble sort. The reason for this is that bubble " +
                "sort only passes through the list in one direction and therefore can only move items backward one step each iteration.";
                string minTime = "n^2";
                string maxTime = "n^2";
                string sortInfoUrl = "https://en.wikipedia.org/wiki/Cocktail_sort";
                SortInfo info = new SortInfo(name, description, minTime, maxTime, sortInfoUrl);
                return new SortingAlgorithm(info, SortAlgorithms.OptimizedCocktailSort);
            }
        }

        public static SortingAlgorithm OptimizedCocktailSort
        {
            get
            {
                string name = "Optimized cocktail sort";
                string description = "Same as a cocktail sort, but with some improvements like " +
                    "bounding sides and 'sorted' flag.";
                string minTime = "n";
                string maxTime = "n^2";
                string sortInfoUrl = "https://en.wikipedia.org/wiki/Cocktail_sort";
                SortInfo info = new SortInfo(name, description, minTime, maxTime, sortInfoUrl);
                return new SortingAlgorithm(info, SortAlgorithms.OptimizedCocktailSort);
            }
        }

        public static SortingAlgorithm CombSort
        {
            get
            {
                string name = "Comb sort";
                string description = "The basic idea is to eliminate turtles, or small values near the end " +
                "of the list, since in a bubble sort these slow the sorting down tremendously. Rabbits, large values " +
                "around the beginning of the list, do not pose a problem in bubble sort. In bubble sort, when " +
                "any two elements are compared, they always have a gap(distance from each other) of 1.The basic idea " +
                "of comb sort is that the gap can be much more than 1.";
                string minTime = "n log n";
                string maxTime = "n^2";
                string sortInfoUrl = "https://en.wikipedia.org/wiki/Comb_sort";
                SortInfo info = new SortInfo(name, description, minTime, maxTime, sortInfoUrl);
                return new SortingAlgorithm(info, SortAlgorithms.CombSort);
            }
        }

        public static SortingAlgorithm ShellSort
        {
            get
            {
                string name = "Shell sort";
                string description = "The method starts by sorting pairs of elements far apart from each other, " +
                "then progressively reducing the gap between elements to be compared. Starting with far apart " +
                "elements, it can move some out-of-place elements into position faster than a simple nearest " +
                "neighbor exchange.";
                string minTime = "n log n";
                string maxTime = "n^(2/3)";
                string sortInfoUrl = "https://en.wikipedia.org/wiki/Shellsort";
                SortInfo info = new SortInfo(name, description, minTime, maxTime, sortInfoUrl);
                return new SortingAlgorithm(info, SortAlgorithms.ShellSort);
            }
        }

        public static SortingAlgorithm QuickSort
        {
            get
            {
                string name = "Quick sort";
                string description = "Quicksort is a comparison sort, meaning that it can sort items of any type " +
                    "for which a 'less - than' relation (formally, a total order) is defined. In efficient implementations " +
                    "it is not a stable sort, meaning that the relative order of equal sort items is not preserved. " +
                    "Quicksort can operate in-place on an array, requiring small additional amounts of memory to perform " +
                    "the sorting. It is very similar to selection sort, except that it does not always choose worst-case partition.";
                string minTime = "n log n";
                string maxTime = "n^2";
                string sortInfoUrl = "https://en.wikipedia.org/wiki/Quicksort";
                SortInfo info = new SortInfo(name, description, minTime, maxTime, sortInfoUrl);
                return new SortingAlgorithm(info, SortAlgorithms.QuickSort);
            }
        }

        public static SortingAlgorithm MergeSort
        {
            get
            {
                string name = "Merge sort";
                string description = "Mergesort is a divide and conquer algorithm that was invented by John von Neumann in 1945. " +
                    "It is an efficient, general-purpose, comparison-based sorting algorithm. Most implementations produce a stable sort.";
                string minTime = "n log n";
                string maxTime = "n log n";
                string sortInfoUrl = "https://en.wikipedia.org/wiki/Merge_sort";
                SortInfo info = new SortInfo(name, description, minTime, maxTime, sortInfoUrl);
                return new SortingAlgorithm(info, SortAlgorithms.MergeSort);
            }
        }

        public static SortingAlgorithm MaxHeapSort
        {
            get
            {
                string name = "Max heap sort";
                string description = "The heapsort algorithm involves preparing the list by first turning it into a max heap. The " +
                    "algorithm then repeatedly swaps the first value of the list with the last value, decreasing the range of values " +
                    "considered in the heap operation by one, and shifting the new first value into its position in the heap. This repeats " +
                    "until the range of considered values is one value in length.";
                string minTime = "n log n";
                string maxTime = "n log n";
                string sortInfoUrl = "https://en.wikipedia.org/wiki/Heapsort";
                SortInfo info = new SortInfo(name, description, minTime, maxTime, sortInfoUrl);
                return new SortingAlgorithm(info, SortAlgorithms.MaxHeapSort);
            }
        }

        public static SortingAlgorithm SelectionSort
        {
            get
            {
                string name = "Selection sort";
                string description = "The algorithm proceeds by finding the largest element in the unsorted sublist, " +
                    "exchanging(swapping) it with the leftmost unsorted element(putting it in sorted order), and moving the sublist " +
                    "boundaries one element to the right. It is the simplest algorithm.";
                string minTime = "n^2";
                string maxTime = "n^2";
                string sortInfoUrl = "https://en.wikipedia.org/wiki/Selection_sort";
                SortInfo info = new SortInfo(name, description, minTime, maxTime, sortInfoUrl);
                return new SortingAlgorithm(info, SortAlgorithms.SelectionSort);
            }
        }

        public static SortingAlgorithm OddEvenSort
        {
            get
            {
                string name = "Odd-Even sort";
                string description = "An odd–even sort or odd–even transposition sort is a relatively simple sorting algorithm, " +
                    "developed originally for use on parallel processors with local interconnections. It is a comparison sort " +
                    "related to bubble sort, with which it shares many characteristics. It functions by comparing all odd/even " +
                    "indexed pairs of adjacent elements in the list and, if a pair is in the wrong order (the first is larger than " +
                    "the second) the elements are switched. The next step repeats this for even/odd indexed pairs (of adjacent elements)." +
                    " Then it alternates between odd/even and even/odd steps until the list is sorted.";
                string minTime = "n";
                string maxTime = "n^2";
                string sortInfoUrl = "https://en.wikipedia.org/wiki/Odd-even_sort";
                SortInfo info = new SortInfo(name, description, minTime, maxTime, sortInfoUrl);
                return new SortingAlgorithm(info, SortAlgorithms.OddEvenSort);
            }
        }

        public static SortingAlgorithm BitonicSort
        {
            get
            {
                string name = "Bitonic sort";
                string description = "Bitonic mergesort is a parallel algorithm for sorting. It is also used as a construction method " +
                    "for building a sorting network. The algorithm was devised by Ken Batcher. This implementation is single-threaded, " +
                    "but bitonic sort is created for parallel sorting. It works perfectly ONLY on arrays with length of powers of 2. " +
                    "Because of that, there is an insertion sort finishing work of bitonic sort.";
                string minTime = "n(log n)^2";
                string maxTime = "n(log n)^2";
                string sortInfoUrl = "https://en.wikipedia.org/wiki/Bitonic_sorter";
                SortInfo info = new SortInfo(name, description, minTime, maxTime, sortInfoUrl);
                return new SortingAlgorithm(info, SortAlgorithms.BitonicSort);
            }
        }
    }
}
