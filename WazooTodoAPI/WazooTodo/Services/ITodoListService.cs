using WazooTodo.Models;

namespace WazooTodo.Services
{
    public interface ITodoListService
    {
        Task<List<TodoItem>> GetItems();
        Task<TodoItem> GetItem(long id);
        Task<TodoItem> AddItem(TodoItem item);
        Task<TodoItem> UpdateItem(long id, TodoItem item);
        Task DeleteItem(long id);
    }
}
