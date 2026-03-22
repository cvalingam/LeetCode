class Node {
    int data;
    Node left, right;

    Node(int item) {
        data = item;
        left = right = null;
    }
}

class Solution {
    // Function to return a list containing the inorder traversal of the tree.
    ArrayList<Integer> inOrder(Node root) {
        ArrayList<Integer> arr = new ArrayList<>();
        helper(root, arr);
        return arr;
    }

    void helper(Node root, ArrayList<Integer> arr) {
        if (root == null)
            return;

        helper(root.left, arr);
        arr.add(root.data);
        helper(root.right, arr);
    }
}