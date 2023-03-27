using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OOP_dll_figure
{
    // https://javarush.com/groups/posts/1684-pattern-command-svoimi-slovami
    // https://habr.com/ru/post/196960/
    
    public abstract class Command
    {
        public abstract void Do();
        public abstract void Undo();
        //public abstract bool IsIt(String str_command);
    }
    public class HistoryCommand
    {
        private Stack<Command> history;
        public HistoryCommand() 
        {
            history = new Stack<Command>();
        }
        public void SetCommand(Command command)
        {
            command.Do();
            history.Push(command);
        }
        public void CancelCommand()
        {
            if (history.Count != 0) history.Pop().Undo();
        }
    }
    public class CompositeFigureCommand : Command
    {
        private Figure figure;
        private Composite composite;
        public CompositeFigureCommand(Storage<Figure> storage, Figure figure)
        {
            this.figure = figure;
            composite = new Composite();
        }
        public override void Do()
        {
            throw new NotImplementedException();
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }
    }
    public class MoveFigureCommand : Command
    {
        private Figure figure;
        private int x, y;
        public MoveFigureCommand(Figure figure, int x, int y)
        {
            this.figure = figure;
            this.x = x;
            this.y = y;
        }
        public override void Do()
        {
            figure.Move(x, y);
        }

        public override void Undo()
        {
            figure.Move(-x, -y);
        }
        //public override bool IsIt(String str_command)
        //{
        //    return str_command == "Move" ? true : false;
        //}
    }

    public class ColorFigureCommand : Command
    {
        private Figure figure;
        private Color color1, color2;

        public ColorFigureCommand(Figure figure, Color color)
        {
            this.figure = figure;
            this.color2 = color;
            color1 = figure.Color;
        }

        public override void Do()
        {
            figure.Color = color2;
        }
        public override void Undo()
        {
            figure.Color = color1;
        }
    }

    public class DecreaseFigureCommand : Command
    {
        private Figure figure;
        public DecreaseFigureCommand(Figure figure)
        {
            this.figure = figure;
        }
        public override void Do()
        {
            figure.Decrease();
        }
        public override void Undo()
        {
            figure.Increase();
        }
    }

    public class IncreaseFigureCommand : Command
    {
        private Figure figure;
        public IncreaseFigureCommand(Figure figure)
        {
            this.figure = figure;
        }
        public override void Do()
        {
            figure.Increase();
        }
        public override void Undo()
        {
            figure.Decrease();
        }
    }
}
