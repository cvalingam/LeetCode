import java.util.*;

class Solution {
    public static int kthLargest(int[] arr, int k) {
        int n = arr.length;

        PriorityQueue<Integer> pq = new PriorityQueue<>();

        int last = 0;
        for (int i = 0; i < n; i++) {
            last += arr[i];
            pq.add(last);

            if (pq.size() > k)
                pq.poll();
            int sum = last;
            for (int j = 0; j < i; j++) {
                sum -= arr[j];

                pq.add(sum);

                if (pq.size() > k)
                    pq.poll();
            }

        }

        return pq.peek();
    }
}