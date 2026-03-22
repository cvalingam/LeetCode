class Node {
    String data;
    Node next;

    Node(String x) {
        data = x;
        next = null;
    }
}

class Solution {
    public boolean compute(Node root) {
        String s = "";

        while (root.next != null) {
            s += root.data;
            root = root.next;
        }

        s += root.data;

        int i = 0, j = s.length() - 1;

        while (i++ <= j--) {
            if (s.charAt(i) != s.charAt(j))
                return false;
        }

        return true;
    }
}