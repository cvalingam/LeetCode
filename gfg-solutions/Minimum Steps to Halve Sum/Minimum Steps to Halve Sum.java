// Approach: Greedy with max-heap. Always halve the largest element; accumulate savings until total >= sum/2.
// Time: O(n log n) Space: O(n)
import java.util.*;

class Solution {
    public int minOperations(int[] arr) {
        PriorityQueue<Double> maxPq = new PriorityQueue<>(Collections.reverseOrder());

        double sum = 0;

        for (int i = 0; i < arr.length; i++) {
            sum += arr[i];
            maxPq.add((double) arr[i]);
        }
        double half = sum / 2;
        int minOperation = 0;

        while (sum > half) {
            double maxVal = maxPq.poll();
            double maxValHalf = maxVal / 2;
            sum -= maxValHalf;
            maxPq.add(maxValHalf);
            minOperation++;
        }
        return minOperation;
    }
}