using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_dll_figure
{
    public abstract class Factory
    {
        public abstract Figure CreateFigure(String type, int x, int y);

    }
    public class Proxy : Factory
    {
        int width, height, r = 30;
        public Proxy(int _width, int _height)
        {
            width = _width; height = _height;
        }
        private bool Check(String type, int x, int y)
        {
            if (type.Equals("Circle") || type.Equals("Square"))
            {
                if (x - r <= 0 || x + r >= width) return false;
                if (y - r <= 0 || y + r >= height) return false;
                return true;
            }
            else // "Triangle"
            {
                Point[] points = new Point[3];

                points[0].X = (int)(x - r / 2 * Math.Sqrt(3));
                points[0].Y = (y + r / 2);

                points[1].X = x;
                points[1].Y = y - r;

                points[2].X = (int)(x + r / 2 * Math.Sqrt(3));
                points[2].Y = (y + r / 2);

                if (points[0].X <= 0 || points[2].X >= width
                    || points[1].Y <= 0 || points[2].Y >= height) return false;
                return true;
            }
        }
        public override Figure CreateFigure(String type, int x, int y)
        {
            if (Check(type, x, y))
            {
                FactoryMethod factory = new FactoryMethod();
                return factory.CreateFigure(type, x, y);
            }
            return null;
        }
    }
}
