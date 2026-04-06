// Approach: BST traversal. At each node, update the closest value seen so far and move left or right.
// Time: O(h) Space: O(1)
class Solution {
    public int findMaxFork(Node root, int k) {
        int ans = -1;

        while (root != null) {
            if (root.data == k)
                return k;
            else if (root.data < k) {
                ans = root.data;
                root = root.right;
            } else
                root = root.left;
        }

        return ans;
    }
}