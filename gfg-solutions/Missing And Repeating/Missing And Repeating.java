import java.util.*;

class Solve {
    int[] findTwoElement(int arr[]) {
        int n = arr.length;
        int[] result = new int[2];

        // Mark visited indices as negative
        for (int i = 0; i < n; i++) {
            int index = Math.abs(arr[i]) - 1;
            if (arr[index] < 0)
                result[0] = index + 1; // Repeating number
            else
                arr[index] *= -1;
        }

        // Find missing number
        for (int i = 0; i < n; i++) {
            if (arr[i] > 0) {
                result[1] = i + 1; // Missing number
                break;
            }
        }

        return result;
    }
}

class Solution {
    ArrayList<Integer> findTwoElement(int arr[]) {
        int[] n = new int[arr.length + 1];
        ArrayList<Integer> al = new ArrayList<>();
        for (int i = 0; i < arr.length; i++) {
            n[arr[i]]++;
        }

        for (int i = 1; i < n.length; i++) {
            if (n[i] == 2)
                al.add(i);
        }
        for (int i = 1; i < n.length; i++) {
            if (n[i] == 0)
                al.add(i);
        }
        return al;
    }
}
