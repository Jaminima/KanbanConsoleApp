using System.Collections.Generic;
using System.Linq;
using KanbanConsoleApp.Features.Clients;
using KanbanConsoleApp.Features.Tasks;

namespace KanbanConsoleApp
{
    public class TaskEngine
    {
        private readonly TaskRepository _taskRepository = new TaskRepository();
        private readonly List<Client> clients = new List<Client>();

        public void SaveTask(Task task)
        {
            if (task.ClientName==null || clients.Any(x => x.Name == task.ClientName)) _taskRepository.SaveTask(task);
            else throw new System.Exception("The supplied Client could not be found.");
        }

        public void SwapTasks(string i1, string i2)
        {
            List<Task> tasks = _taskRepository.GetTasks();
            int indx1 = tasks.FindIndex(0, x => x.Id == i1);
            int indx2 = tasks.FindIndex(0, x => x.Id == i2);

            _taskRepository.Swap(indx1, indx2);
        }

        public Task RetrieveTaskById(string id)
        {
            return _taskRepository.GetTasks().Find(x=>x.Id==id);
        }

        public void SaveClient(Client client)
        {
            clients.Add(client);
        }

        public List<Client> GetClients()
        {
            return clients.OrderBy(x=>x.Name).ToList();
        }

        public void RemoveClientByName(string name)
        {
            int indx = clients.FindIndex(0,x => x.Name == name);
            if (indx>-1) clients.RemoveAt(indx);
        }

        public List<Task> GetTasksForClient(string clientName)
        {
            return _taskRepository.GetTasks().Where(x => x.ClientName == clientName).ToList();
        }
    }
}