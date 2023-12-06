using Abstraction;
namespace GraphTests
{
    /// <summary>
    /// ����� ����������� ������ ������� ������ GraphOnMatrixADJ
    /// </summary>
    [TestClass]
    public class GraphOnMatr
    {
        /// <summary>
        /// ����������� ����� �������������� �������� ������ AddEdge ������ GraphOnMatrixADJ
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
        /// ���� ����������� ���������� ����� ����� 0 � ����
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
        /// ���� ����������� ��������� ����� ����� 1000000 � ������ ����(�� ������� �����)
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
        /// ���� ����������� �������� ���� ����� ������� ���������
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
        /// ���� ����������� �������� �������� ������� ���������
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
        /// ���� ����������� �������� ��������� �������� ������������ ������� ���������
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
        /// ���������� ����� ����������� ����� EdgeLength ������ GraphOnMatrixADJ
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
        /// ���������� ����� ����������� ����� EdgeLength ������ GraphOnMatrixADJ
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
        /// ���������� ����� ����������� ����� EdgeLength ������ GraphOnMatrixADJ
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
    [TestClass]
    public class GraphOnList
    {
        [TestMethod]
        public void AddEdge()
        {
            int n = 3;
            List<(int indxVert, int cost)>[] adjList = new List<(int indxVert, int cost)>[n];
            adjList[0] = new List<(int indxVert, int cost)>();
            adjList[0].Add((1, 1)); adjList[0].Add((2, 1));
            adjList[1] = new List<(int indxVert, int cost)>();
            adjList[1].Add((0, 1)); adjList[1].Add((2, 1));
            adjList[2] = new List<(int indxVert, int cost)>();
            adjList[2].Add((0, 1)); adjList[2].Add((1, 1));
            GraphOnADJList list = new(3);
            list.AddEdge(0, 0, 5);
            list.AddEdge(1, 1, 5);

        }
    }
    /// <summary>
    /// �����, ����������� ������ ������� ����������
    /// </summary>
    [TestClass]
    public class TestSorts
    {
        /// <summary>
        /// ���� ��������� ������ ����������� ����������
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
        /// ���� ��������� ������ ���������� ���������
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
        /// ���� ��������� ������ ���������� �����
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
        /// ���� ��������� ������ ������� ����������
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
        /// ���� ��������� ������ ��������-����������� ����������
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
    }
}