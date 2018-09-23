using System;
using System.Collections.Generic;
using System.Text;

namespace Dijkstra
{
    class Graph
    {
        // Dictionary that holds the graph. Format: A, {B, 7}, {C, 8}
        Dictionary<char, Dictionary<char, int>> Edges = new Dictionary<char, Dictionary<char, int>>();

        /// <summary>
        /// Adds an edge to the graph.
        /// </summary>
        /// <param name="name">The name of the node.</param>
        /// <param name="paths">The paths you can take from this node.</param>
        public void AddEdge(char name, Dictionary<char, int> paths)
        {
            Edges[name] = paths;
        }

        public List<char> FindShortestPath(char start, char end)
        {
            // List of previous nodes.
            Dictionary<char, char> previous = new Dictionary<char, char>();
            // List to keep the distances to and from nodes.
            Dictionary<char, int> distances = new Dictionary<char, int>();
            // List of all nodes in graph.
            List<char> nodes = new List<char>();

            // List of shortest path.
            List<char> path = null;

            // Set start distance to 0 and distances to all other nodes to infinity (max int value).
            foreach (var edge in Edges)
            {
                if (edge.Key == start)
                    distances[edge.Key] = 0;
                else
                    distances[edge.Key] = int.MaxValue;

                // Add node to list of nodes in graph.
                nodes.Add(edge.Key);
            }

            // As long as there are nodes to explore do...
            while (nodes.Count != 0)
            {
                // Sort nodes by distance.
                nodes.Sort((i, j) => distances[i] - distances[j]);

                // Set the shortest distance node to smallest.
                char smallest = nodes[0];
                
                // If the smallest node is the end, set Path = to the path taken.
                if (smallest == end)
                {
                    path = new List<char>();
                    while (previous.ContainsKey(smallest))
                    {
                        path.Add(smallest);
                        smallest = previous[smallest];
                    }

                    break;
                }

                // Prevent infitine loops if I goofed up inputting the graph.
                if (distances[smallest] == int.MaxValue)
                {
                    break;
                }


                nodes.Remove(smallest);

                foreach (var neighbor in Edges[smallest])
                {
                    var alt = distances[smallest] + neighbor.Value;
                    if (alt < distances[neighbor.Key])
                    {
                        distances[neighbor.Key] = alt;
                        previous[neighbor.Key] = smallest;
                    }
                }
            }

            return path;
        }
    }
}

// --PSEUDOCODE--
// 1:	function Dijkstra(Graph, source):
// 2:	    for each vertex v in Graph:	                 Initialization
// 3:	        dist[v] := infinity	                     initial distance from source to vertex v is set to infinite
// 4:	        previous[v] := undefined	             Previous node in optimal path from source
// 5:	    dist[source] := 0	                         Distance from source to source
// 6:	    Q := the set of all nodes in Graph	         all nodes in the graph are unoptimized - thus are in Q
// 7:	    while Q is not empty:	                     main loop
// 8:	        u := node in Q with smallest dist[]
// 9:	        remove u from Q
// 10:	        for each neighbor v of u:	             where v has not yet been removed from Q.
// 11:	            alt := dist[u] + dist_between(u, v)
// 12:	            if alt<dist[v]	                     Relax (u,v)
// 13:	                dist[v] := alt
// 14:	                previous[v] := u
// 15:	    return previous[]