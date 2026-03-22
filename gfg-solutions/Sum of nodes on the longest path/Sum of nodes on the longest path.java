class Node {
    int data;
    Node left, right;

    public Node(int data) {
        this.data = data;
    }
}

class Result {
    int maxLen;
    int maxSum;

    // constructor to initialize variables
    Result() {
        maxLen = 0;
        maxSum = Integer.MIN_VALUE;
    }
}

class Solution {
    public int sumOfLongRootToLeafPath(Node root) {
        Result res = new Result();
        find(root, 0, 0, res);
        return res.maxSum;
    }

    public static void find(Node root, int currSum, int currLen, Result res) {
        if (root == null) {
            // If at a leaf or end of path
            if (currLen > res.maxLen) {
                res.maxLen = currLen;
                res.maxSum = currSum;
            } else if (currLen == res.maxLen)
                res.maxSum = Math.max(res.maxSum, currSum);

            return;
        }

        // Recursive calls for left and right subtree
        find(root.left, currSum + root.data, currLen + 1, res);
        find(root.right, currSum + root.data, currLen + 1, res);
    }
}