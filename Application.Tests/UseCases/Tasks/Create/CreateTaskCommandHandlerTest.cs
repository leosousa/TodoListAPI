using Application.Tests.Mocks.Entities;
using Application.Tests.Mocks.UseCases.Tasks;
using Application.UseCases.Tasks.Create;
using Domain.Interfaces;
using Moq;

namespace Application.Tests.UseCases.Tasks.Create;

public sealed class CreateTaskCommandHandlerTest
{
    private Mock<ITaskRepository> _taskRepository;

    public CreateTaskCommandHandlerTest()
    {
        _taskRepository = new();
    }

    private CreateTaskCommandHandler GenerateScenario(Mock<ITaskRepository> _taskRepository)
    {
        return new CreateTaskCommandHandler(_taskRepository.Object);
    }

    [Fact(DisplayName = "Não deve cadastrar tarefa se a desrição não estiver preenchida")]
    public async Task ShouldNotRegisterTaskWithNullDescription()
    {
        var command = new CreateTaskCommand { Description = null };

        var handler = GenerateScenario(_taskRepository);

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.Null(result);
    }

    [Fact(DisplayName = "Deve cadastrar quando a descrição for enviada")]
    public async Task ShouldRegisterWhenDescriptionIsSent()
    {
        var command = CreateTaskCommandMock.GenerateValidCommand();
        var registeredTask = TaskMock.GenerateValidObject();

        _taskRepository.Setup(taskRepository =>
            taskRepository.CreateAsync(It.IsAny<Domain.Entities.Task>()))
        .ReturnsAsync(registeredTask);

        var handler = GenerateScenario(_taskRepository);

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.NotNull(result);
    }

    [Fact(DisplayName = "Deve retornar nulo quando a task cadastrada estiver nula")]
    public async Task ShouldReturnNullWhenRegisteredTaskIsNull()
    {
        var command = CreateTaskCommandMock.GenerateValidCommand();
        var registeredTask = TaskMock.GenerateNullObject();

        _taskRepository.Setup(taskRepository =>
            taskRepository.CreateAsync(It.IsAny<Domain.Entities.Task>()))
        .ReturnsAsync(registeredTask!);

        var handler = GenerateScenario(_taskRepository);

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.Null(result);
    }
}