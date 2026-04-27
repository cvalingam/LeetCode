
class Solution {

    // Approach: Sliding window with counts of '0', '1', and '2'; expand right,
    // and shrink left greedily while all three are present.
    // Time: O(n) Space: O(1)

    public int smallestSubstring(String s) {
        int cnt_0 = 0;
        int cnt_1 = 0;
        int cnt_2 = 0;

        int i = 0;
        int j = 0;

        int n = s.length();
        int ans = Integer.MAX_VALUE;

        while (j < n) {
            char ch_At_j = s.charAt(j);
            if (ch_At_j == '0') {
                cnt_0++;
            }
            if (ch_At_j == '1') {
                cnt_1++;
            }
            if (ch_At_j == '2') {
                cnt_2++;
            }

            while (cnt_0 >= 1 && cnt_1 >= 1 && cnt_2 >= 1) {
                ans = Math.min(ans, j - i + 1);
                char ch_At_i = s.charAt(i);
                if (ch_At_i == '0') {
                    cnt_0--;
                }
                if (ch_At_i == '1') {
                    cnt_1--;
                }
                if (ch_At_i == '2') {
                    cnt_2--;
                }
                i++;
            }
            j++;
        }
        return ans == Integer.MAX_VALUE ? -1 : ans;
    }
};
