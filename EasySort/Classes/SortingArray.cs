using System;

namespace EasySort.Classes
{
    class SortingArray
    {
        private int[] values;

        public delegate void OnCompare(int pos1, int pos2);
        public event OnCompare Compared;

        public delegate void OnSwap(int pos1, int pos2);
        public event OnSwap Swapped;

        public delegate void OnModify(int pos);
        public event OnModify Modified;

        public delegate void OnRecreate();
        public event OnRecreate Recreated;

        public bool IsEqual(int pos1, int pos2)
        {
            Compared?.Invoke(pos1, pos2);
            return (Get(pos1) == Get(pos2));
        }

        public bool IsBiggerOrEqual(int pos1, int pos2)
        {
            Compared?.Invoke(pos1, pos2);
            return (Get(pos1) >= Get(pos2));
        }

        public bool IsSmallerOrEqual(int pos1, int pos2)
        {
            Compared?.Invoke(pos1, pos2);
            return (Get(pos1) <= Get(pos2));
        }

        public bool IsBigger(int pos1, int pos2)
        {
            Compared?.Invoke(pos1, pos2);
            return (Get(pos1) > Get(pos2));
        }

        public bool IsSmaller(int pos1, int pos2)
        {
            Compared?.Invoke(pos1, pos2);
            return (Get(pos1) < Get(pos2));
        }

        public void Swap(int pos1, int pos2)
        {
            Swapped?.Invoke(pos1, pos2);
            int temp = Get(pos1);
            Set(pos1, Get(pos2));
            Set(pos2, temp);
        }

        public int Get(int pos)
        {
            if (InBounds(pos))
                return values[pos];
            else
                return 0;
        }

        public void Modify(int pos, int value)
        {
            Modified?.Invoke(pos);
            Set(pos, value);
        }

        void Set(int pos, int value)
        {
            if (InBounds(pos))
                values[pos] = value;
        }

        public bool InBounds(int pos)
        {
            return (pos >= 0 && pos < Length);
        }

        public int Length
        {
            get
            {
                return values.Length;
            }
        }

        public void Recreate(int size)
        {
            values = new int[size];
            Recreated?.Invoke();
        }

        public int DistanceToSortedPosition(int pos)
        {
            return Math.Abs(pos - (Get(pos) - 1));
        }

        public SortingArray(int size)
        {
            Recreate(size);
        }
    }
}
