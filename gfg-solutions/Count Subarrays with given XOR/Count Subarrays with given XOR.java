import java.util.*;

class Solution {
    public long subarrayXor(int arr[], int k) {
        long n = arr.length;
        long prefixxor = 0;
        long cnt = 0;
        HashMap<Long, Long> map = new HashMap<>();
        map.put(0L, 1L);
        for (int i = 0; i < n; i++) {
            prefixxor ^= arr[i];
            long target = prefixxor ^ k;
            cnt += map.getOrDefault(target, 0L);
            map.put(prefixxor, map.getOrDefault(prefixxor, 0L) + 1L);
        }
        
        return cnt;
    }
}