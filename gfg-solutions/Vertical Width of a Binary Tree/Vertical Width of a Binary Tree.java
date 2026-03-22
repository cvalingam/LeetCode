class Node {
    int data;
    Node left;
    Node right;

    Node(int data) {
        this.data = data;
        left = null;
        right = null;
    }
}

class Solution {
    public int verticalWidth(Node root) {
        if (root == null)
            return 0;

        int[] a = new int[2];
        dfs(root, a, 0);

        return a[1] - a[0] + 1;
    }

    private void dfs(Node root, int[] a, int curr) {
        if (root == null)
            return;

        if (root.left != null)
            a[0] = Math.min(curr - 1, a[0]);

        if (root.right != null)
            a[1] = Math.max(curr + 1, a[1]);

        dfs(root.left, a, curr - 1);
        dfs(root.right, a, curr + 1);
    }
}