public class Solution
{
    public TreeNode BalanceBST(TreeNode root)
    {
        var nums = new List<int>();
        Inorder(root, nums);
        return build(nums, 0, nums.Count - 1);
    }

    private void Inorder(TreeNode root, List<int> nums)
    {
        if (root == null)
            return;

        Inorder(root.left, nums);
        nums.Add(root.val);
        Inorder(root.right, nums);
    }

    private TreeNode build(List<int> nums, int l, int r)
    {
        if (l > r)
            return null;

        int m = (l + r) / 2;
        return new TreeNode(nums[m], build(nums, l, m - 1), build(nums, m + 1, r));
    }
}