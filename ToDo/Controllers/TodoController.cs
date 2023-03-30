using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.Datas;
using ToDo.Models.Todo;
using ToDo.Models.TodoType;
using ToDo.Repository;
using ToDo.Repository.Contract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly ITodoRepository _todoRepository;

        public TodoController(IMapper mapper, ITodoRepository todoRepository)
        {
            _mapper = mapper;
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoDto>>> AllTodo()
        {
            var todos = await _todoRepository.GetAllAsync();

            var todoDtos = _mapper.Map<List<TodoDto>>(todos);

            return Ok(todoDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoDto>> GetTodo(int id)
        {
            var todo = await _todoRepository.GetAsync(id);

            if (todo == null)
                return NotFound();

            var todoDto = _mapper.Map<TodoDto>(todo);

            return Ok(todoDto);
        }

        [HttpGet("{id}/todoType")]
        public async Task<ActionResult<TodoWithTodoTypeDto>> GetTodoWithTodoType(int id)
        {
            var todo = await _todoRepository.GetWithTodoTypeAsync(id);

            if (todo == null)
                return NotFound();

            var todoDto = _mapper.Map<TodoWithTodoTypeDto>(todo);

            return Ok(todoDto);
        }

        [HttpPost]
        public async Task<ActionResult<TodoDto>> StoreTodo(CreateTodoDto createTodoDto)
        {
            var todo = _mapper.Map<Todo>(createTodoDto);

            await _todoRepository.CreateAsync(todo);

            var x = CreatedAtAction(nameof(GetTodoWithTodoType), new { id = todo.Id }, todo);

            return CreatedAtAction(nameof(GetTodoWithTodoType), new { id = todo.Id }, todo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TodoDto>> UpdateTodo(int id, UpdateTodoDto updateTodoDto)
        {
            if (id != updateTodoDto.Id)
                return BadRequest("Ivalid record Id");

            //_todoDbContext.Entry(todoType).State = EntityState.Modified;
            var todo = await _todoRepository.GetAsync(id);

            if (todo == null)
                return NotFound();

            _mapper.Map(updateTodoDto, todo);

            try
            {
                await _todoRepository.UpdateAsync(todo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TodoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var todo = await _todoRepository.GetAsync(id);

            if (todo == null)
                return NotFound();

            await _todoRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> TodoExists(int id)
        {
            return await _todoRepository.IsExists(id);
        }
    }
}

