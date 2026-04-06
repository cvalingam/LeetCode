// Approach: In-order traversal. Find the two swapped nodes (first: curr < prev violation, second: last such violation).
// Swap their values.
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
    Node a = null;
    Node b = null;
    Node prev = null;

    public void helper(Node root) {
        if (root == null)
            return;
        helper(root.left);
        if (prev != null && prev.data > root.data) {
            if (a == null)
                a = prev;
            b = root;
        }
        prev = root;
        helper(root.right);
    }

    void correctBST(Node root) {
        helper(root);
        int temp = a.data;
        a.data = b.data;
        b.data = temp;
    }
}