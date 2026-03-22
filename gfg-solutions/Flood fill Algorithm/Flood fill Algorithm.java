import java.util.*;

class Solution {
    public int[][] floodFill(int[][] image, int sr, int sc, int newColor) {
        int n = image.length, m = image[0].length;
        boolean[][] visited = new boolean[n][m];
        int[][] direction = { { 0, -1 }, { -1, 0 }, { 0, 1 }, { 1, 0 } };
        Queue<Node> q = new LinkedList<>();
        q.add(new Node(sr, sc));

        while (!q.isEmpty()) {
            Node curr = q.remove();
            visited[curr.row][curr.col] = true;
            for (int[] dir : direction) {
                int newRow = dir[0] + curr.row;
                int newCol = dir[1] + curr.col;
                if (newRow >= 0 && newRow < n && newCol >= 0 && newCol < m &&
                        image[newRow][newCol] == image[sr][sc] && !visited[newRow][newCol]) {
                    image[newRow][newCol] = newColor;
                    q.add(new Node(newRow, newCol));
                }
            }
        }
        image[sr][sc] = newColor;
        return image;
    }
}

class Node {
    int row, col;

    public Node(int row, int col) {
        this.row = row;
        this.col = col;
    }
}