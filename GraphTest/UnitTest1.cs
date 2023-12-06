using Abstraction;
namespace GraphTests
{
    /// <summary>
    /// Класс проверяющий работу методов класса GraphOnMatrixADJ
    /// </summary>
    [TestClass]
    public class GraphOnMatr
    {
        /// <summary>
        /// Тестирующий метод осуществляющий проверку метода AddEdge класса GraphOnMatrixADJ
        /// </summary>
        [TestMethod]
        public void AddEgde1()
        {
            int[,] adj = {
                {0,1,1 },
                {1,0,1 },
                {1,1,0 } };
            GraphOnMatrixADJ graphOnMatrixADJ = new GraphOnMatrixADJ(adj);
            graphOnMatrixADJ.AddEdge(1, 1, 5);
            int[,] res = {
                {0,1,1 },
                {1,5,1 },
                {1,1,0 } };
            GraphOnMatrixADJ result = new GraphOnMatrixADJ(res);
            bool r = result.Equals(graphOnMatrixADJ);
            Assert.AreEqual(true, r);
        }
        /// <summary>
        /// Тест проверяющий добавление ребер длины 0 в граф
        /// </summary>
        [TestMethod]
        public void AddEgdeZero()
        {
            int[,] adj = {
                {0,1,1 },
                {1,0,1 },
                {1,1,0 } };
            GraphOnMatrixADJ graphOnMatrixADJ = new GraphOnMatrixADJ(adj);
            for (int i = 0; i < adj.GetLength(0); i++)
                for (int j = 0; j < adj.GetLength(1); j++)
                    graphOnMatrixADJ.AddEdge(i, j, 0);
            int[,] res = {
                {0,0,0 },
                {0,0,0 },
                {0,0,0 } };
            GraphOnMatrixADJ result = new GraphOnMatrixADJ(res);
            bool r = result.Equals(graphOnMatrixADJ);
            Assert.AreEqual(true, r);
        }
        /// <summary>
        /// Тест проверябщий добавлние ребер длины 1000000 в пустой граф(не имеющий ребер)
        /// </summary>
        [TestMethod]
        public void AddEgdeBigEdge()
        {
            int[,] adj = {
                {0,0,0 },
                {0,0,0 },
                {0,0,0 } };
            GraphOnMatrixADJ graphOnMatrixADJ = new GraphOnMatrixADJ(adj);
            for (int i = 0; i < adj.GetLength(0); i++)
                for (int j = 0; j < adj.GetLength(1); j++)
                    graphOnMatrixADJ.AddEdge(i, j, 1000000);
            int[,] res = {
                {1000000,1000000,1000000 },
                {1000000,1000000,1000000 },
                {1000000,1000000,1000000 } };
            GraphOnMatrixADJ result = new GraphOnMatrixADJ(res);
            bool r = result.Equals(graphOnMatrixADJ);
            Assert.AreEqual(true, r);
        }
        /// <summary>
        /// Тест проверяющий удаление всех ребер матрицы смежности
        /// </summary>
        [TestMethod]
        public void RemoveAllEdge()
        {
            int[,] adj = {
                {12,12,12 },
                {13,13,13 },
                {14,14,14 } };
            GraphOnMatrixADJ graphOnMatrixADJ = new GraphOnMatrixADJ(adj);
            for (int i = 0; i < adj.GetLength(0); i++)
                for (int j = 0; j < adj.GetLength(1); j++)
                    graphOnMatrixADJ.RemoveEdge(i, j);
            int[,] res = {
                {0,0,0 },
                {0,0,0 },
                {0,0,0 } };
            GraphOnMatrixADJ result = new GraphOnMatrixADJ(res);
            bool r = result.Equals(graphOnMatrixADJ);
            Assert.AreEqual(true, r);
        }
        /// <summary>
        /// Тест проверяющий удаление элемента матрицы смежности
        /// </summary>
        [TestMethod]
        public void RemoveEdge()
        {
            int[,] adj = {
                {10} };
            GraphOnMatrixADJ graphOnMatrixADJ = new GraphOnMatrixADJ(adj);
            graphOnMatrixADJ.RemoveEdge(0, 0);
            int[,] res = {
                {0} };
            GraphOnMatrixADJ result = new GraphOnMatrixADJ(res);
            bool r = result.Equals(graphOnMatrixADJ);
            Assert.AreEqual(true, r);
        }
        /// <summary>
        /// Тест проверяющий удаление элементов верхнего треугольника матрицы смежности
        /// </summary>

