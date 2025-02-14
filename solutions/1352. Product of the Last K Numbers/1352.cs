public class ProductOfNumbers
{
    private List<int> prefix;
    public ProductOfNumbers()
    {
        prefix = new List<int> { 1 };
    }

    public void Add(int num)
    {
        if (num == 0)
            prefix = new List<int> { 1 };
        else
            prefix.Add(prefix[prefix.Count - 1] * num);
    }

    public int GetProduct(int k)
    {
        return k >= prefix.Count ? 0 : prefix[prefix.Count - 1] / prefix[prefix.Count - k - 1];
    }
}

/**
 * Your ProductOfNumbers object will be instantiated and called as such:
 * ProductOfNumbers obj = new ProductOfNumbers();
 * obj.Add(num);
 * int param_2 = obj.GetProduct(k);
 */