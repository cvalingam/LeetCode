class Node {
    int data;
    Node left, right;

    Node(int d) {
        data = d;
        left = right = null;
    }
}

class Solution {
    int max = Integer.MIN_VALUE;

    int findMaxSum(Node root) {
        f(root);
        return max;
    }

    int f(Node root) {
        if (root == null)
            return 0;
        int left = f(root.left);
        int right = f(root.right);

        max = Math.max(max,
                Math.max(root.data + left + right, Math.max(root.data + left, Math.max(root.data, root.data + right))));
        return root.data + Math.max(Math.max(left, right), 0);
    }
}