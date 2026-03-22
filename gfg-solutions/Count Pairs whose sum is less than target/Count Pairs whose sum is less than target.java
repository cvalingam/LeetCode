class Solution {
    int countPairs(int arr[], int target) {
        int n = arr.length;
        int left = 0;
        int right = n - 1;
        int count = 0;
        Arrays.sort(arr);
        while (left < right) {
            if (arr[left] + arr[right] < target) {
                count += (right - left);
                left++;
            } else
                right--;
        }
        return count;
    }
}