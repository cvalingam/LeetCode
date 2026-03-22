class Solution {
    public int josephus(int n, int k) {
        int[] p = new int[n];
        for (int i = 0; i < n; i++)
            p[i] = i + 1;

        int c = 0;
        int j = 0, s = 1;
        while (j <= n) {
            // System.out.println(j);
            if (c == n - 1)
                break;
            else {
                if (j == n)
                    j = 0;
                else {
                    if (p[j] != 0) {
                        if (s == k) {
                            p[j] = 0;
                            s = 1;
                            c++;
                        } else
                            s++;
                    }
                    j++;
                }
            }
        }

        int r = 0;
        for (int i = 0; i < n; i++) {
            if (p[i] > 0) {
                r = p[i];
                break;
            }
        }

        return r;
    }
}