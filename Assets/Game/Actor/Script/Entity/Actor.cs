using DDDCore.Implement;

namespace Game.Actor.Script.Entity
{
    public class Actor : AggregateRoot, IActor
    {
        public Actor(string id)
            : base(id) { }
    }
}
