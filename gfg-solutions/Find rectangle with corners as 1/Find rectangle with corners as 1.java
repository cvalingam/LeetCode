// Approach: For each pair of rows, find common column positions with 1. A rectangle exists if any column pair repeats.
// Time: O(n^2 * m) Space: O(m)
import java.util.*;

class Solution {
    public boolean ValidCorner(int mat[][]) {
        HashMap<Integer, ArrayList<Integer>> map = new HashMap<>();
        int n = mat.length;
        int m = mat[0].length;
        for (int i = 0; i < n; i++) {
            ArrayList<Integer> ar = new ArrayList<>();
            for (int j = 0; j < m; j++) {
                if (mat[i][j] == 1)
                    ar.add(j);
            }
            map.put(i, ar);
        }
        
        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                int c = 0;
                for (int x : map.get(j)) {
                    if (map.get(i).contains(x))
                        c++;
                }
                if (c >= 2)
                    return true;
            }
        }

        return false;
    }
}