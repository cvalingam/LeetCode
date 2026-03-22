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
    int ans = 0;

    int diameter(Node root) {
        depth(root);
        return ans;
    }

    int depth(Node root) {
        if (root == null)
            return 0;

        int left = depth(root.left);
        int right = depth(root.right);

        ans = Math.max(ans, left + right);

        return (1 + Math.max(left, right));
    }
}
