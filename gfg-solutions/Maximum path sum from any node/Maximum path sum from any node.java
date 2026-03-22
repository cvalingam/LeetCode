class Node {
    int data;
    Node left, right;

    Node(int d) {
        data = d;
        left = right = null;
    }
}

class Solution {
    // Function to return maximum path sum from any node in a tree.
    int findMaxSum(Node node) {
        int maxi[] = new int[1];
        maxi[0] = Integer.MIN_VALUE;
        maxsum(node, maxi);
        return maxi[0];
    }

    public int maxsum(Node node, int maxi[]) {
        if (node == null)
            return 0;
        int leftsum = Math.max(maxsum(node.left, maxi), 0);
        int rightsum = Math.max(maxsum(node.right, maxi), 0);

        maxi[0] = Math.max(maxi[0], leftsum + rightsum + node.data);

        return node.data + Math.max(leftsum, rightsum);
    }
}
