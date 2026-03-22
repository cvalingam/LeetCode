import java.util.*;

class Node {
    int data;
    Node left, right;

    Node(int key) {
        data = key;
        left = right = null;
    }
}

class Solution {

    public ArrayList<Integer> Ancestors(Node root, int target) {
        ArrayList<Integer> ans = new ArrayList<>();
        solve(root, target, ans);

        return ans;
    }

    private boolean solve(Node root, int target, ArrayList<Integer> ans) {
        if (root == null)
            return false;

        if (root.data == target)
            return true;

        boolean left = solve(root.left, target, ans);
        boolean right = solve(root.right, target, ans);

        if (left || right) {
            ans.add(root.data);
            return true;
        }

        return false;
    }
}