class Solution {
    // Function to find the largest number after k swaps.
    public String findMaximumNum(String str, int k) {
        char s[] = str.toCharArray();

        // Selection Sort
        for (int i = 0; i < s.length; i++) {
            if (k == 0)
                break;
            int max = i;
            for (int j = i + 1; j < s.length; j++) {
                if (s[max] <= s[j])
                    max = j;
            }

            if (s[max] == s[i])
                continue;
            else {
                swap(i, max, s);
                k--;
            }
        }

        return new String(s);
    }

    void swap(int i, int j, char s[]) {
        char t = s[i];
        s[i] = s[j];
        s[j] = t;
    }
}