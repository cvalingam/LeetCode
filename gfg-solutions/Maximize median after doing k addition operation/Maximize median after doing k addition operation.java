import java.util.*;

class Solution {
    public int maximizeMedian(int[] arr, int k) {
        int n = arr.length;
        Arrays.sort(arr);
        PriorityQueue<Integer> pq = new PriorityQueue<>();

        int i = 0;
        if (n % 2 == 0)
            i = (n / 2) - 1;
        else
            i = n / 2;

        while (i < n) {
            pq.add(arr[i]);
            i++;
        }

        while (k > 0) {
            int elem = pq.poll();
            pq.add(elem + 1);
            k--;
        }
        if (n % 2 == 0)
            return (pq.poll() + pq.poll()) / 2;
            
        return pq.poll();
    }
}
