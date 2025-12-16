public class Solution
{
    private int budget;
    private List<int>[] tree;

    public int MaxProfit(int n, int[] present, int[] future, int[][] hierarchy, int budget)
    {
        this.budget = budget;
        tree = new List<int>[n];
        for (int i = 0; i < n; i++)
            tree[i] = new List<int>();

        foreach (var edge in hierarchy)
        {
            int u = edge[0] - 1;
            int v = edge[1] - 1;
            tree[u].Add(v);
        }

        var memo = new Dictionary<(int, int), (int[], int[])>();

        (int[], int[]) Dp(int u, int parent)
        {
            if (memo.ContainsKey((u, parent)))
                return memo[(u, parent)];

            int[] noDiscount = new int[budget + 1];
            int[] withDiscount = new int[budget + 1];
            for (int i = 0; i <= budget; i++)
            {
                noDiscount[i] = 0;
                withDiscount[i] = 0;
            }

            foreach (var v in tree[u])
            {
                if (v == parent)
                    continue;
                var (childNoDiscount, childWithDiscount) = Dp(v, u);
                noDiscount = Merge(noDiscount, childNoDiscount);
                withDiscount = Merge(withDiscount, childWithDiscount);
            }

            int[] newDp0 = new int[budget + 1];
            int[] newDp1 = new int[budget + 1];
            Array.Copy(noDiscount, newDp0, budget + 1);
            Array.Copy(noDiscount, newDp1, budget + 1);

            int fullCost = present[u];
            for (int b = fullCost; b <= budget; b++)
            {
                int profit = future[u] - fullCost;
                newDp0[b] = Math.Max(newDp0[b], withDiscount[b - fullCost] + profit);
            }

            int halfCost = present[u] / 2;
            for (int b = halfCost; b <= budget; b++)
            {
                int profit = future[u] - halfCost;
                newDp1[b] = Math.Max(newDp1[b], withDiscount[b - halfCost] + profit);
            }

            memo[(u, parent)] = (newDp0, newDp1);
            return (newDp0, newDp1);
        }

        var result = Dp(0, -1);
        int maxProfit = int.MinValue;
        foreach (var val in result.Item1)
            if (val > maxProfit)
                maxProfit = val;
        return maxProfit;
    }

    private int[] Merge(int[] dpA, int[] dpB)
    {
        int n = dpA.Length;
        int[] merged = new int[n];
        for (int i = 0; i < n; i++)
            merged[i] = int.MinValue;

        for (int i = 0; i < n; i++)
        {
            if (dpA[i] == int.MinValue) continue;
            for (int j = 0; j < n - i; j++)
            {
                if (dpB[j] == int.MinValue) continue;
                merged[i + j] = Math.Max(merged[i + j], dpA[i] + dpB[j]);
            }
        }
        return merged;
    }
}