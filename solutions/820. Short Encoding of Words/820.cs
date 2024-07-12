public class Solution
{
    public int MinimumLengthEncoding(string[] words)
    {
        int ans = 0;
        var root = new TrieNode();
        var heads = new List<TrieNode>();

        foreach (string word in new HashSet<string>(words))
            heads.Add(insert(root, word));

        foreach (TrieNode head in heads)
        {
            if (head.children.All(child => child == null))
                ans += head.depth + 1;
        }

        return ans;
    }

    private TrieNode insert(TrieNode root, string word)
    {
        TrieNode node = root;
        char[] reversedWord = word.ToCharArray();
        Array.Reverse(reversedWord);
        foreach (char ch in reversedWord)
        {
            int ind = ch - 'a';
            if (node.children[ind] == null)
                node.children[ind] = new TrieNode();
            node = node.children[ind];
        }
        node.depth = word.Length;
        return node;
    }
}

class TrieNode
{
    public TrieNode[] children = new TrieNode[26];
    public int depth = 0;
}