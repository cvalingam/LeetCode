public class Solution
{
    private record OfflineUser(int ReturnTimestamp, int UserId);

    public int[] CountMentions(int numberOfUsers, IList<IList<string>> events)
    {
        int[] ans = new int[numberOfUsers];
        bool[] online = new bool[numberOfUsers];
        Array.Fill(online, true);

        // min-heap to track users that are offline
        var offlineQueue = new PriorityQueue<OfflineUser, int>();
        int allMentionsCount = 0;

        var sortedEvents = events.OrderBy(e => int.Parse(e[1]))
                                  .ThenByDescending(e => e[0])
                                  .ToList();

        foreach (var eventItem in sortedEvents)
        {
            string eventType = eventItem[0];
            int timestamp = int.Parse(eventItem[1]);

            // Bring users back online if their offline period has ended.
            while (offlineQueue.Count > 0 && offlineQueue.Peek().ReturnTimestamp <= timestamp)
            {
                var user = offlineQueue.Dequeue();
                online[user.UserId] = true;
            }

            if (eventType == "MESSAGE")
            {
                string mentionsString = eventItem[2];
                if (mentionsString == "ALL")
                    allMentionsCount++;
                else if (mentionsString == "HERE")
                {
                    for (int userId = 0; userId < numberOfUsers; ++userId)
                    {
                        if (online[userId])
                            ans[userId]++;
                    }
                }
                else
                {
                    foreach (var userId in GetUserIds(mentionsString))
                        ans[userId]++;
                }
            }
            else if (eventType == "OFFLINE")
            {
                int userId = int.Parse(eventItem[2]);
                online[userId] = false;
                // Add to queue to bring back online after 60 units
                offlineQueue.Enqueue(new OfflineUser(timestamp + 60, userId), timestamp + 60);
            }
        }

        // Add the "ALL" mentions to all users.
        for (int userId = 0; userId < numberOfUsers; ++userId)
            ans[userId] += allMentionsCount;

        return ans;
    }

    private List<int> GetUserIds(string s)
    {
        var integers = new List<int>();
        foreach (var part in s.Split(' '))
            integers.Add(int.Parse(part.Substring(2)));
        return integers;
    }

}