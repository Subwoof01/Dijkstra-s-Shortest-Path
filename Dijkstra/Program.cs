using System;
using System.Collections.Generic;

namespace Dijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            // See Graph.png for visual representation of the graph.
            Graph g = new Graph();
            g.AddEdge('A', new Dictionary<char, int>() { { 'B', 1 }, { 'C', 6 }, { 'D', 5 } });
            g.AddEdge('B', new Dictionary<char, int>() { { 'A', 1 }, { 'C', 6 } });
            g.AddEdge('C', new Dictionary<char, int>() { { 'A', 6 }, { 'B', 6 }, { 'F', 3 }, { 'E', 7 } });
            g.AddEdge('D', new Dictionary<char, int>() { { 'A', 5 }, { 'G', 10 }, { 'F', 2 } });
            g.AddEdge('E', new Dictionary<char, int>() { { 'C', 7 }, { 'H', 12 } });
            g.AddEdge('F', new Dictionary<char, int>() { { 'C', 3 }, { 'D', 2 }, { 'H', 8 } });
            g.AddEdge('G', new Dictionary<char, int>() { { 'D', 10 }, { 'H', 7 }, { 'I', 3 } });
            g.AddEdge('H', new Dictionary<char, int>() { { 'E', 12 }, { 'F', 8 }, { 'G', 7 }, { 'I', 8 } });
            g.AddEdge('I', new Dictionary<char, int>() { { 'G', 3 }, { 'H', 8 } });

            List<char> shortestPath = g.FindShortestPath('A', 'I');

            for (int i = shortestPath.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(shortestPath[i]);
            }

            Console.ReadKey();
        }
    }
}
