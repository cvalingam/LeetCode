import java.util.*;

class Solution {
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

    public static int minTime(Node root, int target) {
        Map<Node, Node> parentMap = new HashMap<>();
        // Find the target node and build the parent map
        Node targetNode = BuildParentMap(root, target, parentMap);

        if (targetNode == null)
            return 0; // Target not found in the tree

        // BFS to simulate the burning process
        Queue<Node> queue = new LinkedList<>();
        Set<Node> visited = new HashSet<>();
        queue.add(targetNode);
        visited.add(targetNode);
        int time = 0;

        while (!queue.isEmpty()) {
            int size = queue.size();
            for (int i = 0; i < size; i++) {
                Node current = queue.poll();

                // Check and add the left child
                if (current.left != null && !visited.contains(current.left)) {
                    visited.add(current.left);
                    queue.add(current.left);
                }

                // Check and add the right child
                if (current.right != null && !visited.contains(current.right)) {
                    visited.add(current.right);
                    queue.add(current.right);
                }

                // Check and add the parent
                Node parent = parentMap.get(current);
                if (parent != null && !visited.contains(parent)) {
                    visited.add(parent);
                    queue.add(parent);
                }
            }
            time++; // Increment time after processing all nodes at the current level
        }

        return time - 1; // Subtract 1 because we increment time after the last burn
    }

    private static Node BuildParentMap(Node root, int target, Map<Node, Node> parentMap) {
        Queue<Node> queue = new LinkedList<>();
        queue.add(root);
        Node targetNode = null;

        while (!queue.isEmpty()) {
            Node current = queue.poll();

            // If we find the target node, store it
            if (current.data == target)
                targetNode = current;

            // Add left child and set parent
            if (current.left != null) {
                parentMap.put(current.left, current);
                queue.add(current.left);
            }

            // Add right child and set parent
            if (current.right != null) {
                parentMap.put(current.right, current);
                queue.add(current.right);
            }
        }

        return targetNode;
    }
}