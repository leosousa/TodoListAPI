using Application.Tests.Mocks.Entities;
using Application.Tests.Mocks.UseCases.Tasks;
using Application.UseCases.Tasks.Update;
using Domain.Interfaces;
using Moq;

namespace Application.Tests.UseCases.Tasks.Update;

public sealed class UpdateTaskCommandHandlerTests
{
    private Mock<ITaskRepository> _taskRepository;

    public UpdateTaskCommandHandlerTests()
    {
        _taskRepository = new();
    }

    private UpdateTaskCommandHandler GenerateScenario(Mock<ITaskRepository> _taskRepository)
    {
        return new UpdateTaskCommandHandler(_taskRepository.Object);
    }

    [Fact(DisplayName = "Não deve atualizar a tarefa se os dados não forem enviados")]
    public async Task ShouldNotUpdateTaskWithNullDescriptionIfTheDataIsNotSent()
    {
        var command = UpdateTaskCommandMock.GenerateNullObject();

        var handler = GenerateScenario(_taskRepository);

        var result = await handler.Handle(command!, CancellationToken.None);

        Assert.Null(result);
    }

    [Fact(DisplayName = "Não deve atualizar uma tarefa quando ela não for encontrada")]
    public async Task ShouldNotUpdateTaskWhenItIsNotFound()
    {
        var command = UpdateTaskCommandMock.GenerateValidCommand();
        var foundedTask = TaskMock.GenerateNullObject();

        _taskRepository.Setup(taskRepository =>
            taskRepository.GetByIdAsync(It.IsAny<int>()))
        .ReturnsAsync(foundedTask);

        var handler = GenerateScenario(_taskRepository);

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.Null(result);
    }

    [Fact(DisplayName = "Deve atualizar uma tarefa quando ela for encontrada")]
    public async Task ShouldUpdateTaskWhenItIsFound()
    {
        var command = UpdateTaskCommandMock.GenerateValidCommand();
        var foundedTask = TaskMock.GenerateValidObject();
        var updatedTask = TaskMock.GenerateValidObject();

        _taskRepository.Setup(taskRepository =>
            taskRepository.GetByIdAsync(It.IsAny<int>()))
        .ReturnsAsync(foundedTask);

        _taskRepository.Setup(taskRepository =>
            taskRepository.UpdateAsync(It.IsAny<Domain.Entities.Task>()))
        .ReturnsAsync(updatedTask);

        var handler = GenerateScenario(_taskRepository);

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.NotNull(result);
    }

    [Fact(DisplayName = "Deve retornar nulo quando a task alterada estiver nula")]
    public async Task ShouldReturnNullWhenUpdatedTaskIsNull()
    {
        var command = UpdateTaskCommandMock.GenerateValidCommand();
        var foundedTask = TaskMock.GenerateValidObject();
        var updatedTask = TaskMock.GenerateNullObject();

        _taskRepository.Setup(taskRepository =>
            taskRepository.GetByIdAsync(It.IsAny<int>()))
        .ReturnsAsync(foundedTask);

        _taskRepository.Setup(taskRepository =>
            taskRepository.UpdateAsync(It.IsAny<Domain.Entities.Task>()))
        .ReturnsAsync(updatedTask!);

        var handler = GenerateScenario(_taskRepository);

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.Null(result);
    }
}
