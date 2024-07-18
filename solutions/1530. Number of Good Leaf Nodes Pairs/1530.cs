public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    private int ans = 0;
    public int CountPairs(TreeNode root, int distance)
    {
        dfs(root, distance);

        return ans;
    }

    private int[] dfs(TreeNode root, int distance)
    {
        int[] d = new int[distance + 1];
        if (root == null)
            return d;

        if (root.left == null && root.right == null)
        {
            d[0] = 1;
            return d;
        }

        int[] dl = dfs(root.left, distance);
        int[] dr = dfs(root.right, distance);

        for (int i = 0; i < distance; ++i)
            for (int j = 0; j < distance; ++j)
                if (i + j + 2 <= distance)
                    ans += dl[i] * dr[j];

        for (int i = 0; i < distance; ++i)
            d[i + 1] = dl[i] + dr[i];

        return d;
    }
}