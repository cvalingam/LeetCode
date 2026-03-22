class Solution {

    // Function to return length of longest subsequence of consecutive integers.
    public int longestConsecutive(int[] arr) {
        if (arr.length == 0)
            return 0; // Handle edge case for empty array

        HashSet<Integer> set = new HashSet<>();
        int min = Integer.MAX_VALUE;
        int max = -1;

        for (int i : arr) {
            min = Math.min(min, i);
            max = Math.max(max, i);
            set.add(i);
        }

        int m = 1;
        int cnt = 1;
        for (int i = min; i < max; i++) {
            if (set.contains(i + 1))
                cnt++;
            else {
                m = Math.max(cnt, m);
                cnt = 0;
            }
        }
        
        return Math.max(cnt, m);
    }
}