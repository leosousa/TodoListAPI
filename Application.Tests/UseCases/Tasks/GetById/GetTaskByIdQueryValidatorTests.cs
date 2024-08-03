using Application.Tests.Mocks.UseCases.Tasks;
using Application.UseCases.Tasks.Delete;
using Application.UseCases.Tasks.GetById;

namespace Application.Tests.UseCases.Tasks.GetById;

public sealed class GetTaskByIdQueryValidatorTests
{
    public GetTaskByIdQueryValidatorTests()
    {
    }

    private GetTaskByIdQueryValidator GenerateScenario()
    {
        return new GetTaskByIdQueryValidator();
    }

    [Fact(DisplayName = "Id precisa ser válido")]
    public async Task IdMustBValid()
    {
        var query = GetTaskByIdQueryMock.GenerateValidCommand();
        var validator = GenerateScenario();

        var result = await validator.ValidateAsync(query);

        Assert.True(result.IsValid);
    }

    [Fact(DisplayName = "Id não pode ser menor ou igual a zero")]
    public async Task IdCannotBeNull()
    {
        var query = GetTaskByIdQueryMock.GenerateValidCommand();
        query.Id = 0;

        var validator = GenerateScenario();

        var result = await validator.ValidateAsync(query);

        Assert.False(result.IsValid);
    }
}