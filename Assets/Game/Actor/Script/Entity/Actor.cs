using DDDCore.Implement;
using Actor.Entity.Event;

namespace Actor.Entity
{
    public class Actor : AggregateRoot, IActor
    {
        public Actor(string id)
            : base(id) {
            
            var actorCreated = new ActorCreated();
            actorCreated.ActorId = GetId();
            AddDomainEvent(actorCreated);

        }
    }
}
