using System;
using DDDCore.Implement;
using DDDCore.Usecase.CQRS;
using NUnit.Framework;
using DDDTestFrameWork;
using Game.Actor.Script.Entity;
using Game.Actor.Scripts.UseCase;
using Game.Actor.Scripts.UseCase.Repository;
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
        
        var   createActorUseCase = Container.Resolve<CreateActorUseCase>();
        var   repository         = Container.Resolve<IActorRepository>();
        Actor actor              = null;
        repository.Save(Arg.Do<Actor>(a => actor = a));

        var input  = new CreateActorInput();
        var output = CqrsCommandPresenter.NewInstance();

        string actorId = null;
        Scenario("Create a actor with valid actor id.")
            .When("Create a actor.", () => { createActorUseCase.Execute(input, output); })
            .Then("The repository should save actor, and id equals",
                  () => {
                      repository.ReceivedWithAnyArgs(1).Save(null);
                      Assert.NotNull(actor,         "actor isnull");
                      Assert.NotNull(actor.GetId(), "id is null");
                      actorId = actor.GetId();
                  })
            .And("", () => {
                         // publisher.Received(1)
                         //          .Publish(Arg.Is<DomainEvent>(domainEvent =>
                         //                                           domainEvent.GetType() == typeof(ActorCreated)));
                         // Assert.AreEqual(actorId, actorCreated.actorId, "ActorId is not equal");
                     })
            .And("the result is success",
                 () => {
                     Assert.AreEqual(actorId,          output.GetId(),       "id is not equal");
                     Assert.AreEqual(ExitCode.SUCCESS, output.GetExitCode(), "ExitCode is not equal");
                 });
    }
}
