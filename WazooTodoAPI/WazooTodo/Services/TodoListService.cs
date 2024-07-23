using AutoMapper;
using WazooTodo.Models;
using WazooTodo.Repositories;

namespace WazooTodo.Services
{
    public class TodoListService : ITodoListService
    {
        private readonly ITodoListRepository _repository;
        private readonly IMapper _mapper;

        public TodoListService(
            ITodoListRepository repository,
            IMapper mapper
        )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TodoItem> AddItem(TodoItem item)
        {
            var created = await _repository.AddItem(item);
            await _repository.SaveChangesAsync();

            return _mapper.Map<TodoItem>(created);
        }

        public async Task DeleteItem(long id)
        {
            var item = await _repository.GetById(id);

            if(item is null)
            {
                
            }

            _repository.DeleteItem(item);
            await _repository.SaveChangesAsync();
        }

        public async Task<TodoItem> GetItem(long id)
        {
            var item = await _repository.GetById(id);

            if (item == null)
            {
                throw new Exception("There are no items in the database");
            }

            return item;
        }

        public async Task<List<TodoItem>> GetItems()
        {
            var items = await _repository.GetItems();

            if (items.Count == 0)
            {
                throw new Exception("There are no items in the database");
            }

            return _mapper.Map<List<TodoItem>>(items);
        }

        public async Task<TodoItem> UpdateItem(long id, TodoItem item)
        {
            //var created = await _repository.UpdateItem(item);
            //await _repository.SaveChanges();

            //return _mapper.Map<TodoItem>(created);

            var existingItem = await _repository.GetById(id);

            if(existingItem == null)
            {
                return null;
            }

            existingItem.Description = item.Description;

            await _repository.UpdateItem(existingItem);
            await _repository.SaveChangesAsync();

            return _mapper.Map<TodoItem>(existingItem);
        }
    }
}
