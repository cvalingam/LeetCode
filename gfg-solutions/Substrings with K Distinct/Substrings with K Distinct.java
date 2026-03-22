class Solution {
    int countSubstr(String s, int k) {
        return (int) (calcCount(s, k) - calcCount(s, k - 1));
    }

    long calcCount(String s, int k) {
        // Using Sliding Window Approach
        int i = 0;
        int j = 0;
        int n = s.length();
        int[] charFreq = new int[26];
        int dist_count = 0;
        long ans = 0;
        while (j < n) {
            charFreq[s.charAt(j) - 'a']++;
            if (charFreq[s.charAt(j) - 'a'] == 1) // Distinct Character
                dist_count++;

            // Decreasing Window Size
            while (dist_count > k) {
                charFreq[s.charAt(i) - 'a']--;
                if (charFreq[s.charAt(i) - 'a'] == 0)
                    dist_count--;
                i++;
            }
            j++;
            ans += (j - i + 1);
        }
        return ans;
    }
}