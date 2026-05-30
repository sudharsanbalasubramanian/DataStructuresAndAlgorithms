namespace DataStructuresAndAlgorithms.Graph;

public sealed class Bipartite
{
    public static bool IsBipartite(int[][] adj)
    {
        int[] color = new int[adj.Length];

        Array.Fill(color, -1);

        for (int start = 0; start < adj.Length; start++)
        {
            // already processed
            if (color[start] != -1)
            {
                continue;
            }

            Queue<int> queue = [];

            queue.Enqueue(start);

            color[start] = 0;

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();

                foreach (int neighbor in adj[node])
                {
                    // not colored yet
                    if (color[neighbor] == -1)
                    {
                        color[neighbor] = 1 - color[node];

                        queue.Enqueue(neighbor);
                    }
                    // same color on both sides
                    else if (color[neighbor] == color[node])
                    {
                        return false;
                    }
                }
            }
        }

        return true;
    }
}
