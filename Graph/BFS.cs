using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms.Graph;

public sealed class BFS
{
    /// <summary>
    /// Performs a breadth-first search starting from <paramref name="node"/> and returns
    /// the visitation order as a list of node ids. The caller provides a shared
    /// <paramref name="visited"/> set so multiple traversals can be composed (e.g., counting components).
    /// </summary>
    public static List<int> BFSSearch(int node, Dictionary<int, List<int>> adj, HashSet<int> visited)
    {
        ArgumentNullException.ThrowIfNull(adj, "Adjacent list can't be null");
        ArgumentNullException.ThrowIfNull(visited, "visited set can't be null");

        if (!adj.ContainsKey(node))
        {
            throw new ArgumentException("node provided is not present in adjacent list");
        }

        var order = new List<int>();

        // if already visited, nothing to do
        if (visited.Contains(node))
        {
            return order;
        }

        var queue = new Queue<int>();

        queue.Enqueue(node);
        visited.Add(node);

        while (queue.Count > 0)
        {
            int id = queue.Dequeue();
            order.Add(id);

            // If adjacency list misses an entry for a node, treat it as having no neighbors.
            if (!adj.TryGetValue(id, out var neighbors) || neighbors is null)
            {
                continue;
            }

            foreach (var neighbor in neighbors)
            {
                if (visited.Add(neighbor)) // Add returns true if neighbor was not present
                {
                    queue.Enqueue(neighbor);
                }
            }
        }

        return order;
    }
}
