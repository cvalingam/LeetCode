import java.util.*;

class Solution {
    public int assignHole(int[] mices, int[] holes) {
        Arrays.sort(mices);
        Arrays.sort(holes);
        int ans = 0;
        for (int i = 0; i < holes.length; i++)
            ans = Math.max(ans, Math.abs(holes[i] - mices[i]));
            
        return ans;
    }
};