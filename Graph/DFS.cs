using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms.Graph;

public sealed class DFS
{
    /// <summary>
    /// Performs a depth-first search starting from <paramref name="node"/> and returns
    /// the visitation order as a list of node ids using a recursive traversal. The caller
    /// supplies a shared <paramref name="visited"/> set for composed traversals.
    /// </summary>
    public static List<int> DFSSearch(int node, Dictionary<int, List<int>> adj, HashSet<int> visited)
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

        void Visit(int current)
        {
            visited.Add(current);
            order.Add(current);

            if (!adj.TryGetValue(current, out var neighbors) || neighbors is null)
            {
                return;
            }

            foreach (var neighbor in neighbors)
            {
                if (visited.Add(neighbor))
                {
                    Visit(neighbor);
                }
            }
        }

        Visit(node);
        return order;
    }
}
