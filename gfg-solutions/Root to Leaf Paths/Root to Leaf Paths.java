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
    public static ArrayList<ArrayList<Integer>> Paths(Node root) {
        ArrayList<ArrayList<Integer>> result = new ArrayList<>();
        if (root == null)
            return result;

        ArrayList<Integer> currentPath = new ArrayList<>();
        findPaths(root, currentPath, result);
        return result;
    }

    private static void findPaths(Node node, ArrayList<Integer> currentPath, ArrayList<ArrayList<Integer>> result) {
        if (node == null)
            return;

        currentPath.add(node.data);

        if (node.left == null && node.right == null)
            result.add(new ArrayList<>(currentPath));
        else {
            findPaths(node.left, currentPath, result);
            findPaths(node.right, currentPath, result);
        }

        currentPath.remove(currentPath.size() - 1);
    }
}
