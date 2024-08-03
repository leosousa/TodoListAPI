using Application.UseCases.Tasks.Delete;
using Bogus;

namespace Application.Tests.Mocks.UseCases.Tasks;

public class DeleteTaskCommandMock : Faker<DeleteTaskCommand>
{
    private DeleteTaskCommandMock() : base("pt_BR")
    {
        RuleFor(task => task.Id, faker => faker.Random.Int(1, int.MaxValue));
    }

    public static DeleteTaskCommand GenerateValidCommand()
    {
        return new DeleteTaskCommandMock().Generate();
    }

    public static DeleteTaskCommand? GenerateNullObject()
    {
        return null;
    }
}