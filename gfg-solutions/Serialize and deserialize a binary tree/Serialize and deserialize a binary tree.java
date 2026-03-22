class Tree {
    int data;
    Tree left, right;

    Tree(int d) {
        data = d;
        left = right = null;
    }
}

class Tree {
    // Function to serialize a tree and return a list containing nodes of tree.
    public ArrayList<Integer> serialize(Node root) {
        ArrayList<Integer> list = new ArrayList<>();
        list.add(root.data);
        Queue<Node> queue = new LinkedList<>();
        queue.add(root);
        while (!queue.isEmpty()) {
            int size = queue.size();
            while (size-- > 0) {
                Node cur = queue.poll();
                Node left = cur.left;
                Node right = cur.right;
                list.add(getVal(left));
                list.add(getVal(right));
                if (left != null)
                    queue.add(left);
                if (right != null)
                    queue.add(right);
            }
        }
        return list;
    }

    // Function to deserialize a list and construct the tree.
    public Node deSerialize(ArrayList<Integer> arr) {
        Node root = new Node(arr.get(0));
        int ind = 1;
        int n = arr.size();
        Queue<Node> queue = new LinkedList<>();
        queue.add(root);
        while (!queue.isEmpty()) {
            int size = queue.size();
            while (size-- > 0) {
                Node cur = queue.poll();
                Node left = getNode(ind++, arr);
                Node right = getNode(ind++, arr);
                cur.left = left;
                cur.right = right;
                if (left != null)
                    queue.add(left);
                if (right != null)
                    queue.add(right);
            }
        }
        return root;
    }

    Node getNode(int ind, ArrayList<Integer> list) {
        if (ind >= list.size() || list.get(ind) == null)
            return null;
        return new Node(list.get(ind));
    }

    Integer getVal(Node cur) {
        if (cur == null)
            return null;
        return cur.data;
    }
};