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
    /// <typeparam name="T">Тип данных объекта</typeparam>
    public interface ISorter<T>
    {
        /// <summary>
        /// Сигнатура функции, сравнивающей значения элементов
        /// </summary>
        /// <param name="val1">Первый сравниваемый элемент</param>
        /// <param name="val2">Второй сравниваемый элемент</param>
        /// <returns>
        /// любое число больше 0: val1 > val2
        /// 0: val1 == val2
        /// любое число меньше 0: val1 < val2
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
        /// <summary>
        /// Выполняет блинную сортировку на основе данных
        /// функций сортировки
        /// </summary>
        /// <param name="comparators">
        /// Набор функций-компараторов, на основе которых будет выполняться сравнение 
        /// объектов и соответсвенно сортировка. В случае, если i-тая функция покажет равенство,
        /// будет выполняться сравнение в соотвтствии с i+1-ой
        /// </param>
        void PancakeSort(params ISorter<T>.Comparator[] comparators);

    }
    /// <summary>
    /// Класс-надстройка над индексированной последовательностью элементов,
    /// предоставляющий методы сортировки объектов
    /// по произвольному набору методов-компараторов
    /// </summary>
    /// <typeparam name="T">Тип сортируемых данных</typeparam>
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
            for (int i = 0; i < _values.Count; i++)
            {
                for (int j = i + 1; j < _values.Count; j++)
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
            int low = 0;
            int high = _values.Count - 1;

            FastSortInternal(comparators, low, high);
        }
        /// <summary>
        /// Вспомогательная рекурсивная функция для быстрой сортировки
        /// </summary>
        /// <param name="comparators"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        private void FastSortInternal(ISorter<T>.Comparator[] comparators, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(comparators, low, high);

                Parallel.Invoke(
                () => { FastSortInternal(comparators, low, pivotIndex - 1); },
                () => { FastSortInternal(comparators, pivotIndex + 1, high); }
                );
            }
        }
        /// <summary>
        /// Вспомогательная фукция для быстрой сортировки
        /// </summary>
        /// <param name="comparators"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        private int Partition(ISorter<T>.Comparator[] comparators, int low, int high)
        {
            T pivot = _values[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (GreaterOrEquals(comparators, pivot, _values[j]))
                {
                    i++;
                    Swap(i, j);
                }
            }

            Swap(i + 1, high);
            return i + 1;
        }
        /// <summary>
        /// Проверяет упорядоченность массива для BogoBogo сортировки
        /// </summary>
        /// <param name="list"></param>
        /// <param name="comparators"></param>
        /// <returns></returns>
        private bool IsSorted(params ISorter<T>.Comparator[] comparators)
        {
            for (int i = 0; i < _values.Count - 1; i++)
                if (Greater(comparators, _values[i], _values[i + 1]))
                    return false;
            return true;
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
            Random rand = new Random();
            while (!IsSorted(comparators))
                for (int i = 0; i < _values.Count; i++)
                    for (int j = i + 1; j < _values.Count; j++)
                        Swap(rand.Next(i, _values.Count - 1), rand.Next(j, _values.Count - 1));
        }
        /// <summary>
        /// Выполняет сортировку на основе данных функций сортировки
        /// Методом блинной сортировки
        /// </summary>
        /// <param name="comparators"></param>
        public void PancakeSort(params ISorter<T>.Comparator[] comparators)
        {
            for (var subArrayLength = _values.Count - 1; subArrayLength >= 0; subArrayLength--)
            {
                var indexOfMax = IndexOfMax(comparators, subArrayLength);
                if (indexOfMax != subArrayLength)
                {
                    //переворот массива до индекса максимального элемента
                    Flip(indexOfMax);
                    Flip(subArrayLength);
                }
            }
        }
        /// <summary>
        /// Метод для получения индекса максимального элемента
        /// </summary>
        /// <param name="comparators"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private int IndexOfMax(ISorter<T>.Comparator[] comparators, int n)
        {
            int result = 0;
            for (var i = 1; i <= n; ++i)
            {
                if (GreaterOrEquals(comparators, _values[i], _values[result]))
                {
                    result = i;
                }
            }
            return result;
        }
        /// <summary>
        /// Метод для переворота элементов
        /// </summary>
        /// <param name="end"></param>
        private void Flip(int end)
        {
            for (var start = 0; start < end; start++, end--)
            {
                var temp = _values[start];
                _values[start] = _values[end];
                _values[end] = temp;
            }
        }
        /// <summary>
        /// Случайно перемешивает текущую последовательность
        /// </summary>
        public void Randomize()
        {
            Random rnd = new Random();
            for (int i = 0; i < _values.Count; i++)
            {
                int rndIndex = rnd.Next(0, _values.Count - 1);
                Swap(i, rndIndex);
            }
        }
        /// <summary>
        /// Возвращает строковое отбражение последовательности
        /// </summary>
        /// <returns>Строковое отображение последовательности</returns>
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
        /// Выполняет обмен элементов
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
        /// Проверяет 2 элемента на основе массива функций компараторов
        /// на равернство
        /// </summary>
        /// <param name="comparators">Массив фукнций компараторов</param>
        /// <param name="val1">Первый сравниваемый элемент</param>
        /// <param name="val2">Второй сравниваемый элемент</param>
        /// <returns>
        /// True: val1 >= val2
        /// False: val < va2
        /// </returns>
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

        /// <summary>
        /// Проверяет 2 элемента на основе массива функций компараторов
        /// на равернство
        /// </summary>
        /// <param name="comparators">Массив фукнций компараторов</param>
        /// <param name="val1">Первый сравниваемый элемент</param>
        /// <param name="val2">Второй сравниваемый элемент</param>
        /// <returns>
        /// True: val1 > val2
        /// False: val <= va2
        /// </returns>
        private static bool Greater(ISorter<T>.Comparator[] comparators, T val1, T val2)
        {
            for (int i = 0; i < comparators.Length; i++)
            {
                int res = comparators[i](val1, val2);
                if (res > 0) return true;
                if (res < 0) return false;
            }
            return false;
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
