class Solution {
    public int countTriplets(int[] arr, int target) {
        int count = 0;
        for (int i = 0; i < arr.length - 2; i++) {
            int j = i + 1, k = arr.length - 1;
            while (j < k) {
                int s = arr[i] + arr[j] + arr[k];
                if (s == target) {
                    if (arr[j] == arr[k]) {
                        count += (k - j + 1) * (k - j) / 2;
                        break;
                    }
                    int left = 1, right = 1;
                    while (j + 1 < k && arr[j] == arr[j + 1]) {
                        j++;
                        left++;
                    }
                    while (k - 1 > j && arr[k] == arr[k - 1]) {
                        k--;
                        right++;
                    }
                    count += left * right;
                    j++;
                    k--;
                } else if (s < target)
                    j++;
                else
                    k--;
            }
        }
        return count;
    }
}