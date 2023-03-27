using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace OOP_dll_figure
{
    public class Composite : Figure
    {
        private Storage<Figure> storage;
        public Composite()
        {
            storage = new Storage<Figure>();
            Cursor = false;
        }
        public override bool IsComposite() { return true; }
        public Figure GetElem { get { return storage.GetElem; } }
        
        //public void AddElem(Storage<Figure> upStorage)
        //{
        //    for (int i = 0; i < upStorage.GetCount; ++i, upStorage.NextElem())
        //    {
        //        if (upStorage.GetElem.Cursor)
        //        {
        //            storage.AddElem(upStorage.GetElem);
        //            upStorage.DeleteElem();
        //            upStorage.BackElem();
        //            --i;
        //        }
        //    }
        //    upStorage.NullElem();
        //}

        public void AddElem(Figure figure)
        {
            storage.AddElem(figure);
        }
        public override void UnGroup(Storage<Figure> upStorage)
        {
            upStorage.DeleteElem();
            for (int j = 0; j < storage.GetCount; ++j, storage.NextElem())
            {
                storage.GetElem.Cursor = false;
                upStorage.AddElem(storage.GetElem);
            }
            storage.DeleteAll();
        }

        public override void Draw(PaintEventArgs e)
        {
            for (int i = 0; i < storage.GetCount; ++i)
            {
                storage.GetElem.Cursor = Cursor;
                storage.GetElem.Draw(e);
                storage.NextElem();
            }
            storage.NullElem();
        }
        public override bool Limiter(int _x, int _y)
        {
            bool limit = false;
            for (int i = 0; i < storage.GetCount; ++i)
            {
                if (storage.GetElem.Limiter(_x, _y))
                {
                    if (Cursor)
                    {
                        Cursor = false;
                        storage.GetElem.Cursor = false;
                    }
                    else
                    {
                        Cursor = true;
                        storage.GetElem.Cursor = true;
                    }
                    limit = true;
                }
                storage.NextElem();
            }
            storage.NullElem();
            return limit;
        }
        // проверка за выход pictureBox
        public override bool EndPictureBox(int width, int height)
        {
            if (!Cursor) return false;
            for (int i = 0; i < storage.GetCount; ++i)
            {
                if (!storage.GetElem.EndPictureBox(width, height))
                {
                    storage.NullElem();
                    return false;
                }
                storage.NextElem();
            }
            storage.NullElem();
            return true;
        }
        // изменение размера
        public override void Decrease()
        {
            for (int i = 0; i < storage.GetCount; ++i)
            {
                storage.GetElem.Decrease();
                storage.NextElem();
            }
            storage.NullElem();
        }
        public override void Increase()
        {
            for (int i = 0; i < storage.GetCount; ++i)
            {
                storage.GetElem.Increase();
                storage.NextElem();
            }
            storage.NullElem();
        }
        // смещение
        public override void Move(int move_x, int move_y)
        {
            for (int i = 0; i < storage.GetCount; ++i)
            {
                storage.GetElem.Move(move_x, move_y);
                storage.NextElem();
            }
            storage.NullElem();
        }

        // изменение цвета
        public override Color Color
        {
            get => base.Color;
            set
            {
                for (int i = 0; i < storage.GetCount; ++i)
                {
                    storage.GetElem.Color = value;
                    storage.NextElem();
                }
                storage.NullElem();
            }
        }

        public override Memento createMemento()
        {
            MementoComposite composite = new MementoComposite();
            for (int i = 0; i < storage.GetCount; ++i, storage.NextElem())
            {
                Memento memento = new Memento();
                Figure figure = storage.GetElem;
                if (figure.IsComposite())
                {
                    memento = figure.createMemento();
                }
                else
                {
                    memento.setState(figure.getNameFigure, figure.getX, figure.getY, figure.getR, figure.Color);
                }
                composite.AddFigure(memento);
            }
            storage.NullElem();
            return composite;
        }
    }
}
