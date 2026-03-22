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
    // Function to check whether a Binary Tree is BST or not.
    boolean isBST(Node root) {
        int min = Integer.MIN_VALUE;
        int max = Integer.MAX_VALUE;
        return checkBST(root, min, max);
    }

    boolean checkBST(Node root, int min, int max) {
        if (root == null)
            return true;

        if (root.data <= min || root.data >= max)
            return false;

        boolean left = checkBST(root.left, min, root.data);
        boolean right = checkBST(root.right, root.data, max);

        return left && right;
    }
}