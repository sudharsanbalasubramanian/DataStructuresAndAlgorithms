namespace DataStructuresAndAlgorithms.Graph;

public sealed class RottenOranges
{
    private static readonly int[] _directionRow = [-1, 0, 1, 0];
    private static readonly int[] _directionCol = [0, 1, 0, -1];

    /// <summary>
    /// Returns minutes until all fresh oranges rot, or -1 if impossible.
    /// </summary>
    public static int OrangesRotting(int[][] grid)
    {
        if (grid is null || grid.Length == 0)
        {
            return 0;
        }

        var q = new Queue<(int r, int c, int t)>();
        int fresh = 0;

        // collect initial rotten oranges and count fresh ones
        for (int r = 0; r < grid.Length; r++)
        {
            var row = grid[r];
            if (row is null)
            {
                continue;
            }

            for (int c = 0; c < row.Length; c++)
            {
                if (row[c] == 2)
                {
                    q.Enqueue((r, c, 0));
                }
                else if (row[c] == 1)
                {
                    fresh++;
                }
            }
        }

        int minutes = 0;

        // multi-source BFS
        while (q.Count > 0)
        {
            var (r, c, t) = q.Dequeue();
            minutes = Math.Max(minutes, t);

            for (int i = 0; i < 4; i++)
            {
                int nr = r + _directionRow[i];
                int nc = c + _directionCol[i];

                if (nr < 0 || nr >= grid.Length)
                {
                    continue;
                }

                var nrow = grid[nr];
                if (nrow is null)
                {
                    continue;
                }

                if (nc < 0 || nc >= nrow.Length)
                {
                    continue;
                }

                if (nrow[nc] == 1)
                {
                    // rot this fresh orange
                    nrow[nc] = 2;
                    fresh--;
                    q.Enqueue((nr, nc, t + 1));
                }
            }
        }

        return fresh == 0 ? minutes : -1;
    }
}
