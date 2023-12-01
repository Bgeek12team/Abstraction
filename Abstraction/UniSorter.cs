using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public interface ISorter<T>
    {
        /// <summary>
        /// Сигнатура функции, сравнивающей значения элементов
        /// </summary>
        /// <param name="val1">Первый сравниваемый элемент</param>
        /// <param name="val2">Второй сравниваемый элемент</param>
        /// <returns>
        /// 1: val1 > val2
        /// 0: val1 == val2
        /// -1: val1 < val2
        /// </returns>
        delegate int Comparator(T val1, T val2);
        void BubbleSort(params ISorter<T>.Comparator[] comparators);
        void InsertSort(params ISorter<T>.Comparator[] comparators);
        void ShellSort(params ISorter<T>.Comparator[] comparators);
        void FastSort(params ISorter<T>.Comparator[] comparators);
        void BogoBogoSort(params ISorter<T>.Comparator[] comparators);

    }
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class UniSorter<T> : IList<T>, ISorter<T>
    {
        private IList<T> _values;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        public UniSorter(IList<T> values)
        {
            _values = values;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="comparators"></param>
        public void BubbleSort(params ISorter<T>.Comparator[] comparators)
        {
            for (int i = 0; i<_values.Count; i ++)
            {
                for ( int j = i; j < _values.Count; j++)
                {
                    if (GreaterOrEquals(comparators, _values[i], _values[j]))
                        Swap(i, j);
                }
            }
        }


        public void InsertSort(params ISorter<T>.Comparator[] comparators)
        {
            throw new NotImplementedException();
        }

        public void ShellSort(params ISorter<T>.Comparator[] comparators)
        {
            throw new NotImplementedException();
        }

        public void FastSort(params ISorter<T>.Comparator[] comparators)
        {
            throw new NotImplementedException();
        }

        public void BogoBogoSort(params ISorter<T>.Comparator[] comparators)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void Swap(int i, int j)
        {
            T temp = _values[i];
            _values[i] = _values[j];
            _values[j] = temp;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="comparators"></param>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        private static bool GreaterOrEquals(ISorter<T>.Comparator[] comparators, T val1, T val2)
        {
            for (int i = 0; i < comparators.Length; i++)
            {
                int res = comparators[i](val1, val2);
                if (res > 0) return true;
                if (res < 0) return false;
            }
            return true;
        }

        #region IListMethods

        public T this[int index] { get => _values[index]; set => _values[index] = value; }

        public int Count => _values.Count;

        public bool IsReadOnly => _values.IsReadOnly;

        public void Add(T item)
        {
            _values.Add(item);
        }

        public void Clear()
        {
            _values.Clear();
        }

        public bool Contains(T item)
        {
            return _values.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _values.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _values.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return _values.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _values.Insert(index, item);
        }

        public bool Remove(T item)
        {
            return _values.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _values.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_values).GetEnumerator();
        }

        #endregion
    }
}
