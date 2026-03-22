class Node {
    int data;
    Node left, right;

    public Node(int d) {
        data = d;
        left = right = null;
    }
}

class Solution {
    HashSet<Integer> s = new HashSet<>();

    boolean findTarget(Node root, int target) {
        if (root == null)
            return false;
        boolean l = findTarget(root.left, target);
        boolean temp = false;
        if (s.contains(target - root.data))
            temp = true;
        s.add(root.data);
        boolean r = findTarget(root.right, target);
        return (l || r) || temp;
    }
}