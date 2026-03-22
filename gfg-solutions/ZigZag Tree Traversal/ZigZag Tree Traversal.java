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
    ArrayList<Integer> zigZagTraversal(Node root) {
        ArrayList<Integer> list = new ArrayList<>();
        ArrayList<Integer> ans = new ArrayList<>();
        Queue<Node> queue = new LinkedList<>();

        int turn = 0;

        queue.offer(root);
        queue.offer(null);

        while (queue.size() > 1) {
            Node node = queue.poll();

            if (node == null) {
                queue.add(null);
                if (turn % 2 == 1)
                    Collections.reverse(list);
                turn++;
                ans.addAll(list);
                list = new ArrayList<>();
                continue;
            }

            list.add(node.data);

            if (node.left != null)
                queue.offer(node.left);
            if (node.right != null)
                queue.offer(node.right);
        }
        if (turn % 2 == 1)
            Collections.reverse(list);
        ans.addAll(list);
        return ans;
    }
}