using Application.Tests.Mocks.Entities;
using Application.Tests.Mocks.UseCases.Tasks;
using Application.UseCases.Tasks.Delete;
using Domain.Interfaces;
using Moq;

namespace Application.Tests.UseCases.Tasks.Delete;

public sealed class DeleteTaskCommandHandlerTests
{
    private Mock<ITaskRepository> _taskRepository;

    public DeleteTaskCommandHandlerTests()
    {
        _taskRepository = new();
    }

    private DeleteTaskCommandHandler GenerateScenario(Mock<ITaskRepository> _taskRepository)
    {
        return new DeleteTaskCommandHandler(_taskRepository.Object);
    }

    [Fact(DisplayName = "Não deve remover a tarefa se o id não for enviado")]
    public async Task ShouldNotDeleteTaskIfIdIsNotSent()
    {
        var command = DeleteTaskCommandMock.GenerateNullObject();

        var handler = GenerateScenario(_taskRepository);

        var result = await handler.Handle(command!, CancellationToken.None);

        Assert.False(result);
    }

    [Fact(DisplayName = "Não deve remover a tarefa se a tarefa não for encontrada")]
    public async Task ShouldNotDeleteTaskIfItisNotSent()
    {
        var command = DeleteTaskCommandMock.GenerateValidCommand();
        var notFoundTask = TaskMock.GenerateNullObject();

        _taskRepository.Setup(taskRepository =>
            taskRepository.GetByIdAsync(It.IsAny<int>()))
        .ReturnsAsync(notFoundTask);

        var handler = GenerateScenario(_taskRepository);

        var result = await handler.Handle(command!, CancellationToken.None);

        Assert.False(result);
    }

    [Fact(DisplayName = "Deve retornar false quando não conseguir remover a tarefa")]
    public async Task ShouldReturnFalseWhenUnableToRemoveTask()
    {
        var command = DeleteTaskCommandMock.GenerateValidCommand();
        var foundedTask = TaskMock.GenerateValidObject();
        var removedTask = false;

        _taskRepository.Setup(taskRepository =>
            taskRepository.GetByIdAsync(It.IsAny<int>()))
        .ReturnsAsync(foundedTask);

        _taskRepository.Setup(taskRepository =>
            taskRepository.DeleteAsync(It.IsAny<Domain.Entities.Task>()))
        .ReturnsAsync(removedTask!);

        var handler = GenerateScenario(_taskRepository);

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.False(removedTask);
    }

    [Fact(DisplayName = "Deve remover a tarefa quando ela for encontrada")]
    public async Task ShouldDeleteTaskWhenItIsFound()
    {
        var command = DeleteTaskCommandMock.GenerateValidCommand();
        var foundedTask = TaskMock.GenerateValidObject();
        var removedTask = true;

        _taskRepository.Setup(taskRepository =>
            taskRepository.GetByIdAsync(It.IsAny<int>()))
        .ReturnsAsync(foundedTask);

        _taskRepository.Setup(taskRepository =>
            taskRepository.DeleteAsync(It.IsAny<Domain.Entities.Task>()))
        .ReturnsAsync(removedTask!);

        var handler = GenerateScenario(_taskRepository);

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.True(removedTask);
    }
}