using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_dll_figure
{
    public abstract class Figure : IMyObservable
    {
        protected int x, y, r = 30;
        private bool cursor;
        private Color color = Color.Red;
        protected string nameFigure;
        public List<IMyObserver> _obs;

        public Figure() { }
        public Figure(int x, int y)
        {
            this.x = x;
            this.y = y;
            cursor = false;
            nameFigure = null;
            _obs = new List<IMyObserver>();
        }
        public virtual int getX { get { return x; } }
        public virtual int getY { get { return y; } }
        public virtual int getR { get { return r; } }
        public virtual string getNameFigure { get { { return nameFigure; } } }

        public virtual Color Color { get => color; set => color = value; }
        public virtual bool Cursor { get => cursor; set => cursor = value; }
        public abstract void Draw(PaintEventArgs e);
        public abstract bool Limiter(int _x, int _y);

        public virtual void Move(int move_x, int move_y)
        {
            x += move_x;
            y += move_y;
        }
        // проверка на выход из pictureBox
        public virtual bool EndPictureBox(int width, int height)    //ширина, высота
        {
            if ((x - r <= 0) || (x + r >= width) || (y - r <= 0) || (y + r >= height)) return false;
            return true;
        }
        public virtual void Decrease()
        {
            if (r > 4) --r;
        }
        public virtual void Increase()
        {
            if (r < 60) ++r;
        }
        public virtual bool IsComposite() { return false; }
        public virtual void UnGroup(StorageDecorator<Figure> storage) { }

        // сохранение характеристик
        public virtual Memento createMemento()
        { 
            Memento memento = new Memento();
            memento.setState(nameFigure, x, y, r, color);
            return memento;
        }
        public virtual void updateFromMemento(Memento memento)
        {
            nameFigure = memento.RestoreNameFigure;
            x=memento.RestoreX; 
            y=memento.RestoreY;
            r=memento.RestoreR;
            color = memento.RestoreColor;
        }

        // работа с наблюдением
        
        public virtual void AddObserver(IMyObserver o)
        {
            _obs.Add(o);
        }

        public virtual void RemoveObserver(IMyObserver o)
        {
            _obs.Remove(o);
        }

        public virtual void NotifyCreate()
        {
            for (int i = 0; i < _obs.Count; ++i)
                _obs[i].UpdateCreate(this);
        }

        public virtual void NotifyDelete()
        {
            for (int i = 0; i < _obs.Count; ++i)
                _obs[i].UpdateDelete(this);
        }
    }
    public class Circle : Figure
    {  
        public Circle(int x, int y) : base(x, y) { nameFigure = "Circle"; }
        public override void Draw(PaintEventArgs e)
        {
            SolidBrush BrushFigure = new SolidBrush(Color),
                BrushDelete = new SolidBrush(Color.Black);
            if (Cursor)
                e.Graphics.FillEllipse(BrushDelete, x - r, y - r, r * 2, r * 2);
            else
                e.Graphics.FillEllipse(BrushFigure, x - r, y - r, r * 2, r * 2);
        }
        public override bool Limiter(int _x, int _y)
        {
            bool limit = false;
            int X = Math.Abs(_x - x);
            int Y = Math.Abs(_y - y);
            int distance = (int)Math.Sqrt(Y * Y + X * X);
            if (distance <= r)
            {
                if (Cursor == true) Cursor = false;
                else Cursor = true;
                limit = true;
            }
            return limit;
        }
    }
    public class Square : Figure
    {
        public Square(int x, int y) : base(x, y) { nameFigure = "Square"; }
        public override void Draw(PaintEventArgs e)
        {
            SolidBrush BrushFigure = new SolidBrush(Color),
                BrushDelete = new SolidBrush(Color.Black);
            if (Cursor == true)
                e.Graphics.FillRectangle(BrushDelete, x - r, y - r, r * 2, r * 2);
            else
                e.Graphics.FillRectangle(BrushFigure, x - r, y - r, r * 2, r * 2);
        }
        public override bool Limiter(int _x, int _y)
        {
            bool limit = false;
            int x1 = x - r, x2 = x + r,
                y1 = y - r, y2 = y + r;
            if ((x1 <= _x) & (_x <= x2) & (y1 <= _y) & (_y <= y2))
            {
                if (Cursor == true) Cursor = false;
                else Cursor = true;
                limit = true;
            }
            return limit;
        }

    }
    public class Triangle : Figure
    {
        private Point[] points = new Point[3];
        public Triangle(int x, int y) : base(x, y)
        {
            points[0].X = (int)(x - r / 2 * Math.Sqrt(3));
            points[0].Y = (y + r / 2);

            points[1].X = x;
            points[1].Y = y - r;

            points[2].X = (int)(x + r / 2 * Math.Sqrt(3));
            points[2].Y = (y + r / 2);

            Cursor = false;

            nameFigure = "Triangle";
        }
        public override void Draw(PaintEventArgs e)
        {
            SolidBrush BrushFigure = new SolidBrush(Color),
                BrushDelete = new SolidBrush(Color.Black);
            if (Cursor == true)
                e.Graphics.FillPolygon(BrushDelete, points);
            else
                e.Graphics.FillPolygon(BrushFigure, points);
        }
        public override bool Limiter(int _x, int _y)
        {
            bool limit = false;
            var p1 = (points[0].X - _x) * (points[1].Y - points[0].Y) - (points[1].X - points[0].X) * (points[0].Y - _y);
            var p2 = (points[1].X - _x) * (points[2].Y - points[1].Y) - (points[2].X - points[1].X) * (points[1].Y - _y);
            var p3 = (points[2].X - _x) * (points[0].Y - points[2].Y) - (points[0].X - points[2].X) * (points[2].Y - _y);
            if ((p1 <= 0 && p2 <= 0 && p3 <= 0) || (p1 >= 0 && p2 >= 0 && p3 >= 0))
            {
                if (Cursor == true) Cursor = false;
                else Cursor = true;
                limit = true;
            }
            return limit;
        }
        public override void Move(int move_x, int move_y)
        {
            x += move_x;
            y += move_y;
            for (int i = 0; i < 3; ++i)
            {
                points[i].X += move_x;
                points[i].Y += move_y;
            }
        }
        public override bool EndPictureBox(int width, int height)
        {
            if (points[0].X <= 0 || points[2].X >= width
                || points[1].Y <= 0 || points[2].Y >= height) return false;
            return true;
        }
        public override void Decrease()
        {
            base.Decrease();
            ++points[0].X;
            --points[2].X;
            ++points[1].Y; ++points[1].Y;
        }
        public override void Increase()
        {
            base.Increase();
            --points[0].X;
            ++points[2].X;
            --points[1].Y; --points[1].Y;
        }
    }

}
