namespace WebApplication1.Services
{
    public interface ITaskService
    {
        Task Create(Task model);
        Task Update(int id, Task model);
        Task Delete(int id);
        Task Get(int id);
        IEnumerable<Task> GetAll(string keyword);
    }
}
