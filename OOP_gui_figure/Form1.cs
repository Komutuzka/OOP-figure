using OOP_dll_figure;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OOP_gui_figure
{
    public partial class MainForm : Form //, IMyObserver
    {
        StorageDecorator<Figure> storage = new StorageDecorator<Figure>();
        HistoryCommand historyCommand = new HistoryCommand();
        //TreeNode MainNode = new TreeNode("Storage");
        
        public MainForm()
        {
            InitializeComponent();
            treeVw.Nodes.Add("Figures");
        }

        // рисование фигуры
        private void pctBx_Click(object sender, EventArgs e)
        {
            if (cmBx.Text == "") MessageBox.Show("Сначала нужно выбрать фигуру!");
        }
        private void pctBx_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < storage.GetCount; i++, storage.NextElem())
            {
                storage.GetElem.Draw(e);
            }
            storage.NullElem();
            lblCount.Text = "Количество элементов: " + storage.GetCount.ToString();

            //updateTree();
        }
        private void pctBx_MouseClick(object sender, MouseEventArgs e)
        {
            int a = 0;
            for (int i = 0; i < storage.GetCount; i++)
            {
                if (storage.GetElem.Limiter(e.X, e.Y))
                {
                    a++;
                }
                storage.NextElem();
            }
            storage.NullElem();

            if (a == 0)
            {
                String strFigure = "";
                if (cmBx.SelectedIndex == 0)
                {
                    strFigure = "Circle";
                }
                else if (cmBx.SelectedIndex == 1)
                {
                    strFigure = "Square";
                }
                else if (cmBx.SelectedIndex == 2)
                {
                    strFigure = "Triangle";
                }
                else pctBx_Click(sender, e);


                if (strFigure != "")
                {
                    Factory factory = new Proxy(pctBx.Width, pctBx.Height);
                    Figure figure = factory.CreateFigure(strFigure, e.X, e.Y);
                    if (figure != null)
                    {
                        //figure.AddObserver(this);
                        storage.AddElem(figure);
                    }
                }
            }
            pctBx.Refresh();
        }

        // удаление фигуры
        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < storage.GetCount; ++i)
            {
                if (storage.GetElem.Cursor)
                {
                    storage.DeleteElem();
                    --i;
                }
                else storage.NextElem();

            }
            storage.NullElem();
            pctBx.Refresh();
            lblCount.Text = "Количество элементов: " + storage.GetCount.ToString();

        }
        private void btnClear_Click(object ы, EventArgs e)
        {
            storage.DeleteAll();
            lblCount.Text = "Количество элементов: " + storage.GetCount.ToString();
            pctBx.Refresh();
        }

        // группировка и разгруппировка фигур
        private void btnGroup_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i < storage.GetCount; ++i, storage.NextElem())
            {
                if (storage.GetElem.Cursor)
                {
                    count++;
                    if (count == 2) break;
                }
            }
            storage.NullElem();

            if (count == 1)
            {
                for (int i = 0; i < storage.GetCount; ++i, storage.NextElem())
                {
                    if (storage.GetElem.Cursor && storage.GetElem.IsComposite())
                    {
                        storage.GetElem.UnGroup(storage);
                    }
                }
                storage.NullElem();
            }
            else
            {
                Composite composite = new Composite();
                for (int i = 0; i < storage.GetCount; ++i, storage.NextElem())
                {
                    if (storage.GetElem.Cursor)
                    {                        
                        composite.AddElem(storage.GetElem);
                        storage.DeleteElem();
                        storage.BackElem();
                        i--;
                    }
                }
                //composite.AddObserver(this);
                storage.NullElem();
                storage.AddElem(composite);
                
            }
            pctBx.Refresh();
        }

        // цвет фигуры
        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.Cancel)
                return;
            for (int i = 0; i < storage.GetCount; ++i)
            {
                if (storage.GetElem.Cursor)
                {
                    storage.GetElem.Color = colorDialog.Color;
                }
                storage.NextElem();
            }
            storage.NullElem();
            pctBx.Refresh();
        }

        // размер фигуры
        private void btnDecrease_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < storage.GetCount; ++i)
            {
                if (storage.GetElem.Cursor)
                {
                    Command command = new DecreaseFigureCommand(storage.GetElem);
                    historyCommand.SetCommand(command);
                }
                storage.NextElem();
            }
            storage.NullElem();
            pctBx.Refresh();
        }

        private void btnIncrease_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < storage.GetCount; ++i)
            {
                if (storage.GetElem.Cursor && storage.GetElem.EndPictureBox(pctBx.Width, pctBx.Height))
                {
                    Command command = new IncreaseFigureCommand(storage.GetElem);
                    historyCommand.SetCommand(command);
                    //storage.GetElem.Increase();
                    if (!storage.GetElem.EndPictureBox(pctBx.Width, pctBx.Height))
                    {
                        Command command2 = new DecreaseFigureCommand(storage.GetElem);
                        historyCommand.SetCommand(command2);
                        //storage.GetElem.Decrease();
                    }
                }
                storage.NextElem();
            }
            storage.NullElem();
            pctBx.Refresh();
        }

        // смещение фигуры
        private void btnUp_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < storage.GetCount; ++i)
            {
                if (storage.GetElem.Cursor && storage.GetElem.EndPictureBox(pctBx.Width, pctBx.Height))
                {
                    Command command = new MoveFigureCommand(storage.GetElem, 0, -1);
                    historyCommand.SetCommand(command);
                    //storage.GetElem.Move(0, -1);
                    if (!storage.GetElem.EndPictureBox(pctBx.Width, pctBx.Height))
                    {
                        Command command2 = new MoveFigureCommand(storage.GetElem, 0, 1);
                        historyCommand.SetCommand(command2);
                        //storage.GetElem.Move(0, 1);
                    }
                }
                storage.NextElem();
            }
            storage.NullElem();
            pctBx.Refresh();
        }
        private void btnDown_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < storage.GetCount; ++i)
            {
                if (storage.GetElem.Cursor && storage.GetElem.EndPictureBox(pctBx.Width, pctBx.Height))
                {
                    Command command = new MoveFigureCommand(storage.GetElem, 0, 1);
                    historyCommand.SetCommand(command);
                    //storage.GetElem.Move(0, 1);
                    if (!storage.GetElem.EndPictureBox(pctBx.Width, pctBx.Height))
                    {
                        Command command2 = new MoveFigureCommand(storage.GetElem, 0, -1);
                        historyCommand.SetCommand(command2);
                        //storage.GetElem.Move(0, -1);
                    }
                }
                storage.NextElem();
            }
            storage.NullElem();
            pctBx.Refresh();
        }
        private void btnLeft_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < storage.GetCount; ++i)
            {
                if (storage.GetElem.Cursor && storage.GetElem.EndPictureBox(pctBx.Width, pctBx.Height))
                {
                    Command command = new MoveFigureCommand(storage.GetElem, -1, 0);
                    historyCommand.SetCommand(command);
                    //storage.GetElem.Move(-1, 0);
                    if (!storage.GetElem.EndPictureBox(pctBx.Width, pctBx.Height))
                    {
                        Command command2 = new MoveFigureCommand(storage.GetElem, 1, 0);
                        historyCommand.SetCommand(command2);
                        //storage.GetElem.Move(1, 0);
                    }
                }
                storage.NextElem();
            }
            storage.NullElem();
            pctBx.Refresh();
        }
        private void btnRight_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < storage.GetCount; ++i)
            {
                if (storage.GetElem.Cursor && storage.GetElem.EndPictureBox(pctBx.Width, pctBx.Height))
                {
                    Command command = new MoveFigureCommand(storage.GetElem, 1, 0);
                    historyCommand.SetCommand(command);
                    //storage.GetElem.Move(1, 0);
                    if (!storage.GetElem.EndPictureBox(pctBx.Width, pctBx.Height))
                    {
                        Command command2 = new MoveFigureCommand(storage.GetElem, -1, 0);
                        historyCommand.SetCommand(command2);
                        //storage.GetElem .Move(-1, 0);
                    }
                }
                storage.NextElem();
            }
            storage.NullElem();
            pctBx.Refresh();
        }

        // управление кнопками
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Add: { btnIncrease_Click(sender, e); break; }
                case Keys.Subtract: { btnDecrease_Click(sender, e); break; }
                case Keys.Delete: { btnClear_Click(sender, e); break; }
                case Keys.Back: { btnDelete_Click(sender, e); break; }
                case Keys.Up: { btnUp_Click(sender, e); break; }
                case Keys.Down: { btnDown_Click(sender, e); break; }
                case Keys.Right: { btnRight_Click(sender, e); break; }
                case Keys.Left: { btnLeft_Click(sender, e); break; }
                case Keys.C: { btnColor_Click(sender, e); break; }
                case Keys.G: { btnGroup_Click(sender, e); break; }
                case Keys.Z: { btnCancel_Click(sender, e); break; }

                    // case Keys.: { (sender, e); break; }
            }
        }

        // отмена действий
        private void btnCancel_Click(object sender, EventArgs e)
        {
            historyCommand.CancelCommand();
            pctBx.Refresh();
        }

        // работа с файлами
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                InitialDirectory = @"D:\",
                Title = "Select a save location",

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                RestoreDirectory = true
            };
            if (sfd.ShowDialog() == DialogResult.Cancel)
                return;

            HistoryFigure historyFigure = new HistoryFigure();
            File.WriteAllLines(sfd.FileName, historyFigure.AddToHistory(storage));

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            try
            {
                HistoryFigure historyFigure = new HistoryFigure();
                string[] lines = File.ReadAllLines(openFileDialog.FileName);
                historyFigure.LoadHistory(lines);
                storage = historyFigure.ReturnStorage();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: Не удалось прочитать файлю. Код ошибки: " + ex.Message);
            }
            pctBx.Refresh();
        }

        private void btnTxt_Click(object sender, EventArgs e)
        {
            HistoryFigure historyFigure = new HistoryFigure();
            string[] strHist = historyFigure.AddToHistory(storage);
            string strNew = "";
            for (int i = 0;i < strHist.Length; ++i)
            {
                strNew += strHist[i] + "\n";
            }
            MessageBox.Show(strNew);
        }

        // работа с наблюдателем
        //private void updateTree()
        //{
        //    treeVw.Nodes[0].Nodes.Clear();
        //    treeVw.Nodes[0].Expand();


        //    //for (int i = 0; i < storage.GetCount; ++i, storage.NextElem())
        //    //{
        //    //    if (storage.GetElem.IsComposite())
        //    //    {
        //    //        treeVw.Nodes[0].Nodes.Add(storage.GetElem.getNameFigure());
        //    //    }
        //    //}
        //    //storage.NullElem();


        //    for (int i = 0; i < storage.GetCount; ++i, storage.NextElem())
        //    {
        //        treeVw.Nodes[0].Nodes.Add(storage.GetElem.getNameFigure());
        //    }
        //    storage.NullElem();
        //}

        // работа с наблюдателем
        //public void UpdateCreate(IMyObservable a)
        //{

        //    TreeNode node = new TreeNode(a.GetType().Name);
        //    node.Name = a.GetType().Name;
        //    //MessageBox.Show(a.GetType().Name);
        //    int i = 0;
        //    if (a.GetType().Name is "Composite") i++;
        //    treeVw.Nodes[i].Nodes.Add(node);
        //}

        //public void UpdateDelete(IMyObservable a)
        //{
        //    TreeNode[] nodes = treeVw.Nodes.Find(a.GetType().Name, true);
        //    if (nodes.Length > 0)
        //        treeVw.Nodes.Remove(nodes[0]);
        //}
    }
}