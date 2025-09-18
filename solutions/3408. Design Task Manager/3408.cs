class Task : IComparable<Task>
{
    public int UserId { get; set; }
    public int TaskId { get; set; }
    public int Priority { get; set; }

    public Task() { }

    public Task(int userId, int taskId, int priority)
    {
        UserId = userId;
        TaskId = taskId;
        Priority = priority;
    }

    public int CompareTo(Task other)
    {
        return this.Priority == other.Priority ? other.TaskId.CompareTo(this.TaskId)
                                               : other.Priority.CompareTo(this.Priority);
    }
}

class TaskManager
{
    private Dictionary<int, Task> taskMap = new Dictionary<int, Task>(); // {taskId: Task}
    private SortedSet<Task> taskSet; // Stores tasks sorted by priority and taskId.

    public TaskManager(IList<IList<int>> tasks)
    {
        taskSet = new SortedSet<Task>();
        foreach (var task in tasks)
            Add(task[0], task[1], task[2]);
    }

    public void Add(int userId, int taskId, int priority)
    {
        Task task = new Task(userId, taskId, priority);
        taskMap[taskId] = task;
        taskSet.Add(task);
    }

    public void Edit(int taskId, int newPriority)
    {
        if (taskMap.TryGetValue(taskId, out Task task))
        {
            taskSet.Remove(task);
            Task editedTask = new Task(task.UserId, taskId, newPriority);
            taskSet.Add(editedTask);
            taskMap[taskId] = editedTask;
        }
    }

    public void Rmv(int taskId)
    {
        if (taskMap.TryGetValue(taskId, out Task task))
        {
            taskSet.Remove(task);
            taskMap.Remove(taskId);
        }
    }

    public int ExecTop()
    {
        if (taskSet.Count == 0)
            return -1;

        Task task = taskSet.Min;
        taskSet.Remove(task);
        taskMap.Remove(task.TaskId);
        return task.UserId;
    }
}