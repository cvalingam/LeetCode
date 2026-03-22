import java.util.*;

class Solution {
    public int minDifference(String[] arr) {
        ArrayList<Integer> ar = new ArrayList<>();
        int mid = 24 * 60 * 60, n = arr.length;
        for (int i = 0; i < n; i++) {
            String st = arr[i];
            int h = Integer.valueOf(st.substring(0, 2));
            int m = Integer.valueOf(st.substring(3, 5));
            int s = Integer.valueOf(st.substring(6, 8));
            ar.add(h * 60 * 60 + m * 60 + s);
        }

        Collections.sort(ar);
        int ans = mid;
        for (int i = 1; i < n; i++) {
            int diff = ar.get(i) - ar.get(i - 1);
            ans = Math.min(ans, diff);
            ans = Math.min(ans, (mid - ar.get(i)) + ar.get(0));
        }
        
        return ans;
    }
}
