public class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        var trie = new Trie();

        foreach (string str in strs)
            trie.Insert(str);


        return trie.GetPrefix();
    }
}

public class Trie
{

    private static Node root;
    public Trie()
    {
        root = new Node();
    }

    public void Insert(string word)
    {
        Node node = root;
        foreach (char c in word)
        {
            if (!node.ContainsKey(c))
            {
                node.Add(c, new Node());
                node.childCount++;
                node.lastIndexes = c - 'a';
            }

            node = node.Get(c);
        }
        node.SetEnd();
    }

    public string GetPrefix()
    {
        Node node = root;
        StringBuilder sb = new StringBuilder();
        while (node.childCount == 1 && !node.IsEnd())
        {
            sb.Append((char)('a' + node.lastIndexes));
            node = node.Get(node.lastIndexes);
        }

        return sb.ToString();
    }
}

class Node
{
    Node[] links = new Node[26];
    bool flag = false;
    public int childCount = 0;
    public int lastIndexes;

    public bool ContainsKey(char ch)
    {
        return (links[ch - 'a'] != null);
    }

    public void Add(char ch, Node node)
    {
        links[ch - 'a'] = node;
    }

    public Node Get(char ch)
    {
        return links[ch - 'a'];
    }

    public Node Get(int ind)
    {
        return links[ind];
    }

    public void SetEnd()
    {
        flag = true;
    }

    public bool IsEnd()
    {
        return flag;
    }
}