
// Approach: Iterate diagonals from top-left to bottom-right.
// Each diagonal d has elements at (row, col) where row - col = constant.
// Walk from top-right to bottom-left of each diagonal using row/col iterators.
// Time: O(n^2) Space: O(n^2)
import java.util.*;

class Solution {

    static ArrayList<Integer> diagView(int mat[][]) {
        int n = mat.length;
        int cnt = n + n - 1;
        int row = 0;
        int col = 0;
        ArrayList<Integer> result = new ArrayList<>();
        while (cnt > 0) {
            int colIterator = Math.min(col, n - 1);
            int rowIterator = Math.min(row, n - 1);

            while (colIterator >= 0 && rowIterator < n) {
                result.add(mat[rowIterator][colIterator]);
                rowIterator++;
                colIterator--;
            }
            col++;
            if (col >= n) {
                row++;
            }
            cnt--;
        }
        
        return result;
    }
}
