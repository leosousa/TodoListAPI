namespace Domain.Interfaces;

/// <summary>
/// Interface de persistência das tarefas de forma abstrata, sem conhecimento da infra
/// do banco de dados
/// </summary>
public interface ITaskRepository
{
    /// <summary>
    /// Lista todas as tarefas armazenadas na base de dados
    /// </summary>
    /// <returns>Lista de tarefas encontradas</returns>
    Task<IEnumerable<Entities.Task>> GetAllAsync();

    /// <summary>
    /// Busca uma tarefa armazenada na base de dados pelo seu identificador
    /// </summary>
    /// <param name="id">Identificador da tarefa buscada</param>
    /// <returns>Tarefa encontrada</returns>
    Task<Entities.Task> GetByIdAsync(int id);

    /// <summary>
    /// Cadastra uma nova tarefa na base de dados
    /// </summary>
    /// <param name="task">Tarefa a ser cadastrada</param>
    /// <returns>Identificador da tarefa cadastrada</returns>
    Task<int> Create(Entities.Task task);
}