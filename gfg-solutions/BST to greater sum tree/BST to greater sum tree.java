// Approach: Reverse in-order traversal (right-root-left). Maintain a running suffix sum.
// Update each node's value with the accumulated suffix sum.
// Time: O(n) Space: O(h)
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
    static int totalSum;

    public static void transformTree(Node root) {
        totalSum = 0;
        solve(root);
    }

    static void solve(Node root) {
        if (root == null)
            return;

        solve(root.right);

        int rootVal = root.data;
        root.data = totalSum;
        totalSum += rootVal;

        solve(root.left);
    }
}