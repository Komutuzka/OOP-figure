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
        private StorageDecorator<Figure> storage;
        public Composite()
        {            
            storage = new StorageDecorator<Figure>();
            Cursor = false;
            nameFigure = "Group";

            _obs = new List<IMyObserver>();
        }
        public override bool IsComposite() { return true; }
        public Figure GetElem { get { return storage.GetElem; } }
        public void AddElem(Figure figure)
        {
            storage.AddElem(figure);
        }
        public override void UnGroup(StorageDecorator<Figure> upStorage)
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

        // работа с памятью
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


        // работа с наблюдателем
        //public new List<IMyObserver> _obs;
        //public override void AddObserver(IMyObserver o)
        //{
        //    _obs.Add(o);
        //    for (int i = 0; i < storage.GetCount; ++i)
        //    {
        //        storage.GetElem.AddObserver(o);
        //        storage.NextElem();
        //    }
        //    storage.NullElem();
        //}

        public override void RemoveObserver(IMyObserver o)
        {

            for (int i = 0; i < storage.GetCount; ++i)
            {
                storage.GetElem.RemoveObserver(o);
                storage.NextElem();
            }
            storage.NullElem();
            //_obsvar2.Remove(o);
        }
        public override void NotifyCreate()
        {
            for (int i = 0; i < _obs.Count; ++i)
                _obs[i].UpdateCreate(this);

            for (int i = 0; i < storage.GetCount; ++i)
            {
                storage.GetElem.NotifyDelete();
                storage.GetElem.NotifyCreate();
                storage.NextElem();
            }
            storage.NullElem();
        }

        public override void NotifyDelete()
        {
            for (int i = 0; i < _obs.Count; ++i)
                _obs[i].UpdateDelete(this);

            for (int i = 0; i < storage.GetCount; ++i)
            {
                storage.GetElem.NotifyDelete();
                storage.NextElem();
            }
            storage.NullElem();
        }

    }
}
