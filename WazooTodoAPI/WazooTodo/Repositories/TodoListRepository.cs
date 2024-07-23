using WazooTodo.Models;
using WazooTodo.Data;
using Microsoft.EntityFrameworkCore;

namespace WazooTodo.Repositories
{
    public class TodoListRepository : ITodoListRepository
    {
        private readonly TodoDbContext _dbContext;

        public TodoListRepository(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TodoItem> AddItem(TodoItem item)
        {
            var entry = await _dbContext.TodoItems.AddAsync(item);

            return entry.Entity;
        }

        public void DeleteItem(TodoItem item)
        {
            _dbContext.TodoItems.Remove(item);
        }

        public async Task<List<TodoItem>> GetItems()
        {
            var items = await _dbContext.TodoItems.AsNoTracking().ToListAsync();

            return items;
        }

        public async Task<TodoItem?> GetById(long id)
        {
            var item = await _dbContext.TodoItems.FindAsync(id);

            if(item == null)
            {
                return null;
            }

            return item;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateItem(TodoItem item)
        {
            _dbContext.TodoItems.Update(item);

            //return entry.Entity;

            //var entry = await _dbContext.TodoItems.UpdateAsync(item);

            //return entry.Entity;

            //throw new NotImplementedException();
        }
    }
}
