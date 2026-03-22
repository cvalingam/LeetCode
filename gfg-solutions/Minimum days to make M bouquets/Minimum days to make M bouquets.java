class Solution {
    public int minDaysBloom(int[] arr, int k, int m) {
        int n = arr.length;

        if ((long) m * k > n)
            return -1;

        int left = Integer.MAX_VALUE, right = Integer.MIN_VALUE;

        for (int day : arr) {
            left = Math.min(left, day);
            right = Math.max(right, day);
        }

        while (left < right) {
            int mid = left + (right - left) / 2;
            if (canMakeBouquets(arr, m, k, mid))
                right = mid;
            else
                left = mid + 1;
        }

        return left;
    }

    private boolean canMakeBouquets(int[] arr, int m, int k, int day) {
        int count = 0, bouquets = 0;
        for (int bloomDay : arr) {
            if (bloomDay <= day) {
                count++;
                if (count == k) {
                    bouquets++;
                    count = 0;
                }
            } else
                count = 0;
        }
        return bouquets >= m;
    }
}