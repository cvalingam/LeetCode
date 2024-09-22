public class Solution
{
    public int ComponentValue(int[] nums, int[][] edges)
    {
        int n = nums.Length;
        int sum = nums.Sum();
        List<int>[] tree = new List<int>[n];

        for (int i = 0; i < tree.Length; ++i)
            tree[i] = new List<int>();

        foreach (int[] edge in edges)
        {
            int u = edge[0];
            int v = edge[1];
            tree[u].Add(v);
            tree[v].Add(u);
        }

        for (int i = n; i > 1; --i)
            // Split the tree into i parts, i.e. delete (i - 1) edges.
            if (sum % i == 0 && Dfs(nums, tree, 0, sum / i, new bool[n]) == 0)
                return i - 1;

        return 0;
    }

    private const int kMax = 1_000_000_000;

    // Returns the sum of the subtree rooted at u subtracting the sum of the deleted subtrees.
    private int Dfs(int[] nums, List<int>[] tree, int u, int target, bool[] seen)
    {
        int sum = nums[u];
        seen[u] = true;

        foreach (int v in tree[u])
        {
            if (seen[v])
                continue;
            sum += Dfs(nums, tree, v, target, seen);
            if (sum > target)
                return kMax;
        }

        // Delete the tree that has sum == target.
        if (sum == target)
            return 0;
        return sum;
    }
}