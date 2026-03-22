class Node {
    int data;
    Node left, right;

    Node(int key) {
        data = key;
        left = right = null;
    }
}

class Solution {
    public static Node buildTree(int inorder[], int preorder[]) {
        int n = inorder.length;
        Node root = construct(inorder, 0, n - 1, preorder, 0, n - 1);
        return root;
    }

    public static Node construct(int[] in, int isi, int iei, int[] pre, int psi, int pei) {
        if (isi > iei || psi > pei)
            return null;

        Node node = new Node(pre[psi]);

        int cnt = 0;
        int itr = isi;

        while (in[itr] != node.data) {
            cnt++;
            itr++;
        }

        Node left = construct(in, isi, itr - 1, pre, psi + 1, psi + cnt);
        Node right = construct(in, itr + 1, iei, pre, psi + cnt + 1, pei);

        node.left = left;
        node.right = right;

        return node;
    }
}