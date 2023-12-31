﻿    namespace Abstraction
{
    /// <summary>
    /// Абстрактный класс граф, предоставляющий алгоритмы над графами
    /// не зависящие от конкретной реализации
    /// </summary>
   public abstract class Graph
   {
        /// <summary>
        /// количество вершин
        /// </summary>
        protected int _n;
        /// <summary>
        /// Количество вершин в графе
        /// </summary>
        public int NVertexes { get => _n; }
        /// <summary>
        /// Добавляет ребро между данными вершинами
        /// </summary>
        /// <param name="i">Вершина, из которой выходит ребро</param>
        /// <param name="j">Вершина, в которую входит ребро</param>
        /// <param name="len">Длина ребра между вершинами</param>
        public abstract void AddEdge(int i, int j, int len);
        /// <summary>
        /// Удаляет ребро между веришнами
        /// </summary>
        /// <param name="i">Вершина, из которой выходит удаляемое ребро</param>
        /// <param name="j">Вершина, в которую входит удаляемое ребро</param>
        public abstract void RemoveEdge(int i, int j);
        /// <summary>
        /// Возвращает длину ребра между данными вершинами
        /// </summary>
        /// <param name="i">Вершина, из которой выходит ребро</param>
        /// <param name="j">Вершина, в которую входит ребро</param>
        /// <returns>Длина ребра между вершинами</returns>
        public abstract int EdgeLength(int i, int j);
        /// <summary>
        /// Проверяет вершины на смежность
        /// </summary>
        /// <param name="a">Первая проверяемая вершина</param>
        /// <param name="b">Вторая проверяемая вершина</param>
        /// <returns>
        /// True: вершины смежны, есть ребро из первой во вторую
        /// False: все иные случаи
        /// </returns>
        public virtual bool IsAdjastent(int a, int b)
        {
            return EdgeLength(a, b) != 0;
        }
        /// <summary>
        /// Осуществлет DFS - поиск вглубину
        /// </summary>
        public void DFS()
        {
            bool[] seen = new bool[NVertexes];
            DFS(GetVertexWithNoCons(), seen);
            //unlinked vertexes
            for (int i = 0; i < NVertexes; i++)
            {
                if (!seen[i])
                {
                    DFS(i, seen);
                }
            }
        }

        /// <summary>
        /// Вспомогательная функция для поиска вглубину
        /// </summary>
        protected virtual void DFS(int start, bool[] seen)
        {
            int curV = start < 0 || start > NVertexes ?
                0 : start;
            Stack<int> vertexes = new Stack<int>();

            seen[curV] = true;
            vertexes.Push(curV);

            while (vertexes.Count > 0)
            {
                curV = vertexes.Peek();
                int checkV = FindAdjNotSeen(curV, seen);
                if (checkV != -1)
                {
                    vertexes.Push(checkV);
                    seen[checkV] = true;
                }
                else
                {
                    curV = vertexes.Pop();
                }
            }
        }
        /// <summary>
        /// Возвращает смежную вершину к данной, которой так же нет в массиве
        /// просмотренных вершин
        /// </summary>
        /// <param name="V">Данная вершина</param>
        /// <param name="seen">Массив просмотренных вершин</param>
        /// <returns>Первая смежная вершина к данной, которой так же нет в массиве,
        /// -1 если она отуствует</returns>
        protected virtual int FindAdjNotSeen(int V, bool[] seen)
        {
            for(int i =0; i < NVertexes; i++)
            {
                if (i != V && !seen[i] && IsAdjastent(i, V))
                    return i;
            }
            return -1;
        }
        /// <summary>
        /// Находит вершину, в которую не входит ни одно ребро
        /// </summary>
        /// <returns>Вершина в которую не входит ни одно ребро,
        /// -1 если оная отсутсвует</returns>
        protected virtual int GetVertexWithNoCons()
        {
            for(int i = 0; i < NVertexes; i++)
            {
                bool hasNoCons = true;
                for (int j = 0; j < NVertexes; j++)
                {
                    if (i == j) continue;
                    if(IsAdjastent(j,i))
                    {
                        hasNoCons = false;
                        break;
                    }
                }
                if (hasNoCons)
                    return i;
            }
            return -1;
        }
        /// <summary>
        /// Осуществляет BFS - поиск вширину
        /// </summary>
        public void BFS()
        {
            bool[] seen = new bool[NVertexes];
            BFS(GetVertexWithNoCons(), seen);
            //unlinked vertexes
            for (int i = 0; i < NVertexes; i++)
            {
                if (!seen[i])
                {
                    BFS(i, seen);
                }
            }
        }
        /// <summary>
        /// Вспомогательная функция для поиска вширину
        /// </summary>
        public virtual void BFS(int start, bool[] seen)
        {
            int curV = start < 0 || start > NVertexes ?
                0 : start;
            Queue<int> vertexes = new Queue<int>();

            seen[curV] = true;
            vertexes.Enqueue(curV);

            while (vertexes.Count > 0)
            {
                curV = vertexes.Peek();
                int checkV = FindAdjNotSeen(curV, seen);
                if (checkV != -1)
                {
                    vertexes.Enqueue(checkV);
                    seen[checkV] = true;
                }
                else
                {
                    curV = vertexes.Dequeue();
                }
            }
        }
    }
    /// <summary>
    /// Реализует граф на основе матрицы смежности
    /// </summary>
    public class GraphOnMatrixADJ : Graph
    {
        /// <summary>
        /// матрица смежности
        /// </summary>
        protected int[,] matrixADJ;
        /// <summary>
        /// Создает экземпляр класса на основе матрицы смежности, где
        /// 0 - отсутвие ребра между вершинами
        /// </summary>
        /// <param name="matrixADJ">Матрица смежности графа</param>
        public GraphOnMatrixADJ(int[,] matrixADJ)
        {
            this.matrixADJ = matrixADJ;
            _n = matrixADJ.GetLength(0);
        }
        /// <summary>
        /// Создает новый пустой граф с одной вершиной
        /// </summary>
        public GraphOnMatrixADJ()
        {
            matrixADJ = new int[1, 1];
            _n = 1;
        }
        /// <summary>
        /// Создает граф данного размера без связей между вершинами
        /// </summary>
        /// <param name="N">Количество вершин в графе</param>
        public GraphOnMatrixADJ(int N)
        {
            matrixADJ = new int[N, N];
            _n = N;
        }
        /// <summary>
        /// Возвращает элемент по заданной строке и столбцу
        /// </summary>
        /// <param name="row">Заданная строка</param>
        /// <param name="col">Заданный столбец</param>
        /// <returns>Элемент, имеющий координаты [строка; столбец]</returns>
        public int this[int row, int col]
        {
            get { return matrixADJ[row, col]; }
            set { matrixADJ[row, col] = value; }
        }
        /// <summary>
        /// Возвращает длину ребра между данными вершинами
        /// </summary>
        /// <param name="i">Вершина, из которой выходит ребро</param>
        /// <param name="j">Вершина, в которую входит ребро</param>
        /// <returns>Длина ребра между вершинами</returns>
        public override int EdgeLength(int from, int to)
        {
            return matrixADJ[from, to];
        }
        /// <summary>
        /// Добавляет ребро между данными вершинами
        /// </summary>
        /// <param name="i">Вершина, из которой выходит ребро</param>
        /// <param name="j">Вершина, в которую входит ребро</param>
        /// <param name="len">Длина ребра между вершинами</param>
        public override void AddEdge(int i, int j, int len)
        {
            matrixADJ[i, j] = len;
        }
        /// <summary>
        /// Удаляет ребро между веришнами
        /// </summary>
        /// <param name="i">Вершина, из которой выходит удаляемое ребро</param>
        /// <param name="j">Вершина, в которую входит удаляемое ребро</param>
        public override void RemoveEdge(int i, int j)
        {
            matrixADJ[i, j] = 0;
        }
        /// <summary>
        /// Метод для проверки на равенство значений
        /// </summary>
        /// <param name="graphadj">сравниваемое  число</param>
        /// <returns>возвращает результат сравнения</returns>
        public override bool Equals(object? graphadj)
        {
            if (graphadj == this)
                return true;
            if (graphadj == null || graphadj is not GraphOnMatrixADJ)
                return false;
            GraphOnMatrixADJ graphadj2 = (GraphOnMatrixADJ)graphadj;
            for (int i = 0; i < matrixADJ.GetLength(0); i++)
            {
                for (int j = 0; j < matrixADJ.GetLength(0); j++)
                {
                    if (this[i, j] != graphadj2[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Переопределение метода GetHashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + matrixADJ.GetLength(0).GetHashCode();
            hash = hash * 23 + matrixADJ.GetLength(1).GetHashCode();
            for (int i = 0; i < matrixADJ.GetLength(0); i++)
                for (int j = 0; j < matrixADJ.GetLength(1); j++)
                      hash = hash * 23 + this[i, j].GetHashCode();
            return hash;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class GraphOnADJList : Graph
    {
        /// <summary>
        /// Список смежности
        /// </summary>
        private List<(int indxVert, int cost)>[] adjList;
        /// <summary>
        /// конструктор создающий список смежности по уже имеющемуся списку
        /// </summary>
        /// <param name="adjList"></param>
        public GraphOnADJList(List<(int indxVert, int cost)>[] adjList)
        {
            this.adjList = adjList;
        }
        /// <summary>
        /// Конструктор класса, создает пустой список смежности длины n
        /// </summary>
        /// <param name="n">длина списка</param>
        public GraphOnADJList(int vertices)
        {
            adjList = new List<(int, int)>[vertices];
            for (int i = 0; i < vertices; i++)
                adjList[i] = new List<(int, int)>();
        }
        /// <summary>
        /// Добавляет ребро между данными вершинами
        /// </summary>
        /// <param name="i">Вершина, из которой выходит ребро</param>
        /// <param name="j">Вершина, в которую входит ребро</param>
        /// <param name="len">Длина ребра между вершинами</param>
        public override void AddEdge(int i, int j, int len)
        {
            if (i == j)
                adjList[i].Add((i, len));
            else
            {
                adjList[i].Add((j, len));
            }
        }
        /// <summary>
        /// Возвращает длину ребра между данными вершинами
        /// </summary>
        /// <param name="x">Вершина, из которой выходит ребро</param>
        /// <param name="y">Вершина, в которую входит ребро</param>
        /// <returns>Длина ребра между вершинами</returns>
        public override int EdgeLength(int x, int y)
        {
            foreach (var edge in adjList[x])
                if (y == edge.indxVert)
                    return edge.cost;
            return 0;
        }
        /// <summary>
        /// Удаляет ребро между веришнами
        /// </summary>
        /// <param name="i">Вершина, из которой выходит удаляемое ребро</param>
        /// <param name="j">Вершина, в которую входит удаляемое ребро</param>
        public override void RemoveEdge(int i, int j)
        {
            adjList[i].RemoveAll(adj => adj.Item1 == j);
        }
        /// <summary>
        /// Переопределение метода Equals
        /// </summary>
        /// <param name="obj">объект</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;
            if (obj == null || obj is not GraphOnADJList)
                return false;
            GraphOnADJList gr = (GraphOnADJList)obj;
            List<(int indxVert, int cost)>[] other = gr.adjList;
            if (adjList.Length != other.Length)
                return false;
            for (int i = 0; i < adjList.Length; i++)
            {
                if (adjList[i].Count != other[i].Count)
                    return false;
                for (int j = 0; j < adjList[i].Count; j++)
                    if (adjList[i][j].indxVert != other[i][j].indxVert || adjList[i][j].cost != other[i][j].cost)
                        return false;
            }

            return true;
        }
    }
}