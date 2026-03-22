class Solution {
    int[] printKClosest(int[] arr, int k, int x) {
        int n = arr.length;
        int index = getXorLesserElementIndex(arr, x);

        int left = index >= 0 && arr[index] == x ? index - 1 : index;
        int right = index + 1;

        int[] closestElements = new int[k];
        for (int kIndex = 0; kIndex < k; kIndex++) {
            int firstNum = left == -1 ? (int) 1e9 : Math.abs(arr[left] - x);
            int secondNum = right == n ? (int) 1e9 : Math.abs(arr[right] - x);

            if (firstNum < secondNum) {
                closestElements[kIndex] = arr[left];
                left--;
            } else {
                closestElements[kIndex] = arr[right];
                right++;
            }
        }
        
        return closestElements;
    }

    private int getXorLesserElementIndex(int[] arr, int x) {
        int low = 0, high = arr.length - 1;
        int index = -1;

        while (low <= high) {
            int mid = (low + high) / 2;
            if (arr[mid] <= x) {
                index = mid;
                low = mid + 1;
            } else
                high = mid - 1;

        }

        return index;
    }
}
