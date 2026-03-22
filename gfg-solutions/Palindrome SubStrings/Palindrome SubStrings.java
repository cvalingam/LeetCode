class Solution {
    public int countPS(String s) {
        int n = s.length();
        int cnt = 0;

        for (int i = 0; i < n; i++) {
            cnt += isPalindrome(i, i, s);
            cnt += isPalindrome(i, i + 1, s);
        }

        return cnt;
    }

    public int isPalindrome(int s, int e, String temp) {
        int cnt = 0;
        int n = temp.length();

        while (s >= 0 && e < n && temp.charAt(s) == temp.charAt(e)) {
            if (e - s + 1 >= 2)
                cnt++;
            s--;
            e++;
        }

        return cnt;
    }
}

class Solution1 {
    public int countPS(String s) {
        int n = s.length();
        int count = 0;

        // Odd-length palindromes
        for (int center = 0; center < n; center++) {
            int left = center, right = center;
            while (left >= 0 && right < n && s.charAt(left) == s.charAt(right)) {
                if (right - left + 1 >= 2)
                    count++;
                left--;
                right++;
            }
        }

        // Even-length palindromes
        for (int center = 0; center < n - 1; center++) {
            int left = center, right = center + 1;
            while (left >= 0 && right < n && s.charAt(left) == s.charAt(right)) {
                if (right - left + 1 >= 2)
                    count++;
                left--;
                right++;
            }
        }

        return count;
    }
}