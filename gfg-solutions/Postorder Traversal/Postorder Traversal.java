import java.util.*;

class Node {
    int data;
    Node left, right;

    Node(int val) {
        data = val;
        left = right = null;
    }
}

class Solution {
    public ArrayList<Integer> postOrder(Node root) {
        ArrayList<Integer> res = new ArrayList<>();
        traverse(res, root);
        return res;
    }

    public static void traverse(ArrayList<Integer> res, Node root) {
        if (root == null)
            return;

        traverse(res, root.left);
        traverse(res, root.right);
        res.add(root.data);
    }
}