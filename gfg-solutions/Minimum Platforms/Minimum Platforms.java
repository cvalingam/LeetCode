class Solution {
    // Function to find the minimum number of platforms required at the
    // railway station such that no train waits.
    static int findPlatform(int arr[], int dep[]) {
        int a[] = new int[2360];
        for (int i = 0; i < arr.length; i++)
            a[arr[i]]++;

        for (int i = 0; i < arr.length; i++) {
            if (dep[i] + 1 < a.length)
                a[dep[i] + 1]--;
        }

        int t = 0, ans = 0;
        for (int i = 0; i < a.length; i++) {
            t += a[i];
            ans = Math.max(ans, t);
        }

        return ans;
    }
}