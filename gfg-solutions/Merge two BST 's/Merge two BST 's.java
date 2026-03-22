import java.util.*;

class Node {
    int data;
    Node left, right;

    public Node(int d) {
        data = d;
        left = right = null;
    }
}

class Solution {
    // Function to return a list of integers denoting the node
    // values of both the BST in a sorted order.
    public List<Integer> merge(Node root1, Node root2) {
        List<Integer> ans = new ArrayList<>();
        solve(root1, ans);
        solve(root2, ans);

        Collections.sort(ans);

        return ans;
    }

    private void solve(Node root, List<Integer> list) {
        if (root == null)
            return;

        solve(root.left, list);
        list.add(root.data);
        solve(root.right, list);
    }
}
