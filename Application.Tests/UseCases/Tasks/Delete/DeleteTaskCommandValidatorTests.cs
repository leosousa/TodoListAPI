using Application.Tests.Mocks.UseCases.Tasks;
using Application.UseCases.Tasks.Create;
using Application.UseCases.Tasks.Delete;
using FluentValidation;

namespace Application.Tests.UseCases.Tasks.Delete;

public sealed class DeleteTaskCommandValidatorTests
{
    public DeleteTaskCommandValidatorTests()
    {
    }

    private DeleteTaskCommandValidator GenerateScenario()
    {
        return new DeleteTaskCommandValidator();
    }

    [Fact(DisplayName = "Id precisa ser válido")]
    public async Task IdMustBValid()
    {
        var deleteCommand = DeleteTaskCommandMock.GenerateValidCommand();
        var validator = GenerateScenario();

        var result = await validator.ValidateAsync(deleteCommand);

        Assert.True(result.IsValid);
    }

    [Fact(DisplayName = "Id não pode ser menor ou igual a zero")]
    public async Task IdCannotBeNull()
    {
        var deleteCommand = DeleteTaskCommandMock.GenerateValidCommand();
        deleteCommand.Id = 0;

        var validator = GenerateScenario();

        var result = await validator.ValidateAsync(deleteCommand);

        Assert.False(result.IsValid);
    }
}