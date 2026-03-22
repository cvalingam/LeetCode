import java.util.*;

class Solution {
    static Trie trie;
    static Boolean[] memo;

    public int wordBreak(String s, String[] dictionary) {
        trie = new Trie();

        for (String word : dictionary)
            trie.insert(word);

        memo = new Boolean[s.length()];
        return canBreak(s, 0) ? 1 : 0;
    }

    private boolean canBreak(String s, int start) {
        if (start == s.length())
            return true;
            
        if (memo[start] != null)
            return memo[start];

        TrieNode node = trie.root;
        for (int i = start; i < s.length(); i++) {
            char c = s.charAt(i);
            if (!node.children.containsKey(c))
                break;

            node = node.children.get(c);
            if (node.isEnd && canBreak(s, i + 1))
                return memo[start] = true;
        }

        return memo[start] = false;
    }
}

class TrieNode {
    Map<Character, TrieNode> children = new HashMap<>();
    boolean isEnd = false;
}

class Trie {
    TrieNode root;

    Trie() {
        root = new TrieNode();
    }

    void insert(String word) {
        TrieNode node = root;

        for (char c : word.toCharArray()) {
            node.children.putIfAbsent(c, new TrieNode());
            node = node.children.get(c);
        }

        node.isEnd = true;
    }

    boolean search(String word) {
        TrieNode node = root;

        for (char c : word.toCharArray()) {
            if (!node.children.containsKey(c))
                return false;
            node = node.children.get(c);
        }

        return node.isEnd;
    }
}