using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_dll_figure
{
    public class StorageDecorator<T> : Storage<T> where T : Figure
    {
        public StorageDecorator() : base() {}
        public new void AddElem(T figure)
        {
            base.AddElem(figure);
            array[count - 1].NotifyCreate();
        }
        public new void DeleteElem()
        {
            array[index].NotifyDelete();
            base.DeleteElem();
        }
        public new void DeleteAll()
        {
            for (int i = 0; i < count; ++i)
            {
                array[i].NotifyDelete();
            }
            base.DeleteAll();
        }
    }
}
