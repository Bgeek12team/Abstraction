namespace Abstraction
{
   public abstract class Graph
    {
        protected int _n;
        /// <summary>
        /// 
        /// </summary>
        public int NVertexes { get => _n; }

        public abstract void AddEdge(int i, int j, int cost);
        public abstract void RemoveEdge(int i, int j);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public abstract int EdgeLength(int x, int y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool IsAdjastent(int a, int b)
        {
            return EdgeLength(a, b) != 0;
        }

        /// <summary>
        /// Осуществлет DFS - поиск вглубину
        /// </summary>
        public virtual void DFS()
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

        protected virtual int FindAdjNotSeen(int V, bool[] seen)
        {
            for(int i =0; i < NVertexes; i++)
            {
                if (i != V && !seen[i] && IsAdjastent(i, V))
                    return i;
            }
            return -1;
        }

        protected virtual int GetVertexWithNoCons()
        {
            for(int i = 0; i < NVertexes; i++)
            {
                bool hasNoCons = true;
                for (int j = 0; j < NVertexes; j++)
                {
                    if(IsAdjastent(i,j))
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

    public class GraphOnMatrixADJ : Graph
    {
        protected int[,] matrixADJ { get; set; }

        public GraphOnMatrixADJ(int[,] matrixADJ)
        {
            this.matrixADJ = matrixADJ;
            _n = matrixADJ.GetLength(0);
        }
        public GraphOnMatrixADJ()
        {
            matrixADJ = new int[1, 1];
            _n = 1;
        }
        public GraphOnMatrixADJ(int N)
        {
            matrixADJ = new int[N, N];
            _n = N;
        }

        public override int EdgeLength(int from, int to)
        {
            return matrixADJ[from, to];
        }

        public override void AddEdge(int i, int j, int cost)
        {
            matrixADJ[i, j] = cost;
        }

        public override void RemoveEdge(int i, int j)
        {
            matrixADJ[i, j] = 0;
        }
    }

    public class GraphOnADJList : Graph
    {
        private List<(int indxVert,int cost)>[] adjList;
        public GraphOnADJList(int vertices)
        {
            adjList = new List<(int,int)>[vertices];
            for (int i = 0; i < vertices; i++)
            {
                adjList[i] = new List<(int, int)>();
            }
        }
        public override void AddEdge(int i, int j, int cost)
        {
            adjList[i].Add((j,cost));
            adjList[j].Add((i,cost));
        }

        public override int EdgeLength(int x, int y)
        {
            foreach (var edge in adjList[x])
                if (y == edge.indxVert)
                    return edge.cost;
            return -1;
        }

        public override void RemoveEdge(int i, int j)
        {
            adjList[i].RemoveAll(adj => adj.Item1 == j);
            adjList[j].RemoveAll(adj => adj.Item1 == i);
        }
    }
}