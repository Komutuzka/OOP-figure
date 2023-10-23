using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_dll_figure
{
    public interface IMyObservable
    {
        void AddObserver(IMyObserver o);
        void RemoveObserver(IMyObserver o);
        void NotifyCreate();
        void NotifyDelete();
    }
    public interface IMyObserver
    {
        void UpdateCreate(IMyObservable a);
        void UpdateDelete(IMyObservable a);
    }

}
