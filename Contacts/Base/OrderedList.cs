using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Contacts
{
    /// <summary>
    /// Represents a list of objects that are sorted by the values of a determined function with the objects as inputs.
    /// </summary>
    public class OrderedList<T> : IEnumerable
        where T : class
    {
        private List<T> list = new List<T>();

        private Func<T, object> extraction;

        /// <summary>
        /// The function that extracts the values that the objects are sorted by.
        /// </summary>
        public Func<T, object> Extraction
        {
            get { return extraction; }
            set
            {
                extraction = value;
                sort();
            }
        }

        private void sort() => list = list.OrderBy(extraction).ToList();

        public int Count => list.Count;

        public T this[int index] => list[index];

        public int IndexOf(T item) => list.IndexOf(item);

        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
            sort();
        }

        public void Add(T item)
        {
            list.Add(item);
            sort();
        }

        public void Clear() => list.Clear();

        public bool Contains(T item) => list.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => list.CopyTo(array, arrayIndex);

        public bool Remove(T item)
        {
            bool result = list.Remove(item);
            sort();
            return result;
        }

        public IEnumerator<T> GetEnumerator() => list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => list.GetEnumerator();

        public List<T> ToList() => list;

        public T[] ToArray() => list.ToArray();

        /// <summary>
        /// Initializes a new instance of the <c>SortedList</c> type.
        /// </summary>
        public OrderedList(Func<T, object> extraction) => this.extraction = extraction;

        /// <summary>
        /// Initializes a new instance of the <c>SortedList</c> type.
        /// </summary>
        public OrderedList(Func<T, object> extraction, List<T> list)
        {
            this.list.AddRange(list);
            this.extraction = extraction;
            sort();
        }
    }
}