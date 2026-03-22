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
    public Node constructTree(int[] pre, int[] post) {
        return build(pre, post, new int[] { 0 }, 0, pre.length - 1);
    }

    private Node build(int[] pre, int[] post, int[] preIdx, int l, int h) {
        if (preIdx[0] >= pre.length || l > h)
            return null;
        Node root = new Node(pre[preIdx[0]++]);
        if (l == h)
            return root;

        int i = l;
        while (i <= h && pre[preIdx[0]] != post[i])
            i++;

        if (i <= h) {
            root.left = build(pre, post, preIdx, l, i);
            root.right = build(pre, post, preIdx, i + 1, h - 1);
        }
        return root;
    }

    int getHeight(Node root) {
        return (root == null) ? -1 : 1 + Math.max(getHeight(root.left), getHeight(root.right));
    }

    void levelOrder(Node root) {
        if (root == null)
            return;
        Queue<Node> q = new LinkedList<>();
        q.add(root);
        while (!q.isEmpty()) {
            int size = q.size();
            for (int i = 0; i < size; i++) {
                Node n = q.poll();
                if (n.data != -1) {
                    q.add(n.left != null ? n.left : new Node(-1));
                    q.add(n.right != null ? n.right : new Node(-1));
                }
            }
        }
    }
}