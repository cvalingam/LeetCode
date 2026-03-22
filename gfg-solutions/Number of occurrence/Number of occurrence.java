class Solution {
    int countFreq(int[] arr, int target) {
        int ans = 0;
        for (int num : arr) {
            if (num == target)
                ans++;
        }
        return ans;
    }
}