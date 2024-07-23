using WazooTodo.Models;

namespace WazooTodo.Repositories
{
    public interface ITodoListRepository
    {
        Task<TodoItem> AddItem(TodoItem item);
        Task<List<TodoItem>> GetItems();
        Task<TodoItem> GetById(long id);
        Task UpdateItem(TodoItem item);
        void DeleteItem(TodoItem item);
        Task<int> SaveChangesAsync();
    }
}
