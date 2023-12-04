using Abstraction;

internal class Program
{
    private static void Main(string[] args)
    {
        GraphOnADJList gAdjList = new GraphOnADJList(4);
        gAdjList.AddEdge(1, 2, 4);
        gAdjList.AddEdge(1, 3, 2);
        gAdjList.PrintGraph();
        gAdjList.RemoveEdge(1, 3);
        gAdjList.PrintGraph();
        gAdjList.AddEdge(2, 3, 1);
        gAdjList.PrintGraph();
        Console.WriteLine(gAdjList.EdgeLength(2, 3));
    }
}