import java.util.*;

class Node {
    int val;
    ArrayList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new ArrayList<>();
    }

    public Node(int val) {
        this.val = val;
        neighbors = new ArrayList<>();
    }

    public Node(int val, ArrayList<Node> neighbors) {
        this.val = val;
        this.neighbors = neighbors;
    }
}

class Solution {
    Node cloneGraph(Node node) {
        Set<Node> vis = new HashSet<>();
        return dfs(node, vis);
    }

    private Node dfs(Node node, Set<Node> vis) {
        vis.add(node);
        Node copyNode = new Node(node.val);
        for (Node neighbour : node.neighbors) {
            if (!vis.contains(neighbour))
                copyNode.neighbors.add(dfs(neighbour, vis));
        }

        return copyNode;
    }
}