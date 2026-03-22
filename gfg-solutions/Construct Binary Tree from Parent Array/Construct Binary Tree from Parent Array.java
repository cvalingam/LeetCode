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
    // Function to construct binary tree from parent array.
    public Node createTree(int parent[]) {

        HashMap<Integer, Node> map = new HashMap<>();
        for (int i = -1; i < parent.length; i++)
            map.put(i, new Node(i));

        for (int i = 0; i < parent.length; i++) {
            Node parentNode = map.get(parent[i]);
            Node childNode = map.get(i);

            if (parentNode.left == null)
                parentNode.left = childNode;
            else
                parentNode.right = childNode;
        }

        return map.get(-1).left;
    }
}
