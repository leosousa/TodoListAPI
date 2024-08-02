namespace Domain.Entities;

/// <summary>
/// Classe que representa a tarefa na aplicação
/// </summary>
public class Task
{
    /// <summary>
    /// Identificador da tarefa
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Descrição da tarefa
    /// </summary>
    public required string Description { get; set; }

    /// <summary>
    /// Indicador de tarefa já realizada
    /// </summary>
    public bool IsCompleted { get; set; }
}