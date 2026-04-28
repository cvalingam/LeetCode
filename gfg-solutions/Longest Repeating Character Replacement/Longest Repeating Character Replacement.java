
class Solution {

    // Approach: Sliding window tracking the most-frequent-character count;
    // window is valid when (size - maxCount) <= k. Shrink from left when invalid.
    // Time: O(n) Space: O(1)
    public int longestSubstr(String s, int k) {
        int[] freq = new int[26];
        int left = 0;
        int maxCount = 0;
        int maxLength = 0;

        for (int right = 0; right < s.length(); right++) {
            int index = s.charAt(right) - 'A';
            freq[index]++;

            maxCount = Math.max(maxCount, freq[index]);

            // If more than k replacements needed → shrink window
            while ((right - left + 1) - maxCount > k) {
                freq[s.charAt(left) - 'A']--;
                left++;
            }

            maxLength = Math.max(maxLength, right - left + 1);
        }

        return maxLength;
    }
}
