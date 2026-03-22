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
    class pair {
        int dis;
        Node node;

        pair(int dis, Node node) {
            this.dis = dis;
            this.node = node;
        }
    }

    public ArrayList<ArrayList<Integer>> verticalOrder(Node root) {
        // code here
        var ans = new ArrayList<ArrayList<Integer>>();
        if (root == null)
            return ans;

        Queue<pair> q = new ArrayDeque<>();
        var mp = new TreeMap<Integer, ArrayList<Integer>>();

        q.offer(new pair(0, root));
        while (!q.isEmpty()) {
            pair p = q.poll();
            int d = p.dis;
            Node node = p.node;

            mp.computeIfAbsent(d, k -> new ArrayList<Integer>()).add(node.data);

            if (node.left != null)
                q.offer(new pair(d - 1, node.left));
            if (node.right != null)
                q.offer(new pair(d + 1, node.right));
        }

        for (var l : mp.values())
            ans.add(l);

        return ans;
    }
}