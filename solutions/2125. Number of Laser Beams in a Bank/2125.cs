public class Solution
{
    public int NumberOfBeams(string[] bank)
    {
        int laserBeam = 0;
        int n = bank.Length;

        int prevBankDeviceCnt = 0;
        for (int i = 0; i < bank.Length; i++)
        {
            string b = bank[i];
            int deviceCnt = 0;
            int j = 0;
            while (j < b.Length)
            {
                if (b[j] == '1')
                    deviceCnt++;
                j++;
            }

            if (deviceCnt > 0)
            {
                laserBeam += prevBankDeviceCnt * deviceCnt;
                prevBankDeviceCnt = deviceCnt;
            }
        }

        return laserBeam;
    }
}