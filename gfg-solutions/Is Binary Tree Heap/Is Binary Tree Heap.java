import java.util.*;

class Node {
    int data;
    Node left, right;

    Node(int d) {
        data = d;
        left = right = null;
    }
}

class Solution {
    boolean isHeap(Node tree) {
        Queue<Node> q = new LinkedList<>();
        q.add(tree);
        while (!q.isEmpty()) {
            boolean siblingChild = true;
            int size = q.size();
            for (int i = 1; i <= size; i++) {
                Node curr = q.remove();
                // tree completeness check
                if (curr.left == null && curr.right != null)
                    return false;
                if ((curr.left != null || curr.right != null) && !siblingChild)
                    return false;

                // max-heap check
                if ((curr.left != null && curr.data < curr.left.data) ||
                        (curr.right != null && curr.data < curr.right.data))
                    return false;

                if (curr.left != null)
                    q.add(curr.left);
                if (curr.right != null)
                    q.add(curr.right);

                // tree-completeness maintenance
                if (curr.left == null || curr.right == null)
                    siblingChild = false;
            }
        }

        return true;
    }
}