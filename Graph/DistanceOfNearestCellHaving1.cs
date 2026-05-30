namespace DataStructuresAndAlgorithms.Graph;

public static class DistanceOfNearestCellHaving1
{
    public static int[][] Nearest(int[][] cells)
    {
        ArgumentNullException.ThrowIfNull(cells);

        int rows = cells.Length;
        int[][] result = new int[rows][];
        Queue<(int row, int col)> queue = new();

        // Initialize result array
        for (int i = 0; i < rows; i++)
        {
            int cols = cells[i].Length;
            result[i] = new int[cols];

            for (int j = 0; j < cols; j++)
            {
                if (cells[i][j] == 1)
                {
                    result[i][j] = 0;
                    queue.Enqueue((i, j));
                }
                else
                {
                    result[i][j] = -1;
                }
            }
        }

        int[] dirRow = [-1, 0, 1, 0];
        int[] dirCol = [0, 1, 0, -1];

        // Multi-source BFS
        while (queue.Count > 0)
        {
            var (r, c) = queue.Dequeue();

            for (int k = 0; k < 4; k++)
            {
                int nr = r + dirRow[k];
                int nc = c + dirCol[k];

                if (nr >= 0 &&
                    nr < rows &&
                    nc >= 0 &&
                    nc < cells[nr].Length &&
                    result[nr][nc] == -1)
                {
                    result[nr][nc] = result[r][c] + 1;
                    queue.Enqueue((nr, nc));
                }
            }
        }

        return result;
    }
}