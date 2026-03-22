import java.util.*;

class Solution {
    public static ArrayList<Integer> alternateSort(int[] arr) {
        ArrayList<Integer> list = new ArrayList<>();
        int n = arr.length;
        Arrays.sort(arr);
        int left = 0;
        int right = n - 1;
        while (left <= right) {
            if (left == right) {
                list.add(arr[left++]);
                return list;
            }
            list.add(arr[right--]);
            list.add(arr[left++]);
        }
        return list;
    }
}
