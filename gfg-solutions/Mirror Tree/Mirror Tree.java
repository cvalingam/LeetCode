class Node {
    int data;
    Node left, right;

    Node(int item) {
        data = item;
        left = right = null;
    }
}

class Solution {
    // Function to convert a binary tree into its mirror tree.
    void mirror(Node node) {
        dfs(node);
    }

    void dfs(Node node) {
        if (node == null)
            return;

        dfs(node.left);
        dfs(node.right);

        Node temp = node.right;
        node.right = node.left;
        node.left = temp;
    }
}