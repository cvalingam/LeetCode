public class Solution
{
    public int MaximalRectangle(char[][] matrix)
    {
        int maxRect = 0;
        int rows = matrix.Length;
        int cols = matrix[0].Length;

        int[] height = new int[cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i][j] == '1')
                    height[j]++;
                else
                    height[j] = 0;
            }
            int rect = largestRectangleArea(height);
            maxRect = Math.Max(maxRect, rect);
        }

        return maxRect;
    }

    static int largestRectangleArea(int[] histo)
    {
        Stack<int> st = new Stack<int>();
        int maxA = 0;
        int n = histo.Length;
        for (int i = 0; i <= n; i++)
        {
            while (st.Count != 0 && (i == n || histo[st.Peek()] >= histo[i]))
            {
                int height = histo[st.Peek()];
                st.Pop();
                int width;
                if (st.Count == 0)
                    width = i;
                else
                    width = i - st.Peek() - 1;
                maxA = Math.Max(maxA, width * height);
            }
            st.Push(i);
        }
        
        return maxA;
    }
}