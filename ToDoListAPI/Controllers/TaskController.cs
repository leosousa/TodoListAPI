using Application.UseCases.Tasks.Create;
using Application.UseCases.Tasks.Delete;
using Application.UseCases.Tasks.GetById;
using Application.UseCases.Tasks.List;
using Application.UseCases.Tasks.Update;
using Microsoft.AspNetCore.Mvc;

namespace ToDoListAPI.Controllers
{
    [Route("api/tasks")]
    public class TaskController : ApiControllerBase
    {
        /// <summary>
        /// Cadastra uma nova tarefa
        /// </summary>
        /// <param name="task">Tarfa a ser cadastrada</param>
        /// <returns>Id da nova tarefa cadastrada</returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskCommand task)
        {
            var registered = await Mediator.Send(task);

            if (registered is null) return StatusCode(StatusCodes.Status500InternalServerError);

            return CreatedAtAction(nameof(GetById),
               new
               {
                   id = registered.Id
               },
               registered
            );
        }

        /// <summary>
        /// Busca uma tarefa já cadastrada pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador da tarefa</param>
        /// <returns>Tarefa encontrada</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await Mediator.Send(new GetTaskByIdQuery { Id = id });

            if (result is null) return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Lista as tarefas cadastradas no banco de dados
        /// </summary>
        /// <returns>Lista de tarefas encontradas</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await Mediator.Send(new GetTaskListQuery());

            if (result is null) return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Atualiza uma tarefa já existente
        /// </summary>
        /// <param name="id">Identificador da tarefa a ser atualizada</param>
        /// <param name="task">Tarefa a ser atualizada</param>
        /// <returns>Tarefa atualizada</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTaskCommand task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            var result = await Mediator.Send(task);

            if (result is null) return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Remove uma tarefa já existente
        /// </summary>
        /// <param name="id">Identificador da tarefa a ser removida</param>
        /// <returns>Retorna se a tarefa foi ou não removida</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var taskRemoved = await Mediator.Send(new DeleteTaskCommand { Id = id });

            if (!taskRemoved) return NotFound();

            return Ok(taskRemoved);
        }
    }
}
