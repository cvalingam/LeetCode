class Solution {
    public int findMissing(int[] arr) {
        int n = arr.length;
        int diff1 = arr[1] - arr[0];

        if (n == 2)
            return arr[1] + diff1;

        int diff2 = arr[2] - arr[1];
        int diff = Math.min(diff1, diff2);

        if (diff == 0)
            return arr[0];

        int l = 0, h = n - 1;
        
        while (l <= h) {
            int m = (l + h) / 2;

            int expectedPos = (arr[m] - arr[0]) / diff;
            int actualPos = m;

            if (actualPos < expectedPos)
                h = m - 1;
            else
                l = m + 1;
        }

        if (l == n)
            return arr[n - 1] + diff;

        return arr[0] + diff * l;
    }
}
