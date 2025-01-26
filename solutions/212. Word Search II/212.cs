public class TrieNode
{
    public TrieNode[] children = new TrieNode[26];
    public string word;
}

public class Solution
{
    private TrieNode root = new TrieNode();

    public IList<string> FindWords(char[][] board, string[] words)
    {
        foreach (var word in words)
            Insert(word);

        List<string> ans = new List<string>();

        for (int i = 0; i < board.Length; ++i)
        {
            for (int j = 0; j < board[0].Length; ++j)
                Dfs(board, i, j, root, ans);
        }

        return ans;
    }

    private void Insert(string word)
    {
        TrieNode node = root;
        foreach (char c in word)
        {
            int i = c - 'a';
            if (node.children[i] == null)
                node.children[i] = new TrieNode();
            node = node.children[i];
        }
        node.word = word;
    }

    private void Dfs(char[][] board, int i, int j, TrieNode node, List<string> ans)
    {
        if (i < 0 || i == board.Length || j < 0 || j == board[0].Length)
            return;
        if (board[i][j] == '*')
            return;

        char c = board[i][j];
        TrieNode child = node.children[c - 'a'];
        if (child == null)
            return;
        if (child.word != null)
        {
            ans.Add(child.word);
            child.word = null;
        }

        board[i][j] = '*';
        Dfs(board, i + 1, j, child, ans);
        Dfs(board, i - 1, j, child, ans);
        Dfs(board, i, j + 1, child, ans);
        Dfs(board, i, j - 1, child, ans);
        board[i][j] = c;
    }
}