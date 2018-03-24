using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System;

namespace EasySort.Classes
{
    class Controller
    {
        public readonly SortingArray array;
        public readonly Drawer drawer;
        public readonly Worker worker;

        bool needDrawerUpdate = false;
        bool needDelayUpdate = false;
        bool needStyleUpdate = false;
        double newDelay;
        Graphics newGraph;
        DrawingStyle newStyle;

        double delay;
        Graphics graph;

        int comparisions = 0;
        int swaps = 0;
        int modifies = 0;

        Stopwatch watch;

        public void SetNewDelayNextUpdate(double newDelay)
        {
            needDelayUpdate = true;
            this.newDelay = newDelay;
        }

        void SetNewDelay()
        {
            needDelayUpdate = false;
            delay = newDelay;
        }
        
        public void Update(SortingArray array)
        {
            if (needStyleUpdate)
                UpdateStyle();

            if (needDrawerUpdate)
                UpdateDrawerDisplays();

            if (needDelayUpdate)
                SetNewDelay();
            
            drawer.Update();

            if (delay > 0)
                Delay(delay);
        }

        public void Delay(double millis)
        {
            watch.Restart();

            if (millis < 100)
            {
                while (watch.Elapsed.Ticks < millis * 10000)
                {
                    //SpinWait
                }
            }
            else
            {
                Thread.Sleep((int)millis);
            }
            watch.Stop();
        }

        public void Work(SortingArray array, Algorithm algorithm)
        {
            drawer.Update();
            worker.StartAsync(array, algorithm);
        }

        public void UpdateDrawerDisplaysNextFrame(Graphics newGraph)
        {
            this.newGraph = newGraph;
            needDrawerUpdate = true;
        }

        void UpdateDrawerDisplays()
        {
            needDrawerUpdate = false;
            graph = newGraph;
            
            drawer.UpdateGraphicsNextFrame(graph, GetDisplay());
        }

        public void ResetCounters()
        {
            comparisions = 0;
            swaps = 0;
            modifies = 0;
        }

        void PlusComparisions(int pos1, int pos2)
        {
            comparisions++;
        }

        void PlusSwaps(int pos1, int pos2)
        {
            swaps++;
        }

        void PlusModifies(int pos)
        {
            modifies++;
        }

        public int Comparisions
        {
            get
            {
                return comparisions;
            }
        }

        public int Swaps
        {
            get
            {
                return swaps;
            }
        }

        public int Modifies
        {
            get
            {
                return modifies;
            }
        }

        public void UpdateStyleNextFrame(DrawingStyle newStyle)
        {
            this.newStyle = newStyle;
        }

        public void UpdateStyle()
        {
            DrawingStyler.style = newStyle;
        }

        RectangleF GetDisplay()
        {
            return graph.VisibleClipBounds;
        }

        public Controller(Graphics graph, SortingArray array, double startingDelay)
        {
            this.graph = graph;
            SetNewDelayNextUpdate(startingDelay);

            this.array = array;
            drawer = new Drawer(array, graph, graph.VisibleClipBounds);

            array.Modified += drawer.DrawModified;
            array.Compared += drawer.DrawCompared;
            array.Swapped += drawer.DrawSwapped;
            array.Recreated += drawer.ClearDrawings;

            array.Modified += PlusModifies;
            array.Compared += PlusComparisions;
            array.Swapped += PlusSwaps;

            worker = new Worker();
            
            GeneratorAlgorithms.Updated += Update;
            SortAlgorithms.Updated += Update;

            watch = new Stopwatch();
        }
    }
}
