using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WazooTodo.Data;
using WazooTodo.Models;
using WazooTodo.Services;

namespace WazooTodo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        //private readonly TodoDbContext _context;
        private readonly ITodoListService _todoListService;

        public TodoItemsController(ITodoListService todoListService)
        {
            _todoListService = todoListService;
        }

        // GET: api/TodoItems
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<List<TodoItem>>> GetTodoItems()
        {
            try
            {
                var items = await _todoListService.GetItems();

                return Ok(items);
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<TodoItem?> GetTodoItem(long id)
        {
            var todoItem = await _todoListService.GetItem(id);

            if (todoItem == null)
            {
                return null;
            }

            return todoItem;
        }

        //// PUT: api/TodoItems/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItem todoItem)
        {

            try
            {
                var added = await _todoListService.UpdateItem(id, todoItem);

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }



            //var todoItem = await _todoListService.GetItem(id);

            //if (id != todoItem.Id)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(todoItem).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!TodoItemExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            try 
            { 
                await _todoListService.AddItem(todoItem);

                return StatusCode(200);
            } 
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

         }

        //// DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            try
            {
                await _todoListService.DeleteItem(id);

                return NoContent();
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }

            //_context.TodoItems.Remove(todoItem);
            //await _context.SaveChangesAsync();

            //return NoContent();
        }

        //private bool TodoItemExists(long id)
        //{
        //    return _context.TodoItems.Any(e => e.Id == id);
        //}
    }
}
