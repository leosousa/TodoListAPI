using Application.UseCases.Tasks.Delete;
using Application.UseCases.Tasks.GetById;
using Bogus;

namespace Application.Tests.Mocks.UseCases.Tasks;

public class GetTaskByIdQueryMock : Faker<GetTaskByIdQuery>
{
    private GetTaskByIdQueryMock() : base("pt_BR")
    {
        RuleFor(task => task.Id, faker => faker.Random.Int(1, int.MaxValue));
    }

    public static GetTaskByIdQuery GenerateValidCommand()
    {
        return new GetTaskByIdQueryMock().Generate();
    }

    public static GetTaskByIdQuery? GenerateNullObject()
    {
        return null;
    }
}