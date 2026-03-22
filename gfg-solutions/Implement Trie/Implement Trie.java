class Trie {

    Node root;

    public Trie() {
        root = new Node();
    }

    // Insert a word into the Trie
    public void insert(String word) {
        Node node = root;
        for (int i = 0; i < word.length(); i++) {

            char ch = word.charAt(i);
            if (!node.isNode(ch))
                node.put(ch, new Node());

            node = node.get(ch);
        }
        node.setEnd();
    }

    // Search for a word in the Trie
    public boolean search(String word) {
        Node node = root;
        for (int i = 0; i < word.length(); i++) {

            char ch = word.charAt(i);
            if (!node.isNode(ch))
                return false;

            node = node.get(ch);
        }
        return node.isEnd();
    }

    // Check if a prefix exists in the Trie
    public boolean isPrefix(String word) {
        Node node = root;
        for (int i = 0; i < word.length(); i++) {

            char ch = word.charAt(i);
            if (!node.isNode(ch))
                return false;

            node = node.get(ch);
        }
        return true;
    }
}

class Node {
    Node nde[] = new Node[26];
    boolean end = false;

    Node get(char ch) {
        return nde[ch - 'a'];
    }

    boolean isNode(char ch) {
        return nde[ch - 'a'] != null;
    }

    void put(char ch, Node node) {
        nde[ch - 'a'] = node;
    }

    void setEnd() {
        end = true;
    }

    boolean isEnd() {
        return end;
    }
}