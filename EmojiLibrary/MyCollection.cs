using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EmojiLibrary
{
    public class MyCollection<T> : MyList<T>, IEnumerable<T>, IList<T> where T : IInit, ICloneable, new()
    {
        public MyCollection() : base() { }
        public MyCollection(int size) : base(size) { }
        public MyCollection(MyCollection<T> collection) : base()
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection), "The collection cannot be null.");
            }

            // Копируем первый элемент коллекции, если он существует
            if (collection.beg != null)
            {
                T clonedFirstItem = (T)collection.beg.Data.Clone();
                AddToEnd(clonedFirstItem);
            }

            // Проходим по всем остальным элементам коллекции и копируем их
            Point<T>? current = collection.beg?.Next;
            while (current != null)
            {
                T clonedItem = (T)current.Data.Clone();
                AddToEnd(clonedItem);
                current = current.Next;
            }
        }

        int count = 0;
        private MyCollection<Emoji> list;

        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int IndexOf(T item)
        {
            int index = 0;
            Point<T>? current = beg;
            while (current != null)
            {
                if (current.Data.Equals(item))
                    return index;
                current = current.Next;
                index++;
            }
            return -1;
        }

        public virtual void Insert(int index, T item)
        {
            if (index < 0 || index > Count) throw new ArgumentOutOfRangeException(nameof(index));

            if (index == 0)
            {
                AddToBegin(item);
                return;
            }

            if (index == Count)
            {
                AddToEnd(item);
                return;
            }

            Point<T>? current = beg;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            Point<T> newItem = new Point<T>((T)item.Clone());
            newItem.Next = current;
            newItem.Pred = current.Pred;
            if (current.Pred != null)
                current.Pred.Next = newItem;
            current.Pred = newItem;
            count++;
        }

        public virtual void RemoveAt(int index)
        {
            if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException(nameof(index));

            Point<T>? current = beg;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            if (current != null)
                RemoveItem(current.Data);
        }

        public virtual T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException(nameof(index));

                Point<T>? current = beg;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                return current.Data;
            }
            set
            {
                if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException(nameof(index));

                Point<T>? current = beg;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                current.Data = (T)value.Clone();
            }
        }

        public bool IsReadOnly => false;

        public virtual void Add(T item)
        {
            AddToEnd(item);
        }

        public void Clear()
        {
            beg = null;
            end = null;
            count = 0;
        }

        public bool Contains(T item)
        {
            return FindItem(item) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            if (array.Length - arrayIndex < Count) throw new ArgumentException("The array is too small.");

            Point<T>? current = beg;
            for (int i = arrayIndex; i < arrayIndex + Count; i++)
            {
                if (current != null)
                {
                    array[i] = (T)current.Data.Clone();
                    current = current.Next;
                }
            }
        }

        public virtual bool Remove(T item)
        {
            return RemoveItem(item);
        }
    }

    public class MyEnumerator<T> : IEnumerator<T> where T : IInit, ICloneable, new()
    {
        Point<T>? beg;
        Point<T>? current;

        public MyEnumerator(MyCollection<T> collection)
        {
            beg = collection.beg;
            current = beg;
        }
        public T Current => current.Data;
        object IEnumerator.Current => current.Data;

        public void Dispose() { }

        public bool MoveNext()
        {
            if (current == null || current.Next == null)
            {
                return false;
            }
            else
            {
                current = current.Next;
                return true;
            }
        }

        public void Reset()
        {
            current = beg;
        }
    }
}