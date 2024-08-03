using Application.UseCases.Tasks.Create;
using Application.UseCases.Tasks.Update;
using Bogus;

namespace Application.Tests.Mocks.UseCases.Tasks;

public class UpdateTaskCommandMock : Faker<UpdateTaskCommand>
{
    private UpdateTaskCommandMock() : base("pt_BR")
    {
        RuleFor(task => task.Id, faker => faker.Random.Int(1, int.MaxValue));

        RuleFor(task => task.Description, faker => faker.Lorem.Random.String(1, 255));

        RuleFor(task => task.IsCompleted, faker => faker.Random.Bool());
    }

    private UpdateTaskCommandMock(int length) : base("pt_BR")
    {
        RuleFor(task => task.Id, faker => faker.Random.Int(1, int.MaxValue));

        RuleFor(task => task.Description, faker => faker.Lorem.Random.String(length + 1, length + 2));

        RuleFor(task => task.IsCompleted, faker => faker.Random.Bool());
    }

    public static UpdateTaskCommand GenerateValidCommand()
    {
        return new UpdateTaskCommandMock().Generate();
    }

    public static UpdateTaskCommand? GenerateNullObject()
    {
        return null;
    }

    public static UpdateTaskCommand GenerateDescriptionGreaterThanAllowedCommand()
    {
        return new UpdateTaskCommandMock(255).Generate();
    }
}