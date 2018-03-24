using System.Collections.Generic;
using System.Drawing;

namespace EasySort.Classes
{
    struct DrawingOptions
    {
        public DrawingColor color;
        public bool redraw;

        public DrawingOptions(DrawingColor color, bool redraw)
        {
            this.color = color;
            this.redraw = redraw;
        }

        public static readonly DrawingOptions Default = new DrawingOptions(DrawingColor.Default, false);
    }

    class Drawer
    {
        SortingArray arrayToDraw;
        Graphics graph;
        RectangleF drawingArea;

        //Variables that can be modified between updates.
        Dictionary<int, DrawingOptions> NextFrameDrawings;
        Graphics newGraph;
        RectangleF newDrawingArea;
        bool needGraphUpdate = false;
        bool needDrawingClear = false;
        //------
        
        public SizeF UnitSize
        {
            get
            {
                float w = drawingArea.Width / arrayToDraw.Length;
                float h = drawingArea.Height / arrayToDraw.Length;
                return new SizeF(w, h);
            }
        }

        public RectangleF GetPosRect(int pos)
        {
            float x = pos * UnitSize.Width;
            float y = drawingArea.Height - arrayToDraw.Get(pos) * UnitSize.Height;
            float w = UnitSize.Width;
            float h = drawingArea.Height - y;
            return new RectangleF(x, y, w, h);
        }

        public RectangleF GetPosLine(int pos)
        {
            float x = pos * UnitSize.Width;
            float y = 0;
            float w = UnitSize.Width;
            float h = drawingArea.Height;
            return new RectangleF(x, y, w, h);
        }

        public void Update()
        {
            List<int> redrawPositions = new List<int>();

            if (needGraphUpdate)
                UpdateGraphics();

            if (!needDrawingClear)
            {
                foreach (int pos in NextFrameDrawings.Keys)
                {
                    DrawingOptions options = NextFrameDrawings[pos];
                    DrawPos(pos, options.color);

                    if (options.redraw)
                        redrawPositions.Add(pos);
                }
            }
            else
            {
                needDrawingClear = false;
            }
            ClearDrawings();
            
            foreach (int posToRedraw in redrawPositions)
            {
                DrawPosNextFrame(posToRedraw, DrawingOptions.Default);
            }
        }

        public void ClearDrawingsNextFrame()
        {
            needDrawingClear = true;
        }

        public void ClearDrawings()
        {
            NextFrameDrawings.Clear();
        }

        void ClearPos(int pos)
        {
            RectangleF rect = GetPosLine(pos);
            graph.FillRectangle(Brushes.Black, rect);
        }

        void DrawPos(int pos, DrawingColor color)
        {
            ClearPos(pos);
            RectangleF rect = GetPosRect(pos);
            SolidBrush brush = new SolidBrush(DrawingStyler.GetColor(arrayToDraw, pos, color));
            graph.FillRectangle(brush, rect);
        }

        public void DrawPosNextFrame(int pos, DrawingOptions options)
        {
            if (!NextFrameDrawings.ContainsKey(pos))
                NextFrameDrawings.Add(pos, options);
            else
                NextFrameDrawings[pos] = options;
        }

        public void UpdateGraphicsNextFrame(Graphics newGraph, RectangleF newDrawingArea)
        {
            this.newGraph = newGraph;
            this.newDrawingArea = newDrawingArea;
            needGraphUpdate = true;
        }

        public void RedrawAllNextFrame()
        {
            for (int pos = 0; pos < arrayToDraw.Length; pos++)
            {
                if (NextFrameDrawings.ContainsKey(pos))
                    DrawPosNextFrame(pos, NextFrameDrawings[pos]);
                else
                    DrawPosNextFrame(pos, DrawingOptions.Default);
            }
        }

        public void RedrawAllAsDefault()
        {
            for(int i = 0; i < arrayToDraw.Length; i++)
            {
                DrawPos(i, DrawingColor.Default);
            }
        }

        public void DrawModified(int pos)
        {
            DrawingOptions options = new DrawingOptions(DrawingColor.Special, true);
            DrawPosNextFrame(pos, options);
        }

        public void DrawSwapped(int pos1, int pos2)
        {
            DrawingOptions options = new DrawingOptions(DrawingColor.Swapped, true);
            DrawPosNextFrame(pos1, options);
            DrawPosNextFrame(pos2, options);
        }

        public void DrawCompared(int pos1, int pos2)
        {
            DrawingOptions options = new DrawingOptions(DrawingColor.Selected, true);
            DrawPosNextFrame(pos1, options);
            DrawPosNextFrame(pos2, options);
        }

        void UpdateGraphics()
        {
            graph = newGraph;
            drawingArea = newDrawingArea;
            needGraphUpdate = false;
            RedrawAllNextFrame();
        }

        public Drawer(SortingArray arrayToDraw, Graphics graph, RectangleF drawingArea)
        {
            NextFrameDrawings = new Dictionary<int, DrawingOptions>();
            this.arrayToDraw = arrayToDraw;
            this.graph = graph;
            this.drawingArea = drawingArea;
        }
    }
}
