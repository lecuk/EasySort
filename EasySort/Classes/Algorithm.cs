using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySort.Classes
{
    delegate void Work(SortingArray array);

    abstract class Algorithm
    {
        public Work work;
    }
    
    class SortingAlgorithm : Algorithm
    {
        public readonly SortInfo info;

        public SortingAlgorithm(SortInfo info, Work work)
        {
            this.info = info;
            this.work = work;
        }
    }

    class GeneratorAlgorithm : Algorithm
    {
        public readonly GeneratorInfo info;

        public GeneratorAlgorithm(GeneratorInfo info, Work work)
        {
            this.info = info;
            this.work = work;
        }
    }
}
