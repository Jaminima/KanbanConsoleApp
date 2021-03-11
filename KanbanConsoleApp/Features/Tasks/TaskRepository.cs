using System.Collections.Generic;

namespace KanbanConsoleApp.Features.Tasks
{
    public class TaskRepository
    {
        private readonly List<Task> _tasks = new List<Task>();

        public void SaveTask(Task task)
        {
            _tasks.Add(task);
        }

        public void Swap(int i1,int i2)
        {
            Task t1 = _tasks[i1];
            _tasks[i1] = _tasks[i2];
            _tasks[i2] = t1;
        }

        public void RemoveAt(int i)
        {
            _tasks.RemoveAt(i);
        }

        public List<Task> GetTasks()
        {
            var tasksToReturn = new List<Task>();

            foreach (var task in _tasks)
            {
                tasksToReturn.Add(new Task
                {
                    Id = task.Id,
                    Description = task.Description,
                    ClientName = task.ClientName
                });
            }

            return tasksToReturn;
        }
    }
}
