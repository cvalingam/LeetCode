class Solution {
    boolean hasPathSum(Node root, int target) {
        return pathSum(root, target);
    }

    boolean pathSum(Node root, int target) {
        if (root == null)
            return false;

        if (root.left == null && root.right == null)
            return root.data == target;

        boolean left = pathSum(root.left, target - root.data);
        boolean right = pathSum(root.right, target - root.data);

        return left || right;
    }
}

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