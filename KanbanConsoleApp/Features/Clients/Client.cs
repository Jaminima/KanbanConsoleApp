namespace KanbanConsoleApp.Features.Clients
{
    public class Client
    {
        public string Name { get; set; }

        public Client() { }

        public Client(string _name)
        {
            Name = _name;
        }
    }
}