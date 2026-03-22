class Solution {
    public int maxEdgesToAdd(int V, int[][] edges) {
        int E = edges.length;
        int maxPossible = ((V * (V - 1)) / 2);
        return maxPossible - E;
    }
}