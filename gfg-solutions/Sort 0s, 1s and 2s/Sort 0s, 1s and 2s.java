import java.util.*;

class Solution {
    // Function to sort an array of 0s, 1s, and 2s
    public void sort012(ArrayList<Integer> arr) {
        int left = 0;
        int r = arr.size() - 1;
        int mid = 0;

        while (mid <= r) {
            if (arr.get(mid) == 2) {
                swap(arr, mid, r);
                r--;
            } else if (arr.get(mid) == 0) {
                swap(arr, mid, left);
                left++;
                mid++;
            } else {
                mid++;
            }
        }
    }

    private void swap(List<Integer> arr, int i, int j) {
        int temp = arr.get(i);
        arr.set(i, arr.get(j));
        arr.set(j, temp);
    }
}

// Version 2
class Solution1 {
    public void sort012(int[] arr) {
        int n = arr.length;
        int count0 = 0;
        int count1 = 0;

        for (int i = 0; i < n; i++) {
            if (arr[i] == 0)
                count0++;
            else if (arr[i] == 1)
                count1++;
        }

        for (int i = 0; i < n; i++) {
            if (count0 > 0) {
                arr[i] = 0;
                count0--;
            } else if (count1 > 0) {
                arr[i] = 1;
                count1--;
            } else
                arr[i] = 2;
        }
    }
}