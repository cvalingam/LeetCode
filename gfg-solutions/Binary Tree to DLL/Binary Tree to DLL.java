// Approach: In-order traversal. Convert BST to sorted doubly linked list in-place using Morris or recursive in-order.
// Track the previous node and link current node's left to prev, prev's right to current.
// Time: O(n) Space: O(h)
import java.util.*;

class Node {
    Node left, right;
    int data;

    Node(int d) {
        data = d;
        left = right = null;
    }

}

// This function should return head to the DLL

class Solution {
    // Function to convert binary tree to doubly linked list and return it.
    Node bToDLL(Node root) {
        ArrayList<Integer> list = new ArrayList<>();

        // Perform in-order traversal and store the node values in the list
        inOrder(root, list);

        // Convert ArrayList to a doubly linked list
        return convertToDLL(list);
    }

    void inOrder(Node root, ArrayList<Integer> list) {
        if (root == null)
            return;

        inOrder(root.left, list);
        list.add(root.data);
        inOrder(root.right, list);
    }

    Node convertToDLL(ArrayList<Integer> list) {
        if (list.isEmpty())
            return null;

        Node head = new Node(list.get(0));
        Node current = head;

        for (int i = 1; i < list.size(); i++) {
            Node newNode = new Node(list.get(i));
            current.right = newNode;
            newNode.left = current;
            current = newNode;
        }

        return head;
    }
}