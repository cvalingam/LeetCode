class Node {
    int data;
    Node left, right;

    Node(int item) {
        data = item;
        left = right = null;
    }
}

class Solution {
    boolean ans = true;

    boolean isSumTree(Node root) {
        solve(root);
        return ans;
    }

    int solve(Node root) {
        if (root == null)
            return 0;

        int left = solve(root.left);
        int right = solve(root.right);

        if ((root.left != null || root.right != null) && left + right != root.data)
            ans = false;

        return root.data + left + right;
    }
}
