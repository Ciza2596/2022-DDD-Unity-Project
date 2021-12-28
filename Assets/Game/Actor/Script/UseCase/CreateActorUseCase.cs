using System;
using DDDCore.Event;
using DDDCore.Implement;
using DDDCore.Usecase.CQRS;
using Actor.UseCase.Repository;
using ThirtyParty.DDDCore.Implement.CQRS;
using ThirtyParty.DDDCore.Usecase;


namespace Actor.UseCase
{
    public class CreateActorInput:Input { }
    
    public class CreateActorUseCase:UseCase<CreateActorInput,CqrsCommandPresenter, IActorRepository>
    {
        public CreateActorUseCase(IDomainEventBus domainEventBus, IActorRepository repository)
            : base(domainEventBus, repository) { }

        public override void Execute(CreateActorInput input, CqrsCommandPresenter output) {
            var id    = Guid.NewGuid().ToString();
            var actor = new Entity.Actor(id);
            repository.Save(actor);
            
            domainEventBus.PostAll(actor);

            output.SetId(id);
            output.SetExitCode(ExitCode.SUCCESS);
        }
    }
}
