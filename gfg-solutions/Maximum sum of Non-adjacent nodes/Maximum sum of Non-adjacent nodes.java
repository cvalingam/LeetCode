class Node {
    int data;
    Node left, right;

    Node(int data) {
        this.data = data;
        this.left = null;
        this.right = null;
    }
}

class Solution {
    // Function to return the maximum sum of non-adjacent nodes.
    public int getMaxSum(Node root) {
        int[] both = dfs(root);
        return Math.max(both[0], both[1]);
    }

    private int[] dfs(Node root) {
        if (root == null)
            return new int[] { 0, 0 };
        int[] left = dfs(root.left), right = dfs(root.right);
        int include = root.data + left[1] + right[1];
        int exclude = Math.max(left[0], left[1]) + Math.max(right[0], right[1]);
        return new int[] { include, exclude };
    }
}
