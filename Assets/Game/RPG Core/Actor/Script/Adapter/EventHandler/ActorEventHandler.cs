using Actor.Entity.Event;
using DDDCore.Event;
using DDDCore.Implement;
using Zenject;

namespace Actor.Adapter.EventHandler
{
    public class ActorEventHandler : DomainEventHandler
    {
        [Inject] private IActorPresenter actorPresenter;

        public ActorEventHandler(IDomainEventBus domainEventBus)
            : base(domainEventBus) {
            Register<ActorCreated>(created => { actorPresenter.CreateActor(created.ActorDataId); });
        }
    }
}
