using Application.Tests.Mocks.UseCases.Tasks;
using Application.UseCases.Tasks.Delete;
using Application.UseCases.Tasks.Update;
using FluentValidation;

namespace Application.Tests.UseCases.Tasks.Update;

public sealed class UpdateTaskCommandValidatorTests
{
    public UpdateTaskCommandValidatorTests()
    {
    }

    private UpdateTaskCommandValidator GenerateScenario()
    {
        return new UpdateTaskCommandValidator();
    }

    [Fact(DisplayName = "Id precisa ser válido")]
    public async Task IdMustBValid()
    {
        var updateCommand = UpdateTaskCommandMock.GenerateValidCommand();
        var validator = GenerateScenario();

        var result = await validator.ValidateAsync(updateCommand);

        Assert.True(result.IsValid);
    }

    [Fact(DisplayName = "Id não pode ser menor ou igual a zero")]
    public async Task IdCannotBeNull()
    {
        var updateCommand = UpdateTaskCommandMock.GenerateValidCommand();
        updateCommand.Id = 0;

        var validator = GenerateScenario();

        var result = await validator.ValidateAsync(updateCommand);

        Assert.False(result.IsValid);
    }



    [Fact(DisplayName = "Descrição precisa ser válido")]
    public async Task DescriptionMustBValid()
    {
        var updateCommand = UpdateTaskCommandMock.GenerateValidCommand();
        var validator = GenerateScenario();

        var result = await validator.ValidateAsync(updateCommand);

        Assert.True(result.IsValid);
    }

    [Fact(DisplayName = "Descrição não pode ser nula")]
    public async Task DescriptionCannotBeNull()
    {
        var updateCommand = UpdateTaskCommandMock.GenerateValidCommand();
        updateCommand.Description = null;

        var validator = GenerateScenario();

        var result = await validator.ValidateAsync(updateCommand);

        Assert.False(result.IsValid);
    }

    [Fact(DisplayName = "Descrição não pode ser vazia")]
    public async Task DescriptionCannotBeEmpty()
    {
        var updateCommand = UpdateTaskCommandMock.GenerateValidCommand();
        updateCommand.Description = string.Empty;

        var validator = GenerateScenario();

        var result = await validator.ValidateAsync(updateCommand);

        Assert.False(result.IsValid);
    }

    [Fact(DisplayName = "Descrição não pode ter mais caracteres do que o permitido")]
    public async Task DescriptionCannotBeLongerThanXCharacters()
    {
        var updateCommand = UpdateTaskCommandMock.GenerateDescriptionGreaterThanAllowedCommand();

        var validator = GenerateScenario();

        var result = await validator.ValidateAsync(updateCommand);

        Assert.False(result.IsValid);
    }
}
