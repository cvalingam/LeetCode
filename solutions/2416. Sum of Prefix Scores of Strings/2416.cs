public class Solution
{
    private TrieNode root = new TrieNode();

    public int[] SumPrefixScores(string[] words)
    {
        int[] ans = new int[words.Length];

        foreach (var word in words)
            Insert(word);

        for (int i = 0; i < words.Length; ++i)
            ans[i] = GetScore(words[i]);

        return ans;
    }

    private void Insert(string word)
    {
        TrieNode node = root;
        foreach (var c in word)
        {
            int i = c - 'a';
            if (node.children[i] == null)
                node.children[i] = new TrieNode();
            node = node.children[i];
            ++node.count;
        }
    }

    private int GetScore(string word)
    {
        TrieNode node = root;
        int score = 0;
        foreach (var c in word)
        {
            node = node.children[c - 'a'];
            score += node.count;
        }
        return score;
    }
}

public class TrieNode
{
    public TrieNode[] children = new TrieNode[26];
    public int count = 0;
}