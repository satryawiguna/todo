using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.Datas;
using ToDo.Models.TodoType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoTypeController : ControllerBase
    {
        private readonly TodoDbContext _todoDbContext;
        private readonly IMapper _mapper;

        public TodoTypeController(TodoDbContext todoDbContext, IMapper mapper)
        {
            _todoDbContext = todoDbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoTypeDto>>> AllTodoType()
        {
            var todoTypes = await _todoDbContext.TodoTypes.ToListAsync();

            var todoTypeDtos = _mapper.Map<List<TodoTypeDto>>(todoTypes);

            return Ok(todoTypeDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoTypeDto>> GetTodoType(int id)
        {
            var todoType = await _todoDbContext.TodoTypes.FindAsync(id);

            if (todoType == null)
                return NotFound();

            var todoTypeDto = _mapper.Map<TodoTypeDto>(todoType);

            return Ok(todoTypeDto);
        }

        [HttpGet("{id}/todo")]
        public async Task<ActionResult<TodoTypeWithTodoDto>> GetTodoTypeWithTodo(int id)
        {
            var todoType = await _todoDbContext.TodoTypes.Include(q => q.Todos).FirstOrDefaultAsync(q => q.Id == id);

            if (todoType == null)
                return NotFound();

            var todoTypeDto = _mapper.Map<TodoTypeWithTodoDto>(todoType);

            return Ok(todoTypeDto);
        }

        [HttpPost]
        public async Task<ActionResult<TodoType>> StoreTodoType(CreateTodoTypeDto createTodoTypeDto)
        {
            var todoType = _mapper.Map<TodoType>(createTodoTypeDto);

            _todoDbContext.TodoTypes.Add(todoType);

            await _todoDbContext.SaveChangesAsync();

            return CreatedAtAction("GetTodoType", new { id = todoType.Id, title = todoType.Title });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TodoType>> UpdateTodoType(int id, TodoType todoType)
        {
            if (id != todoType.Id)
                return BadRequest("Ivalid record Id");

            _todoDbContext.Entry(todoType).State = EntityState.Modified;

            try
            {
                await _todoDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TodoTypeExists(id))
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
            var todoType = await _todoDbContext.TodoTypes.FindAsync(id);

            if (todoType == null)
                return NotFound();

            _todoDbContext.TodoTypes.Remove(todoType);

            await _todoDbContext.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> TodoTypeExists(int id)
        {
            return await _todoDbContext.TodoTypes.FindAsync(id) != null;
        }
    }
}

