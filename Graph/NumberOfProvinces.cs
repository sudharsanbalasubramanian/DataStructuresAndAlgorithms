using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms.Graph;

public sealed class NumberOfProvinces
{
    //https://leetcode.com/problems/number-of-provinces/description/
    public static int GetNumberOfProvinces(int[][] matrix)
    {
        ArgumentNullException.ThrowIfNull(matrix, nameof(matrix));

        Dictionary<int, List<int>> adj = [];

        for(int i = 0; i < matrix.Length; i++)
        {
            adj[i] = [];

            for(int j = 0; j < matrix[i].Length; j++)
            {
                if (matrix[i][j] == 1 && i != j)
                {
                    adj[i].Add(j);
                }
            }
        }

        return GetNumberOfProvinces(adj);
    }

    public static int GetNumberOfProvinces(Dictionary<int, List<int>> adj)
    {
        ArgumentNullException.ThrowIfNull(adj, "Adjacent list can't be null");

        HashSet<int> visited = [];

        int countOfProvince = 0;

        foreach (var pair in adj)
        {
            if(visited.Contains(pair.Key))
            {
                continue;
            }

            BFS.BFSSearch(pair.Key, adj, visited);

            countOfProvince++;
        }

        return countOfProvince;
    }
}
