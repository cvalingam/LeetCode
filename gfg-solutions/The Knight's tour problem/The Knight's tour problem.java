import java.util.*;

class Solution {
    int dr[] = { 2, 1, -1, -2, -2, -1, 1, 2 };
    int dc[] = { 1, 2, 2, 1, -1, -2, -2, -1 };

    boolean helper(ArrayList<ArrayList<Integer>> board, int n, int row, int col, int step) {
        board.get(row).set(col, step);
        if (step == (n * n) - 1)
            return true;

        for (int i = 0; i < 8; ++i) {
            int nrow = row + dr[i];
            int ncol = col + dc[i];

            if (nrow >= 0 && nrow < n && ncol >= 0 && ncol < n && board.get(nrow).get(ncol) == -1) {
                if (helper(board, n, nrow, ncol, step + 1))
                    return true;
            }
        }

        board.get(row).set(col, -1);
        return false;
    }

    public ArrayList<ArrayList<Integer>> knightTour(int n) {
        ArrayList<ArrayList<Integer>> board = new ArrayList<>(n);

        for (int i = 0; i < n; ++i)
            board.add(new ArrayList<>(n));

        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j)
                board.get(i).add(-1);
        }

        if (helper(board, n, 0, 0, 0))
            return board;

        board = new ArrayList<>();
        board.add(new ArrayList<>(Arrays.asList(-1)));
        return board;
    }
}