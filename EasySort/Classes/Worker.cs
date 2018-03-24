using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using System.Threading.Tasks;

namespace EasySort.Classes
{
    class Worker
    {
        SortingArray currentArray;
        Algorithm currentAlgorithm;
        bool isWorking = false;
        Thread workThread;

        public delegate void StartWork();
        public event StartWork Started;

        public delegate void FinishWork();
        public event FinishWork Finished;

        public bool IsWorking
        {
            get
            {
                return isWorking;
            }
        }

        public void StartAsync(SortingArray array, Algorithm algorithm)
        {
            currentAlgorithm = algorithm;
            currentArray = array;

            workThread = new Thread(DoWork);
            workThread.Start();
        }

        void DoWork()
        {
            Started?.Invoke();
            isWorking = true;
            currentAlgorithm.work.Invoke(currentArray);
            isWorking = false;
            Finished?.Invoke();
        }

        public void StopImmediately()
        {
            workThread?.Abort();
        }
    }
}
