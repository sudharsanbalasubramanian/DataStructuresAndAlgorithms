using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms.Graph;

public sealed class TopoSort
{
    public int[] Sort(int[][] adjGraph)
    {
        var visited = new HashSet<int>();

        var result = new Stack<int>();

        for(int node = 0; node < adjGraph.Length; node++)
        {
            if (!visited.Contains(node))
            {
                DFS(node, visited, result, adjGraph);
            }
        }

        return [.. result];
    }

    private static void DFS(int node, HashSet<int> visited, Stack<int> result, int[][] adjGraph)
    {
        visited.Add(node);

        foreach(int neighbor in adjGraph[node])
        {
            if (!visited.Contains(neighbor))
            {
                DFS(neighbor, visited, result, adjGraph);
            }
        }

        result.Push(node);
    }
}
