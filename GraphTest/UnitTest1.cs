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
    [TestClass]
    public class GraphOnList
    {
        [TestMethod]
        public void AddEdge()
        {
        }
    }
}