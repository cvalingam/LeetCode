public class Solution
{
    public int LongestCommonPrefix(int[] arr1, int[] arr2)
    {
        int ans = 0;
        Trie trie = new Trie();

        foreach (int num in arr1)
            trie.Insert(num.ToString());

        foreach (int num in arr2)
            ans = Math.Max(ans, trie.Search(num.ToString()));

        return ans;
    }
}

class TrieNode
{
    public TrieNode[] children = new TrieNode[10];
}

class Trie
{
    private TrieNode root = new TrieNode();

    public void Insert(string word)
    {
        TrieNode node = root;
        foreach (char c in word)
        {
            int i = c - '0';
            if (node.children[i] == null)
                node.children[i] = new TrieNode();
            node = node.children[i];
        }
    }

    public int Search(string word)
    {
        int prefixLength = 0;
        TrieNode node = root;
        foreach (char c in word)
        {
            int i = c - '0';
            if (node.children[i] == null)
                break;
            node = node.children[i];
            prefixLength++;
        }
        return prefixLength;
    }
}