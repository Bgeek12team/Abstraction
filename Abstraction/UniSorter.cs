using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
    public class UniSorter<T> : IList<T>, ISorter<T>
    {
        private IList<T> _values;
        public UniSorter(IList<T> values)
        {
            _values = values;
        }
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
            for (int i = 1; i < _values.Count; i++)
            {
                T k = _values[i];
                int j = i - 1;
                while (j >= 0 && Greater(comparators, _values[j], k))
                {
                    _values[j + 1] = _values[j];
                    j--;
                }
                _values[j + 1] = k;
            }
        }
        /// <summary>
        /// Выполняет сортировку Шелла на основе данных
        /// функций сортировки
        /// </summary>
        /// <param name="comparators">
        /// Набор функций-компараторов, на основе которых будет выполняться сравнение 
        /// объектов и соответсвенно сортировка. В случае, если i-тая функция покажет равенство,
        /// будет выполняться сравнение в соотвтствии с i+1-ой
        /// </param>
        public void ShellSort(params ISorter<T>.Comparator[] comparators)
        {
            int n = _values.Count;
            int gap = n / 2;

            while (gap > 0)
            {
                for (int i = gap; i < n; i++)
                {
                    T temp = _values[i];
                    int j = i;

                    while (j >= gap && GreaterOrEquals(comparators, _values[j - gap], temp))
                    {
                        _values[j] = _values[j - gap];
                        j -= gap;
                    }

                    _values[j] = temp;
                }

                gap /= 2;
            }
        }

        public void FastSort(params ISorter<T>.Comparator[] comparators)
        {
            int low = 0;
            int high = _values.Count - 1;

            FastSortInternal(comparators, low, high);
        }
        private void FastSortInternal(ISorter<T>.Comparator[] comparators, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(comparators, low, high);

                FastSortInternal(comparators, low, pivotIndex - 1);
                FastSortInternal(comparators, pivotIndex + 1, high);
            }
        }

        private int Partition(ISorter<T>.Comparator[] comparators, int low, int high)
        {
            T pivot = _values[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (GreaterOrEquals(comparators, _values[j], pivot))
                {
                    i++;
                    Swap(i, j);
                }
            }

            Swap(i + 1, high);
            return i + 1;
        }

        public void BogoBogoSort(params ISorter<T>.Comparator[] comparators)
        {
            throw new NotImplementedException();
        }

        public void Randomize()
        {
            int[] index = new int[_values.Count];
            Random rnd = new Random();
            for (int i = 0; i < index.Length; i++)
            {
                int rndIndex = rnd.Next(0, index.Length - 1);
                Swap(i, rndIndex);
            }
        }
        public override string ToString()
        {
            string res = String.Empty;
            foreach (T element in _values)
            {
                res += element.ToString() + " ";
            }
            return res;
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
