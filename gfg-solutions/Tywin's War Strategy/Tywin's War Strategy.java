import java.util.*;

class Solution {
    public int minSoldiers(int[] arr, int k) {
        int n = (int) Math.ceil(arr.length / 2.0);
        ArrayList<Integer> temp = new ArrayList<>();
        for (int i = 0; i < arr.length; i++) {
            if (arr[i] % k != 0)
                temp.add(k - (arr[i] % k));
            else
                n = n - 1;
        }

        Collections.sort(temp);
        int res = 0;
        int count = 0;
        while (count < n) {
            res += temp.get(count);
            count++;
        }
        
        return res;
    }
}