class Solution {
    int totalCount(int k, int[] arr) {
        int count = 0;

        for (int num : arr)
            count += (num + k - 1) / k;

        return count;
    }
}