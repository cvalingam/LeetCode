public class Solution
{
    public int[] GetCoprimes(int[] nums, int[][] edges)
    {
        int[] ans = new int[nums.Length];
        Array.Fill(ans, -1);
        List<int>[] tree = new List<int>[nums.Length];
        // stacks[i] := (node, depth)s of nodes with value i
        Stack<(int, int)>[] stacks = new Stack<(int, int)>[kMax + 1];

        for (int i = 0; i < nums.Length; ++i)
            tree[i] = new List<int>();

        for (int i = 1; i <= kMax; ++i)
            stacks[i] = new Stack<(int, int)>();

        foreach (int[] edge in edges)
        {
            int u = edge[0];
            int v = edge[1];
            tree[u].Add(v);
            tree[v].Add(u);
        }

        Dfs(tree, 0, -1, 0, nums, stacks, ans);
        return ans;
    }

    private const int kMax = 50;

    private void Dfs(List<int>[] tree, int u, int prev, int depth, int[] nums,
                    Stack<(int, int)>[] stacks, int[] ans)
    {
        ans[u] = GetAncestor(u, stacks, nums);
        stacks[nums[u]].Push((u, depth));

        foreach (int v in tree[u])
        {
            if (v != prev)
                Dfs(tree, v, u, depth + 1, nums, stacks, ans);
        }

        stacks[nums[u]].Pop();
    }

    private int GetAncestor(int u, Stack<(int, int)>[] stacks, int[] nums)
    {
        int maxNode = -1;
        int maxDepth = -1;
        for (int i = 1; i <= kMax; ++i)
        {
            if (stacks[i].Count > 0 && stacks[i].Peek().Item2 > maxDepth && Gcd(nums[u], i) == 1)
            {
                maxNode = stacks[i].Peek().Item1;
                maxDepth = stacks[i].Peek().Item2;
            }
        }
        
        return maxNode;
    }

    private int Gcd(int a, int b)
    {
        return b == 0 ? a : Gcd(b, a % b);
    }
}