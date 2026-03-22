class Node {
    int data;
    Node left, right;

    public Node(int d) {
        data = d;
        left = right = null;
    }
}

class Solution {
    Node LCA(Node root, Node n1, Node n2) {
        if (root == null || root.data == n1.data || root.data == n2.data ||
                (n1.data < root.data && root.data < n2.data) || (n2.data < root.data && root.data < n1.data))
            return root;
        if (root.data < n1.data && root.data < n2.data)
            return LCA(root.right, n1, n2);
        return LCA(root.left, n1, n2);
    }
}