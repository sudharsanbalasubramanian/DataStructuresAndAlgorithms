namespace DataStructuresAndAlgorithms.Graph;

public sealed class NumberOfEnclaves
{
    public static int CountOfEnclaves(int[][] grid)
    {
        Queue<(int row, int col)> queue = [];

        HashSet<(int, int)> visited = [];

        int rows = grid.Length;
        int cols = grid[0].Length;

        // Add all boundary land cells
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                bool isBoundary =
                    i == 0 ||
                    j == 0 ||
                    i == rows - 1 ||
                    j == cols - 1;

                if (isBoundary &&
                    grid[i][j] == 1 &&
                    !visited.Contains((i, j)))
                {
                    queue.Enqueue((i, j));
                    visited.Add((i, j));
                }
            }
        }

        int[] dirRow = [-1, 0, 1, 0];
        int[] dirCol = [0, 1, 0, -1];

        while (queue.Count > 0)
        {
            var (row, col) = queue.Dequeue();

            for (int i = 0; i < 4; i++)
            {
                int nr = row + dirRow[i];
                int nc = col + dirCol[i];

                if (nr < 0 || nr >= rows ||
                    nc < 0 || nc >= cols)
                {
                    continue;
                }

                if (grid[nr][nc] == 1 &&
                    !visited.Contains((nr, nc)))
                {
                    queue.Enqueue((nr, nc));
                    visited.Add((nr, nc));
                }
            }
        }

        int countOfEnclaves = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (grid[i][j] == 1 &&
                    !visited.Contains((i, j)))
                {
                    countOfEnclaves++;
                }
            }
        }

        return countOfEnclaves;
    }
}
