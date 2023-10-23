using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace OOP_dll_figure
{
    public class Memento
    {
        public string nameFigure;
        public int x, y, r, colorToArgb;
        public Color color;

        public string RestoreNameFigure { get { return nameFigure; } }
        public int RestoreX { get { return x; } }
        public int RestoreY { get { return y; } }
        public int RestoreR { get { return r; } }
        public int RestoreColorToArgb { get { return colorToArgb; } }
        public Color RestoreColor { get { return color; } }

        public Memento() { }
        public virtual Figure ReturnFigure()
        {
            FactoryMethod factoryMethod = new FactoryMethod();
            Figure figure = factoryMethod.CreateFigure( RestoreNameFigure,
                                                        RestoreX,
                                                        RestoreY    );
            figure.updateFromMemento(this);
            return figure;
        }

        public virtual bool IsComposite { get { return false; } }

        public void setState(string nameFigure, int x, int y, int r, Color color)
        {
            this.nameFigure = nameFigure;
            this.x = x;
            this.y = y;
            this.r = r;
            this.color = color;
            colorToArgb = color.ToArgb();
        }
        public virtual string InfoFigure()
        {
            string Info = "Figure: " + nameFigure +
                " Coordinate: " + x.ToString() + " " + y.ToString() +
                " Radius: " + r.ToString() +
                " Color: " + colorToArgb.ToString() + " ";
            return Info;
        }
        public virtual void RepackInfoFigure(string[] Info)
        {
            for (int i = 0; i < Info.Length-1; ++i)
            {
                if (Info[i] == "Figure:")
                {
                    i += 1;
                    nameFigure = Info[i];
                }
                else if (Info[i] == "Coordinate:")
                {
                    i += 1; x = int.Parse(Info[i]);
                    i += 1; y = int.Parse(Info[i]);
                }
                else if (Info[i] == "Radius:")
                {
                    i += 1; r = int.Parse(Info[i]);
                }
                else if (Info[i] == "Color:")
                {
                    i += 1; colorToArgb = int.Parse(Info[i]);
                    color = Color.FromArgb(colorToArgb);
                }
            }
        }
    }

    public class MementoComposite : Memento
    {

        public Storage<Memento> history;
        public int GetCount { get { return history.GetCount; } }

        public MementoComposite()
        {
            history = new Storage<Memento>();
        }
        public override bool IsComposite { get { return true; } }

        public Memento GetElem { get { return history.GetElem; } }
        public void NextElem() { history.NextElem(); }
        public void NullElem() { history.NullElem(); }

        public void AddFigure(Memento memento)
        {
            history.AddElem(memento);
        }
        public override string InfoFigure()
        {
            string Info = "{ ";
            for (int i = 0; i < GetCount; ++i, NextElem())
            {
                Info += GetElem.InfoFigure();
            }
            Info += "} ";
            NullElem();
            return Info;
        }
        public override void RepackInfoFigure(string[] s)
        {
            for (int i = 1; i < (s.Length - 1); ++i)
            {
                Memento memento;
                if (s[i] == "{")
                {
                    int c = 0;
                    int ic = i;
                    while (s[i] != "}")
                    {
                        c += 1; i += 1;
                    }
                    i = ic;
                    string[] composite = new string[c];
                    for (int f = 0; f < c; ++f)
                    {
                        composite[f] = s[i]; i += 1;
                    }
                    memento = new MementoComposite();
                    memento.RepackInfoFigure(composite);
                    history.AddElem(memento);
                }
                else
                {
                    if (s[i] != "}")
                    {
                        string[] figure = new string[9];
                        int j = 0;
                        while (j < 9)
                        {
                            figure[j] += s[i];
                            j += 1; i += 1;
                        }
                        i -= 1;
                        memento = new Memento();
                        memento.RepackInfoFigure(figure);
                        AddFigure(memento);
                    }
                }
            }
        }
        public override Figure ReturnFigure()
        {
            Composite figure = new Composite();
            for (int i = 0; i < GetCount; ++i, history.NextElem())
            {
                figure.AddElem(history.GetElem.ReturnFigure());
            }
            return figure;
        }
    }

    public class HistoryFigure      //Caretaker
    {
        private Storage<Memento> history;
        private string[] InfoHistory;
        private int count;

        public HistoryFigure()
        {
            history = new Storage<Memento>();
            count = 0;
        }
        public string[] AddToHistory(Storage<Figure> storage)
        {
            count = storage.GetCount;
            InfoHistory = new string[count];
            for (int i = 0; i < count; ++i, storage.NextElem())
            {
                Memento memento = storage.GetElem.createMemento();
                history.AddElem(memento);
                InfoHistory[i] = memento.InfoFigure();
            }
            storage.NullElem();
            return InfoHistory;
        }
        public string[] AddToHistory2(Storage<Figure> storage)
        {
            count = storage.GetCount;
            InfoHistory = new string[count];

            for (int i = 0; i < count; ++i, storage.NextElem())
            {
                Memento memento = storage.GetElem.createMemento();
                history.AddElem(memento);
                InfoHistory[i] = memento.InfoFigure();
            }
            storage.NullElem();
            return InfoHistory;
        }
        public void LoadHistory(string[] s)
        {
            InfoHistory = s;
            count = s.Length;
            for (int i = 0; i < count; ++i)
            {
                string[] line = s[i].Split(' ');
                Memento memento;
                if (line[0] == "{")
                {
                    memento = new MementoComposite();
                }
                else
                {
                    memento = new Memento();
                }
                memento.RepackInfoFigure(line);
                history.AddElem(memento);
            }
            count = history.GetCount;
        }
        public StorageDecorator<Figure> ReturnStorage() //!!!!
        {
            StorageDecorator<Figure> storage = new StorageDecorator<Figure>();
            for (int i = 0; i < count; ++i, history.NextElem()) 
            {
                Figure figure = history.GetElem.ReturnFigure();
                storage.AddElem(figure);
            }
            history.NullElem();
            return storage;
        }
    }
}

