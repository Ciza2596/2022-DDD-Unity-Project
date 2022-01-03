using DDDCore.Implement;
using DDDCore.Usecase.CQRS;
using NUnit.Framework;
using DDDTestFrameWork;
using Actor.Entity.Event;
using Actor.UseCase;
using Actor.UseCase.Repository;
using NSubstitute;
using ThirtyParty.DDDCore.DDDTestFramwork;
using ThirtyParty.DDDCore.Implement.CQRS;
using Zenject;


[TestFixture]
public class CreateActorUseCaseTest : DDDUnitTestFixture
{
    [Test]
    public void Should_Success_When_Create_Actor() {
        Container.Bind<IActorRepository>().FromSubstitute();
        Container.Bind<CreateActorUseCase>().AsSingle();

        var                createActorUseCase = Container.Resolve<CreateActorUseCase>();
        var                repository         = Container.Resolve<IActorRepository>();
        Actor.Entity.Actor actor              = null;
        repository.Save(Arg.Do<Actor.Entity.Actor>(a => actor = a));

        ActorCreated actorCreated = null;
        publisher.Publish(Arg.Do<ActorCreated>(e => actorCreated = e));
        
        
        CreateActorInput input  = null;
        var              output = CqrsCommandPresenter.NewInstance();
        
        string actorId     = null;
        var    actorDataId = NewGuid();
        
        Scenario("Create a actor with valid actor id.")
            .Given("Give a actor data id",
                   () => { input = new CreateActorInput(actorDataId); })
            .When("Create a actor.", () => { createActorUseCase.Execute(input, output); })
            .Then("The repository should save actor, and id equals",
                  () => {
                      repository.ReceivedWithAnyArgs(1).Save(null);
                      Assert.NotNull(actor,         "actor isnull");
                      Assert.NotNull(actor.GetId(), "id is null");
                      Assert.AreEqual(actorDataId, actor.DataId, $"DataId is not equal");
                      actorId = actor.GetId();
                  }) 
            .And("", () => {
                         publisher.Received(1)
                                  .Publish(Arg.Is<DomainEvent>(domainEvent =>
                                                                   domainEvent.GetType() == typeof(ActorCreated)));
                         Assert.AreEqual(actorId, actorCreated.ActorId, "ActorId is not equal");
                         Assert.AreEqual(actorDataId, actorCreated.ActorDataId, "ActorDataId is not equal");
                     })
            .And("the result is success",
                 () => {
                     Assert.AreEqual(actorId,          output.GetId(),       "id is not equal");
                     Assert.AreEqual(ExitCode.SUCCESS, output.GetExitCode(), "ExitCode is not equal");
                 });
    }
}
