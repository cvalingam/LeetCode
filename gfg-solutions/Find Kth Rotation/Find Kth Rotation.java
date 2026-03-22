class Solution {
    public int findKRotation(int arr[]) {
        int start = 0;
        int end = arr.length - 1;
        while (start <= end) {
            if (arr[start] <= arr[end])
                return start;

            int mid = start + (end - start) / 2;
            int next = (mid + 1) % arr.length;
            int prev = (mid + arr.length - 1) % arr.length;

            if (arr[mid] <= arr[prev] && arr[mid] <= arr[next])
                return mid;
            else if (arr[mid] >= arr[start])
                start = mid + 1;
            else
                end = mid - 1;

        }
        
        return 0;
    }
}