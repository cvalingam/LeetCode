import java.util.*;

class Node {
    int data;
    Node left, right;

    public Node(int data) {
        this.data = data;
    }
}

class Solution {
    public List<Node> printAllDups(Node root) {
        HashMap<String, Integer> map = new HashMap<>();
        List<Node> l = new ArrayList<>();

        solve(root, l, map);

        Collections.sort(l, (a, b) -> a.data - b.data);

        return l;
    }

    private String solve(Node root, List<Node> l, HashMap<String, Integer> map) {
        if (root == null)
            return "";

        String left = solve(root.left, l, map);
        String right = solve(root.right, l, map);

        String curr = left + "-" + root.data + "-" + right;

        if (map.getOrDefault(curr, 0) == 1)
            l.add(root);

        map.put(curr, map.getOrDefault(curr, 0) + 1);

        return curr;
    }
}