// Approach: Apply the equation to all elements, sort the result (or use two-pointer since input is sorted).
// Time: O(n) Space: O(n)
import java.util.*;

class Solution {
    public ArrayList<Integer> sortArray(int[] arr, int A, int B, int C) {
        ArrayList<Integer> al = new ArrayList<>();
        for (int i : arr)
            al.add(A * (int) Math.pow(i, 2) + B * i + C);
        Collections.sort(al);
        return al;
    }
}