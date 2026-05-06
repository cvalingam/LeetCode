// Approach: Use DFS recursion. Size of a tree = size(left subtree) + size(right subtree) + 1 (current node).
// Base case: null node contributes 0.
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

    public int getSize(Node root) {
        if (root == null) {
            return 0;
        }
        int leftSize = getSize(root.left);
        int rightSize = getSize(root.right);
        return rightSize + leftSize + 1;
    }
}
