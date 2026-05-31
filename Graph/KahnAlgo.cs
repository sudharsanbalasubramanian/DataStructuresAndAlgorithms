namespace DataStructuresAndAlgorithms.Graph;

public sealed class KahnAlgo
{
    public static int[] TopologicalSort(int[][] adjGraph)
    {
        ArgumentNullException.ThrowIfNull(adjGraph);

        int vertices = adjGraph.Length;

        int[] indegree = new int[vertices];

        // Calculate indegree of each node
        for (int node = 0; node < vertices; node++)
        {
            foreach (int neighbor in adjGraph[node])
            {
                indegree[neighbor]++;
            }
        }

        Queue<int> queue = [];

        // Add all nodes with indegree 0
        for (int node = 0; node < vertices; node++)
        {
            if (indegree[node] == 0)
            {
                queue.Enqueue(node);
            }
        }

        List<int> result = [];

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();

            result.Add(current);

            foreach (int neighbor in adjGraph[current])
            {
                indegree[neighbor]--;

                if (indegree[neighbor] == 0)
                {
                    queue.Enqueue(neighbor);
                }
            }
        }

        // Cycle detection
        if (result.Count != vertices)
        {
            throw new InvalidOperationException(
                "Topological sort is not possible because the graph contains a cycle.");
        }

        return [.. result];
    }
}
