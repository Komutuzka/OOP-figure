using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_dll_figure
{
    //public class Storage
    //{
    //    Figure[] array;
    //    int count, maxSize, index;

    //    public Storage()
    //    {
    //        index = count = maxSize = 0;
    //        array = null;
    //    }
    //    public Storage(int maxSize)
    //    {
    //        index = count = 0;
    //        this.maxSize = maxSize;
    //        array = new Figure[maxSize];
    //    }

    //    public int GetCount { get { return count; } }

    //    //работа с индексами
    //    public void NextElem()
    //    {
    //        index++;
    //    }
    //    public void BackElem()
    //    {
    //        index--;
    //    }
    //    public void NullElem()
    //    {
    //        index = 0;
    //    }


    //    //работа с элементами
    //    public Figure GetElem
    //    {
    //        get
    //        {
    //            if (array[index] != null)
    //                return array[index];
    //            else
    //                return null;
    //        }
    //    }
    //    public void AddElem(Figure figure)
    //    {
    //        if (figure == null) return;
    //        count++;
    //        if (count > maxSize)
    //        {
    //            Figure[] array2 = new Figure[count];
    //            for (int i = 0; i < maxSize; ++i)
    //                array2[i] = array[i];
    //            array2[maxSize] = figure;
    //            array = array2;
    //            maxSize = count;
    //        }
    //        else array[count - 1] = figure;
    //    }
    //    public void DeleteElem()
    //    {
    //        int j;
    //        for (j = index; j < count - 1; ++j)
    //        {
    //            array[j] = array[j + 1];
    //        }
    //        array[j] = null;
    //        count--;
    //    }
    //    public void DeleteAll()
    //    {
    //        for (int i = 0; i < count; ++i)
    //        {
    //            array[i] = null;
    //        }
    //        count = 0;
    //        index = 0;
    //    }        
    //}

    public class Storage<T>  where T : class
    {
        protected T[] array;
        protected int count, index;

        public Storage()
        {
            index = count = 0;
            array = null;
        }

        public int GetCount { get { return count; } }

        //работа с индексами
        public void NextElem() { index++; }
        public void BackElem() { index--; }
        public void NullElem() { index = 0; }


        //работа с элементами
        public T GetElem
        {
            get
            {
                return array[index];
            }
        }
        public void AddElem(T figure)
        {
            //if (figure == null) return;
            count++;
            T[] array2 = new T[count];
            for (int i = 0; i < count - 1; ++i) 
            {
                array2[i] = array[i];
            }
            array2[count - 1] = figure;
            array = array2;
        }
        public void DeleteElem()
        {
            T[] array2 = new T[count - 1];
            for(int i = 0; i < count; ++i)
            {
                if (i < index)
                {
                    array2[i] = array[i];
                }
                else if (i > index)
                {
                    array2[i-1] = array[i];
                }          
            }
            array = array2;
            count--;
        }
        public void DeleteAll()
        {
            for (int i = 0; i < count; ++i)
            {
                array[i] = default(T);
            }
            count = 0;
            index = 0;
        }
    }
}

