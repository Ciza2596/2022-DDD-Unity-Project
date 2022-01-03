using System;
using DDDCore.Event;
using DDDCore.Implement;
using DDDCore.Usecase.CQRS;
using Actor.UseCase.Repository;
using ThirtyParty.DDDCore.Implement.CQRS;
using ThirtyParty.DDDCore.Usecase;


namespace Actor.UseCase
{
    public class CreateActorInput:Input
    {
        public string ActorDataId { get; set; }
    }
    
    public class CreateActorUseCase:UseCase<CreateActorInput,CqrsCommandPresenter, IActorRepository>
    {
        public CreateActorUseCase(IDomainEventBus domainEventBus, IActorRepository repository)
            : base(domainEventBus, repository) { }

        public override void Execute(CreateActorInput input, CqrsCommandPresenter output) {
            var     id     = Guid.NewGuid().ToString();
            var     dataId = input.ActorDataId;
            var actor  = new Entity.Actor(id, dataId);
            repository.Save(actor);
            
            domainEventBus.PostAll(actor);

            output.SetId(id);
            output.SetExitCode(ExitCode.SUCCESS);
        }
    }
}
