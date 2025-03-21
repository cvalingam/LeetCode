public class Solution
{
    public IList<string> FindAllRecipes(string[] recipes, IList<IList<string>> ingredients, string[] supplies)
    {
        List<string> ans = new List<string>();
        HashSet<string> suppliesSet = new HashSet<string>(supplies);
        Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
        Dictionary<string, int> inDegrees = new Dictionary<string, int>();

        // Build the graph.
        for (int i = 0; i < recipes.Length; ++i)
        {
            foreach (var ingredient in ingredients[i])
            {
                if (!suppliesSet.Contains(ingredient))
                {
                    if (!graph.ContainsKey(ingredient))
                        graph[ingredient] = new List<string>();

                    graph[ingredient].Add(recipes[i]);
                    inDegrees[recipes[i]] = inDegrees.GetValueOrDefault(recipes[i], 0) + 1;
                }
            }
        }

        // Perform topological sorting.
        Queue<string> q = new Queue<string>(recipes.Where(recipe => inDegrees.GetValueOrDefault(recipe, 0) == 0));

        while (q.Count > 0)
        {
            string u = q.Dequeue();
            ans.Add(u);
            if (!graph.ContainsKey(u)) continue;
            foreach (var v in graph[u])
            {
                inDegrees[v] = inDegrees.GetValueOrDefault(v, 0) - 1;
                if (inDegrees[v] == 0)
                    q.Enqueue(v);
            }
        }

        return ans;
    }
}