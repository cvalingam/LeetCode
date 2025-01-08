public class Solution
{
    public int CountPrefixSuffixPairs(string[] words)
    {
        int ans = 0;
        Trie trie = new Trie();

        foreach (string word in words)
            ans += trie.Insert(word);

        return ans;
    }
}

class TrieNode
{
    public Dictionary<int, TrieNode> children = new Dictionary<int, TrieNode>();
    public int count = 0;
}

class Trie
{
    private TrieNode root = new TrieNode();

    public int Insert(string word)
    {
        int n = word.Length;
        int count = 0;
        TrieNode node = root;
        for (int i = 0; i < n; ++i)
        {
            char prefix = word[i];
            char suffix = word[n - 1 - i];
            int key = (prefix - 'a') * 26 + (suffix - 'a');

            if (!node.children.ContainsKey(key))
                node.children[key] = new TrieNode();

            node = node.children[key];
            count += node.count;
        }
        ++node.count;
        return count;
    }
}