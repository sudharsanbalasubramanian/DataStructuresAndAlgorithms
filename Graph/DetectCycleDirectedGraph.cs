using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms.Graph;

public sealed class DetectCycleDirectedGraph
{
    public static bool IsCycleDetected(int[][] adjGraph)
    {
        ArgumentNullException.ThrowIfNull(adjGraph, nameof(adjGraph));

        var visited = new HashSet<int>();
        var pathVisited = new HashSet<int>();

        for (int i = 0; i < adjGraph.Length; i++)
        {
            // Start DFS from unvisited node
            if (!visited.Contains(i))
            {
                if (DFS(i, adjGraph, visited, pathVisited))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private static bool DFS(
        int node,
        int[][] adjGraph,
        HashSet<int> visited,
        HashSet<int> pathVisited)
    {
        visited.Add(node);
        pathVisited.Add(node);

        foreach (int neighbor in adjGraph[node])
        {
            // If neighbor is not visited, continue DFS
            if (!visited.Contains(neighbor))
            {
                if (DFS(neighbor, adjGraph, visited, pathVisited))
                {
                    return true;
                }
            }
            // If neighbor is already in current DFS path
            // then cycle exists
            else if (pathVisited.Contains(neighbor))
            {
                return true;
            }
        }

        // Backtracking step
        pathVisited.Remove(node);

        return false;
    }
}
