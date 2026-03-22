class Solution {
    public long kthElement(int k, int arr1[], int arr2[]) {
        int n = arr1.length;
        int m = arr2.length;

        if (n > m)
            kthElement(k, arr2, arr1);

        int low = Math.max(0, k - m), high = Math.min(n, k);

        while (low <= high) {
            int cut1 = (low + high) / 2;
            int cut2 = k - cut1;

            int l1 = cut1 == 0 ? Integer.MIN_VALUE : arr1[cut1 - 1];
            int l2 = cut2 == 0 ? Integer.MIN_VALUE : arr2[cut2 - 1];

            int r1 = cut1 == n ? Integer.MAX_VALUE : arr1[cut1];
            int r2 = cut2 == m ? Integer.MAX_VALUE : arr2[cut2];

            if (l1 <= r2 && l2 <= r1)
                return Math.max(l1, l2);
            else if (l1 > l2)
                high = cut1 - 1;
            else
                low = cut1 + 1;
        }

        return 1;
    }
}