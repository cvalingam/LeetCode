import java.util.*;

class Solution {
    public static int findUnion(int a[], int b[]) {
        Set<Integer> set = new HashSet<>();
        for (int ele : a)
            set.add(ele);
        for (int ele : b)
            set.add(ele);

        return set.size();
    }
}

class Solution1 {
    public static ArrayList<Integer> findUnion(int[] a, int[] b) {
        Set<Integer> set = new HashSet<>();
        for (int ele : a)
            set.add(ele);
        for (int ele : b)
            set.add(ele);

        return new ArrayList<Integer>(set);
    }
}