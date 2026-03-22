import java.util.*;

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
    int cnt;

    public int sumK(Node root, int k) {
        cnt = 0;
        HashMap<Integer, Integer> map = new HashMap<>();
        solve(root, k, map, 0);

        return cnt;
    }

    void solve(Node root, int k, HashMap<Integer, Integer> map, int sum) {
        if (root == null)
            return;

        sum += root.data;

        if (sum == k)
            cnt++;
        if (map.containsKey(sum - k))
            cnt += map.get(sum - k);
        map.put(sum, map.getOrDefault(sum, 0) + 1);

        solve(root.left, k, map, sum);
        solve(root.right, k, map, sum);

        map.put(sum, map.get(sum) - 1);
        if (map.get(sum) == 0)
            map.remove(sum);
    }
}

// Solution 2
class Solution1 {
    public int helper(Node node, int k, int currentSum) {
        if (node == null)
            return 0;

        int count = 0;
        currentSum += node.data;
        if (currentSum == k)
            count++;

        count += helper(node.left, k, currentSum);
        count += helper(node.right, k, currentSum);

        return count;
    }

    public int dfs(Node node, int k) {
        if (node == null)
            return 0;

        int currentSum = helper(node, k, 0);

        currentSum += dfs(node.left, k);
        currentSum += dfs(node.right, k);

        return currentSum;
    }

    public int countAllPaths(Node root, int k) {
        return dfs(root, k);
    }
}