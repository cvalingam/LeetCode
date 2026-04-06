// Approach: Count integer pairs (w,h) where diagonal <= r*2 and w,h >= 1 using mathematical approach.
// Time: O(r^2) Space: O(1)
class Solution {
    int rectanglesInCircle(int r) {
        int ans = 0;
        int dia = 2 * r;
        int d2 = 4 * r * r;
        
        for(int i = 1; i < dia; i++)
        {
            int diff = d2 - (i * i);
            ans += Math.sqrt(diff);
        }
        
        return ans;
    }
};