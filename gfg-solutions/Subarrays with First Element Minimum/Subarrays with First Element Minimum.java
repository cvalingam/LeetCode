import java.util.*;

class Solution {
    public int countSubarrays(int[] arr) {
        int n = arr.length, cnt = 0;
        LinkedList<Integer> lt = new LinkedList<>();
        for (int i = 0; i < n; i++) {
            cnt += (n - i);
            while (!lt.isEmpty() && arr[lt.getLast()] > arr[i]) {
                cnt += (i - n);
                lt.removeLast();
            }
            lt.add(i);
        }
        
        return cnt;
    }
}
