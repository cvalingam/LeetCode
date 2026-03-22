import java.util.*;

class Solution {

    ArrayList<Integer> nthRowOfPascalTriangle(int n) {
        // Convert to 0-based index (original rows are 1-based)
        n -= 1;

        ArrayList<Integer> row = new ArrayList<>();

        // Initialize the row with 1s
        for (int i = 0; i <= n; i++)
            row.add(1);

        // Build the row in-place
        for (int i = 1; i < n; i++) {
            for (int j = i; j > 0; j--)
                row.set(j, row.get(j) + row.get(j - 1));
        }

        return row;
    }
}