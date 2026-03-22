import java.util.*;

class Solution {
    // Non-static method, so you need to call it on an instance of the class
    public void nearlySorted(int[] arr, int k) {
        Queue<Integer> minHeap = new PriorityQueue<>();
        int j = 0;
        for (int i = 0; i < arr.length; i++) {
            minHeap.add(arr[i]);
            if (minHeap.size() > k)
                arr[j++] = minHeap.poll();
        }
        while (!minHeap.isEmpty())
            arr[j++] = minHeap.poll();
    }
}