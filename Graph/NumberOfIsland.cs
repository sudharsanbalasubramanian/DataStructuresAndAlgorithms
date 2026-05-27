namespace DataStructuresAndAlgorithms.Graph;

public sealed class NumberOfIsland
{
    // 8 directions including diagonals
    private static readonly int[] dr = [-1, -1, -1, 0, 0, 1, 1, 1];
    private static readonly int[] dc = [-1, 0, 1, -1, 1, -1, 0, 1];

    public static int NumIslands(char[][] grid)
    {
        if (grid is null || grid.Length == 0)
        {
            return 0;
        }

        HashSet<(int, int)> visited = [];

        int islands = 0;

        for (int r = 0; r < grid.Length; r++)
        {
            var row = grid[r];
            if (row is null)
            {
                continue;
            }

            for (int c = 0; c < row.Length; c++)
            {
                if (row[c] == '1' && !visited.Contains((r, c)))
                {
                    DFS(r, c, grid, visited);
                    islands++;
                }
            }
        }

        return islands;
    }

    private static void DFS(
        int r,
        int c,
        char[][] grid,
        HashSet<(int, int)> visited)
    {
        // Validate row index
        if (r < 0 || r >= grid.Length)
        {
            return;
        }

        var row = grid[r];
        if (row is null)
        {
            return;
        }

        // Validate column index for the current row (handles jagged arrays)
        if (c < 0 || c >= row.Length)
        {
            return;
        }

        // Water
        if (row[c] == '0')
        {
            return;
        }

        // Already visited
        if (visited.Contains((r, c)))
        {
            return;
        }

        visited.Add((r, c));

        // Explore all 8 directions
        for (int i = 0; i < 8; i++)
        {
            int nr = r + dr[i];
            int nc = c + dc[i];

            // Only recurse if nr is in bounds; DFS will validate nc against that row's length
            if (nr >= 0 && nr < grid.Length)
            {
                DFS(nr, nc, grid, visited);
            }
        }
    }
}
