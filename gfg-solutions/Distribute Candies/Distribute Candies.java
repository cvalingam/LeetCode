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
    
    int ans = 0;
    public int distCandy(Node root) {
        helper(root);
        return ans;
    }

    int helper(Node root) {
        if (root == null)
            return 0;

        int left = helper(root.left);
        int right = helper(root.right);
        ans += Math.abs(left) + Math.abs(right);
        return root.data + left + right - 1;
    }
}