public class Solution
{
    public int[] FindThePrefixCommonArray(int[] A, int[] B)
    {
        int[] commonArray = new int[A.Length];
        int commonNos = 0;
        for (int i = 0; i < A.Length; i++)
        {
            commonNos = 0;
            for (int j = 0; j <= i; j++)
            {
                for (int k = 0; k <= i; k++)
                {
                    if (A[j] == B[k])
                    {
                        commonNos++;
                    }
                }
            }
            Console.WriteLine("Common numbers: " + commonNos);
            commonArray[i] = commonNos;
        }

        return commonArray;
    }
}