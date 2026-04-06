// Approach: Reverse in-order traversal (right-root-left). Track the previous node and assign as successor.
// Time: O(n) Space: O(h)
class Node {
    int data;
    Node left, right, next;

    public Node(int data) {
        this.data = data;
    }
}

class Solution {
    Node prev = null;

    public void populateNext(Node root) {
        Node prev = null;
        IOT(root);
        if (prev != null)
            prev.next = null;
    }

    private void IOT(Node root) {
        if (root == null)
            return;

        IOT(root.left);

        if (prev != null)
            prev.next = root;

        prev = root;
        IOT(root.right);
    }
}