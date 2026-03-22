class Solution {
    public static int countNumbers(int n) {
        int ans = 0;
        for (int i = 6; i * i <= n; i++) {
            int x = i * i, cnt = 1;
            for (int j = 2; j * j < x; j++) {
                if (x % j == 0)
                    cnt++;
                if (cnt > 4)
                    break;
            }
            if (cnt == 4)
                ans++;
        }
        
        return ans;
    }
}