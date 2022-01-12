using DDDCore.Implement;
using Actor.Entity.Event;

namespace Actor.Entity
{
    public class Actor : AggregateRoot, IActor
    {
        public Actor(string id, string dataId)
            : base(id) {
            
            DataId = dataId;
            
            var actorCreated = new ActorCreated(id, DataId);
            AddDomainEvent(actorCreated);
        }

        public string DataId { get;}
    }
}
