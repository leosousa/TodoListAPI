using Application.UseCases.Tasks.Create;
using Bogus;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Application.Tests.Mocks.UseCases.Tasks;

public class CreateTaskCommandMock : Faker<CreateTaskCommand>
{
    private CreateTaskCommandMock() : base("pt_BR")
    {
        RuleFor(task => task.Description, faker => faker.Lorem.Random.String(1, 255));
    }

    private CreateTaskCommandMock(int length) : base("pt_BR")
    {
        RuleFor(task => task.Description, faker => faker.Lorem.Random.String(length + 1, length + 2));
    }

    public static CreateTaskCommand GenerateValidCommand()
    {
        return new CreateTaskCommandMock().Generate();
    }

    public static CreateTaskCommand GenerateDescriptionGreaterThanAllowedCommand()
    {
        return new CreateTaskCommandMock(255).Generate();
    }
}
