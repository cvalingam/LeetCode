import java.util.*;

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
    public int findMedian(Node root) {
        dfs(root);
        if (res.size() % 2 == 0)
            return res.get((res.size() - 1) / 2);
        return res.get((res.size()) / 2);
    }

    ArrayList<Integer> res = new ArrayList<>();

    void dfs(Node root) {
        if (root == null)
            return;
        dfs(root.left);
        res.add(root.data);
        dfs(root.right);
    }
}