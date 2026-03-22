import java.util.*;

class Node {
    int data;
    Node left, right;

    Node(int item) {
        data = item;
        left = right = null;
    }
}

class Tree {
    ArrayList<Integer> ans = new ArrayList<>();

    ArrayList<Integer> leftView(Node root) {
        add(root, 0);

        return ans;
    }

    void add(Node root, int count) {
        if (root == null)
            return;

        if (ans.size() <= count)
            ans.add(root.data);

        add(root.left, count + 1);
        add(root.right, count + 1);
    }
}