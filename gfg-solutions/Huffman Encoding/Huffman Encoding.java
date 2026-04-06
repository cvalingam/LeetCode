// Approach: Build a Huffman tree using a min-heap (priority queue) sorted by frequency.
// Repeatedly merge the two lowest-frequency nodes into a parent until one root remains.
// Traverse the tree assigning '0' for left and '1' for right to generate codes.
// Time: O(n log n) Space: O(n)
import java.util.*;

class Solution {

    static public class Node {

        int freq;
        int minIdx;
        Node left, right;

        public Node(int freq, int idx) {
            this.freq = freq;
            this.minIdx = idx;
            this.left = null;
            this.right = null;
        }
    }

    public ArrayList<String> huffmanCodes(String s, int f[]) {
        PriorityQueue<Node> pq = new PriorityQueue<Node>((a, b) -> (a.freq != b.freq) ? a.freq - b.freq : a.minIdx - b.minIdx);
        for (int i = 0; i < s.length(); i++) {
            pq.add(new Node(f[i], i));
        }

        if (pq.size() == 1) {
            return new ArrayList<String>(Arrays.asList("0"));
        }

        while (pq.size() > 1) {
            Node left = pq.poll(), right = pq.poll();
            Node parent = new Node(left.freq + right.freq, Math.min(left.minIdx, right.minIdx));
            parent.left = left;
            parent.right = right;
            pq.add(parent);
        }

        ArrayList<String> res = new ArrayList<>();
        traverse(pq.poll(), "", res);
        return res;
    }

    void traverse(Node node, String code, ArrayList<String> strs) {
        if (node == null) {
            return;
        }

        if (node.left == null && node.right == null) {
            strs.add(code);
            return;
        }

        traverse(node.left, code + '0', strs);
        traverse(node.right, code + '1', strs);
    }
}
