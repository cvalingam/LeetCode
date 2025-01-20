public class Solution
{
    public IList<IList<string>> SolveNQueens(int n)
    {
        IList<IList<string>> ans = new List<IList<string>>();
        char[][] board = new char[n][];

        for (int i = 0; i < n; i++)
        {
            char[] s = new char[n];
            Array.Fill(s, '.');
            board[i] = s;
        }

        Solve(0, board, ans, n);

        return ans;
    }

    private void Solve(int col, char[][] board, IList<IList<string>> ans, int n)
    {
        if (col == n)
        {
            ans.Add(construct(board));
            return;
        }

        for (int row = 0; row < n; row++)
        {
            if (isSafe(row, col, board, n))
            {
                board[row][col] = 'Q';
                Solve(col + 1, board, ans, n);
                board[row][col] = '.';
            }
        }
    }

    private IList<string> construct(char[][] board)
    {
        IList<string> res = new List<string>();
        for (int i = 0; i < board.Length; i++)
            res.Add(new String(board[i]));
        return res;
    }

    private bool isSafe(int row, int col, char[][] board, int n)
    {
        int r = row, c = col;
        // upper diagonal
        while (r >= 0 && c >= 0)
        {
            if (board[r][c] == 'Q')
                return false;
            r--;
            c--;
        }

        r = row;
        c = col;
        //left
        while (c >= 0)
        {
            if (board[r][c] == 'Q')
                return false;
            c--;
        }

        r = row;
        c = col;
        // lower diagonal
        while (r < n && c >= 0)
        {
            if (board[r][c] == 'Q')
                return false;
            r++;
            c--;
        }

        return true;
    }
}