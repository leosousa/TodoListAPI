using Application.Tests.Mocks.Entities;
using Application.Tests.Mocks.UseCases.Tasks;
using Application.UseCases.Tasks.Delete;
using Application.UseCases.Tasks.GetById;
using Domain.Interfaces;
using Moq;

namespace Application.Tests.UseCases.Tasks.GetById;

public sealed class GetTaskByIdQueryHandlerTests
{
    private Mock<ITaskRepository> _taskRepository;

    public GetTaskByIdQueryHandlerTests()
    {
        _taskRepository = new();
    }

    private GetTaskByIdQueryHandler GenerateScenario(Mock<ITaskRepository> _taskRepository)
    {
        return new GetTaskByIdQueryHandler(_taskRepository.Object);
    }

    [Fact(DisplayName = "Não deve buscar a tarefa se o id não for enviado")]
    public async Task ShouldNotSearchTaskIfIdIsNotSent()
    {
        var query = GetTaskByIdQueryMock.GenerateNullObject();

        var handler = GenerateScenario(_taskRepository);

        var result = await handler.Handle(query!, CancellationToken.None);

        Assert.Null(result);
    }

    [Fact(DisplayName = "Deve retornar nulo se a tarefa não for encontrada")]
    public async Task ShouldReturnNullITaskIsNotFound()
    {
        var query = GetTaskByIdQueryMock.GenerateValidCommand();
        var notFoundTask = TaskMock.GenerateNullObject();

        _taskRepository.Setup(taskRepository =>
            taskRepository.GetByIdAsync(It.IsAny<int>()))
        .ReturnsAsync(notFoundTask);

        var handler = GenerateScenario(_taskRepository);

        var result = await handler.Handle(query!, CancellationToken.None);

        Assert.Null(result);
    }

    [Fact(DisplayName = "Deve retornar a tarefa quando ela for encontrada")]
    public async Task ShouldReturnTaskWhenItIsFound()
    {
        var command = GetTaskByIdQueryMock.GenerateValidCommand();
        var foundedTask = TaskMock.GenerateValidObject();

        _taskRepository.Setup(taskRepository =>
            taskRepository.GetByIdAsync(It.IsAny<int>()))
        .ReturnsAsync(foundedTask);

        var handler = GenerateScenario(_taskRepository);

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.NotNull(result);
    }
}