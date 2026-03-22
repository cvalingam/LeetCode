class Solution {
    public int findMin(int[] arr) {
        int i = 0;
        int j = arr.length - 1;
        int n = arr.length;

        while (i <= j) {
            int mid = (i + j) >> 1;
            int next = (mid + 1) % n;
            int prev = (mid + n - 1) % n;

            if (arr[mid] <= arr[next] && arr[prev] >= arr[mid])
                return arr[mid];
            else {
                if (arr[mid] < arr[j])
                    j = mid - 1;
                else
                    i = mid + 1;
            }
        }
        return -1;
    }
}
