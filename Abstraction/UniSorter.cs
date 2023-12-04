using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    /// <summary>
    /// Интерфейс, отображающий возможность сортировки объектов произвольного типа
    /// </summary>
    /// <typeparam name="T">Тип объекта</typeparam>
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
        /// <summary>
        /// Выполняет пузырьковую сортировку на основе данных
        /// функций сортировки
        /// </summary>
        /// <param name="comparators">
        /// Набор функций-компараторов, на основе которых будет выполняться сравнение 
        /// объектов и соответсвенно сортировка. В случае, если i-тая функция покажет равенство,
        /// будет выполняться сравнение в соотвтствии с i+1-ой
        /// </param>
        void BubbleSort(params ISorter<T>.Comparator[] comparators);
        /// <summary>
        /// Выполняет сортировку вставками на основе данных
        /// функций сортировки
        /// </summary>
        /// <param name="comparators">
        /// Набор функций-компараторов, на основе которых будет выполняться сравнение 
        /// объектов и соответсвенно сортировка. В случае, если i-тая функция покажет равенство,
        /// будет выполняться сравнение в соотвтствии с i+1-ой
        /// </param>
        void InsertSort(params ISorter<T>.Comparator[] comparators);
        /// <summary>
        /// Выполняет сортировку Шелла на основе данных
        /// функций сортировки
        /// </summary>
        /// <param name="comparators">
        /// Набор функций-компараторов, на основе которых будет выполняться сравнение 
        /// объектов и соответсвенно сортировка. В случае, если i-тая функция покажет равенство,
        /// будет выполняться сравнение в соотвтствии с i+1-ой
        /// </param>
        void ShellSort(params ISorter<T>.Comparator[] comparators);
        /// <summary>
        /// Выполняет быструю сортировку на основе данных
        /// функций сортировки
        /// </summary>
        /// <param name="comparators">
        /// Набор функций-компараторов, на основе которых будет выполняться сравнение 
        /// объектов и соответсвенно сортировка. В случае, если i-тая функция покажет равенство,
        /// будет выполняться сравнение в соотвтствии с i+1-ой
        /// </param>
        void FastSort(params ISorter<T>.Comparator[] comparators);
        /// <summary>
        /// Выполняет Bogo Bogo сортировку на основе данных
        /// функций сортировки
        /// </summary>
        /// <param name="comparators">
        /// Набор функций-компараторов, на основе которых будет выполняться сравнение 
        /// объектов и соответсвенно сортировка. В случае, если i-тая функция покажет равенство,
        /// будет выполняться сравнение в соотвтствии с i+1-ой
        /// </param>
        void BogoBogoSort(params ISorter<T>.Comparator[] comparators);

    }
    /// <summary>
    /// Класс-надстройка над индексированной последовательностью элементов,
    /// предоставляющий методы сортировки объектов
    /// по произвольному набору методов-компараторов
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class UniSorter<T> : IList<T>, ISorter<T>
    {
        /// <summary>
        /// Последовательности элементов
        /// </summary>
        private IList<T> _values;
        /// <summary>
        /// Создает экземпляр класса, создавая в качестве сортируемой последовательности
        /// новый пустой список
        /// </summary>
        public UniSorter()
        {
            _values = new List<T>();
        }
        /// <summary>
        /// Создает экземпляр класса на основе последовательности 
        /// элементов 
        /// </summary>
        /// <param name="values"></param>
        public UniSorter(IList<T> values)
        {
            _values = values;
        }
        /// <summary>
        /// Выполняет пузырьковую сортировку на основе данных
        /// функций сортировки
        /// </summary>
        /// <param name="comparators">
        /// Набор функций-компараторов, на основе которых будет выполняться сравнение 
        /// объектов и соответсвенно сортировка. В случае, если i-тая функция покажет равенство,
        /// будет выполняться сравнение в соотвтствии с i+1-ой
        /// </param>
        public void BubbleSort(params ISorter<T>.Comparator[] comparators)
        {
            for (int i = 0; i<_values.Count; i ++)
            {
                for ( int j = i + 1; j < _values.Count; j++)
                {
                    if (GreaterOrEquals(comparators, _values[i], _values[j]))
                        Swap(i, j);
                }
            }
        }
        /// <summary>
        /// Выполняет сортировку вставками на основе данных
        /// функций сортировки
        /// </summary>
        /// <param name="comparators">
        /// Набор функций-компараторов, на основе которых будет выполняться сравнение 
        /// объектов и соответсвенно сортировка. В случае, если i-тая функция покажет равенство,
        /// будет выполняться сравнение в соотвтствии с i+1-ой
        /// </param>
        public void InsertSort(params ISorter<T>.Comparator[] comparators)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
        /// <summary>
        /// Выполняет быструю сортировку на основе данных
        /// функций сортировки
        /// </summary>
        /// <param name="comparators">
        /// Набор функций-компараторов, на основе которых будет выполняться сравнение 
        /// объектов и соответсвенно сортировка. В случае, если i-тая функция покажет равенство,
        /// будет выполняться сравнение в соотвтствии с i+1-ой
        /// </param>
        public void FastSort(params ISorter<T>.Comparator[] comparators)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Выполняет Bogo Bogo сортировку на основе данных
        /// функций сортировки
        /// </summary>
        /// <param name="comparators">
        /// Набор функций-компараторов, на основе которых будет выполняться сравнение 
        /// объектов и соответсвенно сортировка. В случае, если i-тая функция покажет равенство,
        /// будет выполняться сравнение в соотвтствии с i+1-ой
        /// </param>
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
