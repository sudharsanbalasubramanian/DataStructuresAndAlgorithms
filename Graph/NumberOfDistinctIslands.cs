namespace DataStructuresAndAlgorithms.Graph;

public sealed class NumberOfDistinctIslands
{
    private static readonly int[] dirRow = [-1, 0, 1, 0];
    private static readonly int[] dirCol = [0, -1, 0, 1];

    public static int CountOfDistinctIsland(int[][] grid)
    {
        HashSet<(int, int)> visited = [];
        HashSet<string> set = [];

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (visited.Contains((i, j)) || grid[i][j] != 1)
                {
                    continue;
                }

                List<string> shape = [];

                DFS(i, j, visited, grid, i, j, shape);

                set.Add(string.Join("|", shape));
            }
        }

        return set.Count;
    }

    private static void DFS(
        int r,
        int c,
        HashSet<(int, int)> visited,
        int[][] grid,
        int parentR,
        int parentC,
        List<string> shape)
    {
        visited.Add((r, c));

        shape.Add($"{r - parentR},{c - parentC}");

        for (int i = 0; i < 4; i++)
        {
            int nr = r + dirRow[i];
            int nc = c + dirCol[i];

            if (nr < 0 || nr >= grid.Length)
            {
                continue;
            }

            if (nc < 0 || nc >= grid[0].Length)
            {
                continue;
            }

            if (grid[nr][nc] == 1 &&
                !visited.Contains((nr, nc)))
            {
                DFS(nr, nc, visited, grid, parentR, parentC, shape);
            }
        }
    }
}
