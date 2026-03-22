import java.util.*;

class Solution {
    // Function to return a list containing the bottom view of the given tree.
    public ArrayList<Integer> bottomView(Node root) {
        Queue<Pair> q = new ArrayDeque<>();
        Map<Integer, Integer> map = new TreeMap<>();

        q.add(new Pair(0, root));

        while (!q.isEmpty()) {
            Pair curr = q.poll();
            map.put(curr.hdist, curr.node.data);

            if (curr.node.left != null)
                q.add(new Pair(curr.hdist - 1, curr.node.left));

            if (curr.node.right != null)
                q.add(new Pair(curr.hdist + 1, curr.node.right));
        }

        ArrayList<Integer> ans = new ArrayList<>();

        for (Map.Entry<Integer, Integer> mp : map.entrySet())
            ans.add(mp.getValue());

        return ans;
    }
}

class Pair {
    int hdist;
    Node node;

    public Pair(int hdist, Node node) {
        this.hdist = hdist;
        this.node = node;
    }
}

class Node {
    int data; // data of the node
    int hd; // horizontal distance of the node
    Node left, right; // left and right references

    // Constructor of tree node
    public Node(int key) {
        data = key;
        hd = Integer.MAX_VALUE;
        left = right = null;
    }
}

// Version 2

class Solution1 {
    class Pair1 {
        Node node;
        int hd;

        Pair1(Node node, int hd) {
            this.node = node;
            this.hd = hd;
        }
    }

    public ArrayList<Integer> bottomView(Node root) {
        ArrayList<Integer> ans = new ArrayList<>();

        Queue<Pair1> q = new LinkedList<>();
        q.add(new Pair1(root, 0));

        TreeMap<Integer, Node> map = new TreeMap<>();

        while (!q.isEmpty()) {

            Pair1 curr = q.poll();
            map.put(curr.hd, curr.node);

            if (curr.node.left != null)
                q.add(new Pair1(curr.node.left, curr.hd - 1));
            if (curr.node.right != null)
                q.add(new Pair1(curr.node.right, curr.hd + 1));
        }

        for (int ele : map.keySet())
            ans.add(map.get(ele).data);

        return ans;
    }
}
