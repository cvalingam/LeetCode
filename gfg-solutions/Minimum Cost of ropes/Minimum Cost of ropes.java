import java.util.*;

class Solution {
    // Function to return the minimum cost of connecting the ropes.
    public long minCost(long[] arr) {
        PriorityQueue<Long> pq = new PriorityQueue<>();

        for (long val : arr)
            pq.add(val);

        long totalCost = 0;

        while (pq.size() > 1) {
            long first = pq.poll();
            long second = pq.poll();

            long cost = first + second;
            totalCost += cost;

            pq.add(cost);
        }

        return totalCost;
    }
}

// Version 2
class Solution1 {
    // Function to return the minimum cost of connecting the ropes.
    public long minCost(int[] arr) {
        PriorityQueue<Integer> pq = new PriorityQueue<>();

        for (int val : arr)
            pq.add(val);

        long totalCost = 0;

        while (pq.size() > 1) {
            int first = pq.poll();
            int second = pq.poll();

            int cost = first + second;
            totalCost += cost;

            pq.add(cost);
        }

        return totalCost;
    }
}