using Actor.Entity.Event;
using DDDCore.Event;
using DDDCore.Implement;
using Zenject;

namespace Actor.Adapter.EventHandler
{
    public class ActorEventHandler : DomainEventHandler
    {
        [Inject] private IActorFlow actorFlow;

        public ActorEventHandler(IDomainEventBus domainEventBus)
            : base(domainEventBus) {
            Register<ActorCreated>(created => { actorFlow.WhenActorCreated(created.ActorDataId); });
        }
    }
}
