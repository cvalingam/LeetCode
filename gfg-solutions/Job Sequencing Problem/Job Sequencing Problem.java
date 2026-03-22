import java.util.*;

class Solution {
    // Function to find the maximum profit and the number of jobs done.
    int[] JobScheduling(Job arr[], int n) {
        Arrays.sort(arr, (a, b) -> b.profit - a.profit);

        int cnt = 0, sum = 0;
        boolean[] used = new boolean[n + 1];

        for (Job j : arr) {
            int d = j.deadline;
            while (d > 0) {
                if (!used[d]) {
                    used[d] = true;
                    cnt++;
                    sum += j.profit;
                    break;
                }
                d--;
            }
        }

        return new int[] { cnt, sum };
    }
}

class Job {
    int id, profit, deadline;

    Job(int x, int y, int z) {
        this.id = x;
        this.deadline = y;
        this.profit = z;
    }
}

class Solution1 {

    public ArrayList<Integer> jobSequencing(int[] deadline, int[] profit) {
        int n = deadline.length;
        Job[] jobs = new Job[n];

        // Step 1: Store jobs with deadlines and profits
        for (int i = 0; i < n; i++)
            jobs[i] = new Job(deadline[i], profit[i]);

        // Step 2: Sort jobs by profit in descending order
        Arrays.sort(jobs, (a, b) -> b.profit - a.profit);

        // Step 3: Find maximum deadline
        int maxDeadline = 0;
        for (Job job : jobs)
            maxDeadline = Math.max(maxDeadline, job.deadline);

        // Step 4: Create a slot array to track scheduled jobs
        boolean[] slot = new boolean[maxDeadline + 1];

        int maxProfit = 0, countJobs = 0;

        // Step 5: Assign jobs to the latest available slot before their deadline
        for (Job job : jobs) {
            for (int j = job.deadline; j > 0; j--) {
                if (!slot[j]) {
                    slot[j] = true;
                    maxProfit += job.profit;
                    countJobs++;
                    break;
                }
            }
        }

        // Step 6: Return the result as an ArrayList
        ArrayList<Integer> result = new ArrayList<>();
        result.add(countJobs);
        result.add(maxProfit);
        return result;
    }

    // Custom class to store job details
    static class Job {
        int deadline, profit;

        Job(int deadline, int profit) {
            this.deadline = deadline;
            this.profit = profit;
        }
    }
}
