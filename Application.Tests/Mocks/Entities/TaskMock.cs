using Application.Tests.Mocks.UseCases.Tasks;
using Application.UseCases.Tasks.Create;
using Bogus;

namespace Application.Tests.Mocks.Entities;

public class TaskMock : Faker<Domain.Entities.Task>
{
    private TaskMock() : base("pt_BR")
    {
        RuleFor(task => task.Id, faker => faker.Random.Int(1, int.MaxValue));

        RuleFor(task => task.Description, faker => faker.Lorem.Random.String(1, 255));

        RuleFor(task => task.IsCompleted, faker => faker.Random.Bool());
    }

    public static Domain.Entities.Task GenerateValidObject()
    {
        return new TaskMock().Generate();
    }

    public static Domain.Entities.Task? GenerateNullObject()
    {
        return null;
    }

    public static IEnumerable<Domain.Entities.Task> GenerateEmptyListObject()
    {
        return new List<Domain.Entities.Task>();
    }

    public static IEnumerable<Domain.Entities.Task> GenerateListObject()
    {
        return new List<Domain.Entities.Task> { GenerateValidObject(), GenerateValidObject()};
    }
}
