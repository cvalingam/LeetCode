class WaterCell
{
    public int Row;
    public int Column;
    public int Height; // heightMap[Row][Column] or the height after filling water

    public WaterCell(int row, int column, int height)
    {
        Row = row;
        Column = column;
        Height = height;
    }
}

class Solution
{
    public int TrapRainWater(int[][] heightMap)
    {
        int[][] directions = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };
        int rowCount = heightMap.Length;
        int columnCount = heightMap[0].Length;
        int totalWater = 0;
        PriorityQueue<WaterCell, int> minHeap = new PriorityQueue<WaterCell, int>();
        bool[][] visited = new bool[rowCount][];

        for (int i = 0; i < rowCount; ++i)
        {
            visited[i] = new bool[columnCount];
            minHeap.Enqueue(new WaterCell(i, 0, heightMap[i][0]), heightMap[i][0]);
            minHeap.Enqueue(new WaterCell(i, columnCount - 1, heightMap[i][columnCount - 1]), heightMap[i][columnCount - 1]);
            visited[i][0] = true;
            visited[i][columnCount - 1] = true;
        }

        for (int j = 1; j < columnCount - 1; ++j)
        {
            minHeap.Enqueue(new WaterCell(0, j, heightMap[0][j]), heightMap[0][j]);
            minHeap.Enqueue(new WaterCell(rowCount - 1, j, heightMap[rowCount - 1][j]), heightMap[rowCount - 1][j]);
            visited[0][j] = true;
            visited[rowCount - 1][j] = true;
        }

        while (minHeap.Count > 0)
        {
            WaterCell currentCell = minHeap.Dequeue();
            int currentRow = currentCell.Row;
            int currentColumn = currentCell.Column;
            int currentHeight = currentCell.Height;

            foreach (int[] direction in directions)
            {
                int newRow = currentRow + direction[0];
                int newColumn = currentColumn + direction[1];

                if (newRow < 0 || newRow == rowCount || newColumn < 0 || newColumn == columnCount)
                    continue;
                if (visited[newRow][newColumn])
                    continue;

                if (heightMap[newRow][newColumn] < currentHeight)
                {
                    totalWater += currentHeight - heightMap[newRow][newColumn];
                    minHeap.Enqueue(new WaterCell(newRow, newColumn, currentHeight), currentHeight); // Fill water in grid[newRow][newColumn].
                }
                else
                    minHeap.Enqueue(new WaterCell(newRow, newColumn, heightMap[newRow][newColumn]), heightMap[newRow][newColumn]);

                visited[newRow][newColumn] = true;
            }
        }

        return totalWater;
    }
}