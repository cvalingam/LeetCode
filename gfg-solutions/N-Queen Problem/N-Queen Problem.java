import java.util.*;

class Solution {
    ArrayList<ArrayList<Integer>> ans;

    public ArrayList<ArrayList<Integer>> nQueen(int n) {
        ans = new ArrayList<>();
        int[][] board = new int[n][n];
        solve(0, board, n);
        Collections.sort(ans, (a, b) -> {
            for (int i = 0; i < a.size(); i++) {
                if (!a.get(i).equals(b.get(i))) {
                    return a.get(i) - b.get(i);
                }
            }
            return 0;
        });
        return ans;
    }

    public void solve(int row, int[][] board, int n) {
        if (row == n) {
            makeBoard(board, n);
            return;
        }

        for (int col = 0; col < n; col++) {
            if (isSafe(row, col, board)) {
                board[row][col] = 1;
                solve(row + 1, board, n);
                board[row][col] = 0;
            }
        }
    }

    public void makeBoard(int[][] board, int n) {
        ArrayList<Integer> arr = new ArrayList<>();
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++)
                if (board[j][i] == 1)
                    arr.add(j + 1);
        }
        ans.add(arr);
    }

    public boolean isSafe(int row, int col, int[][] board) {
        // checking row upwards
        for (int i = 0; i < row; i++)
            if (board[i][col] == 1)
                return false;

        // checking left diagonal upwards
        int maxLeft = Math.min(row, col);
        for (int i = 0; i <= maxLeft; i++)
            if (board[row - i][col - i] == 1)
                return false;

        // checking right diagonal upwards
        int maxRight = Math.min(row, board.length - 1 - col);
        for (int i = 0; i <= maxRight; i++)
            if (board[row - i][col + i] == 1)
                return false;

        return true;
    }
}

// Variation 2
class Solution {
    public ArrayList<ArrayList<Integer>> nQueen(int n) {
        ArrayList<ArrayList<Integer>> solutions = new ArrayList<>();
        backtrack(n, 0, new ArrayList<>(), solutions);
        return solutions;
    }

    private void backtrack(int n, int col, ArrayList<Integer> queenPositions, ArrayList<ArrayList<Integer>> solutions) {
        if (col == n) {
            solutions.add(new ArrayList<>(queenPositions));
            return;
        }

        for (int row = 1; row <= n; row++) {
            if (isSafe(queenPositions, row, col)) {
                queenPositions.add(row);
                backtrack(n, col + 1, queenPositions, solutions);
                queenPositions.remove(queenPositions.size() - 1);
            }
        }
    }

    private boolean isSafe(ArrayList<Integer> queenPositions, int newRow, int newCol) {
        for (int col = 0; col < queenPositions.size(); col++) {
            int row = queenPositions.get(col);
            if (row == newRow || Math.abs(row - newRow) == Math.abs(col - newCol))
                return false;
        }
        return true;
    }
}
