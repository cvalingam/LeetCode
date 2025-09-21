public class MovieRentingSystem
{
    private class Entry : IComparable<Entry>
    {
        public int Price { get; }
        public int Shop { get; }
        public int Movie { get; }

        public Entry(int price, int shop, int movie)
        {
            Price = price;
            Shop = shop;
            Movie = movie;
        }

        public int CompareTo(Entry other)
        {
            int cmp = Price.CompareTo(other.Price);
            if (cmp != 0)
                return cmp;
            cmp = Shop.CompareTo(other.Shop);
            if (cmp != 0)
                return cmp;
            return Movie.CompareTo(other.Movie);
        }

        public override bool Equals(object obj)
        {
            if (obj is Entry other)
                return Price == other.Price && Shop == other.Shop && Movie == other.Movie;

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Price, Shop, Movie);
        }
    }

    private readonly Dictionary<int, SortedSet<Entry>> unrented = new();
    private readonly Dictionary<(int shop, int movie), int> shopAndMovieToPrice = new();
    private readonly SortedSet<Entry> rented = new();

    public MovieRentingSystem(int n, int[][] entries)
    {
        foreach (var e in entries)
        {
            int shop = e[0];
            int movie = e[1];
            int price = e[2];
            if (!unrented.ContainsKey(movie))
                unrented[movie] = new SortedSet<Entry>();

            var entry = new Entry(price, shop, movie);
            unrented[movie].Add(entry);
            shopAndMovieToPrice[(shop, movie)] = price;
        }
    }

    public IList<int> Search(int movie)
    {
        if (!unrented.TryGetValue(movie, out var set))
            return new List<int>();

        return set.Take(5).Select(e => e.Shop).ToList();
    }

    public void Rent(int shop, int movie)
    {
        int price = shopAndMovieToPrice[(shop, movie)];
        var entry = new Entry(price, shop, movie);
        unrented[movie].Remove(entry);
        rented.Add(entry);
    }

    public void Drop(int shop, int movie)
    {
        int price = shopAndMovieToPrice[(shop, movie)];
        var entry = new Entry(price, shop, movie);
        unrented[movie].Add(entry);
        rented.Remove(entry);
    }

    public IList<IList<int>> Report()
    {
        return rented.Take(5).Select(e => (IList<int>)new List<int> { e.Shop, e.Movie }).ToList();
    }
}

/**
 * Your MovieRentingSystem object will be instantiated and called as such:
 * MovieRentingSystem obj = new MovieRentingSystem(n, entries);
 * IList<int> param_1 = obj.Search(movie);
 * obj.Rent(shop,movie);
 * obj.Drop(shop,movie);
 * IList<IList<int>> param_4 = obj.Report();
 */