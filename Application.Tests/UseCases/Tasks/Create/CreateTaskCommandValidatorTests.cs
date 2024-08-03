using Application.Tests.Mocks.UseCases.Tasks;
using Application.UseCases.Tasks.Create;
using Domain.Interfaces;
using Moq;

namespace Application.Tests.UseCases.Tasks.Create;

public sealed class CreateTaskCommandValidatorTests
{
    public CreateTaskCommandValidatorTests()
    {
    }

    private CreateTaskCommandValidator GenerateScenario()
    {
        return new CreateTaskCommandValidator();
    }

    [Fact(DisplayName = "Descrição precisa ser válido")]
    public async Task DescriptionMustBValid()
    {
        var createCommand = CreateTaskCommandMock.GenerateValidCommand();
        var validator = GenerateScenario();

        var result = await validator.ValidateAsync(createCommand);

        Assert.True(result.IsValid);
    }

    [Fact(DisplayName = "Descrição não pode ser nula")]
    public async Task DescriptionCannotBeNull()
    {
        var createCommand = CreateTaskCommandMock.GenerateValidCommand();
        createCommand.Description = null;

        var validator = GenerateScenario();

        var result = await validator.ValidateAsync(createCommand);

        Assert.False(result.IsValid);
    }

    [Fact(DisplayName = "Descrição não pode ser vazia")]
    public async Task DescriptionCannotBeEmpty()
    {
        var createCommand = CreateTaskCommandMock.GenerateValidCommand();
        createCommand.Description = string.Empty;

        var validator = GenerateScenario();

        var result = await validator.ValidateAsync(createCommand);

        Assert.False(result.IsValid);
    }

    [Fact(DisplayName = "Descrição não pode ter mais caracteres do que o permitido")]
    public async Task DescriptionCannotBeLongerThanXCharacters()
    {
        var createCommand = CreateTaskCommandMock.GenerateDescriptionGreaterThanAllowedCommand();

        var validator = GenerateScenario();

        var result = await validator.ValidateAsync(createCommand);

        Assert.False(result.IsValid);
    }
}