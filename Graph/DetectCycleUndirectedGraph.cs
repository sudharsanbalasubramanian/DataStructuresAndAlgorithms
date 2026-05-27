namespace DataStructuresAndAlgorithms.Graph;

public sealed class DetectCycleUndirectedGraph
{
    public static bool DetectCycle(Dictionary<int, List<int>> adj, int startingNode)
    {
        ArgumentNullException.ThrowIfNull(adj);

        HashSet<int> visited = new HashSet<int>();

        foreach (var kvp in adj)
        {
            int node = kvp.Key;
            if (!visited.Contains(node))
            {
                if (DFS(adj, node, -1, visited))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private static bool DFS(Dictionary<int, List<int>> adj, int current, int parent, HashSet<int> visited)
    {
        visited.Add(current);

        if (!adj.TryGetValue(current, out var neighbors) || neighbors == null)
        {
            return false;
        }

        foreach (var neighbor in neighbors)
        {
            if (!visited.Contains(neighbor))
            {
                if (DFS(adj, neighbor, current, visited))
                {
                    return true;
                }
            }
            else if (neighbor != parent)
            {
                // visited neighbor that's not the parent => cycle
                return true;
            }
        }

        return false;
    }
}
