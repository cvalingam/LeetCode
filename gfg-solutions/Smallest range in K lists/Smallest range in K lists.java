import java.util.*;

class Solution {

    class Node {
        int value, row, col;

        Node(int value, int row, int col) {
            this.value = value;
            this.row = row;
            this.col = col;
        }
    }

    public ArrayList<Integer> findSmallestRange(int[][] arr) {
        int k = arr.length;
        int n = arr[0].length;

        PriorityQueue<Node> minHeap = new PriorityQueue<>((a, b) -> a.value - b.value);
        int max = Integer.MIN_VALUE;
        int start = 0, end = Integer.MAX_VALUE;

        // Initialize heap with first element of each list
        for (int i = 0; i < k; i++) {
            minHeap.add(new Node(arr[i][0], i, 0));
            max = Math.max(max, arr[i][0]);
        }

        while (true) {
            Node curr = minHeap.poll();
            int min = curr.value;

            // Update range if it's smaller
            if (max - min < end - start) {
                start = min;
                end = max;
            }

            // If the current list has more elements, push the next one
            if (curr.col + 1 < n) {
                int nextVal = arr[curr.row][curr.col + 1];
                minHeap.add(new Node(nextVal, curr.row, curr.col + 1));
                max = Math.max(max, nextVal);
            } else {
                // One list is exhausted
                break;
            }
        }

        ArrayList<Integer> result = new ArrayList<>();
        result.add(start);
        result.add(end);
        return result;
    }
}