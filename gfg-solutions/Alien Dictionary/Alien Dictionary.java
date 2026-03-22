import java.util.*;

class Solution {
    public String findOrder(String[] dictionary, int n, int k) {
        // Step 1: Build the graph
        List<Set<Integer>> adjList = new ArrayList<>();
        for (int i = 0; i < k; i++) {
            adjList.add(new HashSet<>());
        }
        int[] inDegree = new int[k];

        // Compare adjacent words to build the graph
        for (int i = 0; i < n - 1; i++) {
            String word1 = dictionary[i];
            String word2 = dictionary[i + 1];
            int minLength = Math.min(word1.length(), word2.length());
            boolean foundDifference = false;
            for (int j = 0; j < minLength; j++) {
                if (word1.charAt(j) != word2.charAt(j)) {
                    int u = word1.charAt(j) - 'a';
                    int v = word2.charAt(j) - 'a';
                    if (!adjList.get(u).contains(v)) {
                        adjList.get(u).add(v);
                        inDegree[v]++;
                    }
                    foundDifference = true;
                    break;
                }
            }
            // If no difference was found and word1 is longer than word2, invalid order
            if (!foundDifference && word1.length() > word2.length()) {
                return ""; // Returning an empty string for invalid input
            }
        }

        // Step 2: Perform topological sort using Kahn's Algorithm (BFS)
        Queue<Integer> zeroInDegreeQueue = new LinkedList<>();
        for (int i = 0; i < k; i++) {
            if (inDegree[i] == 0) {
                zeroInDegreeQueue.add(i);
            }
        }

        StringBuilder order = new StringBuilder();
        while (!zeroInDegreeQueue.isEmpty()) {
            int u = zeroInDegreeQueue.poll();
            order.append((char) (u + 'a'));
            for (int v : adjList.get(u)) {
                inDegree[v]--;
                if (inDegree[v] == 0) {
                    zeroInDegreeQueue.add(v);
                }
            }
        }

        // If the order contains fewer characters than K, there's a cycle
        if (order.length() < k) {
            return ""; // Invalid input with a cycle
        }

        return order.toString();
    }
}

class Solution1 {
    public String findOrder(String[] words) {
        Map<Character, Set<Character>> graph = new HashMap<>();
        Map<Character, Integer> inDegree = new HashMap<>();

        for (String word : words) {
            for (char c : word.toCharArray()) {
                graph.putIfAbsent(c, new HashSet<>());
                inDegree.putIfAbsent(c, 0);
            }
        }

        for (int i = 0; i < words.length - 1; i++) {
            String word1 = words[i];
            String word2 = words[i + 1];

            if (word1.length() > word2.length() && word1.startsWith(word2))
                return "";

            for (int j = 0; j < Math.min(word1.length(), word2.length()); j++) {
                char c1 = word1.charAt(j);
                char c2 = word2.charAt(j);
                if (c1 != c2) {
                    if (!graph.get(c1).contains(c2)) {
                        graph.get(c1).add(c2);
                        inDegree.put(c2, inDegree.get(c2) + 1);
                    }
                    break;
                }
            }
        }

        Queue<Character> queue = new LinkedList<>();
        for (char c : inDegree.keySet()) {
            if (inDegree.get(c) == 0)
                queue.offer(c);
        }

        StringBuilder result = new StringBuilder();
        while (!queue.isEmpty()) {
            char c = queue.poll();
            result.append(c);
            for (char neighbor : graph.get(c)) {
                inDegree.put(neighbor, inDegree.get(neighbor) - 1);
                if (inDegree.get(neighbor) == 0)
                    queue.offer(neighbor);
            }
        }

        if (result.length() < inDegree.size())
            return "";

        return result.toString();
    }
}