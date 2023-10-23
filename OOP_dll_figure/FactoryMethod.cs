using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_dll_figure
{
    public abstract class Factory
    {
        public abstract Figure CreateFigure(String type, int x, int y);
    }
    public class FactoryMethod : Factory
    {
        public override Figure CreateFigure(String type, int x, int y)
        {
            Figure figure = null;
            if (type.Equals("Circle"))
            {
                figure = new Circle(x, y);
            }
            else if (type.Equals("Square"))
            {
                figure = new Square(x, y);
            }
            else if (type.Equals("Triangle"))
            {
                figure = new Triangle(x, y);
            }
            return figure;
        }

    }
}
