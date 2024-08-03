using Application.Tests.Mocks.Entities;
using Application.Tests.Mocks.UseCases.Tasks;
using Application.UseCases.Tasks.GetById;
using Application.UseCases.Tasks.List;
using Domain.Interfaces;
using Moq;

namespace Application.Tests.UseCases.Tasks.List;

public sealed class GetTaskListQueryHandlerTests
{
    private Mock<ITaskRepository> _taskRepository;

    public GetTaskListQueryHandlerTests()
    {
        _taskRepository = new();
    }

    private GetTaskListQueryHandler GenerateScenario(Mock<ITaskRepository> _taskRepository)
    {
        return new GetTaskListQueryHandler(_taskRepository.Object);
    }

    [Fact(DisplayName = "Deve retornar nulo se nenhuma tarefa não for encontrada")]
    public async Task ShouldReturnNullIfNoTasksFound()
    {
        var query = GetTaskByIdQueryMock.GenerateValidCommand();
        var notFoundTasks = TaskMock.GenerateEmptyListObject();

        _taskRepository.Setup(taskRepository =>
            taskRepository.GetAllAsync())
        .ReturnsAsync(notFoundTasks);

        var handler = GenerateScenario(_taskRepository);

        var result = await handler.Handle(new GetTaskListQuery(), CancellationToken.None);

        Assert.Empty(result);
    }

    [Fact(DisplayName = "Deve retornar lista de tarefas encontradas")]
    public async Task ShouldReturnFoundTaskLists()
    {
        var query = GetTaskByIdQueryMock.GenerateValidCommand();
        var foundTasks = TaskMock.GenerateListObject();

        _taskRepository.Setup(taskRepository =>
            taskRepository.GetAllAsync())
        .ReturnsAsync(foundTasks);

        var handler = GenerateScenario(_taskRepository);

        var result = await handler.Handle(new GetTaskListQuery(), CancellationToken.None);

        Assert.NotEmpty(result);
    }
}