        [TestMethod]
        public void RemoveEdgej()
        {
            int[,] adj = {
                {12,12,12,10 },
                {13,13,13,11 },
                {14,14,14,9 },
                {10,10,10,10 } };
            GraphOnMatrixADJ graphOnMatrixADJ = new GraphOnMatrixADJ(adj);
            for (int i = 0; i < adj.GetLength(0); i++)
                for (int j = i; j < adj.GetLength(1); j++)
                    graphOnMatrixADJ.RemoveEdge(i, j);
            int[,] res = {
                {0,0,0,0 },
                {13,0,0,0 },
                {14,14,0,0 },
                {10,10,10,0 },};
            GraphOnMatrixADJ result = new GraphOnMatrixADJ(res);
            bool r = result.Equals(graphOnMatrixADJ);
            Assert.AreEqual(true, r);
        }
        /// <summary>
        /// Теструющий метод проверяющий метод EdgeLength класса GraphOnMatrixADJ
        /// </summary>
        [TestMethod]
        public void EdgeLen()
        {
            int[,] adj = {
                {0,3,0},
                {0,0,1 },
                {0,1,0 } };
            GraphOnMatrixADJ graphOnMatrixADJ = new GraphOnMatrixADJ(adj);
            int res = 3;
            Assert.AreEqual(graphOnMatrixADJ.EdgeLength(0, 1), res);
        }
        /// <summary>
        /// Теструющий метод проверяющий метод EdgeLength класса GraphOnMatrixADJ
        /// </summary>
        [TestMethod]
        public void EdgeLen1()
        {
            int[,] adj = {
                {1000000,1000000,1000000 },
                {1000000,9,1000000 },
                {1000000,1000000,1000000 } };
            GraphOnMatrixADJ graphOnMatrixADJ = new GraphOnMatrixADJ(adj);
            int res = 9;
            Assert.AreEqual(graphOnMatrixADJ.EdgeLength(1, 1), res);
        }
        /// <summary>
        /// Теструющий метод проверяющий метод EdgeLength класса GraphOnMatrixADJ
        /// </summary>
        [TestMethod]
        public void EdgeLenZeros()
        {
            int[,] adj = {
                {0,0,0 },
                {0,0,0 },
                {0,0,0 } };
            GraphOnMatrixADJ graphOnMatrixADJ = new GraphOnMatrixADJ(adj);
            Assert.AreEqual(graphOnMatrixADJ.EdgeLength(0, 2), 0);
        }

    }
    /// <summary>
    /// Тесты класса GraphOnList
    /// </summary>
    [TestClass]
    public class GraphOnList
    {
        /// <summary>
        /// Теструющий метод проверяющий метод AddEdge класса GraphOnADJList
        /// </summary>
        [TestMethod]
        public void AddEdge1()
        {
            int n = 2;
            List<(int indxVert, int cost)>[] adjList = new List<(int indxVert, int cost)>[n];
            adjList[0] = new List<(int indxVert, int cost)>();
            adjList[0].Add((0, 5));
            adjList[1] = new List<(int indxVert, int cost)>();
            adjList[1].Add((1, 5));
            GraphOnADJList list1 = new(adjList);
            GraphOnADJList list = new(n);
            list.AddEdge(0, 0, 5);
            list.AddEdge(1, 1, 5);
            Assert.IsTrue(list.Equals(list1));

        }
        /// <summary>
        /// Теструющий метод проверяющий метод AddEdge класса GraphOnADJList
        /// </summary>
        [TestMethod]
        public void AddEdge2()
        {
            int n = 3;
            List<(int indxVert, int cost)>[] adjList = new List<(int indxVert, int cost)>[n];
            adjList[0] = new List<(int indxVert, int cost)>();
            adjList[0].Add((0, 0)); adjList[0].Add((1, 1)); adjList[0].Add((2, 1));
            adjList[1] = new List<(int indxVert, int cost)>();
            adjList[1].Add((0, 1)); adjList[1].Add((1, 5)); adjList[1].Add((2, 1));
            adjList[2] = new List<(int indxVert, int cost)>();
            adjList[2].Add((0, 1)); adjList[2].Add((1, 1)); adjList[2].Add((2, 0));
            GraphOnADJList list1 = new(adjList);
            GraphOnADJList list = new(n);
            list.AddEdge(0, 0, 0); list.AddEdge(0, 1, 1); list.AddEdge(0, 2, 1);
            list.AddEdge(1, 0, 1); list.AddEdge(1, 1, 5); list.AddEdge(1, 2, 1);
            list.AddEdge(2, 0, 1); list.AddEdge(2, 1, 1); list.AddEdge(2, 2, 0);
            Assert.IsTrue(list.Equals(list1));
        }
        /// <summary>
        /// Теструющий метод проверяющий метод AddEdge класса GraphOnADJList
        /// </summary>
        [TestMethod]
        public void AddEdge3()
        {
            int n = 3;
            List<(int indxVert, int cost)>[] adjList = new List<(int indxVert, int cost)>[n];
            adjList[0] = new List<(int indxVert, int cost)>();
            adjList[0].Add((0, 0)); adjList[0].Add((1, 0)); adjList[0].Add((2, 0));
            adjList[1] = new List<(int indxVert, int cost)>();
            adjList[1].Add((0, 0)); adjList[1].Add((1, 0)); adjList[1].Add((2, 0));
            adjList[2] = new List<(int indxVert, int cost)>();
            adjList[2].Add((0, 0)); adjList[2].Add((1, 0)); adjList[2].Add((2, 0));
            GraphOnADJList list1 = new(adjList);
            GraphOnADJList list = new(n);
            list.AddEdge(0, 0, 0); list.AddEdge(0, 1, 0); list.AddEdge(0, 2, 0);
            list.AddEdge(1, 0, 0); list.AddEdge(1, 1, 0); list.AddEdge(1, 2, 0);
            list.AddEdge(2, 0, 0); list.AddEdge(2, 1, 0); list.AddEdge(2, 2, 0);
            Assert.IsTrue(list.Equals(list1));
        }
        /// <summary>
        /// Теструющий метод проверяющий метод AddEdge класса GraphOnADJList
        /// </summary>
        [TestMethod]
        public void AddEdge4()
        {
            int n = 3;
            List<(int indxVert, int cost)>[] adjList = new List<(int indxVert, int cost)>[n];
            adjList[0] = new List<(int indxVert, int cost)>();
            adjList[0].Add((0, 1000000)); adjList[0].Add((1, 1000000)); adjList[0].Add((2, 1000000));
            adjList[1] = new List<(int indxVert, int cost)>();
            adjList[1].Add((0, 1000000)); adjList[1].Add((1, 1000000)); adjList[1].Add((2, 1000000));
            adjList[2] = new List<(int indxVert, int cost)>();
            adjList[2].Add((0, 1000000)); adjList[2].Add((1, 1000000)); adjList[2].Add((2, 1000000));
            GraphOnADJList list1 = new(adjList);
            GraphOnADJList list = new(n);
            list.AddEdge(0, 0, 1000000); list.AddEdge(0, 1, 1000000); list.AddEdge(0, 2, 1000000);
            list.AddEdge(1, 0, 1000000); list.AddEdge(1, 1, 1000000); list.AddEdge(1, 2, 1000000);
            list.AddEdge(2, 0, 1000000); list.AddEdge(2, 1, 1000000); list.AddEdge(2, 2, 1000000);
            Assert.IsTrue(list.Equals(list1));
        }
        /// <summary>
        /// Теструющий метод проверяющий метод RemoveEdge класса GraphOnADJList
        /// </summary>
        [TestMethod]
        public void Removeedge()
        {
            int n = 3;
            List<(int indxVert, int cost)>[] adjList = new List<(int indxVert, int cost)>[n];
            adjList[0] = new List<(int indxVert, int cost)>();
            adjList[0].Add((0, 12)); adjList[0].Add((1, 12)); adjList[0].Add((2, 12));
            adjList[1] = new List<(int indxVert, int cost)>();
            adjList[1].Add((0, 13)); adjList[1].Add((1, 13)); adjList[1].Add((2, 13));
            adjList[2] = new List<(int indxVert, int cost)>();
            adjList[2].Add((0, 14)); adjList[2].Add((1, 14)); adjList[2].Add((2, 14));
            GraphOnADJList list1 = new(adjList);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    list1.RemoveEdge(i, j);
            GraphOnADJList list = new(n);
            Assert.IsTrue(list.Equals(list1));
        }
        /// <summary>
        /// Теструющий метод проверяющий метод EdgeLength класса GraphOnADJList
        /// </summary>
        [TestMethod]
        public void GetEdgeLeght()
        {
            int n = 3;
            List<(int indxVert, int cost)>[] adjList = new List<(int indxVert, int cost)>[n];
            adjList[0] = new List<(int indxVert, int cost)>();
            adjList[0].Add((0, 12)); adjList[0].Add((1, 100000000)); adjList[0].Add((2, 12));
            adjList[1] = new List<(int indxVert, int cost)>();
            adjList[1].Add((0, 13)); adjList[1].Add((1, 13)); adjList[1].Add((2, 13));
            adjList[2] = new List<(int indxVert, int cost)>();
            adjList[2].Add((0, 14)); adjList[2].Add((1, 14)); adjList[2].Add((2, 14));
            GraphOnADJList list1 = new(adjList);
            Assert.AreEqual(100000000, list1.EdgeLength(0, 1));
        }
    }
    /// <summary>
    /// Класс, проверяющий работу методов сортировки
    /// </summary>
    [TestClass]
    public class TestSorts
    {
        /// <summary>
        /// Тест проверяет работу пузырьковой сортировки
        /// </summary>
        [TestMethod]
        public void TestBubble()
        {
            IList<double> nums = new List<double> { -1.9, -6, -2.5, -4.3 };
            IList<double> nums1 = new List<double>() { -6, -4.3, -2.5, -1.9 };
            UniSorter<double> ints = new UniSorter<double>(nums);
            UniSorter<double> ints1 = new UniSorter<double>(nums1);
            ISorter<double>.Comparator comparebymax = new ISorter<double>.Comparator((p1, p2) => (int)(p1 - p2));
            ints.BubbleSort(comparebymax);
            Assert.AreEqual(ints1.ToString(), ints.ToString());
        }
        /// <summary>
        /// Тест проверяет работу сортировки вставками
        /// </summary>
        [TestMethod]
        public void TestInsert()
        {
            IList<int> nums = new List<int> { -6, 0, 2, 0, 0, -2, -4, 0, 5, 7, 2 };
            IList<int> nums1 = new List<int>() { -6, -4, -2, 0, 0, 0, 0, 2, 2, 5, 7 };
            UniSorter<int> ints = new UniSorter<int>(nums);
            UniSorter<int> ints1 = new UniSorter<int>(nums1);
            ISorter<int>.Comparator comparebymax = new ISorter<int>.Comparator((p1, p2) => p1 - p2);
            ints.InsertSort(comparebymax);
            Assert.AreEqual(ints1.ToString(), ints.ToString());
        }
        /// <summary>
        /// Тест проверяет работу сортировки Шелла
        /// </summary>
        [TestMethod]
        public void TestShell()
        {
            IList<int> nums = new List<int> { 218391, -3210321, 0, 23, 12932138, 321032193, -2313120 };
            IList<int> nums1 = new List<int>() { -3210321, -2313120, 0, 23, 218391, 12932138, 321032193 };
            UniSorter<int> ints = new UniSorter<int>(nums);
            UniSorter<int> ints1 = new UniSorter<int>(nums1);
            ISorter<int>.Comparator comparebymax = new ISorter<int>.Comparator((p1, p2) => p1 - p2);
            ints.ShellSort(comparebymax);
            Assert.AreEqual(ints1.ToString(), ints.ToString());
        }
        /// <summary>
        /// Тест проверяет работу быстрой сортировки
        /// </summary>
        [TestMethod]
        public void TestFast()
        {
            IList<int> nums = new List<int> { -1111, 321321, -32932, 23132131 };
            IList<int> nums1 = new List<int>() { -32932, -1111, 321321, 23132131 };
            UniSorter<int> ints = new UniSorter<int>(nums);
            UniSorter<int> ints1 = new UniSorter<int>(nums1);
            ISorter<int>.Comparator comparebymax = new ISorter<int>.Comparator((p1, p2) => (p1 - p2));
            ints.FastSort(comparebymax);
            Assert.AreEqual(ints1.ToString(), ints.ToString());
        }
        /// <summary>
        /// Тест проверяет работу болотной-преболотной сортировки
        /// </summary>
        [TestMethod]
        public void TestBogoBogoBogoBogo()
        {
            IList<int> nums = new List<int> { -19, -6, -25, -43 };
            IList<int> nums1 = new List<int>() { -43, -25, -19, -6 };
            UniSorter<int> ints = new UniSorter<int>(nums);
            UniSorter<int> ints1 = new UniSorter<int>(nums1);
            ISorter<int>.Comparator comparebymax = new ISorter<int>.Comparator((p1, p2) => p1 - p2);
            ints.BogoBogoSort(comparebymax);
            Assert.AreEqual(ints1.ToString(), ints.ToString());
        }
        /// <summary>
        /// Тест, проверящий отсортирован ли массив
        /// </summary>
        [TestMethod]
        public void TestPancake()
        {
            IList<int> nums = new List<int> { -20321, 0, 64321, 54, 1000000, -932832, -2, 9, 1, 14 };
            IList<int> nums1 = new List<int>() { -932832, -20321, -2, 0, 1, 9, 14, 54, 64321, 1000000 };
            UniSorter<int> ints = new UniSorter<int>(nums);
            UniSorter<int> ints1 = new UniSorter<int>(nums1);
            ISorter<int>.Comparator comparebymax = new ISorter<int>.Comparator((p1, p2) => p1 - p2);
            ints.BogoBogoSort(comparebymax);
            Assert.AreEqual(ints1.ToString(), ints.ToString());
        }
    }
}