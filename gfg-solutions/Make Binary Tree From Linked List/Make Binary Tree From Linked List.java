import java.util.*;

class Tree {
    int data;
    Tree left;
    Tree right;

    Tree(int d) {
        data = d;
        left = null;
        right = null;
    }
}

class Node {
    int data;
    Node next;

    Node(int d) {
        data = d;
        next = null;
    }
}

class GfG {
    // Function to make binary tree from linked list.
    public static Tree convert(Node head, Tree node) {
        Queue<Tree> q = new LinkedList<>();
        node = new Tree(head.data);
        head = head.next;
        q.add(node);

        while (head != null) {
            Tree root = q.poll();

            Tree left = new Tree(head.data);
            root.left = left;
            q.add(left);
            head = head.next;

            if (head == null)
                return node;

            Tree right = new Tree(head.data);
            root.right = right;
            q.add(right);
            head = head.next;
        }

        return node;
    }
}