class Node {
    int data;
    Node left, right;

    public Node(int d) {
        data = d;
        left = right = null;
    }
}

class Solution {
    // Return the size of the largest sub-tree which is also a BST
    static int largestBst(Node root) {
        if (isBST(root, Integer.MIN_VALUE, Integer.MAX_VALUE))
            return countNodes(root);

        int left = largestBst(root.left);
        int right = largestBst(root.right);

        return Math.max(left, right);
    }

    private static boolean isBST(Node node, int min, int max) {
        if (node == null)
            return true;

        if (node.data < min || node.data > max)
            return false;

        return isBST(node.left, min, node.data - 1)
                && isBST(node.right, node.data + 1, max);
    }

    private static int countNodes(Node node) {
        if (node == null)
            return 0;

        return 1 + countNodes(node.left) + countNodes(node.right);
    }
}

// Version 2

class Solution1 {
    // Return the size of the largest sub-tree which is also a BST
    static int largestBst(Node root) {
        maxSize = 0;
        solve(root);
        return maxSize;
    }

    static class Info {
        int size;
        int min;
        int max;
        boolean isBST;

        Info(int size, int min, int max, boolean isBST) {
            this.size = size;
            this.min = min;
            this.max = max;
            this.isBST = isBST;
        }
    }

    static int maxSize = 0;

    static Info solve(Node root) {
        if (root == null)
            return new Info(0, Integer.MAX_VALUE, Integer.MIN_VALUE, true);

        Info left = solve(root.left);
        Info right = solve(root.right);

        // Check if current subtree is BST
        if (left.isBST && right.isBST && root.data > left.max && root.data < right.min) {
            int currSize = left.size + right.size + 1;
            maxSize = Math.max(maxSize, currSize);
            return new Info(
                    currSize,
                    Math.min(root.data, left.min),
                    Math.max(root.data, right.max),
                    true);
        }

        // Not a BST
        return new Info(0, 0, 0, false);
    }
}