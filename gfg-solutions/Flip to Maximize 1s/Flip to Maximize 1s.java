
// Approach: Kadane's-style greedy scan to find the best subarray to flip.
// Count all existing 1s as the baseline (mini). Run a second pass tracking a
// running score: +1 for each 0 (gains a 1 when flipped) and -1 for each 1 (loses a
// 1 when flipped). Reset the window whenever the running score drops to the baseline
// (no net gain). The maximum running score seen is the best achievable 1-count.
// Time: O(n) Space: O(1)
class Solution {

    int maxOnes(int[] arr) {
        int maxi = 0;
        for (int a : arr) {
            if (a == 1) {
                maxi++;
            }
        }

        int mini = maxi;
        int cur = mini;
        for (int a : arr) {
            if (cur <= mini && a == 1) {
                cur = mini; 
            }else if (a == 1) {
                cur--; 
            }else {
                cur++;
            }
            maxi = Math.max(maxi, cur);
        }
        
        return maxi;
    }
};
