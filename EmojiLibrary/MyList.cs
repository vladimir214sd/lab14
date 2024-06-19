using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmojiLibrary
{
    public class MyList<T> where T : IInit, ICloneable, new()
    {
        public Point<T>? beg = null;
        public Point<T>? end = null;

        int count = 0;

        public int Count => count;

        public Point<T> MakeRandomData()
        {
            T data = new T();
            data.RandomInit();
            return new Point<T>(data);
        }

        public T MakeRandomItem()
        {
            T data = new T();
            data.RandomInit();
            return data;
        }

        public void AddToBegin(T item)
        {
            T newData = (T)item.Clone(); // глубокое копирование
            Point<T> newItem = new Point<T>(newData);
            count++;
            if (beg != null)
            {
                beg.Pred = newItem;
                newItem.Next = beg;
                beg = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }

        public void AddToEnd(T item)
        {
            T newData = (T)item.Clone(); // глубокое копирование
            Point<T> newItem = new Point<T>(newData);
            count++;
            if (end != null)
            {
                end.Next = newItem;
                newItem.Pred = end;
                end = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }


        public MyList()
        {
            beg = null;
            end = null;
            count = 0;
        }

        public MyList(int size)
        {
            if (size < 0) throw new Exception("size less zero or zero");
            beg = MakeRandomData();
            end = beg;
            for (int i = 1; i <= size; i++)
            {
                T newItem = MakeRandomItem();
                AddToEnd(newItem);
            }
            count = size;
        }

        public MyList(T[] collection)
        {
            if (collection == null) throw new Exception("empty collection: null");
            if (collection.Length == 0) throw new Exception("empty collection");

            T newData = (T)collection.Clone();
            beg = new Point<T>(newData);
            end = beg;
            for (int i = 0; i < collection.Length; i++)
            {
                AddToEnd(collection[i]);
            }
        }

        public void PrintList()
        {
            if (count == 0)
                Console.WriteLine("list is empty");
            Point<T>? current = beg;
            for (int i = 0; current != null; i++)
            {
                Console.WriteLine(current);
                current = current.Next;
            }
        }

        public Point<T>? FindItem(T item)
        {
            Point<T>? current = beg;
            while (current != null)
            {
                if (current.Data == null)
                    throw new Exception("Data is null");
                if (current.Data.Equals(item))
                    return current;
                current = current.Next;
            }
            return null;
        }

        public bool RemoveItem(T item)
        {
            if (beg == null) throw new Exception("the list is empty");
            Point<T>? pos = FindItem(item);
            if (pos == null) return false;

            count--;

            // One element
            if (beg == end)
            {
                beg = end = null;
                return true;
            }

            // The first
            if (pos.Pred == null)
            {
                beg = beg?.Next;
                beg.Pred = null;
                return true;
            }

            // The last
            if (pos.Next == null)
            {
                end = end?.Pred;
                end.Next = null;
                return true;
            }

            // middle element
            Point<T> next = pos.Next;
            Point<T> pred = pos.Pred;
            next.Pred = pred;
            pred.Next = next;

            return true;
        }
        public void RemoveAllItems(T item)
        {
            Point<T>? current = FindItem(item);
            while (current != null)
            {
                RemoveItem(current.Data);
                current = FindItem(item);
            }
        }
        public void AddKItemsToBeg(int K)
        {
            for (int i = 0; i < K; i++)
            {
                T newItem = MakeRandomItem();
                AddToBegin(newItem);
            }
        }
        public MyList<T> DeepClone()
        {
            MyList<T> newList = new MyList<T>();
            Point<T>? current = beg;
            while (current != null)
            {
                T clonedData = (T)current.Data.Clone();
                Point<T> newPoint = new Point<T>(clonedData);

                if (newList.beg == null)
                {
                    newList.beg = newPoint;
                    newList.end = newPoint;
                }
                else
                {
                    newList.end.Next = newPoint;
                    newPoint.Pred = newList.end;
                    newList.end = newPoint;
                }

                current = current.Next;
            }

            newList.count = this.count;
            return newList;
        }
    }
}