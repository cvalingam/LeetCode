public class Solution
{

    private readonly string[] belowTwenty = { "", "One", "Two", "Three", "Four",
                                               "Five", "Six", "Seven", "Eight", "Nine",
                                               "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen",
                                               "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
    private readonly string[] tens = { "", "", "Twenty", "Thirty", "Forty",
                                        "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

    public string NumberToWords(int num)
    {
        return num == 0 ? "Zero" : Helper(num);
    }

    private string Helper(int num)
    {
        StringBuilder s = new StringBuilder();

        if (num < 20)
            s.Append(belowTwenty[num]);
        else if (num < 100)
            s.Append(tens[num / 10]).Append(" ").Append(belowTwenty[num % 10]);
        else if (num < 1000)
            s.Append(Helper(num / 100)).Append(" Hundred ").Append(Helper(num % 100));
        else if (num < 1000000)
            s.Append(Helper(num / 1000)).Append(" Thousand ").Append(Helper(num % 1000));
        else if (num < 1000000000)
            s.Append(Helper(num / 1000000)).Append(" Million ").Append(Helper(num % 1000000));
        else
            s.Append(Helper(num / 1000000000)).Append(" Billion ").Append(Helper(num % 1000000000));

        return s.ToString().Trim();
    }
}